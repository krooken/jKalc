using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// An ExpressionItem which acts as a double value.
    /// </summary>
    class DoubleItem:ExpressionItem
    {
        protected double value;

        /// <summary>
        /// Creates a new DoubleItem with the given value.
        /// </summary>
        /// <param name="value"></param>
        internal DoubleItem(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns the value.
        /// </summary>
        public override double Value
        {
            get
            {
                return value;
            }
        }

        /// <summary>
        /// Returns true, since a single value is a valid expression.
        /// </summary>
        /// <returns></returns>
        internal protected override bool IsValid()
        {
            return true;
        }
    }
}
