using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GPrintLib.Interfaces;

namespace GPrintLib {
    /// <summary>
    /// 
    /// </summary>
    public class PrintableTextObject : IPrintableObject {   

        private enum constructorType {
            TextFontBrushXY,
            none
        }

        private string text;
        private Font font;
        private Brush brush;
        private float x, y;
        private constructorType constrType = constructorType.none;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintableTextObject"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public PrintableTextObject(string text, Font font, Brush brush, float x, float y) {
            this.text = text;
            this.font = font;
            this.brush = brush;
            this.x = x;
            this.y = y;
            this.constrType = constructorType.TextFontBrushXY;
        }

        //public string Text {
        //    get {
        //        return this.text;
        //    }
        //}

        //public Font Font {
        //    get {
        //        return this.font;
        //    }
        //}

        //public Brush Brush {
        //    get {
        //        return this.brush;
        //    }
        //}

        //public float X {
        //    get {
        //        return this.x;
        //    }
        //}

        //public float Y {
        //    get {
        //        return this.y;
        //    }
        //}

        /// <summary>
        /// Adds to graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void AddToGraphics(Graphics graphics) {
            switch (this.constrType) {
                case constructorType.TextFontBrushXY:
                    graphics.DrawString(this.text, this.font, this.brush, this.x, this.y);
                    break;
                default:
                    break;
            }
        }
    }
}
