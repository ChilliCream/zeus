namespace HotChocolate.Analyzers.Configuration
{

    /// <summary>
    /// The Neo4J generator settings.
    /// </summary>
    public class Neo4JSettings
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; } = "Neo4J";

        /// <summary>
        /// Gets the Neo4J database name.
        /// </summary>
        public string DatabaseName { get; set; } = "neo4j";

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string? Namespace { get; set; }

        /// <summary>
        /// Defines if the generated code shall be emitted.
        /// </summary>
        public bool EmitCode { get; set; }

        /// <summary>
        /// Gets the location of the generated directory.
        /// </summary>
        public string Generated { get; set; } = default!;
    }
}
