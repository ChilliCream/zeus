using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Types;

namespace StrawberryShake.Generators.Utilities
{
    internal sealed class FieldCollector
    {
        private const string _argumentProperty = "argument";
        private readonly ISchema _schema;
        private readonly FragmentCollection _fragments;

        public FieldCollector(ISchema schema, FragmentCollection fragments)
        {
            _schema = schema
                ?? throw new ArgumentNullException(nameof(schema));
            _fragments = fragments
                ?? throw new ArgumentNullException(nameof(fragments));
        }

        public FieldSelectionInfo1 CollectFields(
            INamedOutputType type,
            SelectionSetNode selectionSet,
            Path path)
        {
            FieldSelectionInfo result = CollectFields(type, selectionSet, path);


            if (type.IsAbstractType())
            {
                foreach (ObjectType objectType in _schema.GetPossibleTypes(type))
                {

                }
            }


        }

        private FieldSelectionInfo CollectFieldsInternal(
            INamedOutputType type,
            SelectionSetNode selectionSet,
            Path path)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (selectionSet == null)
            {
                throw new ArgumentNullException(nameof(selectionSet));
            }

            var fields = new OrderedDictionary<string, FieldSelection>();
            var fragments = new List<IFragmentNode>();

            CollectFields(type, selectionSet, path, fields, fragments);

            return new FieldSelectionInfo(
                type,
                selectionSet,
                fields.Values.ToList(),
                fragments);
        }

        private void CollectFields(
            INamedOutputType type,
            SelectionSetNode selectionSet,
            Path path,
            IDictionary<string, FieldSelection> fields,
            ICollection<IFragmentNode> fragments)
        {
            foreach (ISelectionNode selection in selectionSet.Selections)
            {
                ResolveFields(
                    type,
                    selection,
                    path,
                    fields,
                    fragments);
            }
        }

        private void ResolveFields(
            INamedOutputType type,
            ISelectionNode selection,
            Path path,
            IDictionary<string, FieldSelection> fields,
            ICollection<IFragmentNode> fragments)
        {
            if (selection is FieldNode fs && type is IComplexOutputType ct)
            {
                ResolveFieldSelection(
                    ct,
                    fs,
                    path,
                    fields);
            }
            else if (selection is FragmentSpreadNode fragSpread)
            {
                ResolveFragmentSpread(
                    type,
                    fragSpread,
                    path,
                    fields,
                    fragments);
            }
            else if (selection is InlineFragmentNode inlineFrag)
            {
                ResolveInlineFragment(
                    type,
                    inlineFrag,
                    path,
                    fields,
                    fragments);
            }
        }

        internal static void ResolveFieldSelection(
            IComplexOutputType type,
            FieldNode fieldSelection,
            Path path,
            IDictionary<string, FieldSelection> fields)
        {
            NameString fieldName = fieldSelection.Name.Value;
            NameString responseName = fieldSelection.Alias == null
                ? fieldSelection.Name.Value
                : fieldSelection.Alias.Value;

            if (type.Fields.TryGetField(fieldName, out IOutputField field))
            {
                if (!fields.TryGetValue(responseName, out FieldSelection? f))
                {
                    f = new FieldSelection(field, fieldSelection, path);
                    fields.Add(responseName, f);
                }
            }
            else
            {
                // TODO : resources
                throw new InvalidOperationException(
                    $"Field `{fieldName}` does not exist in type `{type.Name}`.");
            }
        }

        private void ResolveFragmentSpread(
            INamedOutputType type,
            FragmentSpreadNode fragmentSpread,
            Path path,
            IDictionary<string, FieldSelection> fields,
            ICollection<IFragmentNode> fragments)
        {
            Fragment fragment = _fragments.GetFragment(
                fragmentSpread.Name.Value);
            var fragmentNode = new FragmentNode(fragment);
            fragments.Add(fragmentNode);

            if (fragment != null && DoesTypeApply(fragment.TypeCondition, type))
            {
                CollectFields(
                    type,
                    fragment.SelectionSet,
                    path,
                    fields,
                    fragmentNode.Children);
            }
        }

        private void ResolveInlineFragment(
            INamedOutputType type,
            InlineFragmentNode inlineFragment,
            Path path,
            IDictionary<string, FieldSelection> fields,
            ICollection<IFragmentNode> fragments)
        {
            Fragment fragment = _fragments.GetFragment(type, inlineFragment);

            if (DoesTypeApply(fragment.TypeCondition, type))
            {
                CollectFields(
                    type,
                    fragment.SelectionSet,
                    path,
                    fields,
                    fragments);
            }
        }

        private static bool DoesTypeApply(
            IType typeCondition,
            INamedOutputType current)
        {
            if (typeCondition is ObjectType ot)
            {
                return ot == current;
            }
            else if (typeCondition is InterfaceType it
                && current is ObjectType cot)
            {
                return cot.Interfaces.ContainsKey(it.Name);
            }
            else if (typeCondition is UnionType ut)
            {
                return ut.Types.ContainsKey(current.Name);
            }
            return false;
        }
    }
}
