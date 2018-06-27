using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// Describes how an operator can be used. Defines the associativity, number of parameters
    /// and precedence of the operator.
    /// </summary>
    public class OperatorConfiguration
    {
        private Associativity associativity;
        private int nrOfParameters;
        private double precedence;

        /// <summary>
        /// Creates an operator config with the given number of parameters and associativity.
        /// Should only be used as comparison.
        /// Don't supply this config to an operator since it lacks the precedence information.
        /// </summary>
        /// <param name="associativity"></param>
        /// <param name="nrOfParameters"></param>
        internal OperatorConfiguration(Associativity associativity, int nrOfParameters):this(associativity,nrOfParameters,0)
        { }

        /// <summary>
        /// Creates an operator config with the given number of parameters, associativity
        /// and precedence..
        /// </summary>
        /// <param name="associativity"></param>
        /// <param name="nrOfParameters"></param>
        /// <param name="precedence"></param>
        internal OperatorConfiguration(Associativity associativity, int nrOfParameters, double precedence)
        {
            this.associativity = associativity;
            this.nrOfParameters = nrOfParameters;
            this.precedence = precedence;
        }

        /// <summary>
        /// Returns the associativity.
        /// </summary>
        internal Associativity Associativity
        {
            get { return this.associativity; }
        }

        /// <summary>
        /// Returns the number of parameters.
        /// </summary>
        internal int NrOfParameters
        {
            get { return nrOfParameters; }
        }

        /// <summary>
        /// Returns the precedence.
        /// </summary>
        internal double Precedence
        {
            get { return precedence; }
        }

        /// <summary>
        /// Returns true if both configurations have the same number of parameters and associativity.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public bool Equals(OperatorConfiguration config)
        {
            return this.associativity == config.associativity && this.nrOfParameters == config.nrOfParameters;
        }
    }
}
