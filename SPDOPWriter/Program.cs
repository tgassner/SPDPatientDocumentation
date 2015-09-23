using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net.Appender;
using SPD.Exceptions;
using log4net.Layout;

namespace SPD.GUI.OPWriter {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            #if DEBUG
                log4net.Config.BasicConfigurator.Configure();
            #else
                ILayout layout = new SimpleLayout();
                FileAppender appender = new FileAppender();
                appender.Layout = layout;
                appender.File = "SPDOpWriter.log";
                appender.AppendToFile = true;
                log4net.Config.BasicConfigurator.Configure(appender);
            #endif

            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Info("SPD start up: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new OPWriterForm());
            } catch (Exception e) {
                handleSPDError(e);
            }
        }

        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            handleSPDError(e.Exception);
        }

        /// Handles the SPD errors.
        /// </summary>
        /// <param name="e">The e.</param>
        static private void handleSPDError(Exception e) {
            SPDException spdExcetion;
            if (e is SPDException) {
                spdExcetion = (SPDException)e;
            } else {
                spdExcetion = new SPDException(e, null, null);
            }
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Fatal(spdExcetion.GetDetailInfo());
            ShowErrorForm showErrorForm = new ShowErrorForm(spdExcetion);
            showErrorForm.ShowDialog();
            Application.Exit();
        }
    }
}
