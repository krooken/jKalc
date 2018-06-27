using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// The superclass of all items that are valid in an expression.
    /// Should not be instantiated.
    /// </summary>
    public class ExpressionItem
    {


        internal ExpressionItem()
        { }

        /// <summary>
        /// Returns the value of the item.
        /// The setter is implemented in order to allow for variables to be assigned new values.
        /// All expression items but VariableItems throws exception if the setter is used.
        /// </summary>
        public virtual double Value
        {
            get { return 0.0; }
            set { throw new Exception("Cannot asign values to non-variables"); }
        }

        /// <summary>
        /// Returns true if this item can supply a value.
        /// Whitespaces returns false.
        /// </summary>
        /// <returns></returns>
        internal protected virtual bool HasValue()
        {
            return true;
        }

        /// <summary>
        /// Is the expression item a valid expression.
        /// For values and variables this is always true,
        /// while functions and operators only return true if 
        /// all parameters are set.
        /// </summary>
        /// <returns></returns>
        internal protected virtual bool IsValid()
        {
            return false;
        }
    }
}
