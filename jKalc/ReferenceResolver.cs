using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;

namespace jKalc
{
    /// <summary>
    /// Class that manages all references.
    /// Contains all variables and functions that can be used in the calculator.
    /// </summary>
    public class ReferenceResolver
    {
        private Dictionary<string, VariableItem> variableList = new Dictionary<string, VariableItem>();
        private Dictionary<string, FunctionItem> functionList = new Dictionary<string, FunctionItem>();
        private static ReferenceResolver resolver = null;

        /// <summary>
        /// Returns the resolver.
        /// There can only be one resolver at any given time.
        /// All calls to this function returns the same resolver.
        /// </summary>
        /// <returns>The current reference resolver.</returns>
        public static ReferenceResolver GetResolver()
        {
            if (resolver == null)
            {
                resolver = new ReferenceResolver();
            }
            return resolver;
        }

        /// <summary>
        /// Constructs a resolver.
        /// </summary>
        private ReferenceResolver()
        {
            //Adds the functions that are supported.
            functionList.Add("+", new PlusOperatorItem());
            functionList.Add("-", new MinusOperatorItem());
            functionList.Add("*", new TimesOperatorItem());
            functionList.Add("/", new DivideOperatorItem());
            functionList.Add("=", new AssignmentOperatorItem());
        }

        /// <summary>
        /// Returns the variable with the specified name.
        /// </summary>
        /// <param name="variableName">The variable name which to return.</param>
        /// <returns>The named variable.</returns>
        public VariableItem GetVariable(string variableName)
        {
            VariableItem item;
            if (!variableList.TryGetValue(variableName, out item))
            {
                item = new VariableItem(variableName);
                variableList.Add(variableName, item);
            }
            
            return item;
        }

        /// <summary>
        /// Returns the reference that matches the provided string. First the variables are searched, then the functions. 
        /// If no reference are found that matches the name, a new variable is retruned.
        /// </summary>
        /// <param name="referenceName">The reference name to search for.</param>
        /// <returns>The mentioned reference.</returns>
        public ExpressionItem GetReference(string referenceName)
        {
            VariableItem varItem;
            FunctionItem funItem;
            //try to find a variable that matches the name.
            if (variableList.TryGetValue(referenceName, out varItem))
            {
                return varItem;
            }
            //Try to find a function that matches the name.
            else if(functionList.TryGetValue(referenceName,out funItem))
            {
                return (FunctionItem)funItem.Clone();
            }

            //No matches
            //Create new variable and return it.
            varItem = new VariableItem(referenceName);
            variableList.Add(referenceName, varItem);

            return varItem;
        }

        /// <summary>
        /// Returns all variables in an array.
        /// </summary>
        public VariableItem[] Variables
        {
            get
            {
                //Remove the uninitialized variables first. They are not interesting at this point.
                RemoveUninitialized();
                return variableList.Values.ToArray();
            }
        }

        /// <summary>
        /// Remove all variables that are nor initialized.
        /// Variables that havn't been assigned a value are considered uninitialized.
        /// </summary>
        private void RemoveUninitialized()
        {
            List<string> uninitializedKeys = new List<string>();
            string[] keys = variableList.Keys.ToArray();
            //Loop the varialbe list and get the names of the uninitialized variables.
            for(int i=0; i<keys.Length; i++)
            {
                if(!variableList[keys[i]].Initialized)
                {
                    uninitializedKeys.Add(keys[i]);
                }
            }

            //Remove them from the list of variables.
            keys = uninitializedKeys.ToArray();
            for(int i=0; i<keys.Length; i++)
            {
                variableList.Remove(keys[i]);
            }
        }
    }
}
