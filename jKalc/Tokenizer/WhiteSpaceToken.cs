using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// A token of only whitespaces.
    /// Creates an empty ExpressionItem which doesn't do anything.
    /// </summary>
    class WhiteSpaceToken:Token
    {
        internal WhiteSpaceToken(string wsText)
        {
           text = wsText;
        }

        public override string ToString()
        {
            return "WhiteSpaceToken: " + text.Length.ToString("D" + text.Length.ToString());
        }

        public override Parser.ExpressionItem GetExpressionItem()
        {
            return new Parser.WhiteSpaceItem();
        }
    }
}
