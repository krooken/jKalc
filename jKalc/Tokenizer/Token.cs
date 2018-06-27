using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// A class that keeps track of the current scanned token.
    /// New scan results are added according to the automaton.
    /// </summary>
    public class Token
    {
        protected string text;

        /// <summary>
        /// Creates a an empty token.
        /// </summary>
        public Token()
        {
            text = String.Empty;
        }

        /// <summary>
        /// Adds the given string to the token.
        /// </summary>
        /// <param name="addition">A string to add.</param>
        public void Add(string addition)
        {
            text += addition;
        }

        /// <summary>
        /// Creates an expressionItem based on the scanned text in this token.
        /// </summary>
        /// <returns>An ExpressionItem.</returns>
        public virtual ExpressionItem GetExpressionItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the scanned text in this token.
        /// </summary>
        public string TokenText
        {
            get { return String.Copy(text); }
        }
    }
}
