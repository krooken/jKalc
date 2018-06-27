using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace jKalc
{
    /// <summary>
    /// Manages the files where scripts are stored.
    /// Loads files from disk, save files to disk
    /// and deletes them.
    /// </summary>
    public class FileManager
    {
        //The folder and file extension of the script files.
        private static readonly string KALC_FILE_PATH = "KalcFiles\\";
        public static readonly string FILE_NAME_EXT = ".jk";
        //A list of the available script files.
        private List<FileInfo> fileList = new List<FileInfo>();

        /// <summary>
        /// Creates a FileManager and loads all available files.
        /// </summary>
        public FileManager()
        {
            LoadFiles();
        }

        /// <summary>
        /// Loads all script files from the script file folder.
        /// </summary>
        public void LoadFiles()
        {
            //If the folder doesn't exists, create it.
            if (!Directory.Exists(KALC_FILE_PATH))
            {
                Directory.CreateDirectory(KALC_FILE_PATH);
            }
            //Acquire all files in the folder and save them to the file list.
            InitializeFileList(Directory.GetFiles(KALC_FILE_PATH, "*" + FILE_NAME_EXT));
        }

        /// <summary>
        /// Reads all files with the specified names and puts them into the file list.
        /// </summary>
        /// <param name="fileNames">The names of the files to read.</param>
        private void InitializeFileList(string[] fileNames)
        {
            fileList.Clear();

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileList.Add(new FileInfo(fileNames[i]));
            }
        }

        /// <summary>
        /// Returns an array of the file names currently in the manager's file list.
        /// </summary>
        public string[] FileNames
        {
            get
            {
                string[] fileNames = new string[fileList.Count];
                FileInfo[] files = fileList.ToArray();
                for (int i = 0; i < fileList.Count; i++)
                {
                    fileNames[i] = files[i].Name;
                }
                return fileNames;
            }
        }

        /// <summary>
        /// Adds a new file with the specified name to the script folder.
        /// If the file is already existing, an exception is thrown.
        /// </summary>
        /// <param name="fileName">The file name to create.</param>
        /// <returns>A file editor wrapping the created file.</returns>
        public FileEditor NewFile(string fileName)
        {
            //If the file doesn't exists, create it and
            //add it to the file list.
            if (FindFileName(fileName) == null)
            {
                FileInfo file = new FileInfo(KALC_FILE_PATH + fileName);
                file.Create().Close();

                fileList.Add(file);
                return new FileEditor(file);
            }
            //If the file exists, no file should be created
            throw new Exception("File already exists");
        }

        /// <summary>
        /// Requests to edit the given file.
        /// The index corresponds to the indices in the FileNames property.
        /// </summary>
        /// <param name="index">The index of the file to edit.</param>
        /// <returns>A file editor wrapping the file.</returns>
        public FileEditor ChangeFile(int index)
        {
            return new FileEditor(fileList.ElementAt(index));
        }

        /// <summary>
        /// Requests to delete the selected file.
        /// </summary>
        /// <param name="index">The index of the file to delete.</param>
        public void DeleteFile(int index)
        {
            fileList.ElementAt(index).Delete();
            fileList.RemoveAt(index);
        }

        /// <summary>
        /// Deletes all files in the file list.
        /// </summary>
        public void DeleteAllFiles()
        {
            FileInfo[] files = fileList.ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
                fileList.RemoveAt(0);
            }
        }

        /// <summary>
        /// Searches for the specified file name and returns the file on success.
        /// </summary>
        /// <param name="fileName">The file name to find.</param>
        /// <returns>The file if success, otherwise null.</returns>
        public FileEditor FindFileName(string fileName)
        {
            string[] names = FileNames;
            for (int i = 0; i < names.Length; i++)
            {
                if (fileName.Equals(names[i]))
                {
                    return new FileEditor(fileList.ElementAt(i));
                }
            }
            return null;
        }
    }
}
