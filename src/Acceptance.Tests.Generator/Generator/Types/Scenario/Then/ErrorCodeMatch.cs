using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.ClassGenerator;

namespace Generator
{
    /// <summary>
    /// error-code - String
    /// args - Object(optional)
    /// loc - Array of Objects | Array of Arrays of Numbers(optional)
    ///     line - Number
    ///     column - Number
    /// </summary>
    internal class ErrorCodeMatch : IAssertion
    {
        private static readonly string _errorCodeKey = "error-code";
        private static readonly string _argsKey = "args";
        private static readonly string _locKey = "loc";
        
        private readonly string _errorCode;
        private readonly Args _args;
        private readonly Loc _loc;

        private ErrorCodeMatch(Dictionary<object, object> value)
        {
            _errorCode = value[_errorCodeKey] as string;
            _args = new Args(value);
            _loc = new Loc(value);
        }

        public static (bool, CreateAssertion) TryCreate(
            Dictionary<object, object> value,
            TestContext context)
        {
            return (value.ContainsKeys(_errorCodeKey, _argsKey, _locKey), Create);
        }

        public static IAssertion Create(Dictionary<object, object> value)
        {
            return new ErrorCodeMatch(value);
        }

        public Block CreateBlock()
        {
            return new Block(new Statement(
                $"Assert.Equal(1, result.Errors.Count(e => e.Code == \"{_errorCode}\" /*&& arg:{_args.Create()}, loc:{_loc.Create()}*/));"));
        }

        private class Args
        {
            private static readonly string _defNameKey = "defName";
            private static readonly string _fieldNameKey = "fieldName";
            private static readonly string _typeKey = "type";

            public Args(Dictionary<object, object> value)
            {
                var argsValue = value[_argsKey] as Dictionary<object, object>;
                if (argsValue == null)
                {
                    throw new InvalidOperationException(
                        "Error code match, args should be an object");
                }

                DefName = argsValue.TryGet(_defNameKey, string.Empty);
                FieldName = argsValue.TryGet(_fieldNameKey, string.Empty);
                Type = argsValue.TryGet(_typeKey, string.Empty);
            }

            public string DefName { get; }
            public string FieldName { get; }
            public string Type { get; }

            public string Create()
            {
                List<string> values = new List<string>();

                if (!string.IsNullOrEmpty(DefName))
                {
                    values.Add($"{_defNameKey}={DefName}");
                }

                if (!string.IsNullOrEmpty(FieldName))
                {
                    values.Add($"{_fieldNameKey}={FieldName}");
                }

                if (!string.IsNullOrEmpty(Type))
                {
                    values.Add($"{_typeKey}={Type}");
                }

                return string.Join("|", values);
            }
        }

        private class Loc
        {
            private static readonly string _lineKey = "line";
            private static readonly string _columnKey = "column";

            public Loc(Dictionary<object, object> value)
            {
                var locValue = value[_locKey] as Dictionary<object, object>;
                if (locValue == null)
                {
                    throw new InvalidOperationException("Error code match, loc should be an object");
                }

                if (!locValue.ContainsKey(_lineKey) || !locValue.ContainsKey(_columnKey))
                {
                    throw new InvalidOperationException("Error code match, invalid loc structure");
                }

                Line = locValue.TryGet(_lineKey, -1);
                Column = locValue.TryGet(_columnKey, -1);
            }

            public int Line { get; }
            public int Column { get; }

            public string Create()
            {
                List<string> values = new List<string>();

                if (Line != -1)
                {
                    values.Add($"{_lineKey}={Line}");
                }

                if (Column != -1)
                {
                    values.Add($"{_columnKey}={Column}");
                }

                return string.Join("|", values);
            }
        }
    }
}
