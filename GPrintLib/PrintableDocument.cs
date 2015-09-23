using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using GPrintLib.Interfaces;

namespace GPrintLib {
    /// <summary>
    /// 
    /// </summary>
    public class PrintableDocument {

        private IList<PrintablePage> printPageList;
        private PrintDocument docToPrint = new PrintDocument();
        private string documentName = "";
        private int pages;
        private int currentPage;
        private bool landscape = false;
        private bool color = true;
        private PaperSize paperSize = null;
        private PaperSource paperSource = null;
        private PaperKind? paperKindIfSupported = null;
        private PaperKind? paperKindOrNothing = null;

        /// <summary>
        /// Gets or sets the name of the document.
        /// </summary>
        /// <value>The name of the document.</value>
        public string DocumentName {
            get {
                return this.documentName;
            }
            set {
                this.documentName = value;
            }
        }

        /// <summary>
        /// Gets or sets the print page list.
        /// </summary>
        /// <value>The print page list.</value>
        public IList<PrintablePage> PrintPageList {
            get {
                return this.printPageList;
            }
            set {
                this.printPageList = value;
            }
        }

        /// <summary>
        /// Gets or sets the paper kind if supported.
        /// </summary>
        /// <value>The paper kind if supported.</value>
        public PaperKind? PaperKindIfSupported {
            get {
                return this.paperKindIfSupported;
            }
            set {
                this.paperKindIfSupported = value;
            }
        }


        /// <summary>
        /// Gets or sets the paper kind or nothing.
        /// </summary>
        /// <value>The paper kind or nothing.</value>
        public PaperKind? PaperKindOrNothing {
            get {
                return this.paperKindOrNothing;
            }
            set {
                this.paperKindOrNothing = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PrintableDocument"/> is landscape.
        /// </summary>
        /// <value><c>true</c> if landscape; otherwise, <c>false</c>.</value>
        public bool Landscape {
            get {
                return this.landscape;
            }
            set {
                this.landscape = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PrintableDocument"/> is color.
        /// </summary>
        /// <value><c>true</c> if color; otherwise, <c>false</c>.</value>
        public bool Color {
            get {
                return this.color;
            }
            set {
                this.color = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the paper.
        /// </summary>
        /// <value>The size of the paper.</value>
        public PaperSize PaperSize {
            get {
                return this.paperSize;
            }
            set {
                this.paperSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the paper source.
        /// </summary>
        /// <value>The paper source.</value>
        public PaperSource PaperSource {
            get {
                return this.paperSource;
            }
            set {
                this.paperSource = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintableDocument"/> class.
        /// </summary>
        public PrintableDocument() {
            printPageList = new List<PrintablePage>();
        }

        /// <summary>
        /// Adds the print page.
        /// </summary>
        /// <param name="page">The page.</param>
        public void AddPrintPage(PrintablePage page) {
            this.printPageList.Add(page);
        }

        /// <summary>
        /// Does the print.
        /// </summary>
        /// <returns>null if OK, the PrintDialog if the Papersize is not supported!!</returns>
        public PrintDialog DoPrint() {
            return DoPrint(null);
        }

        /// <summary>
        /// Printername 
        /// </summary>
        public string PrinterName {
            get { return this.docToPrint.PrinterSettings.PrinterName; }
            set { this.docToPrint.PrinterSettings.PrinterName = value; }
        }

        /// <summary>
        /// is Valid
        /// </summary>
        /// <returns></returns>
        public bool isValid() {
            return this.docToPrint.PrinterSettings.IsValid;
        }

        /// <summary>
        /// Does the print.
        /// </summary>
        /// <returns>null if OK, the PrintDialog if the Papersize is not supported!!</returns>
        public PrintDialog DoPrint(PrintDialog printDialogParam) {
            return DoPrint(null, true);
        }

        

        /// <summary>
        /// Does the print.
        /// </summary>
        /// <returns>null if OK, the PrintDialog if the Papersize is not supported!!</returns>
        public PrintDialog DoPrint(PrintDialog printDialogParam, bool showPrintDialog) {
            PrintDialog printDialog;

            if (printDialogParam == null) {
                printDialog = new PrintDialog();
            } else {
                printDialog = printDialogParam;
            }

            docToPrint.DocumentName = this.documentName;
            docToPrint.DefaultPageSettings.Landscape = this.landscape;

            if (this.paperSource != null) {
                docToPrint.DefaultPageSettings.PaperSource = this.paperSource;
            }

            if (this.paperSize != null) {
                docToPrint.DefaultPageSettings.PaperSize = this.paperSize;
            }
            docToPrint.DefaultPageSettings.Color = this.color;

            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;
            printDialog.Document = docToPrint;

            if (this.paperKindOrNothing != null) {
                foreach (PaperSize ps in printDialog.PrinterSettings.PaperSizes) {
                    if (ps.Kind == this.paperKindOrNothing) {
                        docToPrint.DefaultPageSettings.PaperSize = ps;
                        break;
                    }
                }
            }
            else if (this.paperKindIfSupported != null) {
                foreach (PaperSize ps in printDialog.PrinterSettings.PaperSizes) {
                    if (ps.Kind == this.paperKindIfSupported) {
                        docToPrint.DefaultPageSettings.PaperSize = ps;
                        break;
                    }
                }
            }

            if (showPrintDialog)
            {
                if (printDialogParam == null)
                {
                    DialogResult result = printDialog.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        return null;
                    }
                }
            }

            if (this.paperKindOrNothing != null) {
                bool paperSizeSupported = false;
                foreach (PaperSize ps in printDialog.PrinterSettings.PaperSizes) {
                    if (ps.Kind == this.paperKindOrNothing) {
                        docToPrint.DefaultPageSettings.PaperSize = ps;
                        paperSizeSupported = true;
                        break;
                    }
                }
                if (!paperSizeSupported) {
                    return printDialog;
                }
            }
            else if (this.paperKindIfSupported != null) {
                foreach(PaperSize ps in printDialog.PrinterSettings.PaperSizes) {
                    if (ps.Kind == this.paperKindIfSupported) {
                        docToPrint.DefaultPageSettings.PaperSize = ps;
                        break;
                    }
                }
            }

            docToPrint.PrintPage += new PrintPageEventHandler(document_PrintPage);

            pages = this.printPageList.Count;
            currentPage = 0;
            if (this.printPageList.Count <= 0) {
                return null;
            }

            try {
                docToPrint.Print();
            } catch (Exception e) {
                MessageBox.Show("Error while printing: " + e.ToString());
            }

            return null;
        }

        /// <summary>
        /// Handles the PrintPage event of the document control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        private void document_PrintPage(object sender,
            PrintPageEventArgs e) {

            PrintablePage ppd = this.printPageList[currentPage];
            foreach (IPrintableObject po in ppd.PrintableObjectList) {
                po.AddToGraphics(e.Graphics);
            }

            currentPage++;
            if (--pages > 0)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        /// <summary>
        /// Duplicates the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        public void duplicate(int number) {
            IList<PrintablePage> newPrintPageList = new List<PrintablePage>();
            for (int i = 0; i < number; i++) {
                foreach (PrintablePage pp in printPageList) {
                    newPrintPageList.Add(pp);
                }
            }
            this.printPageList = newPrintPageList;
        }
    }
}
