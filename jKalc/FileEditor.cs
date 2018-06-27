using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace jKalc
{
    /// <summary>
    /// Manages edits of files. The FileEditor Form uses this class to edit and read file contents.
    /// </summary>

    public class FileEditor
    {
        //The file wrapped by this object
        private FileInfo file;

        /// <summary>
        /// Constructs a file editor for the given file.
        /// </summary>
        /// <param name="file">The file to edit.</param>
        public FileEditor(FileInfo file)
        {
            this.file = file;
        }

        /// <summary>
        /// Reads all contents in the wrapped file and returns it as a string.
        /// </summary>
        /// <returns>The string content of the file.</returns>
        public string ReadFileContents()
        {
            //Acquire an input stream to read file contents and read all text.
            StreamReader sr = file.OpenText();
            string result = sr.ReadToEnd();
            sr.Close();

            return result;
        }

        /// <summary>
        /// Writes the strings in the given array as separate lines to the file.
        /// </summary>
        /// <param name="content">An array of strings to write to the file.</param>
        public void WriteFileContents(string[] content)
        {
            //Acquire an output stream to the file
            StreamWriter sw = file.CreateText();

            //Loop over the array and write each item as a separate string to the file
            for (int i = 0; i < content.Length; i++)
            {
                sw.WriteLine(content[i]);
            }
            sw.Close();
        }

        /// <summary>
        /// Returns a string representation of the current file.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return file.Name;
        }
    }
}
