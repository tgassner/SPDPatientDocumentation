using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GPrintLib.Interfaces;

namespace GPrintLib {
    /// <summary>
    /// 
    /// </summary>
    public class PrintableFillRectangleObject : IPrintableObject{

        private Brush brush;
        private int x, y, width, height;
        private constructorType constrType = constructorType.none;

        private enum constructorType {
            BrushXintYintWidthintHeightint,
            none
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintableFillRectangleObject"/> class.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public PrintableFillRectangleObject(Brush brush,int x,int y,int width,int height) {
            this.brush = brush;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.constrType = constructorType.BrushXintYintWidthintHeightint;

        }

        /// <summary>
        /// Adds to graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void AddToGraphics(Graphics graphics) {
            switch (this.constrType) {
                case constructorType.BrushXintYintWidthintHeightint:
                    graphics.FillRectangle(brush, x, y, width, height);
                    break;
                default:
                    break;
            }
        }
    }
}
