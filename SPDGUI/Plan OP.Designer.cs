namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    partial class Plan_OP {
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxSex = new System.Windows.Forms.TextBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIndication = new System.Windows.Forms.TextBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxTherapy = new System.Windows.Forms.TextBox();
            this.labelTherapy = new System.Windows.Forms.Label();
            this.buttonCopyToClipboardAndClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(68, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(543, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(68, 64);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(543, 20);
            this.textBoxAge.TabIndex = 2;
            this.textBoxAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // textBoxSex
            // 
            this.textBoxSex.Location = new System.Drawing.Point(68, 90);
            this.textBoxSex.Name = "textBoxSex";
            this.textBoxSex.Size = new System.Drawing.Size(543, 20);
            this.textBoxSex.TabIndex = 3;
            this.textBoxSex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(68, 116);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(543, 20);
            this.textBoxWeight.TabIndex = 4;
            this.textBoxWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sex:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Weight:";
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(227, 194);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(124, 23);
            this.buttonCopyToClipboard.TabIndex = 8;
            this.buttonCopyToClipboard.Text = "C&opy to Clipboard";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            this.buttonCopyToClipboard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(357, 194);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(124, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "C&lose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Indication:";
            // 
            // textBoxIndication
            // 
            this.textBoxIndication.Location = new System.Drawing.Point(68, 142);
            this.textBoxIndication.Name = "textBoxIndication";
            this.textBoxIndication.Size = new System.Drawing.Size(543, 20);
            this.textBoxIndication.TabIndex = 5;
            this.textBoxIndication.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(487, 194);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(124, 23);
            this.buttonRestore.TabIndex = 10;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            this.buttonRestore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(41, 15);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(68, 12);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(543, 20);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // textBoxTherapy
            // 
            this.textBoxTherapy.Location = new System.Drawing.Point(68, 168);
            this.textBoxTherapy.Name = "textBoxTherapy";
            this.textBoxTherapy.Size = new System.Drawing.Size(543, 20);
            this.textBoxTherapy.TabIndex = 6;
            this.textBoxTherapy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            // 
            // labelTherapy
            // 
            this.labelTherapy.AutoSize = true;
            this.labelTherapy.Location = new System.Drawing.Point(12, 171);
            this.labelTherapy.Name = "labelTherapy";
            this.labelTherapy.Size = new System.Drawing.Size(49, 13);
            this.labelTherapy.TabIndex = 14;
            this.labelTherapy.Text = "Therapy:";
            // 
            // buttonCopyToClipboardAndClose
            // 
            this.buttonCopyToClipboardAndClose.Location = new System.Drawing.Point(68, 194);
            this.buttonCopyToClipboardAndClose.Name = "buttonCopyToClipboardAndClose";
            this.buttonCopyToClipboardAndClose.Size = new System.Drawing.Size(153, 23);
            this.buttonCopyToClipboardAndClose.TabIndex = 7;
            this.buttonCopyToClipboardAndClose.Text = "&Copy to Clipboard and Close";
            this.buttonCopyToClipboardAndClose.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboardAndClose.Click += new System.EventHandler(this.buttonCopyToClipboardAndClose_Click);
            // 
            // Plan_OP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 232);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCopyToClipboardAndClose);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.labelTherapy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTherapy);
            this.Controls.Add(this.textBoxIndication);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.textBoxSex);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(633, 259);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(633, 259);
            this.Name = "Plan_OP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Plan OP";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plan_OP_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxSex;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIndication;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxTherapy;
        private System.Windows.Forms.Label labelTherapy;
        private System.Windows.Forms.Button buttonCopyToClipboardAndClose;
    }
}