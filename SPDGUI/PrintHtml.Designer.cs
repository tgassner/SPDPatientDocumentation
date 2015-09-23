namespace SPD.GUI {
    partial class PrintHtml {
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(700, 412);
            this.webBrowser1.TabIndex = 0;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(0, 420);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            this.buttonPrint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintHtml_KeyPress);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(82, 421);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintHtml_KeyPress);
            // 
            // PrintHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 455);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.webBrowser1);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "PrintHtml";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PrintHtml";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintHtml_KeyPress);
            this.Resize += new System.EventHandler(this.PrintHtml_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonClose;
    }
}