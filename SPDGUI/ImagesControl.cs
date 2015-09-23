using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using SPD.CommonObjects;
using System.Threading;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public delegate void PhotoStoreEventHandler(object sender,
             PhotoStoreEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public delegate void DeleteImageEventHandler(object sender,
             DeleteImageEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class ImagesControl : UserControl {

        /// <summary>
        /// Gets or sets the list view images.
        /// </summary>
        /// <value>The list view images.</value>
        public System.Windows.Forms.ListView ListViewImages {
            set { listViewImages = value; }
            get { return listViewImages; }
        }

        private IList<ImageData> imageList;
        private PatientData currentPatient;

        /// <summary>
        /// Occurs when [store].
        /// </summary>
        public event PhotoStoreEventHandler Store;
        /// <summary>
        /// Occurs when [delete].
        /// </summary>
        public event DeleteImageEventHandler Delete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagesControl"/> class.
        /// </summary>
        public ImagesControl() {
            InitializeComponent();

            listViewImages.View = View.Details;
            listViewImages.LabelEdit = false;
            listViewImages.AllowColumnReorder = true;
            listViewImages.FullRowSelect = true;

            // Create columns for the items and subitems.
            listViewImages.Columns.Add("IID", 30);
            listViewImages.Columns.Add("Filename", 200);
            listViewImages.Columns.Add("Description", 200);
        }

        /// <summary>
        /// Gets or sets the current patient.
        /// </summary>
        /// <value>The current patient.</value>
        public PatientData CurrentPatient {
            get { return currentPatient; }
            set { currentPatient = value; }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        internal void Clear() {
            this.listViewImages.Items.Clear();
            this.textBoxImageName.Text = "";
            this.textBoxDescription.Text = "";
            this.labelPatientData.Text = "";
        }

        /// <summary>
        /// Initts the specified image list.
        /// </summary>
        /// <param name="imageList">The image list.</param>
        internal void Initt(IList<ImageData> imageList) {
            this.imageList = imageList;
            Clear();
            ListViewItem item1;
            if (this.imageList != null) {
                foreach (ImageData im in imageList) {
                    item1 = new ListViewItem(im.PhotoID.ToString(), 0);
                    item1.SubItems.Add(im.Link);
                    item1.SubItems.Add(im.Kommentar);
                    listViewImages.Items.Add(item1);
                }
            }

            if (currentPatient != null) {
                this.labelPatientData.Text = currentPatient.Id.ToString() + " " + currentPatient.FirstName + " " + currentPatient.SurName;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e) {
            string[] fileNames;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            } else {
                return;
            }
            if (fileNames.Length != 1) {
                MessageBox.Show("Please insert only 1 Image");
                return;
            }
            if (!File.Exists(fileNames[0])) {
                MessageBox.Show("Sorry at least one file does not exist or is a directory!");
                return;
            }
            textBoxImageName.Text = fileNames[0];
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox1_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e) {
            long imageID = 0;
            if (!File.Exists(textBoxImageName.Text)) {
                MessageBox.Show("Sorry file does not exist or is directory!");
                return;
            }
            PhotoStoreEventArgs e2 = new PhotoStoreEventArgs(
                new ImageData(imageID, currentPatient.Id, textBoxImageName.Text,
                        textBoxDescription.Text));
            Store(this, e2);
        }

        private ImageData getSelectedImage() {
            long imID = 0;
            try {
                foreach (ListViewItem lvi in listViewImages.SelectedItems) {
                    imID = Int64.Parse(lvi.Text);
                }
            } catch (Exception) {
                return null;
            }

            foreach (ImageData im in imageList) {
                if (im.PhotoID == imID) {
                    return im;
                }
            }
            return null;
        }

        private bool PhotoSelected() {
            return (listViewImages.SelectedItems.Count > 0);
        }

        private void buttonShow_Click(object sender, EventArgs e) {
            if (!PhotoSelected()) {
                MessageBox.Show("Please select a photo to show");
                return;
            }
            ImageData imData = getSelectedImage();
            if (!File.Exists(imData.Link)) {
                MessageBox.Show("Sorry file does not exists any more - or is not readable");
                return;
            }
            System.Diagnostics.Process.Start(imData.Link);
        }

        private void buttonFindPhoto_Click(object sender, EventArgs e) {
            OpenFileDialog fod = new OpenFileDialog();
            fod.Multiselect = false;
            DialogResult dr = fod.ShowDialog();
            if (dr != DialogResult.OK) {
                return;
            }
            textBoxImageName.Text = fod.FileName;
        }

        private void buttonDeleteImage_Click(object sender, EventArgs e) {
            if (!PhotoSelected()) {
                MessageBox.Show("Please select a photo to show");
                return;
            }
            Delete(this,new DeleteImageEventArgs(getSelectedImage()));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteImageEventArgs : EventArgs {
        private ImageData image;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteImageEventArgs"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public DeleteImageEventArgs(ImageData image) {
            this.image = image;
        }
        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>The image.</value>
        public ImageData Image {
            get { return image; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PhotoStoreEventArgs : EventArgs {
        private ImageData image;
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoStoreEventArgs"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public PhotoStoreEventArgs(ImageData image) {
            this.image = image;
        }
        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>The image.</value>
        public ImageData Image {
            get { return image; }
        }
    }
}
