using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace jKalc
{
    /// <summary>
    /// A form that manages the file editor window. At construction the FileEditorForm
    /// is connected to a FileEditor which provides the interface for reading and writing to files.
    /// </summary>
    public partial class FileEditorForm : Form
    {
        //The file to edit
        private FileEditor file;

        /// <summary>
        /// Constructs a form with the given file.
        /// </summary>
        /// <param name="file">The file to view or edit.</param>
        public FileEditorForm(FileEditor file)
        {
            InitializeComponent();

            //Save the file and initialize the GUI
            this.file = file;
            InitializeGUI();
        }

        /// <summary>
        /// Initializez the GUI with the file contents.
        /// </summary>
        private void InitializeGUI()
        {
            //Sets the form title to the filename
            Text = file.ToString();

            //Add the file contents to the form.
            txtEditor.Text = file.ReadFileContents().Trim();
        }

        /// <summary>
        /// Event handler for the save button.
        /// Saves the current text in the form to the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Set the systems new line separators and use them to supply an array of strings to the
            //FileEditor's write method.
            string[] separators = {Environment.NewLine};
            string[] fileContents = txtEditor.Text.Split(separators, StringSplitOptions.None);
            file.WriteFileContents(fileContents);
        }

        /// <summary>
        /// Closes the FileEditorForm without saving.
        /// The user is not asked before closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
