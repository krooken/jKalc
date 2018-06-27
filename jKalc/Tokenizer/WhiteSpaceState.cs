using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// Consumes all consecutive whitespaces.
    /// </summary>
    public class WhiteSpaceState:State
    {
        public WhiteSpaceState(Scanner sc)
            : base(sc)
        { }

        internal WhiteSpaceState(Scanner sc, Token token)
            : base(sc, token)
        { }

        public override State Next()
        {
            return this;
        }

        public override bool IsComplete()
        {
            return true;
        }

        public override Token Token
        {
            get
            {
                return new WhiteSpaceToken(token.TokenText);
            }
        }
    }
}
