namespace SPD.GUI {
    partial class ShortcutsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonOk = new System.Windows.Forms.Button();
            this.richTextBoxShortcuts = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 508);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // richTextBoxShortcuts
            // 
            this.richTextBoxShortcuts.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxShortcuts.Name = "richTextBoxShortcuts";
            this.richTextBoxShortcuts.ReadOnly = true;
            this.richTextBoxShortcuts.Size = new System.Drawing.Size(422, 490);
            this.richTextBoxShortcuts.TabIndex = 1;
            this.richTextBoxShortcuts.Text = "";
            // 
            // ShortcutsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 543);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBoxShortcuts);
            this.Controls.Add(this.buttonOk);
            this.Name = "ShortcutsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Shortcuts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBoxShortcuts;
    }
}