﻿#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Analyzers.StarWars
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPeopleQueryDocument
        : global::StrawberryShake.IDocument
    {
        private GetPeopleQueryDocument()
        {
        }

        public static GetPeopleQueryDocument Instance { get; } = new GetPeopleQueryDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x71, 0x75, 0x65, 0x72, 0x79, 0x20, 0x47, 0x65, 0x74, 0x50, 0x65, 0x6f, 0x70, 0x6c, 0x65, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x70, 0x65, 0x6f, 0x70, 0x6c, 0x65, 0x28, 0x6f, 0x72, 0x64, 0x65, 0x72, 0x5f, 0x62, 0x79, 0x3a, 0x20, 0x7b, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x3a, 0x20, 0x41, 0x53, 0x43, 0x20, 0x7d, 0x29, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x6e, 0x6f, 0x64, 0x65, 0x73, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x65, 0x6d, 0x61, 0x69, 0x6c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x69, 0x73, 0x4f, 0x6e, 0x6c, 0x69, 0x6e, 0x65, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x6c, 0x61, 0x73, 0x74, 0x53, 0x65, 0x65, 0x6e, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x6f, 0x6e, 0x20, 0x50, 0x65, 0x72, 0x73, 0x6f, 0x6e, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x69, 0x64, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x7d, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x7d, 0x0a, 0x20, 0x20, 0x7d, 0x0a, 0x7d };

        public override global::System.String ToString()
        {
            return global::System.Text.Encoding.UTF8.GetString(Body);
        }
    }
}
