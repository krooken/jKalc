using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;

namespace jKalc
{
    class ScriptFileEvaluator
    {
        private string scriptFileContents;

        internal ScriptFileEvaluator(string fileContents)
        {
            scriptFileContents = fileContents;
        }

        internal void Evaluate(out List<ExpressionItem> list)
        {
            Scanner scanner = new Scanner(scriptFileContents, Environment.NewLine);
            RowEvaluator rowEvaluator;
            list = new List<ExpressionItem>();

            while (scanner.HasNext())
            {
                rowEvaluator = new RowEvaluator(scanner.Next());
                rowEvaluator.ParseExpression();
                rowEvaluator.InterpretExpression();
                list.Add(rowEvaluator.InterpretedExpression);
            }
        }
    }
}
