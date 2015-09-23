using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPD.GUI {
    /// <summary>
    /// Online SPD Info
    /// </summary>
    public class OnlineSPDInfo {
        private int version1Major = 0;
        private int version2Minor = 0;
        private int version3BuildNumber = 0;
        private int version4Revision = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineSPDInfo" /> class.
        /// </summary>
        /// <param name="onlineInfo">The online info.</param>
        public OnlineSPDInfo(string onlineInfo) {
            if (string.IsNullOrWhiteSpace(onlineInfo)) {
                return;
            }

            string[] lines = onlineInfo.Split(new char[] {'\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.StartsWith("LatestVersion") & line.Contains("=")) {
                    string value = line.Substring(line.IndexOf('=') + 1, line.Length - line.IndexOf('=') - 1);
                    string[] versionNumbers = value.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                    if (versionNumbers.Length >= 1)
                    {
                        Int32.TryParse(versionNumbers[0], out version1Major);
                    }
                    if (versionNumbers.Length >= 2) {
                        Int32.TryParse(versionNumbers[1], out version2Minor);
                    }
                    if (versionNumbers.Length >= 3) {
                        Int32.TryParse(versionNumbers[2], out version3BuildNumber);
                    }
                    if (versionNumbers.Length >= 4) {
                        Int32.TryParse(versionNumbers[3], out version4Revision);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the version1 major.
        /// </summary>
        /// <value>
        /// The version1 major.
        /// </value>
        public int Version1Major {
            get { return version1Major; }
            set { version1Major = value; }
        }

        /// <summary>
        /// Gets or sets the version2 minor.
        /// </summary>
        /// <value>
        /// The version2 minor.
        /// </value>
        public int Version2Minor {
            get { return version2Minor; }
            set { version2Minor = value; }
        }

        /// <summary>
        /// Gets or sets the version3 build number.
        /// </summary>
        /// <value>
        /// The version3 build number.
        /// </value>
        public int Version3BuildNumber {
            get { return version3BuildNumber; }
            set { version3BuildNumber = value; }
        }

        /// <summary>
        /// Gets or sets the version4 revision.
        /// </summary>
        /// <value>
        /// The version4 revision.
        /// </value>
        public int Version4Revision {
            get { return version4Revision; }
            set { version4Revision = value; }
        }
    }
}
