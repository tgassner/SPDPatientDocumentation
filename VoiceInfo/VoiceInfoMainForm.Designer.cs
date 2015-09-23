namespace SimplePatientDocumentation.VoiceInfo {
    partial class VoiceInfoMainForm {
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.trackBarRate = new System.Windows.Forms.TrackBar();
            this.labelRate = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.comboBoxStimmen = new System.Windows.Forms.ComboBox();
            this.labelVoice = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxSpeechEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(786, 201);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Visible = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(13, 12);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(642, 528);
            this.textBoxLog.TabIndex = 1;
            // 
            // trackBarRate
            // 
            this.trackBarRate.Location = new System.Drawing.Point(64, 105);
            this.trackBarRate.Minimum = -10;
            this.trackBarRate.Name = "trackBarRate";
            this.trackBarRate.Size = new System.Drawing.Size(104, 42);
            this.trackBarRate.TabIndex = 15;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(14, 105);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(33, 13);
            this.labelRate.TabIndex = 14;
            this.labelRate.Text = "Rate:";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(64, 57);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(104, 42);
            this.trackBarVolume.TabIndex = 13;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(14, 57);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(45, 13);
            this.labelVolume.TabIndex = 12;
            this.labelVolume.Text = "Volume:";
            // 
            // comboBoxStimmen
            // 
            this.comboBoxStimmen.FormattingEnabled = true;
            this.comboBoxStimmen.Location = new System.Drawing.Point(64, 30);
            this.comboBoxStimmen.Name = "comboBoxStimmen";
            this.comboBoxStimmen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStimmen.TabIndex = 11;
            this.comboBoxStimmen.SelectedIndexChanged += new System.EventHandler(this.comboBoxStimmen_SelectedIndexChanged);
            // 
            // labelVoice
            // 
            this.labelVoice.AutoSize = true;
            this.labelVoice.Location = new System.Drawing.Point(14, 33);
            this.labelVoice.Name = "labelVoice";
            this.labelVoice.Size = new System.Drawing.Size(40, 13);
            this.labelVoice.TabIndex = 10;
            this.labelVoice.Text = "Voice: ";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxSpeechEnabled);
            this.groupBoxSettings.Controls.Add(this.comboBoxStimmen);
            this.groupBoxSettings.Controls.Add(this.trackBarRate);
            this.groupBoxSettings.Controls.Add(this.labelVoice);
            this.groupBoxSettings.Controls.Add(this.labelRate);
            this.groupBoxSettings.Controls.Add(this.labelVolume);
            this.groupBoxSettings.Controls.Add(this.trackBarVolume);
            this.groupBoxSettings.Location = new System.Drawing.Point(661, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(200, 183);
            this.groupBoxSettings.TabIndex = 16;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // checkBoxSpeechEnabled
            // 
            this.checkBoxSpeechEnabled.AutoSize = true;
            this.checkBoxSpeechEnabled.Location = new System.Drawing.Point(64, 153);
            this.checkBoxSpeechEnabled.Name = "checkBoxSpeechEnabled";
            this.checkBoxSpeechEnabled.Size = new System.Drawing.Size(105, 17);
            this.checkBoxSpeechEnabled.TabIndex = 16;
            this.checkBoxSpeechEnabled.Text = "Speech Enabled";
            this.checkBoxSpeechEnabled.UseVisualStyleBackColor = true;
            this.checkBoxSpeechEnabled.CheckedChanged += new System.EventHandler(this.checkBoxSpeechEnabled_CheckedChanged);
            // 
            // VoiceInfoMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 552);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonStart);
            this.Name = "VoiceInfoMainForm";
            this.Text = "Simple Patient Documentation Voice Info";
            this.Load += new System.EventHandler(this.VoiceInfoMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TrackBar trackBarRate;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.ComboBox comboBoxStimmen;
        private System.Windows.Forms.Label labelVoice;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxSpeechEnabled;
    }
}

