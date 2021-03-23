﻿// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable RedundantNameQualifier
// ReSharper disable ArrangeObjectCreationWhenTypeEvident
// ReSharper disable UnusedType.Global
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedMethodReturnValue.Local
// ReSharper disable ConvertToAutoProperty
// ReSharper disable UnusedMember.Global
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable InconsistentNaming

// DroidEntity

// StrawberryShake.CodeGeneration.CSharp.Generators.EntityTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DroidEntity
    {
        public DroidEntity(
            global::System.String name,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? friends)
        {
            Name = name;
            Friends = friends;
        }

        public global::System.String Name { get; }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? Friends { get; }
    }
}


// HumanEntity

// StrawberryShake.CodeGeneration.CSharp.Generators.EntityTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class HumanEntity
    {
        public HumanEntity(
            global::System.String name,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? friends)
        {
            Name = name;
            Friends = friends;
        }

        public global::System.String Name { get; }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? Friends { get; }
    }
}


// GetHeroResultFactory

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultDataFactoryGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHeroResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Droid> _getHero_Hero_DroidFromDroidEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Human> _getHero_Hero_HumanFromHumanEntityMapper;

        public GetHeroResultFactory(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Droid> getHero_Hero_DroidFromDroidEntityMapper,
            global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Human> getHero_Hero_HumanFromHumanEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _getHero_Hero_DroidFromDroidEntityMapper = getHero_Hero_DroidFromDroidEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getHero_Hero_DroidFromDroidEntityMapper));
            _getHero_Hero_HumanFromHumanEntityMapper = getHero_Hero_HumanFromHumanEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getHero_Hero_HumanFromHumanEntityMapper));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult);

        public GetHeroResult Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is GetHeroResultInfo info)
            {
                return new GetHeroResult(MapIGetHero_Hero(
                    info.Hero,
                    snapshot));
            }

            throw new global::System.ArgumentException("GetHeroResultInfo expected.");
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero? MapIGetHero_Hero(
            global::StrawberryShake.EntityId? entityId,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (entityId is null)
            {
                return null;
            }


            if (entityId.Value.Name.Equals(
                    "Droid",
                    global::System.StringComparison.Ordinal))
            {
                return _getHero_Hero_DroidFromDroidEntityMapper.Map(
                    snapshot.GetEntity<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }

            if (entityId.Value.Name.Equals(
                    "Human",
                    global::System.StringComparison.Ordinal))
            {
                return _getHero_Hero_HumanFromHumanEntityMapper.Map(
                    snapshot.GetEntity<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(
                dataInfo,
                snapshot);
        }
    }
}


// GetHeroResultInfo

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInfoGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHeroResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;

        public GetHeroResultInfo(
            global::StrawberryShake.EntityId? hero,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            global::System.UInt64 version)
        {
            Hero = hero;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::StrawberryShake.EntityId? Hero { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public global::System.UInt64 Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new GetHeroResultInfo(
                Hero,
                _entityIds,
                version);
        }
    }
}


// GetHeroResult

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHeroResult
        : global::System.IEquatable<GetHeroResult>
        , IGetHeroResult
    {
        public GetHeroResult(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero? hero)
        {
            Hero = hero;
        }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero? Hero { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GetHeroResult)obj);
        }

        public global::System.Boolean Equals(GetHeroResult? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (((Hero is null && other.Hero is null) ||Hero != null && Hero.Equals(other.Hero)));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                if (!(Hero is null))
                {
                    hash ^= 397 * Hero.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// GetHero_Hero_DroidFromDroidEntityMapper

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultFromEntityTypeMapperGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_DroidFromDroidEntityMapper
        : global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Droid>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Friends_Nodes_Droid> _getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Friends_Nodes_Human> _getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper;

        public GetHero_Hero_DroidFromDroidEntityMapper(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Friends_Nodes_Droid> getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper,
            global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Friends_Nodes_Human> getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper = getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper));
            _getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper = getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper));
        }

        public GetHero_Hero_Droid Map(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity entity,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            return new GetHero_Hero_Droid(
                entity.Name,
                MapIGetHero_Hero_Friends(
                    entity.Friends,
                    snapshot));
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? MapIGetHero_Hero_Friends(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IGetHero_Hero_Friends returnValue = default!;

            if (data?.__typename.Equals(
                    "CharacterConnection",
                    global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetHero_Hero_Friends_CharacterConnection(MapIGetHero_Hero_Friends_NodesArray(
                    data.Nodes,
                    snapshot));
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>? MapIGetHero_Hero_Friends_NodesArray(
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? list,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (list is null)
            {
                return null;
            }

            var characters = new global::System.Collections.Generic.List<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>();

            foreach (global::StrawberryShake.EntityId? child in list)
            {
                characters.Add(MapIGetHero_Hero_Friends_Nodes(
                    child,
                    snapshot));
            }

            return characters;
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes? MapIGetHero_Hero_Friends_Nodes(
            global::StrawberryShake.EntityId? entityId,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (entityId is null)
            {
                return null;
            }


            if (entityId.Value.Name.Equals(
                    "Droid",
                    global::System.StringComparison.Ordinal))
            {
                return _getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper.Map(
                    snapshot.GetEntity<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }

            if (entityId.Value.Name.Equals(
                    "Human",
                    global::System.StringComparison.Ordinal))
            {
                return _getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper.Map(
                    snapshot.GetEntity<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }
    }
}


// GetHero_Hero_Droid

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Droid
        : global::System.IEquatable<GetHero_Hero_Droid>
        , IGetHero_Hero_Droid
    {
        public GetHero_Hero_Droid(
            global::System.String name,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? friends)
        {
            Name = name;
            Friends = friends;
        }

        public global::System.String Name { get; }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? Friends { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GetHero_Hero_Droid)obj);
        }

        public global::System.Boolean Equals(GetHero_Hero_Droid? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Name.Equals(other.Name))
                && ((Friends is null && other.Friends is null) ||Friends != null && Friends.Equals(other.Friends));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Name.GetHashCode();

                if (!(Friends is null))
                {
                    hash ^= 397 * Friends.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// GetHero_Hero_HumanFromHumanEntityMapper

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultFromEntityTypeMapperGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_HumanFromHumanEntityMapper
        : global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Human>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Friends_Nodes_Droid> _getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Friends_Nodes_Human> _getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper;

        public GetHero_Hero_HumanFromHumanEntityMapper(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Friends_Nodes_Droid> getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper,
            global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Friends_Nodes_Human> getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper = getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper));
            _getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper = getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper));
        }

        public GetHero_Hero_Human Map(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity entity,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            return new GetHero_Hero_Human(
                entity.Name,
                MapIGetHero_Hero_Friends(
                    entity.Friends,
                    snapshot));
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? MapIGetHero_Hero_Friends(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IGetHero_Hero_Friends returnValue = default!;

            if (data?.__typename.Equals(
                    "CharacterConnection",
                    global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetHero_Hero_Friends_CharacterConnection(MapIGetHero_Hero_Friends_NodesArray(
                    data.Nodes,
                    snapshot));
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>? MapIGetHero_Hero_Friends_NodesArray(
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? list,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (list is null)
            {
                return null;
            }

            var characters = new global::System.Collections.Generic.List<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>();

            foreach (global::StrawberryShake.EntityId? child in list)
            {
                characters.Add(MapIGetHero_Hero_Friends_Nodes(
                    child,
                    snapshot));
            }

            return characters;
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes? MapIGetHero_Hero_Friends_Nodes(
            global::StrawberryShake.EntityId? entityId,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (entityId is null)
            {
                return null;
            }


            if (entityId.Value.Name.Equals(
                    "Droid",
                    global::System.StringComparison.Ordinal))
            {
                return _getHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper.Map(
                    snapshot.GetEntity<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }

            if (entityId.Value.Name.Equals(
                    "Human",
                    global::System.StringComparison.Ordinal))
            {
                return _getHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper.Map(
                    snapshot.GetEntity<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }
    }
}


// GetHero_Hero_Human

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Human
        : global::System.IEquatable<GetHero_Hero_Human>
        , IGetHero_Hero_Human
    {
        public GetHero_Hero_Human(
            global::System.String name,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? friends)
        {
            Name = name;
            Friends = friends;
        }

        public global::System.String Name { get; }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? Friends { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GetHero_Hero_Human)obj);
        }

        public global::System.Boolean Equals(GetHero_Hero_Human? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Name.Equals(other.Name))
                && ((Friends is null && other.Friends is null) ||Friends != null && Friends.Equals(other.Friends));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Name.GetHashCode();

                if (!(Friends is null))
                {
                    hash ^= 397 * Friends.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// GetHero_Hero_Friends_CharacterConnection

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// A connection to a list of items.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Friends_CharacterConnection
        : global::System.IEquatable<GetHero_Hero_Friends_CharacterConnection>
        , IGetHero_Hero_Friends_CharacterConnection
    {
        public GetHero_Hero_Friends_CharacterConnection(global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>? nodes)
        {
            Nodes = nodes;
        }

        /// <summary>
        /// A flattened list of the nodes.
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>? Nodes { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GetHero_Hero_Friends_CharacterConnection)obj);
        }

        public global::System.Boolean Equals(GetHero_Hero_Friends_CharacterConnection? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(
                        Nodes,
                        other.Nodes));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                if (!(Nodes is null))
                {
                    foreach (var Nodes_elm in Nodes)
                    {
                        if (!(Nodes_elm is null))
                        {
                            hash ^= 397 * Nodes_elm.GetHashCode();
                        }
                    }
                }

                return hash;
            }
        }
    }
}


// GetHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultFromEntityTypeMapperGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper
        : global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, GetHero_Hero_Friends_Nodes_Droid>
    {
        public GetHero_Hero_Friends_Nodes_Droid Map(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity entity,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            return new GetHero_Hero_Friends_Nodes_Droid(entity.Name);
        }
    }
}


// GetHero_Hero_Friends_Nodes_Droid

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Friends_Nodes_Droid
        : global::System.IEquatable<GetHero_Hero_Friends_Nodes_Droid>
        , IGetHero_Hero_Friends_Nodes_Droid
    {
        public GetHero_Hero_Friends_Nodes_Droid(global::System.String name)
        {
            Name = name;
        }

        public global::System.String Name { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GetHero_Hero_Friends_Nodes_Droid)obj);
        }

        public global::System.Boolean Equals(GetHero_Hero_Friends_Nodes_Droid? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Name.Equals(other.Name));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Name.GetHashCode();

                return hash;
            }
        }
    }
}


// GetHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultFromEntityTypeMapperGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper
        : global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, GetHero_Hero_Friends_Nodes_Human>
    {
        public GetHero_Hero_Friends_Nodes_Human Map(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity entity,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            return new GetHero_Hero_Friends_Nodes_Human(entity.Name);
        }
    }
}


// GetHero_Hero_Friends_Nodes_Human

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHero_Hero_Friends_Nodes_Human
        : global::System.IEquatable<GetHero_Hero_Friends_Nodes_Human>
        , IGetHero_Hero_Friends_Nodes_Human
    {
        public GetHero_Hero_Friends_Nodes_Human(global::System.String name)
        {
            Name = name;
        }

        public global::System.String Name { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GetHero_Hero_Friends_Nodes_Human)obj);
        }

        public global::System.Boolean Equals(GetHero_Hero_Friends_Nodes_Human? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Name.Equals(other.Name));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Name.GetHashCode();

                return hash;
            }
        }
    }
}


// IGetHeroResult

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHeroResult
    {
        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero? Hero { get; }
    }
}


// IGetHero_Hero

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero
    {
        public global::System.String Name { get; }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends? Friends { get; }
    }
}


// IGetHero_Hero_Droid

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Droid
        : IGetHero_Hero
    {
    }
}


// IGetHero_Hero_Human

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Human
        : IGetHero_Hero
    {
    }
}


// IGetHero_Hero_Friends

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// A connection to a list of items.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Friends
    {
        /// <summary>
        /// A flattened list of the nodes.
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHero_Hero_Friends_Nodes?>? Nodes { get; }
    }
}


// IGetHero_Hero_Friends_CharacterConnection

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// A connection to a list of items.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Friends_CharacterConnection
        : IGetHero_Hero_Friends
    {
    }
}


// IGetHero_Hero_Friends_Nodes

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Friends_Nodes
    {
        public global::System.String Name { get; }
    }
}


// IGetHero_Hero_Friends_Nodes_Droid

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Friends_Nodes_Droid
        : IGetHero_Hero_Friends_Nodes
    {
    }
}


// IGetHero_Hero_Friends_Nodes_Human

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IGetHero_Hero_Friends_Nodes_Human
        : IGetHero_Hero_Friends_Nodes
    {
    }
}


// OnReviewSubResultFactory

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultDataFactoryGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSubResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;

        public OnReviewSubResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult);

        public OnReviewSubResult Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is OnReviewSubResultInfo info)
            {
                return new OnReviewSubResult(MapNonNullableIOnReviewSub_OnReview(
                    info.OnReview,
                    snapshot));
            }

            throw new global::System.ArgumentException("OnReviewSubResultInfo expected.");
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSub_OnReview MapNonNullableIOnReviewSub_OnReview(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            IOnReviewSub_OnReview returnValue = default!;

            if (data.__typename.Equals(
                    "Review",
                    global::System.StringComparison.Ordinal))
            {
                returnValue = new OnReviewSub_OnReview_Review(
                    data.__typename ?? throw new global::System.ArgumentNullException(),
                    data.Stars ?? throw new global::System.ArgumentNullException(),
                    data.Commentary);
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(
                dataInfo,
                snapshot);
        }
    }
}


// OnReviewSubResultInfo

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInfoGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSubResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;

        public OnReviewSubResultInfo(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData onReview,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            global::System.UInt64 version)
        {
            OnReview = onReview;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData OnReview { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public global::System.UInt64 Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new OnReviewSubResultInfo(
                OnReview,
                _entityIds,
                version);
        }
    }
}


// OnReviewSubResult

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSubResult
        : global::System.IEquatable<OnReviewSubResult>
        , IOnReviewSubResult
    {
        public OnReviewSubResult(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSub_OnReview onReview)
        {
            OnReview = onReview;
        }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSub_OnReview OnReview { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((OnReviewSubResult)obj);
        }

        public global::System.Boolean Equals(OnReviewSubResult? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (OnReview.Equals(other.OnReview));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * OnReview.GetHashCode();

                return hash;
            }
        }
    }
}


// OnReviewSub_OnReview_Review

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSub_OnReview_Review
        : global::System.IEquatable<OnReviewSub_OnReview_Review>
        , IOnReviewSub_OnReview_Review
    {
        public OnReviewSub_OnReview_Review(
            global::System.String __typename,
            global::System.Int32 stars,
            global::System.String? commentary)
        {
            this.__typename = __typename;
            Stars = stars;
            Commentary = commentary;
        }

        /// <summary>
        /// The name of the current Object type at runtime.
        /// </summary>
        public global::System.String __typename { get; }

        public global::System.Int32 Stars { get; }

        public global::System.String? Commentary { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((OnReviewSub_OnReview_Review)obj);
        }

        public global::System.Boolean Equals(OnReviewSub_OnReview_Review? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (__typename.Equals(other.__typename))
                && Stars == other.Stars
                && ((Commentary is null && other.Commentary is null) ||Commentary != null && Commentary.Equals(other.Commentary));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * __typename.GetHashCode();

                hash ^= 397 * Stars.GetHashCode();

                if (!(Commentary is null))
                {
                    hash ^= 397 * Commentary.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// IOnReviewSubResult

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IOnReviewSubResult
    {
        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSub_OnReview OnReview { get; }
    }
}


// IOnReviewSub_OnReview

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IOnReviewSub_OnReview
    {
        /// <summary>
        /// The name of the current Object type at runtime.
        /// </summary>
        public global::System.String __typename { get; }

        public global::System.Int32 Stars { get; }

        public global::System.String? Commentary { get; }
    }
}


// IOnReviewSub_OnReview_Review

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IOnReviewSub_OnReview_Review
        : IOnReviewSub_OnReview
    {
    }
}


// CreateReviewMutResultFactory

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultDataFactoryGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMutResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;

        public CreateReviewMutResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult);

        public CreateReviewMutResult Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is CreateReviewMutResultInfo info)
            {
                return new CreateReviewMutResult(MapNonNullableICreateReviewMut_CreateReview(
                    info.CreateReview,
                    snapshot));
            }

            throw new global::System.ArgumentException("CreateReviewMutResultInfo expected.");
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMut_CreateReview MapNonNullableICreateReviewMut_CreateReview(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData data,
            global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            ICreateReviewMut_CreateReview returnValue = default!;

            if (data.__typename.Equals(
                    "Review",
                    global::System.StringComparison.Ordinal))
            {
                returnValue = new CreateReviewMut_CreateReview_Review(
                    data.Stars ?? throw new global::System.ArgumentNullException(),
                    data.Commentary);
            }
            else
            {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(
            global::StrawberryShake.IOperationResultDataInfo dataInfo,
            global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(
                dataInfo,
                snapshot);
        }
    }
}


// CreateReviewMutResultInfo

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInfoGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMutResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;

        public CreateReviewMutResultInfo(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData createReview,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            global::System.UInt64 version)
        {
            CreateReview = createReview;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData CreateReview { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public global::System.UInt64 Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new CreateReviewMutResultInfo(
                CreateReview,
                _entityIds,
                version);
        }
    }
}


// CreateReviewMutResult

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMutResult
        : global::System.IEquatable<CreateReviewMutResult>
        , ICreateReviewMutResult
    {
        public CreateReviewMutResult(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMut_CreateReview createReview)
        {
            CreateReview = createReview;
        }

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMut_CreateReview CreateReview { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((CreateReviewMutResult)obj);
        }

        public global::System.Boolean Equals(CreateReviewMutResult? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (CreateReview.Equals(other.CreateReview));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * CreateReview.GetHashCode();

                return hash;
            }
        }
    }
}


// CreateReviewMut_CreateReview_Review

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMut_CreateReview_Review
        : global::System.IEquatable<CreateReviewMut_CreateReview_Review>
        , ICreateReviewMut_CreateReview_Review
    {
        public CreateReviewMut_CreateReview_Review(
            global::System.Int32 stars,
            global::System.String? commentary)
        {
            Stars = stars;
            Commentary = commentary;
        }

        public global::System.Int32 Stars { get; }

        public global::System.String? Commentary { get; }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(
                    null,
                    obj))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((CreateReviewMut_CreateReview_Review)obj);
        }

        public global::System.Boolean Equals(CreateReviewMut_CreateReview_Review? other)
        {
            if (ReferenceEquals(
                    null,
                    other))
            {
                return false;
            }

            if (ReferenceEquals(
                    this,
                    other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Stars == other.Stars)
                && ((Commentary is null && other.Commentary is null) ||Commentary != null && Commentary.Equals(other.Commentary));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;

                hash ^= 397 * Stars.GetHashCode();

                if (!(Commentary is null))
                {
                    hash ^= 397 * Commentary.GetHashCode();
                }

                return hash;
            }
        }
    }
}


// ICreateReviewMutResult

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface ICreateReviewMutResult
    {
        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMut_CreateReview CreateReview { get; }
    }
}


// ICreateReviewMut_CreateReview

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface ICreateReviewMut_CreateReview
    {
        public global::System.Int32 Stars { get; }

        public global::System.String? Commentary { get; }
    }
}


// ICreateReviewMut_CreateReview_Review

// StrawberryShake.CodeGeneration.CSharp.Generators.ResultInterfaceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface ICreateReviewMut_CreateReview_Review
        : ICreateReviewMut_CreateReview
    {
    }
}


// ReviewInputInputValueFormatter

// StrawberryShake.CodeGeneration.CSharp.Generators.InputValueFormatterGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReviewInputInputValueFormatter
        : global::StrawberryShake.Serialization.IInputObjectFormatter
    {
        private global::StrawberryShake.Serialization.IInputValueFormatter _intFormatter = default!;
        private global::StrawberryShake.Serialization.IInputValueFormatter _stringFormatter = default!;

        public global::System.String TypeName => "ReviewInput";

        public void Initialize(global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _intFormatter = serializerResolver.GetInputValueFormatter("Int");
            _stringFormatter = serializerResolver.GetInputValueFormatter("String");
        }

        public global::System.Object? Format(global::System.Object? runtimeValue)
        {
            if (runtimeValue is null)
            {
                return null;
            }

            if (!(runtimeValue is ReviewInput d))
            {
                throw new global::System.ArgumentException(nameof(runtimeValue));
            }

            return new global::System.Collections.Generic.KeyValuePair<global::System.String, global::System.Object?>[] {
                new global::System.Collections.Generic.KeyValuePair<global::System.String, global::System.Object?>(
                    "stars",
                    FormatStars(d.Stars)),
                new global::System.Collections.Generic.KeyValuePair<global::System.String, global::System.Object?>(
                    "commentary",
                    FormatCommentary(d.Commentary))
            };
        }

        private global::System.Object? FormatStars(global::System.Int32 value)
        {
            return _intFormatter.Format(value);
        }

        private global::System.Object? FormatCommentary(global::System.String? value)
        {
            if (!(value is null))
            {
                return _stringFormatter.Format(value);
            }
            else
            {
                return value;
            }
        }
    }
}


// ReviewInput

// StrawberryShake.CodeGeneration.CSharp.Generators.InputTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReviewInput
    {
        public global::System.Int32 Stars { get; set; } = default!;

        public global::System.String? Commentary { get; set; } = default!;
    }
}


// Episode

// StrawberryShake.CodeGeneration.CSharp.Generators.EnumGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public enum Episode
    {
        NewHope,
        Empire,
        Jedi
    }
}


// EpisodeSerializer

// StrawberryShake.CodeGeneration.CSharp.Generators.EnumParserGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class EpisodeSerializer
        : global::StrawberryShake.Serialization.IInputValueFormatter
        , global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, Episode>
    {
        public global::System.String TypeName => "Episode";

        public Episode Parse(global::System.String serializedValue)
        {
            return serializedValue switch
            {
                "NEW_HOPE" => Episode.NewHope,
                "EMPIRE" => Episode.Empire,
                "JEDI" => Episode.Jedi,
                _ => throw new global::StrawberryShake.GraphQLClientException()
            };
        }

        public global::System.Object Format(global::System.Object? runtimeValue)
        {
            return runtimeValue switch
            {
                Episode.NewHope => "NEW_HOPE",
                Episode.Empire => "EMPIRE",
                Episode.Jedi => "JEDI",
                _ => throw new global::StrawberryShake.GraphQLClientException()
            };
        }
    }
}


// GetHeroQueryDocument

// StrawberryShake.CodeGeneration.CSharp.Generators.OperationDocumentGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the operation service of the GetHero GraphQL operation
    /// <code>
    /// query GetHero {
    ///   hero(episode: NEW_HOPE) {
    ///     __typename
    ///     name
    ///     friends {
    ///       __typename
    ///       nodes {
    ///         __typename
    ///         name
    ///         ... on Droid {
    ///           id
    ///         }
    ///         ... on Human {
    ///           id
    ///         }
    ///       }
    ///     }
    ///     ... on Droid {
    ///       id
    ///     }
    ///     ... on Human {
    ///       id
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHeroQueryDocument
        : global::StrawberryShake.IDocument
    {
        private GetHeroQueryDocument()
        {
        }

        public static GetHeroQueryDocument Instance { get; } = new GetHeroQueryDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x71, 0x75, 0x65, 0x72, 0x79, 0x20, 0x47, 0x65, 0x74, 0x48, 0x65, 0x72, 0x6f, 0x20, 0x7b, 0x20, 0x68, 0x65, 0x72, 0x6f, 0x28, 0x65, 0x70, 0x69, 0x73, 0x6f, 0x64, 0x65, 0x3a, 0x20, 0x4e, 0x45, 0x57, 0x5f, 0x48, 0x4f, 0x50, 0x45, 0x29, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x66, 0x72, 0x69, 0x65, 0x6e, 0x64, 0x73, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x6f, 0x64, 0x65, 0x73, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x6f, 0x6e, 0x20, 0x44, 0x72, 0x6f, 0x69, 0x64, 0x20, 0x7b, 0x20, 0x69, 0x64, 0x20, 0x7d, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x6f, 0x6e, 0x20, 0x48, 0x75, 0x6d, 0x61, 0x6e, 0x20, 0x7b, 0x20, 0x69, 0x64, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x6f, 0x6e, 0x20, 0x44, 0x72, 0x6f, 0x69, 0x64, 0x20, 0x7b, 0x20, 0x69, 0x64, 0x20, 0x7d, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x6f, 0x6e, 0x20, 0x48, 0x75, 0x6d, 0x61, 0x6e, 0x20, 0x7b, 0x20, 0x69, 0x64, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d };

        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("sha1Hash", "9f9a72871b1548dfdb9e75702e81c5c5945ff0c3");

        public override global::System.String ToString()
        {
            #if NETSTANDARD2_0
            return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
            #else
            return global::System.Text.Encoding.UTF8.GetString(Body);
            #endif
        }
    }
}


// GetHeroQuery

// StrawberryShake.CodeGeneration.CSharp.Generators.OperationServiceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the operation service of the GetHero GraphQL operation
    /// <code>
    /// query GetHero {
    ///   hero(episode: NEW_HOPE) {
    ///     __typename
    ///     name
    ///     friends {
    ///       __typename
    ///       nodes {
    ///         __typename
    ///         name
    ///         ... on Droid {
    ///           id
    ///         }
    ///         ... on Human {
    ///           id
    ///         }
    ///       }
    ///     }
    ///     ... on Droid {
    ///       id
    ///     }
    ///     ... on Human {
    ///       id
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHeroQuery
        : global::StrawberryShake.IOperationRequestFactory
    {
        private readonly global::StrawberryShake.IOperationExecutor<IGetHeroResult> _operationExecutor;

        public GetHeroQuery(global::StrawberryShake.IOperationExecutor<IGetHeroResult> operationExecutor)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IGetHeroResult);

        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IGetHeroResult>> ExecuteAsync(global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest();

            return await _operationExecutor
                .ExecuteAsync(
                    request,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IGetHeroResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest();
            return _operationExecutor.Watch(
                request,
                strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest()
        {

            return CreateRequest(null);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {

            return new global::StrawberryShake.OperationRequest(
                id: GetHeroQueryDocument.Instance.Hash.Value,
                name: "GetHero",
                document: GetHeroQueryDocument.Instance,
                strategy: global::StrawberryShake.RequestStrategy.Default);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest();
        }
    }
}


// OnReviewSubSubscriptionDocument

// StrawberryShake.CodeGeneration.CSharp.Generators.OperationDocumentGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the operation service of the OnReviewSub GraphQL operation
    /// <code>
    /// subscription OnReviewSub {
    ///   onReview(episode: NEW_HOPE) {
    ///     __typename
    ///     stars
    ///     commentary
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSubSubscriptionDocument
        : global::StrawberryShake.IDocument
    {
        private OnReviewSubSubscriptionDocument()
        {
        }

        public static OnReviewSubSubscriptionDocument Instance { get; } = new OnReviewSubSubscriptionDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Subscription;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x73, 0x75, 0x62, 0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x4f, 0x6e, 0x52, 0x65, 0x76, 0x69, 0x65, 0x77, 0x53, 0x75, 0x62, 0x20, 0x7b, 0x20, 0x6f, 0x6e, 0x52, 0x65, 0x76, 0x69, 0x65, 0x77, 0x28, 0x65, 0x70, 0x69, 0x73, 0x6f, 0x64, 0x65, 0x3a, 0x20, 0x4e, 0x45, 0x57, 0x5f, 0x48, 0x4f, 0x50, 0x45, 0x29, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x73, 0x74, 0x61, 0x72, 0x73, 0x20, 0x63, 0x6f, 0x6d, 0x6d, 0x65, 0x6e, 0x74, 0x61, 0x72, 0x79, 0x20, 0x7d, 0x20, 0x7d };

        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("sha1Hash", "92220fce37342d7ade3d63a2a81342eb1fb14bac");

        public override global::System.String ToString()
        {
            #if NETSTANDARD2_0
            return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
            #else
            return global::System.Text.Encoding.UTF8.GetString(Body);
            #endif
        }
    }
}


// OnReviewSubSubscription

// StrawberryShake.CodeGeneration.CSharp.Generators.OperationServiceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the operation service of the OnReviewSub GraphQL operation
    /// <code>
    /// subscription OnReviewSub {
    ///   onReview(episode: NEW_HOPE) {
    ///     __typename
    ///     stars
    ///     commentary
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSubSubscription
        : global::StrawberryShake.IOperationRequestFactory
    {
        private readonly global::StrawberryShake.IOperationExecutor<IOnReviewSubResult> _operationExecutor;

        public OnReviewSubSubscription(global::StrawberryShake.IOperationExecutor<IOnReviewSubResult> operationExecutor)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IOnReviewSubResult);

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IOnReviewSubResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest();
            return _operationExecutor.Watch(
                request,
                strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest()
        {

            return CreateRequest(null);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {

            return new global::StrawberryShake.OperationRequest(
                id: OnReviewSubSubscriptionDocument.Instance.Hash.Value,
                name: "OnReviewSub",
                document: OnReviewSubSubscriptionDocument.Instance,
                strategy: global::StrawberryShake.RequestStrategy.Default);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest();
        }
    }
}


// CreateReviewMutMutationDocument

// StrawberryShake.CodeGeneration.CSharp.Generators.OperationDocumentGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the operation service of the CreateReviewMut GraphQL operation
    /// <code>
    /// mutation CreateReviewMut($episode: Episode!, $review: ReviewInput!) {
    ///   createReview(episode: $episode, review: $review) {
    ///     __typename
    ///     stars
    ///     commentary
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMutMutationDocument
        : global::StrawberryShake.IDocument
    {
        private CreateReviewMutMutationDocument()
        {
        }

        public static CreateReviewMutMutationDocument Instance { get; } = new CreateReviewMutMutationDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;

        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{ 0x6d, 0x75, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x43, 0x72, 0x65, 0x61, 0x74, 0x65, 0x52, 0x65, 0x76, 0x69, 0x65, 0x77, 0x4d, 0x75, 0x74, 0x28, 0x24, 0x65, 0x70, 0x69, 0x73, 0x6f, 0x64, 0x65, 0x3a, 0x20, 0x45, 0x70, 0x69, 0x73, 0x6f, 0x64, 0x65, 0x21, 0x2c, 0x20, 0x24, 0x72, 0x65, 0x76, 0x69, 0x65, 0x77, 0x3a, 0x20, 0x52, 0x65, 0x76, 0x69, 0x65, 0x77, 0x49, 0x6e, 0x70, 0x75, 0x74, 0x21, 0x29, 0x20, 0x7b, 0x20, 0x63, 0x72, 0x65, 0x61, 0x74, 0x65, 0x52, 0x65, 0x76, 0x69, 0x65, 0x77, 0x28, 0x65, 0x70, 0x69, 0x73, 0x6f, 0x64, 0x65, 0x3a, 0x20, 0x24, 0x65, 0x70, 0x69, 0x73, 0x6f, 0x64, 0x65, 0x2c, 0x20, 0x72, 0x65, 0x76, 0x69, 0x65, 0x77, 0x3a, 0x20, 0x24, 0x72, 0x65, 0x76, 0x69, 0x65, 0x77, 0x29, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x73, 0x74, 0x61, 0x72, 0x73, 0x20, 0x63, 0x6f, 0x6d, 0x6d, 0x65, 0x6e, 0x74, 0x61, 0x72, 0x79, 0x20, 0x7d, 0x20, 0x7d };

        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("sha1Hash", "7b7488dce3bce5700fe4fab0d349728a5121c153");

        public override global::System.String ToString()
        {
            #if NETSTANDARD2_0
            return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
            #else
            return global::System.Text.Encoding.UTF8.GetString(Body);
            #endif
        }
    }
}


// CreateReviewMutMutation

// StrawberryShake.CodeGeneration.CSharp.Generators.OperationServiceGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the operation service of the CreateReviewMut GraphQL operation
    /// <code>
    /// mutation CreateReviewMut($episode: Episode!, $review: ReviewInput!) {
    ///   createReview(episode: $episode, review: $review) {
    ///     __typename
    ///     stars
    ///     commentary
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMutMutation
        : global::StrawberryShake.IOperationRequestFactory
    {
        private readonly global::StrawberryShake.IOperationExecutor<ICreateReviewMutResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _episodeFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _reviewInputFormatter;

        public CreateReviewMutMutation(
            global::StrawberryShake.IOperationExecutor<ICreateReviewMutResult> operationExecutor,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _episodeFormatter = serializerResolver.GetInputValueFormatter("Episode");
            _reviewInputFormatter = serializerResolver.GetInputValueFormatter("ReviewInput");
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(ICreateReviewMutResult);

        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<ICreateReviewMutResult>> ExecuteAsync(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.Episode episode,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ReviewInput review,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(
                episode,
                review);

            return await _operationExecutor
                .ExecuteAsync(
                    request,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<ICreateReviewMutResult>> Watch(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.Episode episode,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ReviewInput review,
            global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(
                episode,
                review);
            return _operationExecutor.Watch(
                request,
                strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.Episode episode,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ReviewInput review)
        {
            var variables = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();

            variables.Add(
                "episode",
                FormatEpisode(episode));
            variables.Add(
                "review",
                FormatReview(review));

            return CreateRequest(variables);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {

            return new global::StrawberryShake.OperationRequest(
                id: CreateReviewMutMutationDocument.Instance.Hash.Value,
                name: "CreateReviewMut",
                document: CreateReviewMutMutationDocument.Instance,
                strategy: global::StrawberryShake.RequestStrategy.Default,
                variables:variables);
        }

        private global::System.Object? FormatEpisode(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.Episode value)
        {
            return _episodeFormatter.Format(value);
        }

        private global::System.Object? FormatReview(global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ReviewInput value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _reviewInputFormatter.Format(value);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest(variables!);
        }
    }
}


// GetHeroBuilder

// StrawberryShake.CodeGeneration.CSharp.Generators.JsonResultBuilderGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetHeroBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;

        public GetHeroBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer idSerializer,
            global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer
                 ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String")
                 ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
        }

        public global::StrawberryShake.IOperationResult<IGetHeroResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IGetHeroResult Result, GetHeroResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;

            try
            {
                if (response.Body != null)
                {
                    if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                    {
                        data = BuildData(dataElement);
                    }
                    if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                    {
                        errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                    }
                }
            }
            catch(global::System.Exception ex)
            {
                errors = new global::StrawberryShake.IClientError[] {
                    new global::StrawberryShake.ClientError(
                        ex.Message,
                        exception: ex)
                };
            }

            return new global::StrawberryShake.OperationResult<IGetHeroResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                errors);
        }

        private (IGetHeroResult, GetHeroResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default!;

            global::StrawberryShake.EntityId? heroId = default!;
            _entityStore.Update(session => 
            {
                heroId = UpdateIGetHero_HeroEntity(
                    session,
                    global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                        obj,
                        "hero"),
                    entityIds);

                snapshot = session.CurrentSnapshot;
            });

            var resultInfo = new GetHeroResultInfo(
                heroId,
                entityIds,
                snapshot.Version);

            return (
                _resultDataFactory.Create(resultInfo),
                resultInfo
            );
        }

        private global::StrawberryShake.EntityId? UpdateIGetHero_HeroEntity(
            global::StrawberryShake.IEntityStoreUpdateSession session,
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            global::StrawberryShake.EntityId entityId = _idSerializer.Parse(obj.Value);
            entityIds.Add(entityId);


            if (entityId.Name.Equals(
                    "Droid",
                    global::System.StringComparison.Ordinal))
            {
                if (session.CurrentSnapshot.TryGetEntity(
                        entityId,
                        out global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity? entity))
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            DeserializeIGetHero_Hero_Friends(
                                session,
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "friends"),
                                entityIds)));
                }
                else
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            DeserializeIGetHero_Hero_Friends(
                                session,
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "friends"),
                                entityIds)));
                }

                return entityId;
            }

            if (entityId.Name.Equals(
                    "Human",
                    global::System.StringComparison.Ordinal))
            {
                if (session.CurrentSnapshot.TryGetEntity(
                        entityId,
                        out global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity? entity))
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            DeserializeIGetHero_Hero_Friends(
                                session,
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "friends"),
                                entityIds)));
                }
                else
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            DeserializeIGetHero_Hero_Friends(
                                session,
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "friends"),
                                entityIds)));
                }

                return entityId;
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData? DeserializeIGetHero_Hero_Friends(
            global::StrawberryShake.IEntityStoreUpdateSession session,
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("CharacterConnection", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CharacterConnectionData(
                    typename,
                    nodes: UpdateIGetHero_Hero_Friends_NodesEntityArray(
                        session,
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "nodes"),
                        entityIds));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? UpdateIGetHero_Hero_Friends_NodesEntityArray(
            global::StrawberryShake.IEntityStoreUpdateSession session,
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var characters = new global::System.Collections.Generic.List<global::StrawberryShake.EntityId?>();

            foreach (global::System.Text.Json.JsonElement child in obj.Value.EnumerateArray())
            {
                characters.Add(UpdateIGetHero_Hero_Friends_NodesEntity(
                    session,
                    child,
                    entityIds));
            }

            return characters;
        }

        private global::StrawberryShake.EntityId? UpdateIGetHero_Hero_Friends_NodesEntity(
            global::StrawberryShake.IEntityStoreUpdateSession session,
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            global::StrawberryShake.EntityId entityId = _idSerializer.Parse(obj.Value);
            entityIds.Add(entityId);


            if (entityId.Name.Equals(
                    "Droid",
                    global::System.StringComparison.Ordinal))
            {
                if (session.CurrentSnapshot.TryGetEntity(
                        entityId,
                        out global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity? entity))
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            entity.Friends));
                }
                else
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            default!));
                }

                return entityId;
            }

            if (entityId.Name.Equals(
                    "Human",
                    global::System.StringComparison.Ordinal))
            {
                if (session.CurrentSnapshot.TryGetEntity(
                        entityId,
                        out global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity? entity))
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            entity.Friends));
                }
                else
                {
                    session.SetEntity(
                        entityId,
                        new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity(
                            DeserializeNonNullableString(
                                global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                                    obj,
                                    "name")),
                            default!));
                }

                return entityId;
            }

            throw new global::System.NotSupportedException();
        }
    }
}


// OnReviewSubBuilder

// StrawberryShake.CodeGeneration.CSharp.Generators.JsonResultBuilderGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnReviewSubBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;

        public OnReviewSubBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer idSerializer,
            global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer
                 ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String")
                 ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int")
                 ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
        }

        public global::StrawberryShake.IOperationResult<IOnReviewSubResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IOnReviewSubResult Result, OnReviewSubResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;

            try
            {
                if (response.Body != null)
                {
                    if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                    {
                        data = BuildData(dataElement);
                    }
                    if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                    {
                        errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                    }
                }
            }
            catch(global::System.Exception ex)
            {
                errors = new global::StrawberryShake.IClientError[] {
                    new global::StrawberryShake.ClientError(
                        ex.Message,
                        exception: ex)
                };
            }

            return new global::StrawberryShake.OperationResult<IOnReviewSubResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                errors);
        }

        private (IOnReviewSubResult, OnReviewSubResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default!;

            _entityStore.Update(session => 
            {

                snapshot = session.CurrentSnapshot;
            });

            var resultInfo = new OnReviewSubResultInfo(
                DeserializeNonNullableIOnReviewSub_OnReview(
                    global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                        obj,
                        "onReview")),
                entityIds,
                snapshot.Version);

            return (
                _resultDataFactory.Create(resultInfo),
                resultInfo
            );
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData DeserializeNonNullableIOnReviewSub_OnReview(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("Review", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData(
                    typename,
                    stars: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "stars")),
                    commentary: DeserializeString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "commentary")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }

        private global::System.String? DeserializeString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }
    }
}


// CreateReviewMutBuilder

// StrawberryShake.CodeGeneration.CSharp.Generators.JsonResultBuilderGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CreateReviewMutBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.Episode> _episodeParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;

        public CreateReviewMutBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer idSerializer,
            global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer
                 ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _episodeParser = serializerResolver.GetLeafValueParser<global::System.String, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.Episode>("Episode")
                 ?? throw new global::System.ArgumentException("No serializer for type `Episode` found.");
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int")
                 ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String")
                 ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
        }

        public global::StrawberryShake.IOperationResult<ICreateReviewMutResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (ICreateReviewMutResult Result, CreateReviewMutResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;

            try
            {
                if (response.Body != null)
                {
                    if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                    {
                        data = BuildData(dataElement);
                    }
                    if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                    {
                        errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                    }
                }
            }
            catch(global::System.Exception ex)
            {
                errors = new global::StrawberryShake.IClientError[] {
                    new global::StrawberryShake.ClientError(
                        ex.Message,
                        exception: ex)
                };
            }

            return new global::StrawberryShake.OperationResult<ICreateReviewMutResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                errors);
        }

        private (ICreateReviewMutResult, CreateReviewMutResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default!;

            _entityStore.Update(session => 
            {

                snapshot = session.CurrentSnapshot;
            });

            var resultInfo = new CreateReviewMutResultInfo(
                DeserializeNonNullableICreateReviewMut_CreateReview(
                    global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                        obj,
                        "createReview")),
                entityIds,
                snapshot.Version);

            return (
                _resultDataFactory.Create(resultInfo),
                resultInfo
            );
        }

        private global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData DeserializeNonNullableICreateReviewMut_CreateReview(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value
                .GetProperty("__typename")
                .GetString();

            if (typename?.Equals("Review", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.ReviewData(
                    typename,
                    stars: DeserializeNonNullableInt32(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "stars")),
                    commentary: DeserializeString(
                        global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(
                            obj,
                            "commentary")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }

        private global::System.String? DeserializeString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }
    }
}


// CharacterConnectionData

// StrawberryShake.CodeGeneration.CSharp.Generators.DataTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    /// <summary>
    /// A connection to a list of items.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class CharacterConnectionData
    {
        public CharacterConnectionData(
            global::System.String typename,
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? nodes = null)
        {
            __typename = typename
                 ?? throw new global::System.ArgumentNullException(nameof(typename));
            Nodes = nodes;
        }

        public global::System.String __typename { get; }

        /// <summary>
        /// A flattened list of the nodes.
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? Nodes { get; }
    }
}


// ReviewData

// StrawberryShake.CodeGeneration.CSharp.Generators.DataTypeGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReviewData
    {
        public ReviewData(
            global::System.String typename,
            global::System.Int32? stars = null,
            global::System.String? commentary = null)
        {
            __typename = typename
                 ?? throw new global::System.ArgumentNullException(nameof(typename));
            Stars = stars;
            Commentary = commentary;
        }

        public global::System.String __typename { get; }

        public global::System.Int32? Stars { get; }

        public global::System.String? Commentary { get; }
    }
}


// MultiProfileClient

// StrawberryShake.CodeGeneration.CSharp.Generators.ClientGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    /// <summary>
    /// Represents the MultiProfileClient GraphQL client
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class MultiProfileClient
    {
        private readonly global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery _getHero;
        private readonly global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription _onReviewSub;
        private readonly global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation _createReviewMut;

        public MultiProfileClient(
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery getHero,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription onReviewSub,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation createReviewMut)
        {
            _getHero = getHero
                 ?? throw new global::System.ArgumentNullException(nameof(getHero));
            _onReviewSub = onReviewSub
                 ?? throw new global::System.ArgumentNullException(nameof(onReviewSub));
            _createReviewMut = createReviewMut
                 ?? throw new global::System.ArgumentNullException(nameof(createReviewMut));
        }

        public static global::System.String ClientName => "MultiProfileClient";

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery GetHero => _getHero;

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription OnReviewSub => _onReviewSub;

        public global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation CreateReviewMut => _createReviewMut;
    }
}


// MultiProfileClientEntityIdFactory

// StrawberryShake.CodeGeneration.CSharp.Generators.EntityIdFactoryGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class MultiProfileClientEntityIdFactory
        : global::StrawberryShake.IEntityIdSerializer
    {
        private static readonly global::System.Text.Json.JsonWriterOptions _options = new global::System.Text.Json.JsonWriterOptions(){ Indented = false };

        public global::StrawberryShake.EntityId Parse(global::System.Text.Json.JsonElement obj)
        {
            global::System.String typeName = obj
                .GetProperty("__typename")
                .GetString()!;

            return typeName switch
            {
                "Droid" => ParseDroidEntityId(
                    obj,
                    typeName),
                "Human" => ParseHumanEntityId(
                    obj,
                    typeName),
                _ => throw new global::System.NotSupportedException()
            };
        }

        public global::System.String Format(global::StrawberryShake.EntityId entityId)
        {
            return entityId.Name switch
            {
                "Droid" => FormatDroidEntityId(entityId),
                "Human" => FormatHumanEntityId(entityId),
                _ => throw new global::System.NotSupportedException()
            };
        }

        private global::StrawberryShake.EntityId ParseDroidEntityId(
            global::System.Text.Json.JsonElement obj,
            global::System.String type)
        {
            return new global::StrawberryShake.EntityId(
                type,
                obj
                    .GetProperty("id")
                    .GetString()!);
        }

        private global::System.String FormatDroidEntityId(global::StrawberryShake.EntityId entityId)
        {
            using var writer = new global::StrawberryShake.Internal.ArrayWriter();
            using var jsonWriter = new global::System.Text.Json.Utf8JsonWriter(
                writer,
                _options);
            jsonWriter.WriteStartObject();

            jsonWriter.WriteString(
                "__typename",
                entityId.Name);

            jsonWriter.WriteString(
                "id",
                (global::System.String)entityId.Value);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();

            return global::System.Text.Encoding.UTF8.GetString(
                writer.GetInternalBuffer(),
                0,
                writer.Length);
        }

        private global::StrawberryShake.EntityId ParseHumanEntityId(
            global::System.Text.Json.JsonElement obj,
            global::System.String type)
        {
            return new global::StrawberryShake.EntityId(
                type,
                obj
                    .GetProperty("id")
                    .GetString()!);
        }

        private global::System.String FormatHumanEntityId(global::StrawberryShake.EntityId entityId)
        {
            using var writer = new global::StrawberryShake.Internal.ArrayWriter();
            using var jsonWriter = new global::System.Text.Json.Utf8JsonWriter(
                writer,
                _options);
            jsonWriter.WriteStartObject();

            jsonWriter.WriteString(
                "__typename",
                entityId.Name);

            jsonWriter.WriteString(
                "id",
                (global::System.String)entityId.Value);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();

            return global::System.Text.Encoding.UTF8.GetString(
                writer.GetInternalBuffer(),
                0,
                writer.Length);
        }
    }
}


// MultiProfileClientServiceCollectionExtensions

// StrawberryShake.CodeGeneration.CSharp.Generators.DependencyInjectionGenerator

#nullable enable

namespace Microsoft.Extensions.DependencyInjection
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public static partial class MultiProfileClientServiceCollectionExtensions
    {
        public static global::StrawberryShake.IClientBuilder<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.MultiProfileClientStoreAccessor> AddMultiProfileClient(
            this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services,
            global::StrawberryShake.ExecutionStrategy strategy = global::StrawberryShake.ExecutionStrategy.NetworkOnly,
            global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClientProfileKind profile = global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClientProfileKind.InMemory)
        {
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var serviceCollection = profile switch
                    {
                        global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClientProfileKind.InMemory => ConfigureClientInMemory(
                            sp,
                            strategy),
                        global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClientProfileKind.Default => ConfigureClientDefault(
                            sp,
                            strategy)
                    };

                    return new ClientServiceProvider(
                        global::Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(serviceCollection));
                });

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => new global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.MultiProfileClientStoreAccessor(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityStore>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityIdSerializer>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationRequestFactory>>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationResultDataFactory>>(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp))));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClient>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ClientServiceProvider>(sp)));

            return new global::StrawberryShake.ClientBuilder<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.MultiProfileClientStoreAccessor>(
                "MultiProfileClient",
                services);
        }

        private static global::Microsoft.Extensions.DependencyInjection.IServiceCollection ConfigureClientInMemory(
            global::System.IServiceProvider parentServices,
            global::StrawberryShake.ExecutionStrategy strategy = global::StrawberryShake.ExecutionStrategy.NetworkOnly)
        {
            var services = new global::Microsoft.Extensions.DependencyInjection.ServiceCollection();
            global::Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton<global::StrawberryShake.IEntityStore, global::StrawberryShake.EntityStore>(services);
            global::Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton<global::StrawberryShake.IOperationStore>(
                services,
                sp => new global::StrawberryShake.OperationStore(global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityStore>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var clientFactory = global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.InMemory.IInMemoryClientFactory>(parentServices);
                    return new global::StrawberryShake.Transport.InMemory.InMemoryConnection(async ct => await clientFactory.CreateAsync(
                        "MultiProfileClient",
                        ct));
                });

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Droid>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_DroidFromDroidEntityMapper>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Human>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_HumanFromHumanEntityMapper>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Friends_Nodes_Droid>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Friends_Nodes_Human>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper>(services);

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.EpisodeSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.StringSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.BooleanSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ByteSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ShortSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.IntSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.LongSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.FloatSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DecimalSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.UrlSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.UuidSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.IdSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DateTimeSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DateSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ByteArraySerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.TimeSpanSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ReviewInputInputValueFormatter>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializerResolver>(
                services,
                sp => new global::StrawberryShake.Serialization.SerializerResolver(
                    global::System.Linq.Enumerable.Concat(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.Serialization.ISerializer>>(
                            parentServices),
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.Serialization.ISerializer>>(
                            sp))));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHeroResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHeroBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.InMemory.InMemoryConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.OnReviewSubResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.OnReviewSubBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.InMemory.InMemoryConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CreateReviewMutResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CreateReviewMutBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.InMemory.InMemoryConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityIdSerializer, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.MultiProfileClientEntityIdFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClient>(services);
            return services;
        }

        private static global::Microsoft.Extensions.DependencyInjection.IServiceCollection ConfigureClientDefault(
            global::System.IServiceProvider parentServices,
            global::StrawberryShake.ExecutionStrategy strategy = global::StrawberryShake.ExecutionStrategy.NetworkOnly)
        {
            var services = new global::Microsoft.Extensions.DependencyInjection.ServiceCollection();
            global::Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton<global::StrawberryShake.IEntityStore, global::StrawberryShake.EntityStore>(services);
            global::Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton<global::StrawberryShake.IOperationStore>(
                services,
                sp => new global::StrawberryShake.OperationStore(global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IEntityStore>(sp)));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var sessionPool = global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.WebSockets.ISessionPool>(parentServices);
                    return new global::StrawberryShake.Transport.WebSockets.WebSocketConnection(async ct => await sessionPool.CreateAsync(
                        "MultiProfileClient",
                        ct));
                });
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(
                services,
                sp => 
                {
                    var clientFactory = global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Net.Http.IHttpClientFactory>(parentServices);
                    return new global::StrawberryShake.Transport.Http.HttpConnection(() => clientFactory.CreateClient("MultiProfileClient"));
                });

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Droid>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_DroidFromDroidEntityMapper>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Human>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_HumanFromHumanEntityMapper>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.DroidEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Friends_Nodes_Droid>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_Friends_Nodes_DroidFromDroidEntityMapper>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityMapper<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.HumanEntity, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHero_Hero_Friends_Nodes_Human>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHero_Hero_Friends_Nodes_HumanFromHumanEntityMapper>(services);

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.EpisodeSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.StringSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.BooleanSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ByteSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ShortSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.IntSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.LongSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.FloatSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DecimalSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.UrlSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.UuidSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.IdSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DateTimeSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.DateSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.ByteArraySerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.Serialization.TimeSpanSerializer>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializer, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ReviewInputInputValueFormatter>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.Serialization.ISerializerResolver>(
                services,
                sp => new global::StrawberryShake.Serialization.SerializerResolver(
                    global::System.Linq.Enumerable.Concat(
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.Serialization.ISerializer>>(
                            parentServices),
                        global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::System.Collections.Generic.IEnumerable<global::StrawberryShake.Serialization.ISerializer>>(
                            sp))));

            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHeroResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.GetHeroBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.Http.HttpConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IGetHeroResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.GetHeroQuery>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.OnReviewSubResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.OnReviewSubBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.WebSockets.WebSocketConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.IOnReviewSubResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.OnReviewSubSubscription>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CreateReviewMutResultFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultDataFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultDataFactory<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationRequestFactory>(
                services,
                sp => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation>(sp));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.CreateReviewMutBuilder>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IOperationExecutor<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>>(
                services,
                sp => new global::StrawberryShake.OperationExecutor<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>(
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.Transport.Http.HttpConnection>(sp),
                    () => global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.ICreateReviewMutResult>>(sp),
                    global::Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<global::StrawberryShake.IOperationStore>(sp),
                    strategy));
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.CreateReviewMutMutation>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.IEntityIdSerializer, global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State.MultiProfileClientEntityIdFactory>(services);
            global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.MultiProfileClient>(services);
            return services;
        }

        private class ClientServiceProvider
            : System.IServiceProvider
            , System.IDisposable
        {
            private readonly System.IServiceProvider _provider;

            public ClientServiceProvider(System.IServiceProvider provider)
            {
                _provider = provider;
            }

            public object? GetService(System.Type serviceType)
            {
                return _provider.GetService(serviceType);
            }

            public void Dispose()
            {
                if (_provider is System.IDisposable d)
                {
                    d.Dispose();
                }
            }
        }
    }
}


// MultiProfileClientProfileKind

// StrawberryShake.CodeGeneration.CSharp.Generators.TransportProfileEnumGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public enum MultiProfileClientProfileKind
    {
        InMemory,
        Default
    }
}


// MultiProfileClientStoreAccessor

// StrawberryShake.CodeGeneration.CSharp.Generators.StoreAccessorGenerator

#nullable enable

namespace StrawberryShake.CodeGeneration.CSharp.Integration.MultiProfile.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class MultiProfileClientStoreAccessor
        : global::StrawberryShake.StoreAccessor
    {
        public MultiProfileClientStoreAccessor(
            global::StrawberryShake.IOperationStore operationStore,
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityIdSerializer entityIdSerializer,
            global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationRequestFactory> requestFactories,
            global::System.Collections.Generic.IEnumerable<global::StrawberryShake.IOperationResultDataFactory> resultDataFactories)
            : base(
                operationStore,
                entityStore,
                entityIdSerializer,
                requestFactories,
                resultDataFactories)
        {
        }
    }
}


