using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// The assignment operator.
    /// Can be used as a binary operator.
    /// It is right associative and has precedence 14.
    /// </summary>
    class AssignmentOperatorItem:OperatorItem
    {
        internal AssignmentOperatorItem()
        {
            configs = new OperatorConfiguration[] 
                {new OperatorConfiguration(Associativity.right,2,14)};
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

        /// <summary>
        /// Assigns the right hand value to the variable to the left.
        /// Exceptions will be thrown if the left hand side is not a variable.
        /// </summary>
        /// <returns></returns>
        private double CalculateValue()
        {
            if (!IsValid())
            {
                throw new Exception("The + expression is not valid");
            }

            if (config.Equals(configs[0]))
            {
                parameters[0].Value = parameters[1].Value;
                return parameters.ElementAt(1).Value;
            }
            else
            {
                throw new Exception("The + operator has not got valid parameters");
            }
        }

        public override object Clone()
        {
            return new AssignmentOperatorItem();
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
                if (parameters[0] is VariableItem)
                {
                    config = configs[0];
                    return true;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the variable's name.
        /// </summary>
        internal string VariableName
        {
            get { return parameters[0].ToString(); }
        }
    }
}
