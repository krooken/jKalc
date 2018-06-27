using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// An ExpressionItem that represents a function.
    /// A function has parameters.
    /// Should not be initiated as is.
    /// </summary>
    public class FunctionItem:ExpressionItem,ICloneable
    {
        /// <summary>
        /// A list of all the parameters, from left to right.
        /// </summary>
        protected List<ExpressionItem> parameters = new List<ExpressionItem>();

        internal FunctionItem()
        {
        }

        public override double Value
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Adds a parameter to the right.
        /// </summary>
        /// <param name="parameter">A parameter to add.</param>
        internal protected void AddParameter(ExpressionItem parameter)
        {
            parameters.Add(parameter);
        }

        /// <summary>
        /// Sets an array of ExpressionItems as parameters.
        /// </summary>
        /// <param name="parameters">An array of parameters.</param>
        internal protected void AddParameterRange(ExpressionItem[] parameters)
        {
            this.parameters.AddRange(parameters);
        }

        /// <summary>
        /// Removes all the parameters.
        /// </summary>
        internal protected void RemoveParameters()
        {
            parameters = new List<ExpressionItem>();
        }

        /// <summary>
        /// Returns an array of all the parameters.
        /// </summary>
        public ExpressionItem[] Parameters
        {
            get { return parameters.ToArray(); }
        }

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }

        public virtual bool SuggestParameters(ExpressionItem[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
