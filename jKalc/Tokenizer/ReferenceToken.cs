using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// Represents a token that is a reference.
    /// That could be variables and functions.
    /// </summary>
    class ReferenceToken:Token
    {
        /// <summary>
        /// Creates a token with the given reference string.
        /// </summary>
        /// <param name="referenceText">The reference text.</param>
        internal ReferenceToken(string referenceText)
        {
            text = referenceText;
        }

        /// <summary>
        /// Returns the reference name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ReferenceToken: " + text;
        }

        /// <summary>
        /// Returns the expression item that corresponds to the reference text.
        /// The reference resolver manages the creation of the expression item.
        /// </summary>
        /// <returns>An expression item for the reference.</returns>
        public override ExpressionItem GetExpressionItem()
        {
            return ReferenceResolver.GetResolver().GetReference(text);
        }
    }
}
