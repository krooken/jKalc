using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc.Parser
{
    /// <summary>
    /// Represents a variable.
    /// Instantiated and acwuired from the reference resolver.
    /// </summary>
    public class VariableItem:ExpressionItem
    {
        protected double value;
        private bool initialized = false;
        private string name;

        internal VariableItem(string name)
        {
            this.name = name;
            this.value = 0.0;
        }

        /// <summary>
        /// Returns the variable's value if it is initiated.
        /// Sets the value and initiates it.
        /// </summary>
        public override double Value
        {
            get
            {
                if (!initialized)
                {
                    throw new Exception(String.Format("This variable '{0}' has not been initialized, and contains no value",ToString()));
                }
                return value;
            }
            set 
            { 
                this.value = value;
                initialized = true;
            }
        }

        /// <summary>
        /// Returns true if the varaible has been given a value.
        /// </summary>
        internal bool Initialized
        {
            get { return initialized; }
        }

        /// <summary>
        /// returns true.
        /// </summary>
        /// <returns></returns>
        internal protected override bool IsValid()
        {
            return true;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
