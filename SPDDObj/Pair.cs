using System;
using System.Collections.Generic;
using System.Text;

namespace SPD.CommonUtilities {
    /// <summary>
    /// Generic Pair Class
    /// </summary>
    /// <typeparam name="T">first Datatype</typeparam>
    /// <typeparam name="U">second Datatype</typeparam>
    public class Pair<T, U> {

        /// <summary>
        /// empty constructor
        /// </summary>
        public Pair() {
        }

        /// <summary>
        /// Constructor with values
        /// </summary>
        /// <param name="first">first value</param>
        /// <param name="second">second value</param>
        public Pair(T first, U second) {
            this.First = first;
            this.Second = second;
        }

        /// <summary>
        /// get / set first value
        /// </summary>
        public T First { get; set; }

        /// <summary>
        /// get / set second value
        /// </summary>
        public U Second { get; set; }
    };

}
