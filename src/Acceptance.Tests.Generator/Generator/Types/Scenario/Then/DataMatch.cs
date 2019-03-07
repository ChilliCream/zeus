using System.Collections.Generic;
using Generator.ClassGenerator;

namespace Generator
{
    /// <summary>
    /// data - Object
    /// </summary>
    internal class DataMatch : IAssertion
    {
        private static readonly string _dataKey = "data";

        private DataMatch(Dictionary<object, object> value)
        {
        }

        public static (bool, CreateAssertion) TryCreate(Dictionary<object, object> value)
        {
            return (value.ContainsKey(_dataKey), Create);
        }

        public static IAssertion Create(Dictionary<object, object> value)
        {
            return new DataMatch(value);
        }

        public Block CreateBlock(Statement header, Block whenBlock)
        {
            return new Block(new Statement("throw new NotImplementedException();"));
        }
    }
}
