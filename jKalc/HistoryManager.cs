using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace jKalc
{
    /// <summary>
    /// Manages the command history.
    /// </summary>
    public class HistoryManager
    {
        //The list of historic commands.
        private List<string> historyList = new List<string>();
        private const string HISTORY_FILE_NAME = "history.txt";
        private const string HISTORY_FILE_PATH = "History\\";

        /// <summary>
        /// Creates a new history manager and loads the history from file.
        /// </summary>
        public HistoryManager()
        {
            LoadHistory();
        }

        /// <summary>
        /// Loads the history from file.
        /// </summary>
        public void LoadHistory()
        {
            //Get the saved history
            string fileContents = GetStoredHistory();
            string[] delimiters = { Environment.NewLine };

            //Split the file contents into an array
            string[] historyItems = fileContents.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Add the lines of the file to the list of historic commands.
            historyList.Clear();
            historyList.AddRange(historyItems);
        }

        /// <summary>
        /// Acquire the file contents of the stored history file.
        /// </summary>
        /// <returns>A string with all the file contents.</returns>
        private string GetStoredHistory()
        {
            //Create the history directory if non-existent
            if(!Directory.Exists(HISTORY_FILE_PATH))
            {
                Directory.CreateDirectory(HISTORY_FILE_PATH);
            }

            //Create the history file if non-existent
            if(!File.Exists(HISTORY_FILE_PATH + HISTORY_FILE_NAME))
            {
                File.CreateText(HISTORY_FILE_PATH + HISTORY_FILE_NAME).Close();
            }
            
            //Read all text from the file and return
            return File.ReadAllText(HISTORY_FILE_PATH+HISTORY_FILE_NAME);
        }

        /// <summary>
        /// Return an array of all contents in the history list.
        /// </summary>
        public string[] HistoryList
        {
            get
            {
                return historyList.ToArray();
            }
        }

        /// <summary>
        /// Adds a command to the history list.
        /// </summary>
        /// <param name="historyItem">The command to add.</param>
        public void Add(string historyItem)
        {
            if(String.IsNullOrWhiteSpace(historyItem))
                throw new Exception("Illegal argument exception");

            historyList.Add(historyItem);
        }

        /// <summary>
        /// Returns the command at the given position in the history.
        /// </summary>
        /// <param name="index">The index of the command.</param>
        /// <returns>The command.</returns>
        public string GetHistory(int index)
        {
            return historyList.ElementAt(index);
        }

        /// <summary>
        /// Returns all the history as a string, where all items are separated by a new line.
        /// </summary>
        /// <returns>A string with all history.</returns>
        public string GetHistory()
        {
            string result = "";
            string[] array = HistoryList;

            for (int i = 0; i < array.Length; i++)
            {
                if(!String.IsNullOrWhiteSpace(array[i]))
                    result += array[i] + Environment.NewLine;
            }

            return result;
        }

        /// <summary>
        /// Save the history list to the history file.
        /// </summary>
        public void SaveHistory()
        {
            File.WriteAllText(HISTORY_FILE_PATH + HISTORY_FILE_NAME, GetHistory());
        }
    }
}
