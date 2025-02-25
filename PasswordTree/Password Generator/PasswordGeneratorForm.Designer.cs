namespace PasswordTree.Password_Generator
{
    partial class PasswordGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordGeneratorForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAppsIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxCurrentPassword = new System.Windows.Forms.TextBox();
            this.buttonGeneratePassword = new System.Windows.Forms.Button();
            this.textBoxPreviousPasswords = new System.Windows.Forms.TextBox();
            this.numericPasswordLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownSelectionCooldown = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPasswordDistinct = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPasswordLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectionCooldown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Settings";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAppsIconToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutAppsIconToolStripMenuItem
            // 
            this.aboutAppsIconToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aboutAppsIconToolStripMenuItem.Name = "aboutAppsIconToolStripMenuItem";
            this.aboutAppsIconToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutAppsIconToolStripMenuItem.Text = "About App\'s Icon";
            this.aboutAppsIconToolStripMenuItem.Click += new System.EventHandler(this.aboutAppsIconToolStripMenuItem_Click);
            // 
            // textBoxCurrentPassword
            // 
            this.textBoxCurrentPassword.BackColor = System.Drawing.Color.White;
            this.textBoxCurrentPassword.Location = new System.Drawing.Point(130, 107);
            this.textBoxCurrentPassword.MaxLength = 200;
            this.textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            this.textBoxCurrentPassword.ReadOnly = true;
            this.textBoxCurrentPassword.Size = new System.Drawing.Size(196, 20);
            this.textBoxCurrentPassword.TabIndex = 2;
            // 
            // buttonGeneratePassword
            // 
            this.buttonGeneratePassword.Location = new System.Drawing.Point(251, 136);
            this.buttonGeneratePassword.Name = "buttonGeneratePassword";
            this.buttonGeneratePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonGeneratePassword.TabIndex = 3;
            this.buttonGeneratePassword.Text = "Generate";
            this.buttonGeneratePassword.UseVisualStyleBackColor = true;
            this.buttonGeneratePassword.Click += new System.EventHandler(this.buttonGeneratePassword_Click);
            // 
            // textBoxPreviousPasswords
            // 
            this.textBoxPreviousPasswords.BackColor = System.Drawing.Color.White;
            this.textBoxPreviousPasswords.Location = new System.Drawing.Point(126, 27);
            this.textBoxPreviousPasswords.Multiline = true;
            this.textBoxPreviousPasswords.Name = "textBoxPreviousPasswords";
            this.textBoxPreviousPasswords.ReadOnly = true;
            this.textBoxPreviousPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPreviousPasswords.Size = new System.Drawing.Size(302, 74);
            this.textBoxPreviousPasswords.TabIndex = 4;
            // 
            // numericPasswordLength
            // 
            this.numericPasswordLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericPasswordLength.Location = new System.Drawing.Point(125, 159);
            this.numericPasswordLength.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericPasswordLength.Name = "numericPasswordLength";
            this.numericPasswordLength.Size = new System.Drawing.Size(42, 20);
            this.numericPasswordLength.TabIndex = 5;
            this.numericPasswordLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Generated Password: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Previous Passwords: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Selection Cooldown: ";
            // 
            // numericUpDownSelectionCooldown
            // 
            this.numericUpDownSelectionCooldown.Location = new System.Drawing.Point(125, 133);
            this.numericUpDownSelectionCooldown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSelectionCooldown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSelectionCooldown.Name = "numericUpDownSelectionCooldown";
            this.numericUpDownSelectionCooldown.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownSelectionCooldown.TabIndex = 19;
            this.numericUpDownSelectionCooldown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSelectionCooldown.ValueChanged += new System.EventHandler(this.numericUpDownSelectionCooldown_ValueChanged);
            // 
            // checkBoxPasswordDistinct
            // 
            this.checkBoxPasswordDistinct.AutoSize = true;
            this.checkBoxPasswordDistinct.Checked = true;
            this.checkBoxPasswordDistinct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPasswordDistinct.Location = new System.Drawing.Point(332, 109);
            this.checkBoxPasswordDistinct.Name = "checkBoxPasswordDistinct";
            this.checkBoxPasswordDistinct.Size = new System.Drawing.Size(61, 17);
            this.checkBoxPasswordDistinct.TabIndex = 18;
            this.checkBoxPasswordDistinct.Text = "Distinct";
            this.checkBoxPasswordDistinct.UseVisualStyleBackColor = true;
            this.checkBoxPasswordDistinct.CheckedChanged += new System.EventHandler(this.checkBoxPasswordDistinct_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Password Length: ";
            // 
            // PasswordGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 185);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownSelectionCooldown);
            this.Controls.Add(this.checkBoxPasswordDistinct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericPasswordLength);
            this.Controls.Add(this.textBoxPreviousPasswords);
            this.Controls.Add(this.buttonGeneratePassword);
            this.Controls.Add(this.textBoxCurrentPassword);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PasswordGeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordGeneratorForm_FormClosing);
            this.Load += new System.EventHandler(this.PasswordGeneratorForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPasswordLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectionCooldown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxCurrentPassword;
        private System.Windows.Forms.Button buttonGeneratePassword;
        private System.Windows.Forms.TextBox textBoxPreviousPasswords;
        private System.Windows.Forms.NumericUpDown numericPasswordLength;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAppsIconToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxPasswordDistinct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectionCooldown;
    }
}