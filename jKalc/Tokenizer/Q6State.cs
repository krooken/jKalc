using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// See finite automata in Automata folder.
    /// </summary>
    class Q6State:State
    {
        internal Q6State(Scanner sc)
            : base(sc)
        { }

        internal Q6State(Scanner sc, Token token)
            : base(sc, token)
        { }

        public override State Next()
        {
            if (sc.HasNext())
            {
                string next = sc.Peek();
                if (Char.IsDigit(next, 0))
                {
                    token.Add(sc.Next());
                    return new Q4State(sc, token);
                }
                else
                {
                    throw new Exception(token.TokenText + next + " is not a valid token");
                }
            }
            throw new Exception(token.TokenText + " is not a valid token");
        }
    }
}
