namespace HotChocolate.Language
{
    public class Utf8ParserContext
    {
        public Utf8ParserContext(ParserOptions options)
        {
        }

        public ParserOptions Options { get; }

        public void Start(in Utf8GraphQLReader reader)
        {
            // use stack for token info
        }

        public Location CreateLocation(in Utf8GraphQLReader reader)
        {

        }

        public void PushDescription(StringValueNode description)
        {

        }

        public StringValueNode PopDescription()
        {

        }
    }
}
