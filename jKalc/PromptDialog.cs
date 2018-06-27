using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jKalc
{
    /// <summary>
    /// A special dialog that asks the user for a file name.
    /// (Or any name)
    /// </summary>
    public partial class PromptDialog : Form
    {
        /// <summary>
        /// Shows the dialog with the given message and title.
        /// </summary>
        /// <param name="promptMessage">The message to show.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <returns></returns>
        public static PromptDialogResult Show(string promptMessage, string title)
        {
            PromptDialog dialog = new PromptDialog(promptMessage, title);
            DialogResult result = dialog.ShowDialog();
            return new PromptDialogResult(result, dialog.Message);
        }

        /// <summary>
        /// Creates a new dialog with the specified message and title.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="title"></param>
        PromptDialog(string promptMessage,string title)
        {
            InitializeComponent();

            this.Text = title;
            this.lblPrompt.Text = promptMessage;
        }

        /// <summary>
        /// Returns the message left by the user.
        /// </summary>
        string Message
        {
            get { return txtPrompt.Text; }
        }
    }
}
