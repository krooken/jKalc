using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jKalc
{
    /// <summary>
    /// A class that handles the result from the prompt dialog.
    /// </summary>
    public class PromptDialogResult
    {

        private DialogResult result;
        private string message;

        /// <summary>
        /// Creates a new result with the given DialogResult and message.
        /// </summary>
        /// <param name="result">The dialogresult of the prompt dialog.</param>
        /// <param name="message">The message result of the prompt dialog.</param>
        public PromptDialogResult(DialogResult result, string message)
        {
            this.result = result;
            this.message = message;
        }

        /// <summary>
        /// Returns the dialog result.
        /// </summary>
        public DialogResult Result
        {
            get { return result; }
        }

        /// <summary>
        /// Returns the message result.
        /// </summary>
        public string Message
        {
            get { return message; }
        }
    }
}
