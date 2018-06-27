using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jKalc.Parser;

namespace jKalc.Tokenizer
{
    /// <summary>
    /// A token containing a text string which is parsable as a double.
    /// </summary>
    class DoubleToken:Token
    {
        internal DoubleToken(string doubleText)
        {
            text = doubleText;
        }

        public override string ToString()
        {
            return "DoubleToken: " + text;
        }

        /// <summary>
        /// Returns an expression item with the value of this token's text's value.
        /// </summary>
        /// <returns></returns>
        public override ExpressionItem GetExpressionItem()
        {
            string[] parts = new string[4];

            //Find the positions of the different separators.
            int pointSeparatorIdx = text.IndexOf(".");
            int exponentSeparatorIdx = text.IndexOf("e", StringComparison.OrdinalIgnoreCase);
            int plusSeparatorIdx = text.IndexOf("+");
            int minusSeparatorIdx = text.IndexOf("-");
            int exponentIdx = Math.Max(Math.Max(exponentSeparatorIdx, plusSeparatorIdx), minusSeparatorIdx);

            //Find the substrings separated by the various separators.
            //If the index of a separator is lower than zero, the separator was not found.

            //Find the exponent
            if(exponentIdx >0)
            {
                parts[3] = text.Substring(exponentIdx+1);
            }
            else
            {
                parts[3] = "";
            }

            //Find the sign of the exponent
            if (plusSeparatorIdx > 0)
            {
                parts[2] = "+";
            }
            else if (minusSeparatorIdx > 0)
            {
                parts[2] = "-";
            }
            else
            {
                parts[2] = "";
            }

            //Find the integer part of the double
            if(pointSeparatorIdx>-1)
            {
                parts[0] = text.Substring(0, pointSeparatorIdx);
            }
            else if (exponentSeparatorIdx > -1)
            {
                parts[0] = text.Substring(0, exponentSeparatorIdx);
            }
            else
            {
                parts[0] = text;
            }

            //Find the decimal part of the double
            if (pointSeparatorIdx > -1 && exponentSeparatorIdx > 0)
            {
                parts[1] = text.Substring(pointSeparatorIdx + 1, exponentSeparatorIdx - pointSeparatorIdx - 1);
            }
            else if (pointSeparatorIdx > -1)
            {
                parts[1] = text.Substring(pointSeparatorIdx + 1);
            }
            else
            {
                parts[1] = "";
            }

            //Parse the different parts of the double
            return new DoubleItem(Parse(parts));
        }

        /// <summary>
        /// Parses the integer part, the decimal part, the sign of the exponent and the exponent of the double token.
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        private double Parse(string[] parts)
        {
            double result = 0;

            //Parse the integer part
            if (!String.IsNullOrEmpty(parts[0]))
            {
                result += Parse(parts[0]);
            }

            //Parse the decimal part
            if (!String.IsNullOrEmpty(parts[1]))
            {
                int decimalPlaces = parts[1].Length;
                result += Parse(parts[1]) * Math.Pow(10, -decimalPlaces);
            }

            //Parse the exponent and negate it if preceded by minus sign.
            if (!String.IsNullOrEmpty(parts[3]))
            {
                double exponent = Parse(parts[3]);

                if(parts[2].Equals("-"))
                {
                    exponent = -exponent;
                }

                result *= Math.Pow(10,exponent);
            }

            return result;
        }

        /// <summary>
        /// Parses a string that represents an integer.
        /// </summary>
        /// <param name="doubleValue"></param>
        /// <returns></returns>
        private double Parse(string doubleValue)
        {
            return double.Parse(doubleValue);
        }

    }
}
