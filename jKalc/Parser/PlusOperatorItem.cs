using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// The plus operator.
    /// Can be used as an unary or binary operator.
    /// Both are left associative.
    /// The binary has precedence 4,
    /// while the unary has precedence 2.
    /// </summary>
    class PlusOperatorItem:OperatorItem
    {
        internal PlusOperatorItem()
        {
            configs = new OperatorConfiguration[] 
                {new OperatorConfiguration(Associativity.left,2,4),new OperatorConfiguration(Associativity.left,1,2)};
        }

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

        private double CalculateValue()
        {
            if (!IsValid())
            {
                throw new Exception("The + expression is not valid");
            }

            if (config.Equals(configs[0]))
            {
                return parameters.ElementAt(0).Value + parameters.ElementAt(1).Value;
            }
            else if (config.Equals(configs[1]))
            {
                return parameters.ElementAt(0).Value;
            }
            else
            {
                throw new Exception("The + operator has not got valid parameters");
            }
        }

        public override object Clone()
        {
            return new PlusOperatorItem();
        }

        /// <summary>
        /// The operator is supplied by a range of parameters.
        /// The operator returns true if the parameters are accepted.
        /// If the parameters are not accepted, 
        /// the suggested configuration is returned.
        /// If the config is null, this means that the parameters are not accepted in any way.
        /// </summary>
        /// <param name="parameters">The parameters suggested.</param>
        /// <param name="config">The alternative config suggested by the operator.</param>
        /// <returns>True if the parameters are accepted as is.</returns>
        public override bool SuggestParameters(ExpressionItem[] parameters, out OperatorConfiguration config)
        {
            bool result = base.SuggestParameters(parameters, out config);
            if (result)
            {
                if (parameters.Length == 2 && parameters[0] is OperatorItem)
                {
                    config = configs[1];
                    return false;
                }
                else if (parameters.Length == 1 && parameters[0] is OperatorItem)
                {
                    config = null;
                    return false;
                }
            }
            return result;
        }
    }
}
