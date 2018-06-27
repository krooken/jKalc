using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// The state when a double has been encountered.
    /// See finite automata in Automata folder.
    /// </summary>
    class DoubleState:State
    {
        internal DoubleState(Scanner sc)
            : base(sc)
        { }

        internal DoubleState(Scanner sc, Token token)
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
                return new DoubleToken(token.TokenText);
            }
        }
    }
}
