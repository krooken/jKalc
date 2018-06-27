using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// See finite automata in Automata folder.
    /// </summary>
    public class Q7State:State
    {
        public Q7State(Scanner sc)
            : base(sc)
        { }

        internal Q7State(Scanner sc, Token token)
            : base(sc, token)
        { }

        public override State Next()
        {
            if (sc.HasNext())
            {
                string next = sc.Peek();
                if (next.ToCharArray()[0] == ' ')
                {
                    token.Add(sc.Next());
                    return new Q7State(sc, token);
                }
                else
                {
                    return new WhiteSpaceState(sc,token);
                }
            }
            return new WhiteSpaceState(sc, token);
        }
    }
}
