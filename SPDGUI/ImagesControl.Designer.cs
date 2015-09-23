namespace SPD.GUI {
    partial class ImagesControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.labelPatientData = new System.Windows.Forms.Label();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxImageName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.buttonShow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonFindPhoto = new System.Windows.Forms.Button();
            this.buttonDeleteImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // labelPatientData
            // 
            this.labelPatientData.AutoSize = true;
            this.labelPatientData.Location = new System.Drawing.Point(70, 4);
            this.labelPatientData.Name = "labelPatientData";
            this.labelPatientData.Size = new System.Drawing.Size(35, 13);
            this.labelPatientData.TabIndex = 1;
            this.labelPatientData.Text = "label2";
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Location = new System.Drawing.Point(73, 115);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(132, 23);
            this.buttonAddPhoto.TabIndex = 3;
            this.buttonAddPhoto.Text = "Store Link";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Photo:";
            // 
            // textBoxImageName
            // 
            this.textBoxImageName.AllowDrop = true;
            this.textBoxImageName.Location = new System.Drawing.Point(73, 25);
            this.textBoxImageName.MaxLength = 255;
            this.textBoxImageName.Name = "textBoxImageName";
            this.textBoxImageName.Size = new System.Drawing.Size(476, 20);
            this.textBoxImageName.TabIndex = 0;
            this.textBoxImageName.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            this.textBoxImageName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBoxImageName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(73, 89);
            this.textBoxDescription.MaxLength = 255;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(557, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // listViewImages
            // 
            this.listViewImages.HideSelection = false;
            this.listViewImages.Location = new System.Drawing.Point(73, 144);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(557, 146);
            this.listViewImages.TabIndex = 4;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(73, 296);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 5;
            this.buttonShow.Text = "Show Image";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "You can drag a Photo from the Explorer and drop it into the Textbox";
            // 
            // buttonFindPhoto
            // 
            this.buttonFindPhoto.Location = new System.Drawing.Point(555, 23);
            this.buttonFindPhoto.Name = "buttonFindPhoto";
            this.buttonFindPhoto.Size = new System.Drawing.Size(75, 23);
            this.buttonFindPhoto.TabIndex = 1;
            this.buttonFindPhoto.Text = "Find";
            this.buttonFindPhoto.UseVisualStyleBackColor = true;
            this.buttonFindPhoto.Click += new System.EventHandler(this.buttonFindPhoto_Click);
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.Location = new System.Drawing.Point(154, 296);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Size = new System.Drawing.Size(91, 23);
            this.buttonDeleteImage.TabIndex = 10;
            this.buttonDeleteImage.Text = "Delete Image";
            this.buttonDeleteImage.UseVisualStyleBackColor = true;
            this.buttonDeleteImage.Click += new System.EventHandler(this.buttonDeleteImage_Click);
            // 
            // ImagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDeleteImage);
            this.Controls.Add(this.buttonFindPhoto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxImageName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddPhoto);
            this.Controls.Add(this.labelPatientData);
            this.Controls.Add(this.label1);
            this.Name = "ImagesControl";
            this.Size = new System.Drawing.Size(633, 332);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPatientData;
        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxImageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFindPhoto;
        private System.Windows.Forms.Button buttonDeleteImage;
    }
}
