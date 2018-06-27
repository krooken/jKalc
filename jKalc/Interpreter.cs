using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;

namespace jKalc
{
    /// <summary>
    /// An object that parses and evaluates an expression.
    /// </summary>
    public class Interpreter
    {
        private List<ExpressionItem> expression;
        private List<ExpressionItem> scannedItems = new List<ExpressionItem>();
        private int pointer = 0;

        /// <summary>
        /// Creates an interpreter and associates it with the given expression string.
        /// </summary>
        /// <param name="expression">The string to interpret.</param>
        public Interpreter(List<ExpressionItem> expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Parses the expression string. If the expression is well-formed
        /// a tree will be constructed and the top node of the tree is returned.
        /// </summary>
        /// <returns>The top node of the tree.</returns>
        public ExpressionItem Interpret()
        {
            ExpressionItem topNode = NextItem();

            //Inserts the first node into the tree.
            //This has to be managed separatly.
            if (topNode is OperatorItem)
            {
                //Find out the accepted configurations of the item to add.
                OperatorConfiguration[] configs = ((OperatorItem)topNode).AcceptedConfigurations;
                //The only valid config is a unary operator with the data on the right.
                OperatorConfiguration config = new OperatorConfiguration(Associativity.left, 1);

                //Find out whether the operator may have the only possible config
                bool result = false;
                for (int i = 0; i < configs.Length; i++)
                {
                    if (config.Equals(configs[i]))
                    {
                        //A valid configuration is found.
                        //Indicate success and tell the operator which configuration it is in.
                        result = true;
                        ((OperatorItem)topNode).Configuration = configs[i];
                        break;
                    }
                }
                if (!result)
                {
                    throw new Exception("Interpreter.Interpret(): Malformed expression");
                }
                //Fill all the parameter places of the top node to acquire a valid expression.
                FillParameters(topNode);
            }

            //As long as there exists more items in the expression,
            //add the next item to the tree.
            while (HasNext())
            {
                AddNextToTree(ref topNode);
            }

            return topNode;
        }

        /// <summary>
        /// Takes an operator and fills the right hand side parameters recurively to form an valid expression.
        /// </summary>
        /// <param name="item">An operator to fill.</param>
        private void FillParameters(ExpressionItem item)
        {
            //If the item is already valid, return.
            if (item.IsValid())
            {
                return;
            }
            //Find the NextItem item
            ExpressionItem next = NextItem();
            //If the next item is an operator,
            //check if the operator accepts the only valid config and check whether the
            //supplied parameters are accepted.
            if (next is OperatorItem)
            {
                OperatorConfiguration[] configs = ((OperatorItem)next).AcceptedConfigurations;
                OperatorConfiguration config = new OperatorConfiguration(Associativity.left, 1);
                bool result = false;
                for (int i = 0; i < configs.Length; i++)
                {
                    ExpressionItem rightParam = Peek();
                    ExpressionItem[] param = new ExpressionItem[1];
                    param[0] = rightParam;
                    OperatorConfiguration oc;
                    if (config.Equals(configs[i]) && ((OperatorItem)next).SuggestParameters(param,out oc))
                    {
                        //The operator accepts the parameters and config which it is given
                        result = true;
                        ((OperatorItem)next).Configuration = configs[i];
                        break;
                    }
                }
                if (!result)
                {
                    //The operator can't be used in the way supplied
                    throw new Exception("Interpreter.FillParameters: Malformed expression");
                }
                //Fill the parameters of the new operator recursively
                FillParameters(next);
            }

            //Add the next item as a parameter to the operator.
            ((FunctionItem)item).AddParameter(next);
        }

        /// <summary>
        /// Add the next item to the expression tree.
        /// </summary>
        /// <param name="topNode">The top node of the tree.</param>
        private void AddNextToTree(ref ExpressionItem topNode)
        {
            //Get the next item. If the next item is an operator,
            //find the possible configurations and try to add it to the tree.
            ExpressionItem next = NextItem();
            if (next is OperatorItem && HasNext())
            {
                int nrOfParameters = 2;
                OperatorConfiguration[] configs = ((OperatorItem)next).AcceptedConfigurations;
                OperatorConfiguration oc;
                ExpressionItem rightParam = Peek();
                ExpressionItem leftParam = scannedItems[scannedItems.Count - 2];
                ExpressionItem[] param = new ExpressionItem[nrOfParameters];
                param[0] = leftParam;
                param[1] = rightParam;
                bool result = false;
                //Find the correct configuration.
                for (int i = 0; i < configs.Length; i++)
                {
                    if (configs[i].NrOfParameters == nrOfParameters && ((OperatorItem)next).SuggestParameters(param,out oc))
                    {
                        ((OperatorItem)next).Configuration = configs[i];
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    //The parameters were accepted as is and the item can be addd to the tree.
                    AddToTree(ref topNode, next);
                }
                else
                {
                    //The parameters were not accepted, negotiate config.
                    Negotiate(ref topNode, next, param);
                }
            }
                //The current item is an operator, but no items to the right of it.
                //Try to add it as unary operator.
            else if (next is OperatorItem)
            {
                int nrOfParameters = 1;
                OperatorConfiguration[] configs = ((OperatorItem)next).AcceptedConfigurations;
                OperatorConfiguration config = new OperatorConfiguration(Associativity.right, 1);
                OperatorConfiguration oc;
                ExpressionItem leftParam = scannedItems[scannedItems.Count - 2];
                ExpressionItem[] param = new ExpressionItem[nrOfParameters];
                param[0] = leftParam;
                bool result = false;
                for (int i = 0; i < configs.Length; i++)
                {
                    if (configs[i].Equals(config) && ((OperatorItem)next).SuggestParameters(param, out oc))
                    {
                        //The configuration were accepted
                        ((OperatorItem)next).Configuration = configs[i];
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    //Add the opeartor to the tree
                    AddToTree(ref topNode, next);
                }
                else
                {
                    //The operator wouldn't accept to be unary, throw exception
                    throw new Exception("Interpreter.AddNextToTree()1: Cannot form expression");
                }
            }
            else
            {
                //The next item is not an operator,
                //the tree is valid, but the next item can't be linked to the tree.
                throw new Exception("Interpreter.AddNextToTree()2: Cannot form expression");
            }
        }

        /// <summary>
        /// Negotiates recursively with the operator which parameter configuration to use.
        /// The operator suggest a config and the interpreter tries to find parameters.
        /// If it fails, this function is called again with new parameters.
        /// </summary>
        /// <param name="topNode">The top node in the tree.</param>
        /// <param name="next">The operator to negotiate with.</param>
        /// <param name="param">the suggested parameters.</param>
        private void Negotiate(ref ExpressionItem topNode, ExpressionItem next, ExpressionItem[] param)
        {
            OperatorConfiguration config;
            //The suggested parameters are accepted.
            //Add the operator to the tree.
            if (((OperatorItem)next).SuggestParameters(param,out config))
            {
                AddToTree(ref topNode, next);
            }
            else if (config != null)
            {
                //If the operator suggests a valid config
                //try to supply better parameters.
                if (config.NrOfParameters == 1 && config.Associativity == Associativity.left)
                {
                    //The operator is unary with the operator to the left.
                    //Suggest the right parameter and continue to negotiate.
                    ExpressionItem[] param1 = new ExpressionItem[1];
                    param1[0] = param[1];
                    Negotiate(ref topNode, next, param1);
                }
                else if (config.NrOfParameters == 1)
                {
                    //The operator is unary with the operator to the right.
                    //Suggest the left parameter and continue to negotiate.
                    ExpressionItem[] param1 = new ExpressionItem[1];
                    param1[0] = param[0];
                    Negotiate(ref topNode, next, param1);
                }
                else
                {
                    //Suggest one less parameter. Only used when the operator is ternary or more.
                    ExpressionItem[] param1 = new ExpressionItem[config.NrOfParameters];
                    for (int i = 0; i < param1.Length; i++)
                    {
                        param1[i] = param[i];
                    }
                    Negotiate(ref topNode, next, param1);
                }
            }
            else
            {
                //The operator didn't accept the parameters,
                //and has no alternative.
                throw new Exception("Interpreter.Negotiate(): MalformedExpression");
            }
        }

        /// <summary>
        /// Adds the supplied operator to the tree.
        /// The operator is added according to precedence and associativity.
        /// </summary>
        /// <param name="topNode">The top node of the tree.</param>
        /// <param name="next">The operator to add.</param>
        private void AddToTree(ref ExpressionItem topNode, ExpressionItem next)
        {
            if (topNode is OperatorItem)
            {
                OperatorItem currentNode = (OperatorItem)topNode;
                if (currentNode.Configuration.Precedence < ((OperatorItem)next).Configuration.Precedence
                    || (currentNode.Configuration.Precedence == ((OperatorItem)next).Configuration.Precedence
                    && ((OperatorItem)next).Configuration.Associativity == Associativity.left))
                {
                    //The top node has lower precedence, or the new operator has left associativity:
                    //add it as top node and add the current tree as left parameter.
                    ((OperatorItem)next).AddParameter(currentNode);
                    topNode = next;
                }
                else if (((OperatorItem)next).Configuration.Associativity == Associativity.left)
                {
                    //The new operator has associativity left.
                    //Find the first node with same precedence and add the new operator at that position
                    //with the found node as left parameter.
                    ExpressionItem child = currentNode.Parameters[currentNode.Parameters.Length - 1];
                    while (child is OperatorItem &&
                        ((OperatorItem)child).Configuration.Precedence > ((OperatorItem)next).Configuration.Precedence)
                    {
                        currentNode = (OperatorItem)child;
                        child = currentNode.Parameters[currentNode.Parameters.Length - 1];
                    }
                    ExpressionItem[] currentParams = currentNode.Parameters;
                    currentNode.RemoveParameters();
                    ((OperatorItem)next).AddParameter(currentParams[currentParams.Length - 1]);
                    currentParams[currentParams.Length - 1] = next;
                    currentNode.AddParameterRange(currentParams);
                }
                else if (((OperatorItem)next).Configuration.Associativity == Associativity.right)
                {
                    //The new node has right associativity.
                    //find the first node with lower precedence and add the new operator at that position
                    //with the found node as left parameter.
                    ExpressionItem child = currentNode.Parameters[currentNode.Parameters.Length - 1];
                    while (child is OperatorItem &&
                        ((OperatorItem)child).Configuration.Precedence >= ((OperatorItem)next).Configuration.Precedence)
                    {
                        currentNode = (OperatorItem)child;
                        child = currentNode.Parameters[currentNode.Parameters.Length - 1];
                    }
                    ExpressionItem[] currentParams = currentNode.Parameters;
                    currentNode.RemoveParameters();
                    ((OperatorItem)next).AddParameter(currentParams[currentParams.Length - 1]);
                    currentParams[currentParams.Length - 1] = next;
                    currentNode.AddParameterRange(currentParams);
                }
            }
            else
            {
                //The next item isn't an operator. This case will not be used.
                ((OperatorItem)next).AddParameter(topNode);
                topNode = next;
            }
            //Fill the right hand side of the new operator.
            FillParameters(next);
        }

        /// <summary>
        /// Returns the next item in the expression list.
        /// Increases the pointer to the next item.
        /// </summary>
        /// <returns></returns>
        private ExpressionItem NextItem()
        {
            for (int i = pointer; i < expression.Count; i++)
            {
                if (expression[i].HasValue())
                {
                    scannedItems.Add(expression[i]);
                    pointer = i + 1;
                    return expression[i];
                }
            }
            throw new Exception("Interpreter.NextItem(): No items left!");
        }

        /// <summary>
        /// Returns the next item in the expression list without increasing the pointer.
        /// </summary>
        /// <returns></returns>
        private ExpressionItem Peek()
        {
            for (int i = pointer; i < expression.Count; i++)
            {
                if (expression[i].HasValue())
                {
                    return expression[i];
                }
            }
            throw new Exception("Interpreter.Peek(): No items left!");
        }

        /// <summary>
        /// Checks whether there are a next item in the expression list.
        /// </summary>
        /// <returns></returns>
        private bool HasNext()
        {
            try
            {
                Peek();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
