using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc;

namespace FileManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testLines = { "12 + 23", "23*34", "34-45", "45/56" };
            string[] testLines1 = { "56+67", "67*78", "", "89/90" };

            FileManager fm = new FileManager();
            Console.WriteLine(FormatArray(fm.FileNames));

            fm.NewFile("Jonas.jk").WriteFileContents(testLines);
            fm.NewFile("Krook.jk").WriteFileContents(testLines);
            fm.NewFile("Add.jk").WriteFileContents(testLines);
            fm.NewFile("Exp.jk").WriteFileContents(testLines);
            fm.NewFile("Trigonometry.jk").WriteFileContents(testLines);

            Console.WriteLine(FormatArray(fm.FileNames));

            fm.ChangeFile(2);

            Console.WriteLine(FormatArray(fm.FileNames));

            fm.DeleteFile(0);

            Console.WriteLine(FormatArray(fm.FileNames));

            fm.ChangeFile(1).WriteFileContents(testLines1);

            Console.WriteLine(fm.ChangeFile(1).ReadFileContents());

            Console.WriteLine(fm.ChangeFile(1));

            Console.Read();

            fm.DeleteAllFiles();
        }

        static string FormatArray(string[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + Environment.NewLine;
            }
            return result;
        }
    }
}
