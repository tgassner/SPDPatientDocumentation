using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;
using System.Drawing;
using System.IO;

namespace SPD.CommonUtilities {

    /// <summary>
    /// List view Comparer for sorting
    /// </summary>
    public class ListViewItemComparer : System.Collections.IComparer {
        private int col;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItemComparer"/> class.
        /// </summary>
        public ListViewItemComparer() {
            col = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewItemComparer"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        public ListViewItemComparer(int column) {
            col = column;
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value Condition Less than zero <paramref name="x"/> is less than <paramref name="y"/>. Zero <paramref name="x"/> equals <paramref name="y"/>. Greater than zero <paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.-or- <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other. </exception>
        public int Compare(object x, object y) {
            string xStr = ((ListViewItem)x).SubItems[col].Text;
            string yStr = ((ListViewItem)y).SubItems[col].Text;

            try {
                long xInt = Int64.Parse(xStr);
                long yInt = Int64.Parse(yStr);
                if (xInt == yInt) {
                    return 0;
                } else {
                    if (yInt > xInt) {
                        return -1;
                    } else {
                        return +1;
                    }
                }
            } catch (Exception) {}

            return String.Compare(xStr, yStr);
        }
    }

    /// <summary>
    /// Provides some static utilities
    /// </summary>
    public class StaticUtilities {

        /// <summary>
        /// Gets the SPD local change path.
        /// </summary>
        /// <returns>PAth</returns>
        public static string getSPDLocalChangePath() {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + Path.DirectorySeparatorChar +
                "SPD";

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        /// <summary>
        /// Comperer Patients by Wait List Date
        /// </summary>
        /// <param name="x">Patient a</param>
        /// <param name="y">Patient b</param>
        /// <returns></returns>
        public static int comparePatientsByWaitList(PatientData x, PatientData y) {
            if (x == null) {
                if (y == null) {
                    return 0;
                } else {
                    return -1;
                }
            } else {
                if (y == null) {
                    return 1;
                } else {
                    int retval = ((DateTime)x.WaitListStartDate).CompareTo(((DateTime)y.WaitListStartDate));

                    if (retval != 0) {
                        return retval;
                    } else {
                        return ((DateTime)x.WaitListStartDate).CompareTo(((DateTime)y.WaitListStartDate));
                    }
                }
            }
        }

        /// <summary>
        /// Gets the age from birth date.
        /// </summary>
        /// <param name="birthDate">The birth date.</param>
        /// <returns>Age</returns>
        public static string getAgeFromBirthDate(DateTime birthDate) {
            DateTime dt = new DateTime(Math.Abs(DateTime.Now.Ticks - birthDate.Ticks));
            int years = dt.Year - 1;
            if (years >= 2) {
                return years.ToString();
            } else {
                double months = (1.0 / 12.0) * (double)(dt.Month - 1);
                months = Math.Round(months, 2);
                if (years == 0) {
                    return months.ToString();
                } else {
                    if (years == 1) {
                        return (months + 1.0).ToString();
                    } else {
                        MessageBox.Show("Bitte Gassi Melden da darf das Programm nicht herkommen! CommonUtils Birth to Age");
                    }
                }
            }
            return (dt.Year - 1).ToString();
        }

        /// <summary>
        /// Gets the birth date from age.
        /// </summary>
        /// <param name="age">The age.</param>
        /// <returns>Birthdate</returns>
        public static DateTime getBirthDateFromAge(int age) {
            return new DateTime(DateTime.Today.Year - age, DateTime.Today.Month, 1);
        }

        /// <summary>
        /// Compares the operations by date.
        /// </summary>
        /// <param name="x">The OperatioData 1</param>
        /// <param name="y">The OperatioData 2</param>
        /// <returns></returns>
        private static int CompareOperationsByDate(OperationData x, OperationData y) {
            if (x == null) {
                if (y == null) {
                    return 0;
                } else {
                    return -1;
                }
            } else {
                if (y == null) {
                    return 1;
                } else {
                    int comp = x.Date.CompareTo(y.Date);
                    if (comp == 0) {
                        return x.OperationId.CompareTo(y.OperationId);
                    } else {
                        return comp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the operation list by date.
        /// </summary>
        /// <param name="operations">The operations.</param>
        /// <returns>sorted List of operations</returns>
        public static IList<OperationData> SortOperationListByDate(IList<OperationData> operations){
            List<OperationData> list = new List<OperationData>(operations);
            list.Sort(CompareOperationsByDate);
            return list;
        }

        /// <summary>
        /// Compares the visits by date.
        /// </summary>
        /// <param name="x">The VisitData 1</param>
        /// <param name="y">The VisitData 2</param>
        /// <returns></returns>
        private static int CompareVisitsByDate(VisitData x, VisitData y) {
            if (x == null) {
                if (y == null) {
                    return 0;
                } else {
                    return -1;
                }
            } else {
                if (y == null) {
                    return 1;
                } else {
                    int comp = x.VisitDate.CompareTo(y.VisitDate);
                    if (comp == 0) {
                        return x.Id.CompareTo(y.Id);
                    } else {
                        return comp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the visits list by date.
        /// </summary>
        /// <param name="visits">The visits.</param>
        /// <returns>Sorted List of visits</returns>
        public static IList<VisitData> SortVisitsListByDate(IList<VisitData> visits) {
            List<VisitData> list = new List<VisitData>(visits);
            list.Sort(CompareVisitsByDate);
            return list;
        }

        /// <summary>
        /// Checks if Font is installed
        /// </summary>
        /// <param name="fontFamilyName">the name of the Font family</param>
        /// <returns></returns>
        public static bool IsFontInstalled(string fontFamilyName) {
            foreach (FontFamily family in FontFamily.Families) {
                if (String.Equals(family.Name, fontFamilyName)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Getns the th visit.
        /// </summary>
        /// <param name="visitList">The visit list.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public static VisitData GetnThVisit(IList<VisitData> visitList, int n) {
            if (n == 0) {
                throw new NotSupportedException("Parameter n must not be 0!!");
            }
            
            if (visitList == null || visitList.Count == 0 || (visitList.Count < n && n > 0)) {
                return null;
            }

            List<long> ticks = new List<long>();

            foreach (var visitData in visitList)
            {
                ticks.Add(visitData.VisitDate.Ticks);
            }

            ticks.Sort();

            long retTick;
            if (n < 0) {
                retTick = ticks[ticks.Count - 1];
            } else {
                retTick = ticks[n - 1];
            }

            foreach (VisitData visit in visitList) {
                if (visit.VisitDate.Ticks == retTick) {
                    return visit;
                }
            }

            throw new NotSupportedException("Programming Error! Please report Thomas Gassner CommonUtilies.GetnThVisit");
        }

        /// <summary>
        /// Newests the OP.
        /// </summary>
        /// <param name="operationList">The operation list.</param>
        /// <returns></returns>
        public static OperationData NewestOP(IList<OperationData> operationList) {
            OperationData newestOperation = null;
            foreach (OperationData operation in operationList) {
                if (newestOperation == null) {
                    newestOperation = operation;
                } else {
                    if (operation.Date.Ticks > newestOperation.Date.Ticks) {
                        newestOperation = operation;
                    } else {
                        if (operation.Date.Ticks == newestOperation.Date.Ticks) {
                            if (operation.OperationId > newestOperation.OperationId) {
                                newestOperation = operation;
                            }
                        }
                    }
                }
            }
            return newestOperation;
        }

        /// <summary>
        /// Oldest the OP.
        /// </summary>
        /// <param name="operationList">The operation list.</param>
        /// <returns></returns>
        public static OperationData OldestOP(IList<OperationData> operationList) {
            OperationData oldestOperation = null;
            foreach (OperationData operation in operationList) {
                if (oldestOperation == null) {
                    oldestOperation = operation;
                } else {
                    if (operation.Date.Ticks < oldestOperation.Date.Ticks) {
                        oldestOperation = operation;
                    } else {
                        if (operation.Date.Ticks == oldestOperation.Date.Ticks) {
                            if (operation.OperationId < oldestOperation.OperationId) {
                                oldestOperation = operation;
                            }
                        }
                    }
                }
            }
            return oldestOperation;
        }
    }
}
