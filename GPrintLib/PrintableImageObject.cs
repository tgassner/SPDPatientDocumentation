using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GPrintLib.Interfaces;

namespace GPrintLib {
    /// <summary>
    /// 
    /// </summary>
    public class PrintableImageObject : IPrintableObject{

        private Image image;
        private int x,y;
        private constructorType constrType = constructorType.none;

        private enum constructorType {
            Imagexintyint,
            none
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintableImageObject"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public PrintableImageObject(Image image, int x, int y) {
            this.image = image;
            this.x = x;
            this.y = y;
            this.constrType = constructorType.Imagexintyint;

        }

        /// <summary>
        /// Adds to graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void AddToGraphics(Graphics graphics) {
            switch (this.constrType) {
                case constructorType.Imagexintyint:
                    graphics.DrawImage(image,x,y);
                    break;
                default:
                    break;
            }
        }
    }
}
