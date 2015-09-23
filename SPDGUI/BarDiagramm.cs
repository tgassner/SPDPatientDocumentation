using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    public class BardiagramElement{
        private string name;
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BardiagramElement"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public BardiagramElement(string name, int value) {
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name{
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value {
            get { return value; }
            set { this.value = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class BarDiagram : UserControl {
        private IList<BardiagramElement> elements; 
        private int maxSize;
        private int sum;
        private int bannertop;
        private int bannerbottom;
        private string headline;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarDiagram"/> class.
        /// </summary>
        public BarDiagram() {
            InitializeComponent();
            elements = new List<BardiagramElement>();

            this.bannertop = 30;
            this.bannerbottom = 55;
        }

        /// <summary>
        /// Initts the specified elements.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <param name="headline">The headline.</param>
        public void Init(IList<BardiagramElement> elements,string headline) {
            this.elements = elements;
            this.maxSize = Int32.MinValue;
            this.sum = 0;
            foreach(BardiagramElement bde in this.elements){
                if (bde.Value > this.maxSize) {
                    maxSize = bde.Value;
                }
                sum += bde.Value;
            }
            this.headline = headline + " Total: " + sum;
        }

        private void draw(Graphics g) {
            int localwidth = this.Size.Width / ((elements.Count * 3) + 1);
            g.DrawString(headline, this.Font, Brushes.Black, 5, 5);
            Brush brusch = Brushes.Blue;
            int i = 0;
            g.DrawRectangle(Pens.Black, localwidth - (int)((((double)localwidth) / 2.0)) - 2, bannertop - 6, this.Size.Width - localwidth - 6, this.Size.Height - bannertop - bannerbottom + 11);
            foreach (BardiagramElement bde in this.elements){
                int y = (int)(((((double)this.Size.Height) - ((double)bannerbottom) - ((double)bannertop)) -
                         (((((double)this.Size.Height) - ((double)bannerbottom) - ((double)bannertop)) / ((double)this.maxSize)) * ((double)bde.Value))) + ((double)bannertop));

                int height = (int)((((this.Size.Height) - ((double)bannerbottom) - ((double)bannertop)) / ((double)this.maxSize)) * ((double)bde.Value));

                g.FillRectangle(brusch, (localwidth * i * 3) + localwidth, y, localwidth * 2, height);


                g.DrawString(bde.Name, this.Font, Brushes.Black, (localwidth * i * 3) + localwidth, this.Size.Height - bannerbottom + 8);
                double percent = Math.Round(((100.0 / ((double)this.sum))*((double)bde.Value)), 2);
                g.DrawString(bde.Value.ToString(), this.Font, Brushes.Black, (localwidth * i * 3) + localwidth, this.Size.Height - bannerbottom + this.Font.GetHeight() + 8 + 2);
                g.DrawString(percent.ToString() + "%", this.Font, Brushes.Black, (localwidth * i * 3) + localwidth, this.Size.Height - bannerbottom + this.Font.GetHeight() * 2 + 8 + 2 + 2);
                i++;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            draw(e.Graphics);
        }

        /// <summary>
        /// Compares the operations by date.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private static int CompareOperationsByDate(BardiagramElement x, BardiagramElement y) {
            //if (x == null) {
            //    if (y == null) {
            //        return 0;
            //    } else {
            //        return -1;
            //    }
            //} else {
            //    if (y == null) {
            //        return 1;
            //    } else {
                    return x.Name.CompareTo(y.Name);
            //    }
            //}
        }

        /// <summary>
        /// Bars the diagramm elements by value.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns></returns>
        public static IList<BardiagramElement> BarDiagrammElementsByValue(IList<BardiagramElement> elements) {
            List<BardiagramElement> list = new List<BardiagramElement>(elements);
            list.Sort(CompareOperationsByDate);
            return list;
        }
    }
}
