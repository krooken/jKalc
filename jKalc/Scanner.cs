using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jKalc
{
    /// <summary>
    /// A class that scans tokens in a string.
    /// Tokens are separated by the supplied delimiter.
    /// If the delimiter is null, each item in the string is considered a token.
    /// </summary>
    public class Scanner
    {
        private string text;
        private int pointer;
        private string delimiter;

        /// <summary>
        /// Constructs a scanner with the given text, that uses null as delimiter.
        /// </summary>
        /// <param name="text">The text to scan.</param>
        public Scanner(string text):this(text,null)
        {

        }

        /// <summary>
        /// Creates a scanner with the given text and delimiter.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delimiter"></param>
        public Scanner(string text, string delimiter)
        {
            if(String.IsNullOrEmpty(text))
            {
                throw new Exception("Scanner cannot operate on no text");
            }

            this.text = text;
            this.delimiter = delimiter;
            pointer = 0;
        }

        /// <summary>
        /// Returns the next token without increasing the pointer.
        /// </summary>
        /// <returns>The next token.</returns>
        public string Peek()
        {
            int oldPointer = pointer;
            string result = Next();
            pointer = oldPointer;
            return result;
        }

        /// <summary>
        /// Returns the next token while increasing the pointer.
        /// </summary>
        /// <returns></returns>
        public string Next()
        {
            string result;
            int count, delimitLength;

            if (delimiter == null)
            {
                count = 1;
                delimitLength = 0;
            }
            else
            {
                //Find the next occurence of the delimiter in the text.
                count = text.IndexOf(delimiter, pointer) - pointer;
                if (count <= 0)
                {
                    count = text.Length - pointer;
                }
                delimitLength = delimiter.Length;
            }
            //Get the substring beginning at the pointer position and ending before the next delimiter.
            result = text.Substring(pointer, count);
            //Advance the pointer to the place after the next delimiter.
            pointer += count + delimitLength;
            return result;
        }

        /// <summary>
        /// Indicates whether the scanner has more text to scan.
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            if (pointer < text.Length)
                return true;
            return false;
        }
    }
}
