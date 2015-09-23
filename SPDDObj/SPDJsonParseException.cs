using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPD.Exceptions
{
    /// <summary>
    ///  SPD Json Parse Exception
    /// </summary>
    public class SPDJsonParseException : SPDException
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SPDException"/> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        /// <param name="message">The message.</param>
        /// <param name="url">The URL.</param>
        public SPDJsonParseException(Exception inner, string message, string url) : base(inner, message, url) {
            
        }
    }
}
