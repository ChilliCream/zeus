using System.Threading;
using System.Security.Cryptography;

namespace HotChocolate.Language
{
    public class Sha1DocumentHashProvider
        : DocumentHashProviderBase
    {
        private readonly ThreadLocal<SHA1> _sha =
            new ThreadLocal<SHA1>(() => SHA1.Create());

        public Sha1DocumentHashProvider()
            : this(HashRepresentation.Base64)
        {
        }

        public Sha1DocumentHashProvider(HashRepresentation representation)
            : base(representation)
        {
        }

        public override string Name => "sha1Hash";

        protected override byte[] ComputeHash(byte[] document, int length)
        {
            return _sha.Value.ComputeHash(document, 0, length);
        }
    }
}
