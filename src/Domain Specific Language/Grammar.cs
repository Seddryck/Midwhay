using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace Midwhay.Dsl
{
    public class Grammar
    {
        public static readonly Parser<ActionType> Action =
            Parse.String("LINK").Return(ActionType.Link)
                .Or(Parse.String("SNOWFLAKE").Return(ActionType.Snowflake))
                .Or(Parse.String("JUNK").Return(ActionType.Junk)
                .Or(Parse.String("OUTRIGGER").Return(ActionType.Outrigger)).Token());

        public static readonly Parser<QualifierType> Qualifier =
            Parse.String("FROM").Return(QualifierType.From)
                .Or(Parse.String("TO").Return(QualifierType.To))
                .Or(Parse.String("THROUGH").Return(QualifierType.Through)).Token();

        public static readonly Parser<string> Textual = Parse.Letter.AtLeastOnce().Text().Token();
        public static readonly Parser<string> BracketTextual = Parse.CharExcept("[]").AtLeastOnce().Text().Contained(Parse.Char('['), Parse.Char(']'));
        public static readonly Parser<string> Record = Textual.Or(BracketTextual);
        public static readonly Parser<IEnumerable<string>> RecordSequence = Record.DelimitedBy(Parse.Char(','));
        public static readonly Parser<char> Terminator = Parse.Char(';');

        public static readonly Parser<RoleObject> RoleObject =
            (
                from qualifier in Qualifier
                from obj in RecordSequence
                select new RoleObject(qualifier, obj)
            ).Token();

        public static readonly Parser<Sentence> Sentence =
            (
                from action in Action
                from roleObjects in RoleObject.Many()
                from terminator in Terminator
                select new Sentence(action, roleObjects)
            ).Token();

        public static readonly Parser<IEnumerable<Sentence>> Sentences = Sentence.Many();

    }
}
