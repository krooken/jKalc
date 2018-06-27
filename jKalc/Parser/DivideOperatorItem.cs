using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// The division operator.
    /// </summary>
    class DivideOperatorItem:OperatorItem
    {
        /// <summary>
        /// Creates a division operator.
        /// Binary operator, left associative with precedence 3.
        /// </summary>
        internal DivideOperatorItem()
        {
            configs = new OperatorConfiguration[] 
                {new OperatorConfiguration(Associativity.left,2,3)};
        }

        /// <summary>
        /// Returns the value of this expression.
        /// Throws an exception if set.
        /// </summary>
        public override double Value
        {
            get
            {
                return CalculateValue();
            }
            set
            {
                base.Value = value;
            }
        }

        /// <summary>
        /// Calculates the value of this operator applied to the parameters.
        /// </summary>
        /// <returns>The value of the operation.</returns>
        private double CalculateValue()
        {
            if (!IsValid())
            {
                throw new Exception("The / expression is not valid");
            }

            if (config.Equals(configs[0]))
            {
                return parameters.ElementAt(0).Value / parameters.ElementAt(1).Value;
            }
            else
            {
                throw new Exception("The - operator has not got valid parameters");
            }
        }

        public override object Clone()
        {
            return new DivideOperatorItem();
        }
    }
}
