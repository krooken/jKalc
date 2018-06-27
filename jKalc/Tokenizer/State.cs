using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// This is the superclass of all states in the finite automata.
    /// See the automata folder.
    /// Each state has a scanner and a token linked to it.
    /// Every new token scanned by the scanner results in a
    /// transition.
    /// The transitions that are available are determined by the finite automaton.
    /// In each transition the scanner's next scan are added to the state's token.
    /// The token and scanner are then passed to the next state.
    /// If the scanner's next scan isn't a valid transition,
    /// an exception is thrown.
    /// At certain points the state's token are considered to be complete.
    /// At such a time the IsComplete returns true, and the automaton is restarted from the beginning.
    /// </summary>
    public class State
    {
        protected Scanner sc;
        protected Token token;

        /// <summary>
        /// Creates a state with the given scanner and an empty token.
        /// </summary>
        /// <param name="sc">The scanner that contains the expression to be parsed.</param>
        public State(Scanner sc):this(sc,new Token())
        {
        }

        /// <summary>
        /// Creates a state with the fgiven scanner and token.
        /// </summary>
        /// <param name="sc">The scanner that contains the expression to be parsed.</param>
        /// <param name="token">A token in which the result of the parsing is stored.</param>
        protected State(Scanner sc, Token token)
        {
            this.sc = sc;
            this.token = token;
        }

        /// <summary>
        /// Returns the next state in the automaton.
        /// </summary>
        /// <returns>The next state</returns>
        public virtual State Next()
        {
            return null;
        }

        /// <summary>
        /// Tells whether the automaton has reached an exit state.
        /// </summary>
        /// <returns>True if the automaton has reached its final state.</returns>
        public virtual bool IsComplete()
        {
            return false;
        }

        /// <summary>
        /// Returnes the scanned token.
        /// </summary>
        public virtual Token Token
        {
            get { return token; }
        }
    }
}
