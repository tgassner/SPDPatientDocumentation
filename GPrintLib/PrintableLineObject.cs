using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GPrintLib.Interfaces;

namespace GPrintLib {
    /// <summary>
    /// 
    /// </summary>
    public class PrintableLineObject : IPrintableObject{

        private Pen pen;
        private int xint1, xint2, yint1, yint2;
        private constructorType constrType = constructorType.none;

        private enum constructorType {
            PenXint1Yint1Xint2Yint2,
            none
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintableLineObject"/> class.
        /// </summary>
        /// <param name="pen">The pen.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        public PrintableLineObject(Pen pen, int x1, int y1, int x2, int y2) {
            this.pen = pen;
            this.xint1 = x1;
            this.yint1 = y1;
            this.xint2 = x2;
            this.yint2 = y2;
            this.constrType = constructorType.PenXint1Yint1Xint2Yint2;

        }

        /// <summary>
        /// Adds to graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void AddToGraphics(Graphics graphics) {
            switch (this.constrType) {
                case constructorType.PenXint1Yint1Xint2Yint2:
                    graphics.DrawLine(this.pen, xint1, yint1, xint2, yint2);
                    break;
                default:
                    break;
            }
        }

        
    }
}
