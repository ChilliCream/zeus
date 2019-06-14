namespace HotChocolate.Types.Filters
{
    public enum FilterOperationKind
        : byte
    {
        Equals = 0x0000,
        NotEquals = 0x0001,

        Contains = 0x0002,
        NotContains = 0x0003,

        In = 0x0004,
        NotIn = 0x0005,

        StartsWith = 0x0006,
        NotStartsWith = 0x0007,

        EndsWith = 0x0008,
        NotEndsWith = 0x0009,

        GreaterThan = 0x0016,
        NotGreaterThan = 0x0017,

        GreaterThanOrEqual = 0x0018,
        NotGreaterThanOrEqual = 0x0019,

        LowerThan = 0x0020,
        NotLowerThan = 0x0021,

        LowerThanOrEqual = 0x0022,
        NotLowerThanOrEqual = 0x0023,
    }
}
