﻿using HotChocolate.Language;

namespace HotChocolate.Types.Factories
{
    internal interface ITypeFactory<in TNode, out TType>
        where TNode : ISyntaxNode
        where TType : IHasName
    {
        TType Create(TNode node);
    }
}
