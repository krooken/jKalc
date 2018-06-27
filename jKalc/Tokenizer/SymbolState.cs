using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// The state when a symbol has been encountered.
    /// See automata folder for more info.
    /// </summary>
    class SymbolState:State
    {
        internal SymbolState(Scanner sc)
            : base(sc)
        { }

        internal SymbolState(Scanner sc, Token token)
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
                return new ReferenceToken(token.TokenText);
            }
        }
    }
}
