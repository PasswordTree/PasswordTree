namespace PasswordTree.Configuration
{
    partial class SettingsForm
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxPreviousPass = new System.Windows.Forms.CheckBox();
            this.numericUpDownPreviousPassCounts = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviousPassCounts)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(553, 293);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tree:  ";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(409, 327);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBoxPreviousPass
            // 
            this.checkBoxPreviousPass.AutoSize = true;
            this.checkBoxPreviousPass.Checked = true;
            this.checkBoxPreviousPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPreviousPass.Location = new System.Drawing.Point(12, 328);
            this.checkBoxPreviousPass.Name = "checkBoxPreviousPass";
            this.checkBoxPreviousPass.Size = new System.Drawing.Size(163, 17);
            this.checkBoxPreviousPass.TabIndex = 2;
            this.checkBoxPreviousPass.Text = "Previous Passwords Counts: ";
            this.checkBoxPreviousPass.UseVisualStyleBackColor = true;
            this.checkBoxPreviousPass.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDownPreviousPassCounts
            // 
            this.numericUpDownPreviousPassCounts.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownPreviousPassCounts.Location = new System.Drawing.Point(181, 327);
            this.numericUpDownPreviousPassCounts.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownPreviousPassCounts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPreviousPassCounts.Name = "numericUpDownPreviousPassCounts";
            this.numericUpDownPreviousPassCounts.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownPreviousPassCounts.TabIndex = 0;
            this.numericUpDownPreviousPassCounts.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(490, 327);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxPreviousPass);
            this.Controls.Add(this.numericUpDownPreviousPassCounts);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviousPassCounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownPreviousPassCounts;
        private System.Windows.Forms.CheckBox checkBoxPreviousPass;
    }
}