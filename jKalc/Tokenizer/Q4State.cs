using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// See finite automata in Automata folder.
    /// </summary>
    class Q4State:State
    {
        internal Q4State(Scanner sc)
            : base(sc)
        { }

        internal Q4State(Scanner sc, Token token)
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
                    return this;
                }
                else
                {
                    return new DoubleState(sc, token);
                }
            }
            return new DoubleState(sc, token);
        }
    }
}
