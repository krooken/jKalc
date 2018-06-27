using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc;

namespace HistoryManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HistoryManager hm = new HistoryManager();

            Console.WriteLine(hm.GetHistory());

            try
            {
                hm.Add("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                hm.Add(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                hm.Add("23+54");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(GetArrayAsString(hm.HistoryList));

            Console.WriteLine();

            Console.WriteLine(hm.GetHistory(0));

            Console.WriteLine();

            hm.Add("9*294");

            Console.WriteLine(hm.GetHistory());

            Console.Read();

            hm.SaveHistory();
        }

        static string GetArrayAsString(string[] array)
        {
            string result = "";

            for (int i = 0; i < array.Length; i++)
                result += array[i] + "\n";

            return result;
        }
    }
}
