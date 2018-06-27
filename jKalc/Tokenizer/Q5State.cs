using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// See finite automata in Automata folder.
    /// </summary>
    class Q5State:State
    {
        internal Q5State(Scanner sc)
            : base(sc)
        { }

        internal Q5State(Scanner sc, Token token)
            : base(sc, token)
        { }

        public override State Next()
        {
            if (sc.HasNext())
            {
                string next = sc.Peek();
                if (Char.IsLetterOrDigit(next, 0))
                {
                    token.Add(sc.Next());
                    return this;
                }
                else
                {
                    return new SymbolState(sc, token);
                }
            }
            return new SymbolState(sc, token);
        }
    }
}
