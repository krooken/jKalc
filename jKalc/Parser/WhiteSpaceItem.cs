using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// A placeholder for whitespaces. Has no meaning for the evaluation of the expression.
    /// </summary>
    class WhiteSpaceItem:ExpressionItem
    {
        protected double value;

        internal WhiteSpaceItem()
        {
            this.value = 0.0;
        }

        public override double Value
        {
            get
            {
                return value;
            }
        }

        internal protected override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Always false. The interpreter uses this to distinguish whitespaces from items containing values.
        /// </summary>
        /// <returns></returns>
        protected internal override bool HasValue()
        {
            return false;
        }
    }
}
