using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// See finite automata in Automata folder.
    /// </summary>
    public class Q0State:State
    {
        public Q0State(Scanner sc)
            : base(sc)
        { }

        Q0State(Scanner sc, Token token)
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
                    return new Q1State(sc, token);
                }
                else if (Char.IsLetter(next, 0))
                {
                    token.Add(sc.Next());
                    return new Q5State(sc, token);
                }
                else if (next.ToCharArray()[0] == '.')
                {
                    token.Add(sc.Next());
                    return new Q2State(sc, token);
                }
                else if (next.ToCharArray()[0] == ' ')
                {
                    token.Add(sc.Next());
                    return new Q7State(sc, token);
                }
                else if (next.ToCharArray()[0] == '+')
                {
                    token.Add(sc.Next());
                    return new SymbolState(sc,token);
                }
                else if (next.ToCharArray()[0] == '-')
                {
                    token.Add(sc.Next());
                    return new SymbolState(sc, token);
                }
                else if (next.ToCharArray()[0] == '*')
                {
                    token.Add(sc.Next());
                    return new SymbolState(sc, token);
                }
                else if (next.ToCharArray()[0] == '/')
                {
                    token.Add(sc.Next());
                    return new SymbolState(sc, token);
                }
                else if (next.ToCharArray()[0] == '=')
                {
                    token.Add(sc.Next());
                    return new SymbolState(sc, token);
                }
                else
                {
                    throw new Exception(token.TokenText + next + " is not a valid token");
                }
            }
            return null;
        }
    }
}
