using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jKalc.Parser;

namespace jKalc
{
    /// <summary>
    /// The main form of the application. 
    /// </summary>
    public partial class MainForm : Form
    {

        private FileManager fm;
        private HistoryManager hm;
        private ReferenceResolver resolver;

        /// <summary>
        /// Constructs the main form and initializes the GUI.
        /// The relevant helper classes are initiated.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            fm = new FileManager();
            hm = new HistoryManager();
            resolver = ReferenceResolver.GetResolver();

            InitializeGUI();
        }

        /// <summary>
        /// Initiates the GUI to remove design time data.
        /// </summary>
        private void InitializeGUI()
        {
            lstFiles.Items.Clear();
            lstResultList.Items.Clear();
            lstVariables.Items.Clear();
            lstCommandHistory.Items.Clear();
            txtExpressionInput.Text = "";

            UpdateGUI();
        }

        /// <summary>
        /// Updates the GUI to show the current state of files, variables and history.
        /// </summary>
        private void UpdateGUI()
        {
            UpdateButtons();

            UpdateFileList();

            UpdateHistory();

            UpdateVariableList();
        }

        /// <summary>
        /// Updates the state of the buttons. If no file is selected the change and delete buttons mustn't be enabled.
        /// </summary>
        private void UpdateButtons()
        {

            int fileIndex = lstFiles.SelectedIndex;

            if (fileIndex == System.Windows.Forms.ListBox.NoMatches)
            {
                btnChangeFile.Enabled = false;
                btnDeleteFile.Enabled = false;
            }
            else
            {
                btnChangeFile.Enabled = true;
                btnDeleteFile.Enabled = true;
            }
        }

        /// <summary>
        /// Asks the FileManager of the available files and adds the names to the file list.
        /// </summary>
        private void UpdateFileList()
        {
            fm.LoadFiles();

            lstFiles.Items.Clear();
            lstFiles.Items.AddRange(fm.FileNames);
        }

        /// <summary>
        /// Asks the HistoryManager of the history list
        /// and updates it.
        /// </summary>
        private void UpdateHistory()
        {
            lstCommandHistory.Items.Clear();
            lstCommandHistory.Items.AddRange(hm.HistoryList);

            lstCommandHistory.SelectedIndex = lstCommandHistory.Items.Count - 1;
            lstCommandHistory.SelectedIndex = System.Windows.Forms.ListBox.NoMatches;
        }

        /// <summary>
        /// Event handler for the calculate button.
        /// Parses and evaluates the input expression.
        /// If the expression was valid, the result are shown in the main list view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculateExpression_Click(object sender, EventArgs e)
        {
            string expression = ReadExpression();

            lstResultList.Items.Add(String.Format(">> {0}", expression));

            //Calculate expression and add result to list
            RowEvaluator evaluator = new RowEvaluator(expression);

            //Try to parse and evaluate the expression.
            //Any errors are printed to the main list view.
            if (ParseExpression(evaluator) && EvaluateExpression(evaluator))
            {
                try
                {
                    PrintValue(evaluator.InterpretedExpression);
                }
                catch (Exception ex)
                {
                    lstResultList.Items.Add(String.Format("  error: {0}", ex.Message));
                }
            }

            AddExpressionToHistory(expression);

            lstResultList.Items.Add(String.Empty);

            UpdateGUI();
        }

        /// <summary>
        /// Event handler for the add file button.
        /// Creates a new file with the given name and shows it in the editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            //Asks the user for a file name.
            PromptDialogResult result = PromptDialog.Show("Enter file name:", "Input file name");
            if (result.Result == DialogResult.OK)
            {
                try
                {
                    FileEditor file = fm.NewFile(result.Message + FileManager.FILE_NAME_EXT);
                    OpenFile(file);
                    UpdateGUI();
                }
                catch (Exception ex)
                {
                    lstResultList.Items.Add(ex.Message);
                }
            }

        }

        /// <summary>
        /// Event handler for the change file button.
        /// Similar to the add button, but doesn't create a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeFile_Click(object sender, EventArgs e)
        {
            FileEditor file = fm.ChangeFile(lstFiles.SelectedIndex);

            OpenFile(file);
            UpdateGUI();
        }

        /// <summary>
        /// Creates a new FileEditorForm and shows it.
        /// </summary>
        /// <param name="file"></param>
        private void OpenFile(FileEditor file)
        {
            FileEditorForm editor = new FileEditorForm(file);

            editor.Show();
        }

        /// <summary>
        /// Event handler for the delete file button.
        /// Deletes the selected file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            fm.DeleteFile(lstFiles.SelectedIndex);
            UpdateGUI();
        }

        /// <summary>
        /// Reads the content of the expression input textField.
        /// </summary>
        /// <returns></returns>
        private string ReadExpression()
        {
            return txtExpressionInput.Text;
        }

        /// <summary>
        /// Tries to parse the input expression contained in the given evaluator.
        /// </summary>
        /// <param name="evaluator">The row evaluator with the given expression.</param>
        /// <returns>True if the parse was successfull.</returns>
        private bool ParseExpression(RowEvaluator evaluator)
        {
            try
            {
                evaluator.ParseExpression();
                return true;
            }
            catch (Exception ex)
            {
                lstResultList.Items.Add(String.Format("  error: {0}", ex.Message));
                return false;
            }
        }

        /// <summary>
        /// Tries to evaluate the input expression contained in the given evaluator.
        /// </summary>
        /// <param name="evaluator">The row evaluator with the given expression.</param>
        /// <returns>True if the evaluation was successfull.</returns>
        private bool EvaluateExpression(RowEvaluator evaluator)
        {

            try
            {
                evaluator.InterpretExpression();
                return true;
            }
            catch (Exception ex)
            {
                lstResultList.Items.Add(String.Format("  error: {0}", ex.Message));
                return false;
            }
        }

        /// <summary>
        /// Updates the variable list with the current variables and their values.
        /// </summary>
        private void UpdateVariableList()
        {
            VariableItem[] variables = resolver.Variables;
            lstVariables.Items.Clear();
            for (int i = 0; i < variables.Length; i++)
            {
                lstVariables.Items.Add(String.Format("{0,-15} {1,5}", variables[i].ToString(), variables[i].Value));
            }
        }

        /// <summary>
        /// Adds an expression to the history.
        /// </summary>
        /// <param name="expression"></param>
        private void AddExpressionToHistory(string expression)
        {
            hm.Add(expression);
        }

        /// <summary>
        /// Event handler for closing the form.
        /// Saves the history to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hm.SaveHistory();
        }

        /// <summary>
        /// Event handler for double click on a history item in the history list.
        /// Adds the clicked item to the expression textField.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCommandHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Find the location of the double click.
            int index = lstCommandHistory.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //The location corresponded to an item.
                //Add it to the expression textField.
                txtExpressionInput.Text = hm.GetHistory(index);
            }
        }

        /// <summary>
        /// Event handler for double click on a file item in the file list.
        /// The clicked file are executed and the results from the calculations are shown in the result list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Find the location of the double click.
            int index = lstFiles.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //The location corresponded to an item.
                //Run the script file.
                FileEditor editor = fm.ChangeFile(index);
                ScriptFileEvaluator fileEvaluator = new ScriptFileEvaluator(editor.ReadFileContents());
                List<ExpressionItem> list = new List<ExpressionItem>();

                try
                {
                    //Try to evaluate and print the rows in the script file.
                    fileEvaluator.Evaluate(out list);
                    PrintValues(list);
                }
                catch (Exception ex)
                {
                    //All rows weren't possible to evaluate.
                    //Print the rows that were evaluated and display an error message.
                    PrintValues(list);
                    lstResultList.Items.Add(String.Format("  error: {0}", ex.Message));
                }
            }

            lstResultList.Items.Add(String.Empty);

            UpdateGUI();
        }

        /// <summary>
        /// Prints the values of an array of expression items.
        /// </summary>
        /// <param name="list">The list of expression items.</param>
        private void PrintValues(List<ExpressionItem> list)
        {
            //Loop through all items and try to print them.
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    PrintValue(list[i]);
                }
            }
            catch (Exception ex)
            {
                lstResultList.Items.Add(String.Format("  error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Print the value of an expression item.
        /// </summary>
        /// <param name="item">The expression item.</param>
        private void PrintValue(ExpressionItem item)
        {
            if (item is AssignmentOperatorItem)
            {
                //If the expression was an assignment display the new varaible name and its value.
                string variableName = ((AssignmentOperatorItem)item).VariableName;
                lstResultList.Items.Add(String.Format("  {1} = {0}", item.Value, variableName));
            }
            else
            {
                //Otherwise, store the result in 'answer'.
                lstResultList.Items.Add(String.Format("  answer = {0}", item.Value));
                //Save the result in the variable 'answer'
                resolver.GetReference("answer").Value = item.Value;
            }
        }

        /// <summary>
        /// Event handler for the file list.
        /// Enables and disables the button according to file choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        /// <summary>
        /// Event handler for when the main form gains focus.
        /// Updates the buttons according to file choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        /// <summary>
        /// Event handler for when the main form loses focus.
        /// Updates the buttons according to file choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            UpdateGUI();
        }
    }
}
