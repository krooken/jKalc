using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc;
using jKalc.Tokenizer;
using jKalc.Parser;

namespace TokenizerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner sc;
            try
            {
                sc = new Scanner(null);
                Console.WriteLine("Fail");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            sc = new Scanner("Hej på dig min lilla vän","ll");

            while (sc.HasNext())
            {
                Console.WriteLine(sc.Peek());
                Console.WriteLine(sc.Next());
            }

            string testString = "hej123   34uie 12 87.23e+45 .23 34E-100 .9E32 +-*/";
            Console.WriteLine(testString);
            Scanner sc0 = new Scanner(testString);

            State state;
            List<Token> tokenList = new List<Token>();

            while (sc0.HasNext())
            {
                state = new Q0State(sc0);

                while (!state.IsComplete())
                {
                    state = state.Next();
                }

                tokenList.Add(state.Token);
            }

            ReferenceResolver resolver = ReferenceResolver.GetResolver();
            VariableItem item = resolver.GetVariable("hej123");
            item.Value = 123456789;
            VariableItem[] items = resolver.Variables;

            List<ExpressionItem> itemList = new List<ExpressionItem>();

            for(int i=0; i<tokenList.Count; i++)
            {
                Console.WriteLine(tokenList.ElementAt(i));
                itemList.Add(tokenList.ElementAt(i).GetExpressionItem());
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < itemList.Count; i++)
            {
                try
                {
                    Console.WriteLine(itemList.ElementAt(i).Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            items = resolver.Variables;

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i].Value);
            }

            string expressionString = "1+2*-variable";

            Console.WriteLine(expressionString);
            Scanner sc1 = new Scanner(expressionString);

            State state1;
            List<Token> tokenList1 = new List<Token>();

            while (sc1.HasNext())
            {
                state1 = new Q0State(sc1);

                while (!state1.IsComplete())
                {
                    state1 = state1.Next();
                }

                tokenList1.Add(state1.Token);
            }

            List<ExpressionItem> itemList1 = new List<ExpressionItem>();

            for (int i = 0; i < tokenList1.Count; i++)
            {
                Console.WriteLine(tokenList1.ElementAt(i));
                itemList1.Add(tokenList1.ElementAt(i).GetExpressionItem());
            }

            Interpreter interpreter = new Interpreter(itemList1);
            ExpressionItem item1;
            try
            {
                item1 = interpreter.Interpret();
                Console.WriteLine(item1.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }
            Console.Read();
        }
    }
}
