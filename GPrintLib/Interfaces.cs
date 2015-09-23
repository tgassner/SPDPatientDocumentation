using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GPrintLib.Interfaces {
    /// <summary>
    /// Interface for adding a printable Object to to the Graphics.
    /// </summary>
    public interface IPrintableObject {
        /// <summary>
        /// Adds to graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        void AddToGraphics(Graphics graphics);
    }
}
