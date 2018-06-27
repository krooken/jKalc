using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// Represents an operator.
    /// Do not initiate this.
    /// </summary>
    public class OperatorItem:FunctionItem
    {
        protected OperatorConfiguration config;
        protected OperatorConfiguration[] configs;

        internal OperatorItem()
        {
        }

        /// <summary>
        /// Returns the current configuration.
        /// </summary>
        internal OperatorConfiguration Configuration
        {
            get { return config; }
            set { config = value; }
        }

        /// <summary>
        /// Returns an array of possible configurations for this operator.
        /// </summary>
        internal OperatorConfiguration[] AcceptedConfigurations
        {
            get { return configs.ToArray(); }
        }

        /// <summary>
        /// Returns true if this operator is configured
        /// and all parameters are valid.
        /// </summary>
        /// <returns></returns>
        protected internal override bool IsValid()
        {
            if (config == null)
            {
                throw new Exception("Operator is not configured");
            }

            bool valid = true;

            for (int i = 0; i < config.NrOfParameters; i++)
            {
                try
                {
                    valid &= parameters.ElementAt(i).IsValid();
                }
                catch (Exception)
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }

        /// <summary>
        /// Clones this object.
        /// </summary>
        /// <returns>A new operator of this type.</returns>
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override bool SuggestParameters(ExpressionItem[] parameters)
        {
            OperatorConfiguration oc;
            return SuggestParameters(parameters,out oc);
        }

        /// <summary>
        /// Returns true if the suggested parameters match a configuration.
        /// That configuration is returned.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public virtual bool SuggestParameters(ExpressionItem[] parameters, out OperatorConfiguration config)
        {
            for (int i = 0; i < configs.Length; i++)
            {
                if (parameters.Length == configs[i].NrOfParameters)
                {
                    config = configs[i];
                    return true;
                }
            }
            config = null;
            return false;
        }
    }
}
