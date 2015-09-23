using System;
using System.Collections.Generic;
using System.Text;
using GPrintLib.Interfaces;

namespace GPrintLib {

    /// <summary>
    /// 
    /// </summary>
    public class PrintablePage {
        private IList<IPrintableObject> printableObjectList;

        /// <summary>
        /// Gets the printable object list.
        /// </summary>
        /// <value>The printable object list.</value>
        public IList<IPrintableObject> PrintableObjectList {
            get {
                if (this.printableObjectList == null) {
                    this.printableObjectList = new List<IPrintableObject>();
                }
                return this.printableObjectList;
            }
            set {
                this.printableObjectList = value;
            }
        }

        /// <summary>
        /// Adds the printable object.
        /// </summary>
        /// <param name="printableObject">The printable object.</param>
        public void AddPrintableObject(IPrintableObject printableObject) {

            this.PrintableObjectList.Add(printableObject);
        }
    }
}
