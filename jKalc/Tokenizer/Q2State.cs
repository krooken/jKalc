﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// See finite automata in Automata folder.
    /// </summary>
    class Q2State:State
    {
        internal Q2State(Scanner sc)
            : base(sc)
        { }

        internal Q2State(Scanner sc, Token token)
            : base(sc, token)
        { }

        public override State Next()
        {
            if (sc.HasNext())
            {
                string next = sc.Peek();
                if (Char.IsDigit(next,0))
                {
                    token.Add(sc.Next());
                    return this;
                }
                else if (next.ToCharArray()[0] == 'e' || next.ToCharArray()[0] == 'E')
                {
                    token.Add(sc.Next());
                    return new Q3State(sc, token);
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
