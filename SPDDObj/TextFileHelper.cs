using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SPD.CommonUtilities {
    /// <summary>
    /// 
    /// </summary>
    public class TextFileHelper {
        ///<summary>
        /// Returns the content of a textfile.
        ///</summary>
        ///<param name="sFilename">file path</param>
        public static string ReadFile(String sFilename) {
            string sContent = "";

            if (File.Exists(sFilename)) {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }
            return sContent;
        }

        ///<summary>
        /// writes the given string into the given textfile.
        ///</summary>
        ///<param name="sFilename">file path</param>
        ///<param name="sLines">text to write</param>
        public static void WriteFile(String sFilename, String sLines) {
            StreamWriter myFile = new StreamWriter(sFilename);
            myFile.Write(sLines);
            myFile.Close();
        }

        ///<summary>
        /// appends the given string on the given textfile
        ///</summary>
        ///<param name="sFilename">file path</param>
        ///<param name="sLines">text</param>
        public static void Append(string sFilename, string sLines) {
            StreamWriter myFile = new StreamWriter(sFilename, true);
            myFile.Write(sLines);
            myFile.Close();
        }

        ///<summary>
        /// Returns the content of the given Line in the given TextFile
        ///</summary>
        ///<param name="sFilename">path of the File</param>
        ///<param name="iLine">Linenumber</param>
        public static string ReadLine(String sFilename, int iLine) {
            string sContent = string.Empty;
            float fRow = 0;
            if (File.Exists(sFilename)) {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                while (!myFile.EndOfStream && fRow < iLine) {
                    fRow++;
                    sContent = myFile.ReadLine();
                }
                myFile.Close();
                if (fRow < iLine)
                    sContent = string.Empty;
            }
            return sContent;
        }

        /// <summary>
        /// Writes the given Text into the given Line
        ///</summary>
        ///<param name="sFilename">file path</param>
        ///<param name="iLine">Linenumber</param>
        ///<param name="sLines">content of the Line</param>
        ///<param name="bReplace">true.. overwrite ; false insert</param>
        public static void WriteLine(String sFilename, int iLine, string sLines, bool bReplace) {
            string sContent = "";
            string[] delimiterstring = { Environment.NewLine };

            if (File.Exists(sFilename)) {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }

            string[] sCols = sContent.Split(delimiterstring, StringSplitOptions.None);

            if (sCols.Length >= iLine) {
                if (!bReplace)
                    sCols[iLine - 1] = sLines + Environment.NewLine + sCols[iLine - 1];
                else
                    sCols[iLine - 1] = sLines;

                sContent = string.Empty;
                for (int x = 0; x < sCols.Length - 1; x++) {
                    sContent += sCols[x] + Environment.NewLine;
                }
                sContent += sCols[sCols.Length - 1];

            } else {
                for (int x = 0; x < iLine - sCols.Length; x++)
                    sContent += Environment.NewLine;

                sContent += sLines;
            }


            StreamWriter mySaveFile = new StreamWriter(sFilename);
            mySaveFile.Write(sContent);
            mySaveFile.Close();
        }

    }
}