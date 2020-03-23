using System;

namespace HotChocolate.Language.Utilities
{
    public sealed partial class SyntaxSerializer
    {
        private void VisitOperationDefinition(
            OperationDefinitionNode node,
            ISyntaxWriter writer)
        {
            if (node.Name != null)
            {
                writer.Write(node.Operation.ToString().ToLowerInvariant());
                writer.WriteSpace();

                writer.WriteName(node.Name);
                if (node.VariableDefinitions.Count > 0)
                {
                    writer.Write('(');

                    writer.WriteMany(node.VariableDefinitions, VisitVariableDefinition);

                    writer.Write(')');
                }

                writer.WriteMany(node.Directives,
                    (n, w) => w.WriteDirective(n),
                    w => w.WriteSpace());

                writer.WriteSpace();
            }
            else if (node.Operation != OperationType.Query)
            {
                writer.Write(node.Operation.ToString().ToLowerInvariant());
                writer.WriteSpace();
            }

            VisitSelectionSet(node.SelectionSet, writer);
        }

        private void VisitVariableDefinition(VariableDefinitionNode node, ISyntaxWriter writer)
        {
            writer.WriteVariable(node.Variable);

            writer.Write(": ");

            writer.WriteType(node.Type);

            if (node.DefaultValue is { })
            {
                writer.Write(" = ");
                writer.WriteValue(node.DefaultValue);
            }
        }

        private void VisitFragmentDefinition(FragmentDefinitionNode node, ISyntaxWriter writer)
        {
            writer.Write(Keywords.Fragment);
            writer.WriteSpace();

            writer.WriteName(node.Name);
            writer.WriteSpace();

            if (node.VariableDefinitions.Count > 0)
            {
                writer.Write('(');

                writer.WriteMany(
                    node.VariableDefinitions,
                    VisitVariableDefinition);

                writer.Write(')');
                writer.WriteSpace();
            }

            writer.Write(Keywords.On);
            writer.WriteSpace();

            writer.WriteNamedType(node.TypeCondition);

            writer.WriteMany(node.Directives,
                (n, w) => w.WriteDirective(n));

            if (node.SelectionSet != null)
            {
                writer.WriteSpace();
                VisitSelectionSet(node.SelectionSet, writer);
            }
        }

        private void VisitSelectionSet(SelectionSetNode node, ISyntaxWriter writer)
        {
            if (node != null && node.Selections.Count > 0)
            {
                writer.Write('{');

                string separator;
                if (_indent)
                {
                    writer.WriteLine();
                    writer.Indent();
                    separator = Environment.NewLine;
                }
                else
                {
                    writer.WriteSpace();
                    separator = " ";
                }

                writer.WriteMany(node.Selections, VisitSelection, separator);

                if (_indent)
                {
                    writer.WriteLine();
                    writer.Unindent();
                }
                else
                {
                    writer.WriteSpace();
                }

                writer.WriteIndent();
                writer.Write('}');
            }
        }

        private void VisitSelection(ISelectionNode node, ISyntaxWriter context)
        {
            switch (node.Kind)
            {
                case NodeKind.Field:
                    VisitField((FieldNode)node, context);
                    break;
                case NodeKind.FragmentSpread:
                    VisitFragmentSpread((FragmentSpreadNode)node, context);
                    break;
                case NodeKind.InlineFragment:
                    VisitInlineFragment((InlineFragmentNode)node, context);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private void VisitField(FieldNode node, ISyntaxWriter writer)
        {
            writer.WriteIndent();

            if (node.Alias != null)
            {
                writer.WriteName(node.Alias);
                writer.Write(": ");
            }

            writer.WriteName(node.Name);

            if (node.Arguments.Count > 0)
            {
                writer.Write('(');
                writer.WriteMany(node.Arguments, (n, w) => w.WriteArgument(n));
                writer.Write(')');
            }

            if (node.Directives.Count > 0)
            {
                writer.WriteSpace();
                writer.WriteMany(node.Directives,
                    (n, w) => w.WriteDirective(n),
                    w => w.WriteSpace());
            }

            if (node.SelectionSet is { } selectionSet && selectionSet.Selections.Count > 0)
            {
                writer.WriteSpace();
                VisitSelectionSet(selectionSet, writer);
            }
        }

        private void VisitFragmentSpread(FragmentSpreadNode node, ISyntaxWriter writer)
        {
            writer.WriteIndent();

            writer.Write("... ");
            writer.WriteName(node.Name);

            if (node.Directives.Count > 0)
            {
                writer.WriteMany(node.Directives,
                    (n, w) => w.WriteDirective(n),
                    w => w.WriteSpace());
            }
        }

        private void VisitInlineFragment(InlineFragmentNode node, ISyntaxWriter writer)
        {
            writer.WriteIndent();

            writer.Write("...");

            if (node.TypeCondition != null)
            {
                writer.WriteSpace();
                writer.Write(Keywords.On);
                writer.WriteSpace();

                writer.WriteNamedType(node.TypeCondition);
            }

            if (node.Directives.Count > 0)
            {
                writer.WriteSpace();
                writer.WriteMany(node.Directives,
                    (n, w) => w.WriteDirective(n),
                    w => w.WriteSpace());
            }

            if (node.SelectionSet is { })
            {
                writer.WriteSpace();
                VisitSelectionSet(node.SelectionSet, writer);
            }
        }
    }
}
