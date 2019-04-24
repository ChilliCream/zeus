﻿using System;

namespace HotChocolate.Language
{
    internal static class ParserHelper
    {
        public static string ExpectName(in Utf8GraphQLReader reader)
        {
            if (reader.Kind == TokenKind.Name)
            {
                string name = reader.GetString(reader.Value);
                reader.Read();
                return name;
            }

            throw new SyntaxException(reader,
                $"Expected a name token: {TokenVisualizer.Visualize(reader)}.");
        }

        public static void ExpectColon(in Utf8GraphQLReader reader)
        {
            Expect(in reader, TokenKind.Colon);
        }

        public static void ExpectDollar(in Utf8GraphQLReader reader)
        {
            Expect(in reader, TokenKind.Dollar);
        }

        public static void ExpectAt(in Utf8GraphQLReader reader)
        {
            Expect(in reader, TokenKind.At);
        }

        public static void ExpectRightBracket(in Utf8GraphQLReader reader)
        {
            Expect(in reader, TokenKind.RightBracket);
        }

        public static void ExpectLeftBrace(in Utf8GraphQLReader reader)
        {
            Expect(in reader, TokenKind.RightBracket);
        }

        public static string ExpectString(in Utf8GraphQLReader reader)
        {
            if (TokenHelper.IsString(in reader))
            {
                string value = reader.GetString();
                reader.Read();
                return value;
            }

            throw new SyntaxException(reader,
                "Expected a string token: " +
                $"{TokenVisualizer.Visualize(reader)}.");
        }

        public static string ExpectScalarValue(in Utf8GraphQLReader reader)
        {
            if (TokenHelper.IsScalarValue(in reader))
            {
                string value = reader.GetString(reader.Value);
                reader.Read();
                return value;
            }

            throw new SyntaxException(reader,
                "Expected a scalar value token: " +
                $"{TokenVisualizer.Visualize(reader)}.");
        }


        public static void ExpectSpread(in Utf8GraphQLReader reader)
        {
            Expect(in reader, TokenKind.Spread);
        }

        public static void Expect(
            in Utf8GraphQLReader reader,
            TokenKind kind)
        {
            if (reader.Kind == kind)
            {
                reader.Read();
            }

            throw new SyntaxException(reader,
                $"Expected a name token: {reader.Kind}.");
        }

        public static void ExpectScalarKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Scalar);
        }

        public static void ExpectSchemaKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Schema);
        }

        public static void ExpectTypeKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Type);
        }

        public static void ExpectInterfaceKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Interface);
        }

        public static void ExpectUnionKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Union);
        }

        public static void ExpectEnumKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Enum);
        }

        public static void ExpectInputKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Input);
        }

        public static void ExpectExtendKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Extend);
        }

        public static void ExpectDirectiveKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Directive);
        }

        public static void ExpectOnKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.On);
        }

        public static void ExpectFragmentKeyword(
            in Utf8GraphQLReader reader)
        {
            ExpectKeyword(in reader, Utf8Keywords.Fragment);
        }

        public static void ExpectKeyword(
            in Utf8GraphQLReader reader,
            byte[] keyword)
        {
            if (TokenHelper.IsName(in reader)
                && reader.Value.SequenceEqual(keyword))
            {
                reader.Read();
                return;
            }
            throw new SyntaxException(reader,
                $"Expected \"{keyword}\", found " +
                $"{TokenVisualizer.Visualize(in reader)}");
        }

        public static SyntaxTokenInfo CreateTokenInfo(
            in Utf8GraphQLReader reader)
        {
            return new SyntaxTokenInfo(
                reader.Kind,
                reader.Start,
                reader.End,
                reader.Line,
                reader.Column);
        }

        public static SyntaxException Unexpected(
            in Utf8GraphQLReader reader, TokenKind kind)
        {
            return new SyntaxException(reader,
                $"Unexpected token: {TokenVisualizer.Visualize(kind)}.");
        }

        public static void SkipDescription(in Utf8GraphQLReader reader)
        {
            if (TokenHelper.IsDescription(in reader))
            {
                reader.Read();
            }
        }

        public static void SkipWhile(in Utf8GraphQLReader reader, TokenKind kind)
        {
            while (Skip(in reader, kind)) ;
        }

        public static bool Skip(in Utf8GraphQLReader reader, TokenKind kind)
        {
            if (reader.Kind == kind)
            {
                return reader.Read();
            }
            return false;
        }

        public static bool SkipRepeatableKeyword(in Utf8GraphQLReader reader)
        {
            return SkipKeyword(in reader, Utf8Keywords.Repeatable);
        }

        public static bool SkipKeyword(
            in Utf8GraphQLReader reader,
            byte[] keyword)
        {
            if (TokenHelper.IsName(in reader)
                && reader.Value.SequenceEqual(keyword))
            {
                reader.Read();
                return true;
            }
            return false;
        }
    }
}
