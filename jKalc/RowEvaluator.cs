using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;
using jKalc.Tokenizer;

namespace jKalc
{
    /// <summary>
    /// Evaluates an expression row.
    /// </summary>
    class RowEvaluator
    {
        private string rawExpression;
        private List<ExpressionItem> parsedExpression;
        private ExpressionItem interpretedExpression;

        /// <summary>
        /// Creates a row evaluator that should evaluate the given expression.
        /// </summary>
        /// <param name="expression">An expression to evaluate.</param>
        internal RowEvaluator(string expression)
        {
            rawExpression = expression;
        }

        /// <summary>
        /// Parses the given expression string to a list of expression items.
        /// </summary>
        internal void ParseExpression()
        {
            Scanner scanner = new Scanner(rawExpression);

            State state;
            parsedExpression = new List<ExpressionItem>();

            //Parse until the expression string has no more tokens.
            while(scanner.HasNext())
            {
                state = new Q0State(scanner);

                while(!state.IsComplete())
                {
                    state = state.Next();
                }
                parsedExpression.Add(state.Token.GetExpressionItem());
            }
        }

        /// <summary>
        /// Interprets the parsed expression list.
        /// </summary>
        internal void InterpretExpression()
        {
            //Create an interpreter and construct a tree of the expression list.
            Interpreter interpreter = new Interpreter(parsedExpression);
            
            interpretedExpression = interpreter.Interpret();
        }

        /// <summary>
        /// Returns the parsed expression list.
        /// </summary>
        internal List<ExpressionItem> ParsedExpression
        {
            get { return parsedExpression; }
        }

        /// <summary>
        /// Returns the top node of the interpreted expression.
        /// </summary>
        internal ExpressionItem InterpretedExpression
        {
            get { return interpretedExpression; }
        }

        /// <summary>
        /// Returns the calculated value of the expression tree.
        /// </summary>
        internal double Value
        {
            get { return interpretedExpression.Value; }
        }
    }
}
