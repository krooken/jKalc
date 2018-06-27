namespace jKalc
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.txtExpressionInput = new System.Windows.Forms.TextBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnChangeFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.lstResultList = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCalculateExpression = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstCommandHistory = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.Items.AddRange(new object[] {
            "Sine.jk",
            "FFT.jk",
            "AutocropRGBImage.jk"});
            this.lstFiles.Location = new System.Drawing.Point(3, 19);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(192, 316);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDoubleClick);
            // 
            // txtExpressionInput
            // 
            this.txtExpressionInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpressionInput.Location = new System.Drawing.Point(4, 399);
            this.txtExpressionInput.Name = "txtExpressionInput";
            this.txtExpressionInput.Size = new System.Drawing.Size(318, 20);
            this.txtExpressionInput.TabIndex = 1;
            this.txtExpressionInput.Text = "2+4-(23*0.003)";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFile.Location = new System.Drawing.Point(3, 339);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(192, 23);
            this.btnAddFile.TabIndex = 2;
            this.btnAddFile.Text = "Add file";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnChangeFile
            // 
            this.btnChangeFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeFile.Location = new System.Drawing.Point(3, 368);
            this.btnChangeFile.Name = "btnChangeFile";
            this.btnChangeFile.Size = new System.Drawing.Size(192, 23);
            this.btnChangeFile.TabIndex = 2;
            this.btnChangeFile.Text = "Change file";
            this.btnChangeFile.UseVisualStyleBackColor = true;
            this.btnChangeFile.Click += new System.EventHandler(this.btnChangeFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFile.Location = new System.Drawing.Point(3, 397);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(192, 23);
            this.btnDeleteFile.TabIndex = 2;
            this.btnDeleteFile.Text = "Delete file";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // lstResultList
            // 
            this.lstResultList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResultList.Items.AddRange(new object[] {
            "4+5",
            "ans = 9",
            "2*3;",
            "2*3",
            "ans = 6"});
            this.lstResultList.Location = new System.Drawing.Point(4, 3);
            this.lstResultList.Name = "lstResultList";
            this.lstResultList.Size = new System.Drawing.Size(416, 381);
            this.lstResultList.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lstFiles);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteFile);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddFile);
            this.splitContainer1.Panel1.Controls.Add(this.btnChangeFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(829, 425);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Files";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtExpressionInput);
            this.splitContainer2.Panel1.Controls.Add(this.lstResultList);
            this.splitContainer2.Panel1.Controls.Add(this.btnCalculateExpression);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(625, 425);
            this.splitContainer2.SplitterDistance = 425;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnCalculateExpression
            // 
            this.btnCalculateExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculateExpression.Location = new System.Drawing.Point(328, 397);
            this.btnCalculateExpression.Name = "btnCalculateExpression";
            this.btnCalculateExpression.Size = new System.Drawing.Size(92, 23);
            this.btnCalculateExpression.TabIndex = 2;
            this.btnCalculateExpression.Text = "Calculate";
            this.btnCalculateExpression.UseVisualStyleBackColor = true;
            this.btnCalculateExpression.Click += new System.EventHandler(this.btnCalculateExpression_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Location = new System.Drawing.Point(-3, -1);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.lstVariables);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label1);
            this.splitContainer3.Panel2.Controls.Add(this.lstCommandHistory);
            this.splitContainer3.Size = new System.Drawing.Size(198, 425);
            this.splitContainer3.SplitterDistance = 212;
            this.splitContainer3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Variables";
            // 
            // lstVariables
            // 
            this.lstVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVariables.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVariables.ItemHeight = 14;
            this.lstVariables.Items.AddRange(new object[] {
            "ans\t6"});
            this.lstVariables.Location = new System.Drawing.Point(5, 19);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(188, 186);
            this.lstVariables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Command history";
            // 
            // lstCommandHistory
            // 
            this.lstCommandHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCommandHistory.Items.AddRange(new object[] {
            "2012-08-08",
            "4+5",
            "2*3;",
            "2*3"});
            this.lstCommandHistory.Location = new System.Drawing.Point(5, 17);
            this.lstCommandHistory.Name = "lstCommandHistory";
            this.lstCommandHistory.Size = new System.Drawing.Size(188, 186);
            this.lstCommandHistory.TabIndex = 0;
            this.lstCommandHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCommandHistory_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 449);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "jKalculator";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.TextBox txtExpressionInput;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnChangeFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.ListBox lstResultList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCalculateExpression;
        private System.Windows.Forms.ListBox lstVariables;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox lstCommandHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

