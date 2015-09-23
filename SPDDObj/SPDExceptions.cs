using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SPD.Exceptions {
    /// <summary>
    /// 
    /// </summary>
    public class SPDException : Exception {
        private string url;
        private string where;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPDException"/> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        /// <param name="message">The message.</param>
        /// <param name="url">The URL.</param>
        public SPDException(Exception inner, string message, string url) 
            :base(message, inner) {
            StackFrame frame = new System.Diagnostics.StackTrace(true).GetFrame(1);
            this.where = "File: " + frame.GetFileName() + Environment.NewLine + "Method: " + frame.GetMethod().Name + Environment.NewLine + "Line: " + frame.GetFileLineNumber() + Environment.NewLine + "Col: " + frame.GetFileColumnNumber();
            this.url = url;
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url {
            get { return url; }
        }

        /// <summary>
        /// Gets the where.
        /// </summary>
        /// <value>The where.</value>
        public string Where {
            get { return where; }
        }

        /// <summary>
        /// Gets the short info.
        /// </summary>
        /// <returns></returns>
        public string GetShortInfo() {
            return "Press OK to Exit SPD" +
                   Environment.NewLine + Environment.NewLine +
                   "SPDException" + 
                   ((!string.IsNullOrEmpty(Message))
                       ? (Message + Environment.NewLine + Environment.NewLine)
                       : string.Empty) +
                   ((!string.IsNullOrEmpty(url))
                       ? ("Try to get help from: " + url + Environment.NewLine + Environment.NewLine)
                       : string.Empty) +
                   ((InnerException != null && InnerException is SPDException && !string.IsNullOrEmpty(InnerException.ToString()))
                       ? (((SPDException)InnerException).GetShortInfo())
                       : string.Empty) +
                   ((InnerException != null && !(InnerException is SPDException) && !string.IsNullOrEmpty(InnerException.ToString()))
                       ? (InnerException.Message)
                       : string.Empty);
        }

        /// <summary>
        /// Gets the detail info.
        /// </summary>
        /// <returns></returns>
        public string GetDetailInfo() {
            return "SPDException   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + 
                   ((!string.IsNullOrEmpty(Message))
                       ? (Message + Environment.NewLine)
                       : string.Empty) +
                   ((!string.IsNullOrEmpty(url))
                       ? ("Try to get help from: " + url + Environment.NewLine)
                       : string.Empty) +
                   ((!string.IsNullOrEmpty(where))
                       ? (where + Environment.NewLine)
                       : string.Empty) +
                   ((!string.IsNullOrEmpty(Source))
                       ? (Source + Environment.NewLine)
                       : string.Empty) +
                   ((!string.IsNullOrEmpty(StackTrace))
                       ? (StackTrace + Environment.NewLine)
                       : string.Empty) +
                   ((InnerException != null && InnerException is SPDException && !string.IsNullOrEmpty(InnerException.ToString()))
                       ? (((SPDException)InnerException).GetDetailInfo())
                       : string.Empty) +
                   ((InnerException != null && !(InnerException is SPDException) && !string.IsNullOrEmpty(InnerException.ToString()))
                       ? (InnerException.Message + Environment.NewLine + InnerException.Source + Environment.NewLine +  InnerException.StackTrace)
                       : string.Empty);
        }

    }
}
