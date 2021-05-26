namespace HotChocolate.Data.Neo4J.Analyzers
{
    public static class TypeNames
    {
        public const string Types = "HotChocolate." + nameof(Types);
        public const string Data = "HotChocolate." + nameof(Data);
        public const string Neo4J = Data + "." + nameof(Neo4J);
        public const string SystemCollections = "System.Collections.Generic";
        public const string Neo4JExecutable = Neo4J + "." + nameof(Neo4JExecutable);
        public const string UsePagingAttribute = Types + "." + nameof(UsePagingAttribute);
        public const string UseOffsetPagingAttribute = Types + "." + nameof(UseOffsetPagingAttribute);
        public const string UseFilteringAttribute = Data + "." + nameof(UseFilteringAttribute);
        public const string UseSortingAttribute = Data + "." + nameof(UseSortingAttribute);
        public const string List = SystemCollections + "." + nameof(List);

        public static string Global(string s)
        {
            return "global::" + s;
        }

        public static string Generics(string s, params string[] args)
        {
            return $"{s}<{string.Join(", ", args)}>";
        }

        public static string Nullable(string s)
        {
            return $"{s}?";
        }
    }
}