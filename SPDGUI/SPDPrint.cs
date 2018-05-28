using System;
using System.Collections.Generic;
using System.Text;
using GPrintLib;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using System.Drawing;
using SPD.CommonUtilities;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace SPD.Print {
    /// <summary>
    /// 
    /// </summary>
    public class SPDPrint {

        private int A4smallSite = 826;
        private int A4LargeSite = 1169;

        private ISPDBL patComp;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPDPrint"/> class.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        public SPDPrint(ISPDBL patComp) {
            this.patComp = patComp;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PrintFormat {
            /// <summary>
            /// 
            /// </summary>
            A4,
            /// <summary>
            /// 
            /// </summary>
            A3
        }

        /// <summary>
        /// Prints the a3 temperatur curve.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <param name="weeks">The weeks.</param>
        /// <param name="copies">The copies.</param>
        /// <param name="printFormat">The print format.</param>
        /// <param name="opParam">The op.</param>
        public void PrintA3TemperaturCurve(IList<PatientData> patients, int weeks, int copies, PrintFormat printFormat, OperationData opParam) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            if (copies < 1 || copies > 20) {
                return;
            }

            if (opParam != null && patients.Count != 1) {
                return;
            }

            IList<PrintablePage> printablePageA4 = new List<PrintablePage>();
            IList<PrintablePage> printablePageA3 = new List<PrintablePage>();

            PrintableDocument pd = new PrintableDocument();

            Font headlineFont = new Font("Arial", 18.0f, FontStyle.Underline | FontStyle.Bold);
            Font dateFont = new Font("Arial", 10.5f, FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Bold);
            Font medicationFont = new Font("Arial", 10, FontStyle.Bold);
            Font symbolFont = new Font("Arial", 22, FontStyle.Bold);

            float leftMargin = 65;
            float topMargin = 30;

            foreach (PatientData patient in patients) {
                int daysSinceOp = 0;
                OperationData op;
                if (opParam == null) {
                    op = patComp.GetLastOperationByPatientID(patient.Id);
                } else {
                    op = opParam;
                }

                if (op == null) {
                    continue;
                }

                IList<string> medications = new List<string>();
                IList<int> medDays = new List<int>();
                bool hasCatheter = op.KathDays > 0;
                long kathDays = op.KathDays + 1; //CR ignoring OP Day.

                fillMedications(op, medications, medDays);

                //count = 0;
                
                DateTime opDate = op.Date;
                for (int week = 0; week < weeks; week++) {
                    //PrintablePage pp = new PrintablePage();
                    PrintablePage a4Page = new PrintablePage();
                    PrintablePage a3Page = new PrintablePage();

                    //Organ Images...
                    handleOrganImage(topMargin, op, a4Page, a3Page);

                    addPrintableTextObject(1, a4Page, a3Page, "Paediatric Urology Team Austria", headlineFont, new SolidBrush(Color.FromArgb(0, 61, 120)), leftMargin, topMargin + (float)(0 * 17.56));

                    addPrintableTextObject(1, a4Page, a3Page, "Paediatric Urology Team Austria", headlineFont, new SolidBrush(Color.FromArgb(0, 61, 120)), leftMargin, topMargin + (float)(0 * 17.56));
                    addPrintableTextObject(1, a4Page, a3Page, op.Date.Month.ToString() + " " + op.Date.Year.ToString() + "   Page: " + (week + 1), dateFont, Brushes.Red, leftMargin + 250, topMargin + (float)28.74);

                    addPrintableTextObject(1, a4Page, a3Page, "Additional Information:", printFont, Brushes.Black, leftMargin + (float)610, topMargin + 10F);
                    //pp.AddPrintableObject(new PrintableTextObject("Notes - Final Report:", printFont, Brushes.Black, leftMargin + (float)635, topMargin + 120F));

                    addPrintableLineObject(1, a4Page, a3Page, Pens.Black, (int)leftMargin + 610, (int)topMargin + 27, (int)leftMargin + 635 + 175, (int)topMargin + 27);
                    //pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin + 635, (int)topMargin + 137, (int)leftMargin + 635 + 200, (int)topMargin + 137));

                    Bitmap imgKinderurologieLogo = SPD.GUI.Properties.Resources.KinderurologieLogo;
                    imgKinderurologieLogo.SetResolution(408, 408);
                    addPrintableImageObject(1, a4Page, a3Page, imgKinderurologieLogo, 500, (int)topMargin);

                    addPrintableRectangleObject(1, a4Page, a3Page, Brushes.Yellow, (int)leftMargin - 5 + 3, (int)topMargin + 198 - (2 * 17), 600, (int)printFont.GetHeight());

                    //Additional Info Rectangle
                    addPrintableRectangleObject(1, a4Page, a3Page, Pens.Black, (int)(leftMargin + 605), (int)topMargin, 300, 220);
                    addPrintableLineObject(1, a4Page, a3Page, Pens.Black, (int)(leftMargin + 605), (int)topMargin + 110, (int)(leftMargin + 605 + 300), (int)topMargin + 110);

                    List<string> addInfo = new List<string>();
                    addInfo.Add(op.Additionalinformation.Replace(Environment.NewLine, " "));
                    addInfo = this.SplitStringsForPrinting(40, addInfo);
                    int count = 0;
                    foreach (string line in addInfo) {
                        addPrintableTextObject(1, a4Page, a3Page, line, printFont, Brushes.Black, leftMargin + (float)610, topMargin + 27F + count * 17);
                        count++;
                    }

                    float y = (float)topMargin + (float)(3 * 17.56) - 8;

                    float leftMarginValues = leftMargin + 160;

                    addPrintableTextObject(1, a4Page, a3Page, "Patient ID: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, patient.Id.ToString(), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;

                    addPrintableTextObject(1, a4Page, a3Page, "First name: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, patient.FirstName.Replace(Environment.NewLine, " "), printFont, Brushes.Black, leftMarginValues, y);

                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "Surname: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, patient.SurName.Replace(Environment.NewLine, " "), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "Birthdate: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, ((patient.DateOfBirth == null || patient.DateOfBirth.Year < 1800) ? "undefined" : patient.DateOfBirth.ToShortDateString() + " - Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth)), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "Weight: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, patient.Weight.ToString(), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;
                    
                    addPrintableTextObject(1, a4Page, a3Page, "Resident of Asmara: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, patient.ResidentOfAsmara.ToString(), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "OP Date: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, op.Date.ToShortDateString(), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "OP Diagnosis:", printFont, Brushes.Black, leftMargin, y);
                    if (op.Diagnoses.Replace(Environment.NewLine, " ").Length > 60) {
                        List<string> diagnosesList = new List<string>();
                        diagnosesList.Add(op.Diagnoses.Replace(Environment.NewLine, " "));
                        diagnosesList = SplitStringsForPrinting(60, diagnosesList);
                        if (diagnosesList.Count >= 1) {
                            addPrintableTextObject(1, a4Page, a3Page, diagnosesList[0], printFont, Brushes.Black, leftMarginValues, y);
                        }
                        if (diagnosesList.Count >= 2) {
                            y += 17;
                            addPrintableTextObject(1, a4Page, a3Page, diagnosesList[1], printFont, Brushes.Black, leftMarginValues, y);
                        }
                    } else {
                        addPrintableTextObject(1, a4Page, a3Page, op.Diagnoses.Replace(Environment.NewLine, " "), printFont, Brushes.Black, leftMarginValues, y);
                    }
                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "Performed OP: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, op.Performed.Replace(Environment.NewLine, " "), printFont, Brushes.Black, leftMarginValues, y);
                    y += 17;
                    addPrintableTextObject(1, a4Page, a3Page, "OP Team: ", printFont, Brushes.Black, leftMargin, y);
                    addPrintableTextObject(1, a4Page, a3Page, op.Team.Replace(Environment.NewLine, " "), printFont, Brushes.Black, leftMarginValues, y);

                    //Gray Box
                    addPrintableRectangleObject(1, a4Page, a3Page, Brushes.LightGray, 40, 270, 6 * 182, 30);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40 + j * 182, 270, 40 + j * 182, 270 + 7 * 30);
                    }
                    //horizintal lines
                    for (int j = 0; j < 8; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40, 270 + j * 30, 40 + 6 * 182, 270 + j * 30);
                    }

                    ////Beschriftung begin

                    if (kathDays > (week * 12)) {
                        addPrintableTextObject(1, a4Page, a3Page, "catheter", printFont, Brushes.Black, 41, 305 + 5 * 30);
                    }

                    count = 0;
                    foreach (string medication in medications) {
                        if (week == 0) {
                            addPrintableTextObject(1, a4Page, a3Page, medication, medicationFont, Brushes.Black, 41, 305 + count * 30);
                        } else if (medDays[medications.IndexOf(medication)] >= ((week * 12) + 1)) {
                            addPrintableTextObject(1, a4Page, a3Page, medication, medicationFont, Brushes.Black, 41, 305 + count * 30);
                        }
                        for (int j = 0; j < 6; j++) {
                            int currentMedDay = (week * 12 + j) + 1;
                            if ((currentMedDay > 1) && (((currentMedDay - 1) % 6) != 0) && (medDays[count] >= (currentMedDay + 1))) {
                                addPrintableTextObject(1, a4Page, a3Page, "      -", symbolFont, Brushes.Black, 41 + j * 182, (305 + count * 30) - 10);
                            }
                            if ((medDays[count] == currentMedDay)) {
                                addPrintableTextObject(1, a4Page, a3Page, "      -          >", symbolFont, Brushes.Black, 41 + j * 182, (305 + count * 30) - 10);
                            }
                        }
                        count++;
                    }

                    for (int j = 0; j < 6; j++) {
                        int currentMedDay = (week * 12 + j) + 1;
                        if (hasCatheter && (currentMedDay == kathDays)) {
                            if (((kathDays - 1) % 12) == 0) {
                                addPrintableTextObject(1, a4Page, a3Page, "                 DK ex ", printFont, Brushes.Black, 41 + j * 182, 305 + 5 * 30);
                            } else {
                                addPrintableTextObject(1, a4Page, a3Page, "DK ex ", printFont, Brushes.Black, 41 + j * 182, 305 + 5 * 30);
                            }
                        } else if (hasCatheter && (currentMedDay < kathDays) && ((currentMedDay - 1) % 12) != 0) {
                            addPrintableTextObject(1, a4Page, a3Page, "      -", symbolFont, Brushes.Black, 41 + j * 182, 305 + 5 * 30 - 9);
                        }
                    }

                    //Kalendar Überschrift
                    for (int j = 0; j < 6; j++) {
                        addPrintableTextObject(1, a4Page, a3Page, "     " + opDate.DayOfWeek.ToString() + " " + opDate.ToShortDateString(), dateFont, Brushes.Blue, 41 + j * 182, 275);
                        if (daysSinceOp == 0) {
                            addPrintableTextObject(1, a4Page, a3Page, "op", dateFont, Brushes.Red, 41 + j * 182, 275);
                        } else {
                            addPrintableTextObject(1, a4Page, a3Page, daysSinceOp.ToString(), dateFont, Brushes.Red, 41 + j * 182, 275);
                        }
                        opDate = opDate.AddDays(1.0);
                        daysSinceOp++;
                    }

                    //// Beschriftung ende

                    int yNursing = 500;
                    addPrintableTextObject(1, a4Page, a3Page, "Nursing and medical orders:", printFont, Brushes.Black, 41, yNursing);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40 + j * 182, yNursing + 20, 40 + j * 182, yNursing + 150);
                    }
                    //horizintal lines
                    addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40, yNursing + 20, 40 + 6 * 182, yNursing + 20);
                    addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40, yNursing + 150, 40 + 6 * 182, yNursing + 150);

                    int yTemperature = 670;
                    addPrintableTextObject(1, a4Page, a3Page, "Temperature:", printFont, Brushes.Black, 41, yTemperature);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40 + j * 182, yTemperature + 20, 40 + j * 182, yTemperature + 20 + 1/*=number of lines*/ * 30);
                    }
                    //horizintal lines
                    for (int j = 0; j < 2; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40, yTemperature + 20 + j * 30, 40 + 6 * 182, yTemperature + 20 + j * 30);
                    }

                    //Local status
                    int yLocalStatus = 735;
                    addPrintableTextObject(1, a4Page, a3Page, "Localstatus:", printFont, Brushes.Black, 41, yLocalStatus);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40 + j * 182, yLocalStatus + 20, 40 + j * 182, yLocalStatus + 20 + 1/*=number of lines*/ * 30);
                    }
                    //horizintal lines
                    for (int j = 0; j < 2; j++) {
                        addPrintableLineObject(1, a4Page, a3Page, Pens.Black, 40, yLocalStatus + 20 + j * 30, 40 + 6 * 182, yLocalStatus + 20 + j * 30);
                    }

                    printablePageA4.Add(a4Page);
                    a4Page = new PrintablePage();

                    a3Page.AddPrintableObject(new PrintableLineObject(Pens.LightGray, 0, A4smallSite + 45, A4LargeSite, A4smallSite + 45));

                    //2. seite

                    addPrintableTextObject(2, a4Page, a3Page, "Patient ID: " + patient.Id.ToString(), printFont, Brushes.Black, leftMargin, 13 + 45);

                    //Gray Box
                    int calendary = (int)topMargin + 45;
                    addPrintableRectangleObject(2, a4Page, a3Page, Brushes.LightGray, 40, calendary, 6 * 182, 30);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40 + j * 182, calendary, 40 + j * 182, calendary + 7 * 30);
                    }
                    //horizintal lines
                    for (int j = 0; j < 8; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40, calendary + j * 30, 40 + 6 * 182, calendary + j * 30);
                    }

                    ////Beschriftung begin

                    if (kathDays > ((week * 12) + 6)) {
                        addPrintableTextObject(2, a4Page, a3Page, "catheter", printFont, Brushes.Black, 41, calendary + 5 + 6 * 30);
                    }

                    count = 0;
                    foreach (string medication in medications) {
                        if (medDays[medications.IndexOf(medication)] >= ((week * 12) + 7)) {
                            addPrintableTextObject(2, a4Page, a3Page, medication, medicationFont, Brushes.Black, 41, calendary + 5 + 30 + count * 30);
                        }
                        for (int j = 0; j < 6; j++) {
                            int currentMedDay = (week * 12 + j) + 1 + 6;
                            if (((currentMedDay - 1) % 6) != 0 && (medDays[count] >= (currentMedDay + 1))) {
                                addPrintableTextObject(2, a4Page, a3Page, "      -", symbolFont, Brushes.Black, 41 + j * 182, (calendary + 5 + 30 + count * 30) - 10);
                            }
                            if ((medDays[count] == currentMedDay)) {
                                addPrintableTextObject(2, a4Page, a3Page, "      -          >", symbolFont, Brushes.Black, 41 + j * 182, (calendary + 5 + 30 + count * 30) - 10);
                            }
                        }
                        count++;
                    }

                    for (int j = 0; j < 6; j++) {
                        int currentMedDay = (week * 12 + j) + 1 + 6;
                        if (hasCatheter && (currentMedDay == kathDays)) {
                            if (((kathDays - 7) % 12) == 0) {
                                addPrintableTextObject(2, a4Page, a3Page, "                 DK ex ", printFont, Brushes.Black, 41 + j * 182, calendary + 5 + 6 * 30);
                            } else {
                                addPrintableTextObject(2, a4Page, a3Page, "DK ex ", printFont, Brushes.Black, 41 + j * 182, calendary + 5 + 6 * 30);
                            }
                        } else if (hasCatheter && (currentMedDay < kathDays) && ((currentMedDay - 7) % 12) != 0) {
                            addPrintableTextObject(2, a4Page, a3Page, "      -", symbolFont, Brushes.Black, 41 + j * 182, calendary + 5 + 6 * 30 - 9);
                        }
                    }

                    //Kalendar Überschrift
                    for (int j = 0; j < 6; j++) {
                        addPrintableTextObject(2, a4Page, a3Page, "     " + opDate.DayOfWeek.ToString() + " " + opDate.ToShortDateString(), dateFont, Brushes.Blue, 41 + j * 182, calendary + 5);
                        if (daysSinceOp == 0) {
                            addPrintableTextObject(2, a4Page, a3Page, "op", dateFont, Brushes.Red, 41 + j * 182, calendary + 5);
                        } else {
                            addPrintableTextObject(2, a4Page, a3Page, daysSinceOp.ToString(), dateFont, Brushes.Red, 41 + j * 182, calendary + 5);
                        }
                        opDate = opDate.AddDays(1.0);
                        daysSinceOp++;
                    }

                    //// Beschriftung ende

                    yNursing = 295;
                    addPrintableTextObject(2, a4Page, a3Page, "Nursing and medical orders:", printFont, Brushes.Black, 41, yNursing);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40 + j * 182, yNursing + 20, 40 + j * 182, yNursing + 150);
                    }
                    //horizintal lines
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40, yNursing + 20, 40 + 6 * 182, yNursing + 20);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40, yNursing + 150, 40 + 6 * 182, yNursing + 150);


                    yTemperature = 455; 
                    addPrintableTextObject(2, a4Page, a3Page, "Temperature:", printFont, Brushes.Black, 41, yTemperature);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40 + j * 182, yTemperature + 20, 40 + j * 182, yTemperature + 20 + 1/*=number of lines*/ * 30);
                    }
                    //horizintal lines
                    for (int j = 0; j < 2; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40, yTemperature + 20 + j * 30, 40 + 6 * 182, yTemperature + 20 + j * 30);
                    }

                    //Local Status
                    yLocalStatus = 520; 
                    addPrintableTextObject(2, a4Page, a3Page, "Localstatus:", printFont, Brushes.Black, 41, yLocalStatus);
                    //vertical lines
                    for (int j = 0; j < 7; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40 + j * 182, yLocalStatus + 20, 40 + j * 182, yLocalStatus + 20 + 1/*=number of lines*/ * 30);
                    }
                    //horizintal lines
                    for (int j = 0; j < 2; j++) {
                        addPrintableLineObject(2, a4Page, a3Page, Pens.Black, 40, yLocalStatus + 20 + j * 30, 40 + 6 * 182, yLocalStatus + 20 + j * 30);
                    }

                    int y3rdBlock = 580;
                    int widthlastbox = 335;
                    int xft = 41;
                    int xcont = xft + widthlastbox + xft;
                    int xfo = xft + widthlastbox + xft + widthlastbox + xft;
                    
                    addPrintableTextObject(2, a4Page, a3Page, "Further Treatment for discharge:", printFont, Brushes.Black, xft, y3rdBlock);
                    addPrintableTextObject(2, a4Page, a3Page, "Control(s) planned for:", printFont, Brushes.Black, xcont, y3rdBlock);
                    addPrintableTextObject(2, a4Page, a3Page, "Further operation planned for:", printFont, Brushes.Black, xfo, y3rdBlock);

                    //3 oberen Linien der Boxen
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft, y3rdBlock + 20, xft + widthlastbox, y3rdBlock + 20);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft, y3rdBlock + 20, xft + widthlastbox + xft + widthlastbox, y3rdBlock + 20);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft + widthlastbox + xft, y3rdBlock + 20, xft + widthlastbox + xft + widthlastbox + xft + widthlastbox, y3rdBlock + 20);
                    //3 unteren Linien der Boxen
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft, y3rdBlock + 177, xft + widthlastbox, y3rdBlock + 177);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft, y3rdBlock + 200, xft + widthlastbox + xft + widthlastbox, y3rdBlock + 200);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft + widthlastbox + xft, y3rdBlock + 200, xft + widthlastbox + xft + widthlastbox + xft + widthlastbox, y3rdBlock + 200);

                    //vertikale Linien der Boxen
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft, y3rdBlock + 20, xft, y3rdBlock + 177);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox, y3rdBlock + 20, xft + widthlastbox, y3rdBlock + 177);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft, y3rdBlock + 20, xft + widthlastbox + xft, y3rdBlock + 200);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft + widthlastbox, y3rdBlock + 20, xft + widthlastbox + xft + widthlastbox, y3rdBlock + 200);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft + widthlastbox + xft, y3rdBlock + 20, xft + widthlastbox + xft + widthlastbox + xft, y3rdBlock + 200);
                    addPrintableLineObject(2, a4Page, a3Page, Pens.Black, xft + widthlastbox + xft + widthlastbox + xft + widthlastbox, y3rdBlock + 20, xft + widthlastbox + xft + widthlastbox + xft + widthlastbox, y3rdBlock + 200);

                    addPrintableTextObject(2, a4Page, a3Page, "Treatment completed: yes        no", printFont, Brushes.Black, xft, y3rdBlock + 180);
                    addPrintableRectangleObject(2, a4Page, a3Page, Pens.Black, xft + 195, y3rdBlock + 180, 20, 20);
                    addPrintableRectangleObject(2, a4Page, a3Page, Pens.Black, xft + 246, y3rdBlock + 180, 20, 20);

                    printablePageA4.Add(a4Page);
                    printablePageA3.Add(a3Page);
                }
            }

            pd.PrintPageList = printablePageA3;
            pd.duplicate(copies);
            pd.Landscape = false;
            pd.DocumentName = "SPD Temperature Curve A3";

            PrintDialog printDialog = null;

            if (printFormat == PrintFormat.A3) {
                pd.PaperKindOrNothing = PaperKind.A3;

                printDialog = pd.DoPrint();

                if (printDialog != null) {
                    pd.PaperKindOrNothing = PaperKind.A4;
                    pd.Landscape = true;
                    pd.PrintPageList = printablePageA4;
                    pd.duplicate(copies);
                    printDialog = pd.DoPrint(printDialog);
                }

            } else if (printFormat == PrintFormat.A4) {
                pd.PaperKindOrNothing = PaperKind.A4;

                printDialog = pd.DoPrint();
            }
            
            if (printDialog != null) {
                MessageBox.Show("Sorry - printing not possible!");
            }
            
        }

        private void handleOrganImage(float topMargin, OperationData op, PrintablePage a4Page, PrintablePage a3Page) {
            Bitmap imgOrgan;

            switch (op.Organ) {
                case Organ.penis:
                    imgOrgan = SPD.GUI.Properties.Resources.Penis;
                    imgOrgan.SetResolution(250, 250);
                    addPrintableImageObject(1, a4Page, a3Page, imgOrgan, 980, (int)topMargin + 15);
                    break;
                case Organ.renal:
                    imgOrgan = SPD.GUI.Properties.Resources.Reneal;
                    imgOrgan.SetResolution(500, 500);
                    addPrintableImageObject(1, a4Page, a3Page, imgOrgan, 980, (int)topMargin + 15);
                    break;
                case Organ.testicle:
                    imgOrgan = SPD.GUI.Properties.Resources.Testicle;
                    imgOrgan.SetResolution(400, 400);
                    addPrintableImageObject(1, a4Page, a3Page, imgOrgan, 970, (int)topMargin + 15);
                    break;
                default:
                    imgOrgan = null;
                    break;
            }
        }

        private static void fillMedications(OperationData op, IList<string> medications, IList<int> medDays) {
            foreach (string med in op.Medication.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)) {
                if (!String.IsNullOrEmpty(med)) {
                    string tmpMed = med.Trim();
                    string[] parts = tmpMed.Split(new String[] { }, StringSplitOptions.None);
                    int days = 0;
                    try {
                        days = Int32.Parse(parts[parts.Length - 1]);
                    } catch (Exception) { }
                    medDays.Add(days + 1); // + 1 => CR ignoring OP Day.
                    if (days > 0) {
                        StringBuilder sb = new StringBuilder();
                        for (int j = 0; j < (parts.Length - 1); j++) {
                            sb.Append(parts[j]);
                            if (j < (parts.Length - 2)) {
                                sb.Append(" ");
                            }
                        }
                        tmpMed = sb.ToString();
                    } else {
                        tmpMed = med;
                    }
                    medications.Add(tmpMed);
                }
            }
        }

        /// <summary>
        /// Adds the printable text object.
        /// </summary>
        /// <param name="a3page">The a3page.</param>
        /// <param name="pA4">The p a4.</param>
        /// <param name="pA3">The p a3.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        private void addPrintableTextObject(int a3page, PrintablePage pA4, PrintablePage pA3, string text, Font font, Brush brush, float x, float y) {
            pA4.AddPrintableObject(new PrintableTextObject(text, font, brush, x, y));
            if (a3page > 1) {
                pA3.AddPrintableObject(new PrintableTextObject(text, font, brush, x, y + A4smallSite));
            } else {
                pA3.AddPrintableObject(new PrintableTextObject(text, font, brush, x, y));
            }
        }

        /// <summary>
        /// Adds the printable line object.
        /// </summary>
        /// <param name="a3page">The a3page.</param>
        /// <param name="pA4">The p a4.</param>
        /// <param name="pA3">The p a3.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        private void addPrintableLineObject(int a3page, PrintablePage pA4, PrintablePage pA3, Pen pen, int x1, int y1, int x2, int y2) {
            pA4.AddPrintableObject(new PrintableLineObject(pen, x1, y1, x2, y2));
            if (a3page > 1) {
                pA3.AddPrintableObject(new PrintableLineObject(pen, x1, y1 + A4smallSite, x2, y2 + A4smallSite));
            } else {
                pA3.AddPrintableObject(new PrintableLineObject(pen, x1, y1, x2, y2));
            }
        }

        /// <summary>
        /// Adds the printable rectangle object.
        /// </summary>
        /// <param name="a3page">The a3page.</param>
        /// <param name="pA4">The p a4.</param>
        /// <param name="pA3">The p a3.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private void addPrintableRectangleObject(int a3page, PrintablePage pA4, PrintablePage pA3, Brush brush,int x,int y,int width,int height) {
            pA4.AddPrintableObject(new PrintableRectangleObject(brush, x, y, width, height));
            if (a3page > 1) {
                pA3.AddPrintableObject(new PrintableRectangleObject(brush, x, y + A4smallSite, width, height));
            } else {
                pA3.AddPrintableObject(new PrintableRectangleObject(brush, x, y, width, height));
            }
        }


        /// <summary>
        /// Adds the printable rectangle object.
        /// </summary>
        /// <param name="a3page">The a3page.</param>
        /// <param name="pA4">The p a4.</param>
        /// <param name="pA3">The p a3.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private void addPrintableRectangleObject(int a3page, PrintablePage pA4, PrintablePage pA3, Pen pen, int x, int y, int width, int height) {
            pA4.AddPrintableObject(new PrintableRectangleObject(pen, x, y, width, height));
            if (a3page > 1) {
                pA3.AddPrintableObject(new PrintableRectangleObject(pen, x, y + A4smallSite, width, height));
            } else {
                pA3.AddPrintableObject(new PrintableRectangleObject(pen, x, y, width, height));
            }
        }

        /// <summary>
        /// Adds the printable rectangle object.
        /// </summary>
        /// <param name="a3page">The a3page.</param>
        /// <param name="pA4">The p a4.</param>
        /// <param name="pA3">The p a3.</param>
        /// <param name="image">The image.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        private void addPrintableImageObject(int a3page, PrintablePage pA4, PrintablePage pA3, Image image, int x, int y) {
            pA4.AddPrintableObject(new PrintableImageObject(image, x, y));
            if (a3page > 1) {
                pA3.AddPrintableObject(new PrintableImageObject(image, x, y + A4smallSite));
            } else {
                pA3.AddPrintableObject(new PrintableImageObject(image, x, y));
            }
        }

        private void putLetterhead(PrintablePage pp) {
            Bitmap img = SPD.GUI.Properties.Resources.letterhead;
            //img.SetResolution();
            pp.AddPrintableObject(new PrintableImageObject(img, 0, 0));
        }

        public void PrintStoneReport(IList<PatientData> patients, bool operations, bool visits) {
            if (patients == null || patients.Count == 0)
            {
                return;
            }

            float leftMargin = 100;
            float topMargin = 100;

            Font headlineFont = new Font("Arial", 18.0f, FontStyle.Underline | FontStyle.Bold);
            Font dateFont = new Font("Arial", 12f, FontStyle.Bold);
            Font finalReportFont = new Font("Arial", 14.0f, FontStyle.Underline | FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Regular);
            Font fatFont = new Font("Arial", 11, FontStyle.Bold);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode)
            {
                barCodeFont = new Font("Free 3 of 9 Extended", 35, FontStyle.Regular, GraphicsUnit.Point);
            }

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Stone Report";

            foreach (PatientData patient in patients)
            {
                PrintablePage pp = new PrintablePage();
               
                putLetterhead(pp);

                float yPos = (float)topMargin + (float)(4 * 16.86523);
                if (barCodeFont != null)
                {
                    pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 500, yPos));
                }
                pp.AddPrintableObject(new PrintableTextObject("Patient ID: " + patient.Id.ToString(), printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("First name: " + patient.FirstName, printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("Surname: " + patient.SurName, printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth), printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                yPos += 16.86523F;

                if (operations) {
                    IList<OperationData> ops = patComp.GetOperationsByPatientID(patient.Id);

                    if (ops != null && ops.Count != 0) {

                        pp.AddPrintableObject(new PrintableTextObject("Operations", fatFont, Brushes.Black, leftMargin, yPos));
                        yPos += 16.86523F;

                        foreach (OperationData op in ops.Reverse()) {
                            pp.AddPrintableObject(new PrintableTextObject("OP Date: " + op.Date.ToShortDateString(), printFont, Brushes.Black, leftMargin, yPos));
                            pp.AddPrintableObject(new PrintableTextObject("                                             OP Team: " + op.Team.Replace('\n', ' ').Replace('\r', ' '), printFont, Brushes.Black, leftMargin, yPos));
                            yPos += 16.86523F;

                            if (!String.IsNullOrWhiteSpace(op.Diagnoses))
                            {
                                List<string> strs = new List<string>();
                                strs.Add(op.Diagnoses.Replace('\n', ' ').Replace('\r', ' '));
                                strs = SplitStringsForPrinting(75, strs);

                                pp.AddPrintableObject(new PrintableTextObject("OP Diagnosis: " + strs[0], printFont, Brushes.Black, leftMargin, yPos));
                                yPos += 16.86523F;

                                for (int i = 1; i < strs.Count; i++)
                                {
                                    pp.AddPrintableObject(new PrintableTextObject("   " + strs[i], printFont, Brushes.Black, leftMargin, yPos));
                                    yPos += 16.86523F;
                                }
                            }

                            pp.AddPrintableObject(new PrintableTextObject(
                                "Performed OP: " + op.Performed.Replace('\n', ' ').Replace('\r', ' '), printFont,
                                Brushes.Black, leftMargin, yPos));
                            yPos += 16.86523F;
                            yPos += 5.621743333333333F; // 1/3 Zeile
                        }
                    }
                }

                if (visits)
                {
                    IList<VisitData> vis = patComp.GetVisitsByPatientID(patient.Id);

                    if (vis != null && vis.Count != 0) {

                        pp.AddPrintableObject(new PrintableTextObject("Visits", fatFont, Brushes.Black, leftMargin, yPos));
                        yPos += 16.86523F;
                        
                        foreach (VisitData vi in vis.Reverse()) {
                            pp.AddPrintableObject(new PrintableTextObject("Visit Date: " + vi.VisitDate.ToShortDateString(), printFont, Brushes.Black, leftMargin, yPos));
                            yPos += 16.86523F;

                            if (!String.IsNullOrWhiteSpace(vi.ExtraDiagnosis)) {
                                List<string> strs = new List<string>();
                                strs.Add(vi.ExtraDiagnosis.Replace('\n', ' ').Replace('\r', ' '));
                                strs = SplitStringsForPrinting(75, strs);

                                pp.AddPrintableObject(new PrintableTextObject("Visit Diagnosis: " + strs[0], printFont, Brushes.Black, leftMargin, yPos));
                                yPos += 16.86523F;

                                for (int i = 1; i < strs.Count; i++) {
                                    pp.AddPrintableObject(new PrintableTextObject("   " + strs[i], printFont, Brushes.Black, leftMargin, yPos));
                                    yPos += 16.86523F;
                                }
                            }

                            if (!String.IsNullOrWhiteSpace(vi.ExtraTherapy)) {
                                List<string> strs = new List<string>();
                                strs.Add(vi.ExtraTherapy.Replace('\n', ' ').Replace('\r', ' '));
                                strs = SplitStringsForPrinting(75, strs);

                                pp.AddPrintableObject(new PrintableTextObject("Visit Therapy: " + strs[0], printFont, Brushes.Black, leftMargin, yPos));
                                yPos += 16.86523F;

                                for (int i = 1; i < strs.Count; i++)
                                {
                                    pp.AddPrintableObject(new PrintableTextObject("   " + strs[i], printFont, Brushes.Black, leftMargin, yPos));
                                    yPos += 16.86523F;
                                }
                            }
                            yPos += 5.621743333333333F; // 1/3 Zeile
                        }
                    }
                }

                pp.AddPrintableObject(new PrintableTextObject("Stone Report:", finalReportFont, Brushes.Red, leftMargin, yPos));

                yPos += 16.86523F;
                yPos += 16.86523F;

                List<string> stoneReportList = new List<string>();
                stoneReportList.Add(patComp.GetStoneReportByPatientId(patient.Id));
                stoneReportList = SplitStringsForPrinting(80, stoneReportList);
                
                foreach (string stoneReportLine in stoneReportList)
                {
                    pp.AddPrintableObject(new PrintableTextObject(stoneReportLine, printFont, Brushes.Black, leftMargin, yPos));
                    yPos += 16.86523F;
                    if (yPos > 1050)
                    {
                        yPos = topMargin;
                        pd.AddPrintPage(pp);
                        pp = new PrintablePage();
                    }
                }

                pd.AddPrintPage(pp);
            }

            pd.DoPrint();
        }

        /// <summary>
        /// Prints the final report.
        /// </summary>
        /// <param name="patients">The patients.</param>
        public void PrintFinalReport(IList<PatientData> patients) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            float leftMargin = 100;
            float topMargin = 100;

            Font headlineFont = new Font("Arial", 18.0f, FontStyle.Underline | FontStyle.Bold);
            Font dateFont = new Font("Arial", 12f, FontStyle.Bold);
            Font finalReportFont = new Font("Arial", 14.0f, FontStyle.Underline | FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Regular);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode) {
                barCodeFont = new Font("Free 3 of 9 Extended", 35, FontStyle.Regular, GraphicsUnit.Point);
            }

            //HeadlineFont: 27,59766
            //dateFont: 18,39844
            //finalReportFont: 21,46484
            //printFont: 16,86523

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Final Report";

            foreach (PatientData patient in patients) {
                PrintablePage pp = new PrintablePage();
                OperationData od = patComp.GetLastOperationByPatientID(patient.Id);



                //pp.AddPrintableObject(new PrintableTextObject("Paediatric Urology Team Austria", headlineFont, new SolidBrush(Color.FromArgb(0, 61, 120)), leftMargin, (float)(topMargin + (0 * 16.86523))));
                pp.AddPrintableObject(new PrintableTextObject(od.Date.Month.ToString() + " " + od.Date.Year.ToString(), dateFont, Brushes.Red, leftMargin, (float)(topMargin + 40)));
                pp.AddPrintableObject(new PrintableFillRectangleObject(Brushes.Yellow, (int)(leftMargin - 5 + 3), 320, 600, (int)(16.86523 + 1)));

                //Bitmap img = SPD.GUI.Properties.Resources.KinderurologieLogo;
                //img.SetResolution(408, 408);
                //pp.AddPrintableObject(new PrintableImageObject(img, 550, (int)topMargin));

                //img = SPD.GUI.Properties.Resources.HFO;
                //img.SetResolution(550, 550);
                //pp.AddPrintableObject(new PrintableImageObject(img, 550, (int)topMargin + 40));

                putLetterhead(pp);

                float yPos = (float)topMargin + (float)(4 * 16.86523);
                if (barCodeFont != null) {
                    pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 500, yPos));
                }
                pp.AddPrintableObject(new PrintableTextObject("Patient ID: " + patient.Id.ToString(), printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("First name: " + patient.FirstName, printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("Surname: " + patient.SurName, printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth), printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                yPos += 16.86523F;
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("OP Date: " + od.Date.ToShortDateString(), printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                List<string> strs = new List<string>();
                strs.Add(od.Diagnoses.Replace('\n', ' ').Replace('\r', ' '));
                strs = SplitStringsForPrinting(75, strs);
                pp.AddPrintableObject(new PrintableTextObject("OP Diagnosis: " + strs[0], printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                if (strs.Count > 1) {
                    pp.AddPrintableObject(new PrintableTextObject("   " + strs[1], printFont, Brushes.Black, leftMargin, yPos));
                }
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("Performed OP: " + od.Performed.Replace('\n', ' ').Replace('\r', ' '), printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                pp.AddPrintableObject(new PrintableTextObject("OP Team: " + od.Team.Replace('\n', ' ').Replace('\r', ' '), printFont, Brushes.Black, leftMargin, yPos));



                pp.AddPrintableObject(new PrintableTextObject("Final Report:", finalReportFont, Brushes.Red, leftMargin, 380));


                List<string> finalReportList = new List<string>();
                finalReportList.Add(patComp.GetFinalReportByPatientId(patient.Id));
                finalReportList = SplitStringsForPrinting(80, finalReportList);
                yPos = 410;
                foreach (string finalReportLine in finalReportList) {
                    pp.AddPrintableObject(new PrintableTextObject(finalReportLine, printFont, Brushes.Black, leftMargin, yPos));
                    yPos += 16.86523F;
                    if (yPos > 1050) {
                        yPos = topMargin;
                        pd.AddPrintPage(pp);
                        pp = new PrintablePage();
                    }
                }

                pd.AddPrintPage(pp);
            }

            pd.DoPrint();
        }

        /// <summary>
        /// Prints the next action faxlist.
        /// </summary>
        /// <param name="patients">List of Patients</param>
        /// <param name="year">The year.</param>
        /// <param name="halfYear">The half year.</param>
        /// <param name="actionKind">Kind of the action.</param>
        public void PrintNextActionFaxlist(IList<PatientData> patients, long year, long halfYear, ActionKind actionKind) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Next Action Fax List";
            pd.Landscape = true;

            Font headlineFont = new Font("Arial", 13.0f, FontStyle.Bold);
            Font tableHeadFont = new Font("Arial", 10, FontStyle.Bold);
            Font printFont = new Font("Arial", 10, FontStyle.Regular);

            float leftMargin = 30;
            float topMargin = 30;
            int page = 1;

            int xId = (int)leftMargin;
            int xName = 70;
            int xAge = 350;
            int xSex = 400;
            int xPhone = 450;
            int xDiagnoses = 600;
        //    private int A4smallSite = 826;
        //private int A4LargeSite = 1169;

            PrintablePage pp = new PrintablePage();
            int yTable = (int)topMargin + 22;

            //Headline
            DrawNextActionFaxListHeadline(patients, pp, actionKind, halfYear, year, page, headlineFont, leftMargin, topMargin, tableHeadFont, xId, xName, xAge, xSex, xPhone, xDiagnoses);

            int patientCount = 0;
            foreach (PatientData patient in patients) {
                //pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, yTable, (int)leftMargin + 1109, yTable));
                pp.AddPrintableObject(new PrintableTextObject(patient.Id.ToString(), printFont, Brushes.Black, xId, yTable + 1 + 16 + (patientCount * 16)));
                pp.AddPrintableObject(new PrintableRectangleObject(Brushes.White, xName, yTable + 1 + 16 + (patientCount * 16), 1000, 16));

                pp.AddPrintableObject(new PrintableTextObject(patient.FirstName + " " + patient.SurName, printFont, Brushes.Black, xName, yTable + 1 + 16 + (patientCount * 16)));
                pp.AddPrintableObject(new PrintableRectangleObject(Brushes.White, xAge, yTable + 1 + 16 + (patientCount * 16), 1000, 16));

                pp.AddPrintableObject(new PrintableTextObject(StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth), printFont, Brushes.Black, xAge, yTable + 1 + 16 + (patientCount * 16)));
                pp.AddPrintableObject(new PrintableRectangleObject(Brushes.White, xSex, yTable + 1 + 16 + (patientCount * 16), 1000, 16));

                pp.AddPrintableObject(new PrintableTextObject(patient.Sex.ToString() , printFont, Brushes.Black, xSex, yTable + 1 + 16 + (patientCount * 16)));
                pp.AddPrintableObject(new PrintableRectangleObject(Brushes.White, xPhone, yTable + 1 + 16 + (patientCount * 16), 1000, 16));

                pp.AddPrintableObject(new PrintableTextObject(patient.Phone , printFont, Brushes.Black, xPhone, yTable + 1 + 16 + (patientCount * 16)));
                pp.AddPrintableObject(new PrintableRectangleObject(Brushes.White, xDiagnoses, yTable + 1 + 16 + (patientCount * 16), 1000, 16));

                string diagnoses = string.Empty;
                OperationData op = patComp.GetLastOperationByPatientID(patient.Id);
                if (op != null && !string.IsNullOrEmpty(op.Diagnoses)) {
                    diagnoses = "OP: " + op.Diagnoses;
                } else {
                    VisitData visit = patComp.GetLastVisitByPatientID(patient.Id);
                    if (visit != null && !string.IsNullOrEmpty(visit.ExtraDiagnosis)) {
                        diagnoses = "Visit: " + visit.ExtraDiagnosis;
                    }
                }
                pp.AddPrintableObject(new PrintableTextObject(diagnoses, printFont, Brushes.Black, xDiagnoses, yTable + 1 + 16 + (patientCount * 16)));
                pp.AddPrintableObject(new PrintableRectangleObject(Brushes.White, (int)leftMargin + 1109, yTable + 1 + 16 + (patientCount * 16), 1000, 16));

                patientCount++;

                if (patientCount > 45) {
                    drawNextActionFaxListTable(pp, leftMargin, yTable, xId, xName, xAge, xSex, xPhone, xDiagnoses);
                    page++;
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                    patientCount = 0;
                    DrawNextActionFaxListHeadline(patients, pp, actionKind, halfYear, year, page, headlineFont, leftMargin, topMargin, tableHeadFont, xId, xName, xAge, xSex, xPhone, xDiagnoses);        
                }
            }
            drawNextActionFaxListTable(pp, leftMargin, yTable, xId, xName, xAge, xSex, xPhone, xDiagnoses);
            pd.AddPrintPage(pp);
            pd.DoPrint();
        }

        private void DrawNextActionFaxListHeadline(IList<PatientData> patients, PrintablePage pp, ActionKind actionKind, long halfYear, long year, int page, Font headlineFont, float leftMargin, float topMargin, Font tableHeadFont, int xId, int xName, int xAge, int xSex, int xPhone, int xDiagnoses) {
            pp.AddPrintableObject(new PrintableTextObject("SPD  -  NextAction - FAX List  " + actionKind.ToString() + "  " + halfYear + "/" + year + " Page: " + page + "   No of Patients: " + patients.Count, headlineFont, Brushes.Black, leftMargin, topMargin));

            //TableHead
            pp.AddPrintableObject(new PrintableFillRectangleObject(Brushes.LightGray, (int)leftMargin, (int)topMargin + 22, 1109, 16));
            pp.AddPrintableObject(new PrintableTextObject("ID", tableHeadFont, Brushes.Black, xId, topMargin + 23));
            pp.AddPrintableObject(new PrintableTextObject("Name", tableHeadFont, Brushes.Black, xName, topMargin + 23));
            pp.AddPrintableObject(new PrintableTextObject("Age", tableHeadFont, Brushes.Black, xAge, topMargin + 23));
            pp.AddPrintableObject(new PrintableTextObject("Sex", tableHeadFont, Brushes.Black, xSex, topMargin + 23));
            pp.AddPrintableObject(new PrintableTextObject("Phone", tableHeadFont, Brushes.Black, xPhone, topMargin + 23));
            pp.AddPrintableObject(new PrintableTextObject("Diagnoses", tableHeadFont, Brushes.Black, xDiagnoses, topMargin + 23));
        }

        private void drawNextActionFaxListTable(PrintablePage pp, float leftMargin, int yTable, int xId, int xName, int xAge, int xSex, int xPhone, int xDiagnoses) {
            //Horizontal Lines:
            int numberOflines = 47;
            for (int i = 0; i <= numberOflines; i++) {
                pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, yTable + (i * 16), (int)leftMargin + 1109, yTable + (i * 16)));
            }

            //Vertikal Lines
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, xId, yTable, xId, yTable + (numberOflines * 16)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, xName, yTable, xName, yTable + (numberOflines * 16)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, xAge, yTable, xAge, yTable + (numberOflines * 16)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, xSex, yTable, xSex, yTable + (numberOflines * 16)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, xPhone, yTable, xPhone, yTable + (numberOflines * 16)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, xDiagnoses, yTable, xDiagnoses, yTable + (numberOflines * 16)));
            //Last verticalLine...
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin + 1109, yTable, (int)leftMargin + 1109, yTable + (numberOflines * 16)));
        }

        /// <summary>
        /// Prints Id Cards   86 mm * 54 mm
        /// </summary>
        /// <param name="patients">List of Patients</param>
        public void PrintIdCard(IList<PatientData> patients) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            if (patients.Count > 1) {
                throw new NotImplementedException("More Id-Cards not supported until now!");
            }

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD ID Card";
            pd.Landscape = true;
            Font idFont = new Font("Arial", 22, FontStyle.Bold);
            Font nameFont = new Font("Arial", 14, FontStyle.Bold);

            PrintablePage pp = new PrintablePage();

            PatientData patient = patients[0];

            pp.AddPrintableObject(new PrintableTextObject("ID " + patient.Id, idFont, Brushes.Black, 15, 163));

            pp.AddPrintableObject(new PrintableTextObject(patient.FirstName, nameFont, Brushes.Black, 140, 161));
            pp.AddPrintableObject(new PrintableTextObject(patient.SurName, nameFont, Brushes.Black, 140, 181));

            pd.AddPrintPage(pp);
            
            PrintDialog oPrintDialog = new PrintDialog();
            string printername = null;
            foreach (string printernameloop in PrinterSettings.InstalledPrinters) {
                if (printernameloop.ToLower().Contains("zebra") || 
                    printernameloop.ToLower().Contains("p110"))
                {
                    printername = printernameloop;
                    break;
                }
            }

            if (printername != null) {
                pd.PrinterName = printername;
            }

            pd.DoPrint(null, printername == null);
        }

        /// <summary>
        /// Prints the next action list.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <param name="year">The year.</param>
        /// <param name="halfyear">The halfyear.</param>
        /// <param name="actionKind">Kind of the action.</param>
        public void PrintNextActionList(IList<PatientData> patients, long year, long halfyear, ActionKind actionKind) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Next Action List";
            pd.Landscape = false;

            Font headlineFont = new Font("Arial", 13.0f, FontStyle.Bold);
            Font dateFont = new Font("Arial", 10.5f, FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Regular);
            Font boldPrintFont = new Font("Arial", 11, FontStyle.Bold);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode) {
                barCodeFont = new Font("Free 3 of 9 Extended", 30, FontStyle.Regular, GraphicsUnit.Point);
            }

            float leftMargin = 65;
            float topMargin = 30;
            int page = 1;
            int line = 2;

            PrintablePage pp = new PrintablePage();

            pp.AddPrintableObject(new PrintableTextObject("SPD  -  NextAction - " + actionKind.ToString(), headlineFont, Brushes.Black, leftMargin, topMargin + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableTextObject(year + " - " + halfyear + "        " + patients.Count + " Patients", printFont, Brushes.Black, leftMargin + 300, topMargin + 3 + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableTextObject(DateTime.Now.ToShortDateString() + " Page: " + page, printFont, Brushes.Black, leftMargin + 545, topMargin + 3 + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin + 20, (int)leftMargin + 680, (int)topMargin + 20));

            foreach (PatientData patient in patients) {
                pp.AddPrintableObject(new PrintableTextObject("ID: " + patient.Id, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Sex: " + patient.Sex, printFont, Brushes.Black, leftMargin + 100, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Phone: " + patient.Phone, printFont, Brushes.Black, leftMargin + 200, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - " + CommonUtilities.StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth) + " years", printFont, Brushes.Black, leftMargin + 450, topMargin + (float)(line * 17.56)));
                line++;
                if (barCodeFont != null) {
                    pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 500, topMargin + (float)(line * 17.56)));
                }
                pp.AddPrintableObject(new PrintableTextObject("Name: " + patient.FirstName + " " + patient.SurName, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                line++;
                List<string> extradiagnoses = new List<string>();
                OperationData operation = this.patComp.GetLastOperationByPatientID(patient.Id);
                VisitData visit = this.patComp.GetLastVisitByPatientID(patient.Id);
                if (operation != null && !String.IsNullOrEmpty(operation.Diagnoses)) {
                    extradiagnoses.Add(operation.Diagnoses);
                    extradiagnoses = this.SplitStringsForPrinting(80, extradiagnoses);
                    pp.AddPrintableObject(new PrintableTextObject("OP Diagnoses:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    foreach (string diagnosesLine in extradiagnoses) {
                        pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                } 
                if (visit != null && !String.IsNullOrEmpty(visit.ExtraDiagnosis)) {
                    extradiagnoses.Add(visit.ExtraDiagnosis);
                    extradiagnoses = this.SplitStringsForPrinting(80, extradiagnoses);
                    pp.AddPrintableObject(new PrintableTextObject("Visit Diagnoses:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    foreach (string diagnosesLine in extradiagnoses) {
                        pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                }
                //Therapy
                if (visit != null && !String.IsNullOrEmpty(visit.ExtraTherapy)) {
                    List<string> therapy = new List<string>();
                    therapy.Add(visit.ExtraTherapy);
                    therapy = this.SplitStringsForPrinting(80, therapy);
                    pp.AddPrintableObject(new PrintableTextObject("Visit Therapy:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    foreach (string therapyLine in therapy) {
                        pp.AddPrintableObject(new PrintableTextObject(therapyLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                }
                //TODO
                List<string> todo = new List<string>();
                foreach(NextActionData nextAction in patComp.GetNextActionsByPatientID(patient.Id)) {
                    if (nextAction.ActionYear == year &&
                        nextAction.ActionhalfYear == halfyear &&
                        nextAction.ActionKind == actionKind &&
                        !String.IsNullOrEmpty(nextAction.Todo)) {
                        todo.Add(nextAction.Todo);
                    }
                }
                if (todo.Count > 0) {
                    pp.AddPrintableObject(new PrintableTextObject("ToDo:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    todo = this.SplitStringsForPrinting(80, todo);
                    foreach (string todoLine in todo) {
                        pp.AddPrintableObject(new PrintableTextObject(todoLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                }
                pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)((line + 2) * 17.56), (int)leftMargin + 680, (int)((line + 2) * 17.56)));
                line++;

                if (line > 50) {
                    page++;
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                    line = 2;
                    pp.AddPrintableObject(new PrintableTextObject("NextAction - " + actionKind.ToString() + " " + year + "\\" + halfyear + "     " + patients.Count + " Patients", headlineFont, Brushes.Black, leftMargin, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableTextObject("SPD", headlineFont, Brushes.Black, leftMargin + 400, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableTextObject(DateTime.Now.ToShortDateString() + " Page: " + page, headlineFont, Brushes.Black, leftMargin + 500, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin + 20, (int)leftMargin + 680, (int)topMargin + 20));
                }
            }
            pd.AddPrintPage(pp);
            pd.DoPrint();
        }

        /// <summary>
        /// Prints the next action list.
        /// </summary>
        /// <param name="patients">The patients.</param>
        public void PrintWaitList(IList<PatientData> patients) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Waiting List";
            pd.Landscape = false;

            Font headlineFont = new Font("Arial", 13.0f, FontStyle.Bold);
            Font dateFont = new Font("Arial", 10.5f, FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Regular);
            Font boldPrintFont = new Font("Arial", 11, FontStyle.Bold);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode) {
                barCodeFont = new Font("Free 3 of 9 Extended", 30, FontStyle.Regular, GraphicsUnit.Point);
            }

            float leftMargin = 65;
            float topMargin = 30;
            int page = 1;
            int line = 2;

            PrintablePage pp = new PrintablePage();

            pp.AddPrintableObject(new PrintableTextObject("SPD  -  Waiting List", headlineFont, Brushes.Black, leftMargin, topMargin + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableTextObject(patients.Count + " Patients", printFont, Brushes.Black, leftMargin + 300, topMargin + 3 + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableTextObject(DateTime.Now.ToShortDateString() + " Page: " + page, printFont, Brushes.Black, leftMargin + 545, topMargin + 3 + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin + 20, (int)leftMargin + 680, (int)topMargin + 20));

            foreach (PatientData patient in patients) {
                pp.AddPrintableObject(new PrintableTextObject("ID: " + patient.Id, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Sex: " + patient.Sex, printFont, Brushes.Black, leftMargin + 100, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Phone: " + patient.Phone, printFont, Brushes.Black, leftMargin + 200, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - " + CommonUtilities.StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth) + " years", printFont, Brushes.Black, leftMargin + 450, topMargin + (float)(line * 17.56)));
                line++;
                if (barCodeFont != null) {
                    pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 550, topMargin + (float)(line * 17.56)));
                }
                pp.AddPrintableObject(new PrintableTextObject("Name: " + patient.FirstName + " " + patient.SurName, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject((patient.WaitListStartDate == null) ? "" : "Waitlist Date: " + ((DateTime)patient.WaitListStartDate).ToShortDateString(), printFont, Brushes.Black, leftMargin + 300, topMargin + (float)(line * 17.56)));
                line++;
                List<string> extradiagnoses = new List<string>();
                OperationData operation = this.patComp.GetLastOperationByPatientID(patient.Id);
                VisitData visit = this.patComp.GetLastVisitByPatientID(patient.Id);
                if (operation != null && !String.IsNullOrEmpty(operation.Diagnoses)) {
                    extradiagnoses.Add(operation.Diagnoses);
                    extradiagnoses = this.SplitStringsForPrinting(80, extradiagnoses);
                    pp.AddPrintableObject(new PrintableTextObject("OP Diagnoses:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    foreach (string diagnosesLine in extradiagnoses) {
                        pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                }
                if (visit != null && !String.IsNullOrEmpty(visit.ExtraDiagnosis)) {
                    extradiagnoses.Add(visit.ExtraDiagnosis);
                    extradiagnoses = this.SplitStringsForPrinting(80, extradiagnoses);
                    pp.AddPrintableObject(new PrintableTextObject("Visit Diagnoses:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    foreach (string diagnosesLine in extradiagnoses) {
                        pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                }
                //Therapy
                if (visit != null && !String.IsNullOrEmpty(visit.ExtraTherapy)) {
                    List<string> therapy = new List<string>();
                    therapy.Add(visit.ExtraTherapy);
                    therapy = this.SplitStringsForPrinting(80, therapy);
                    pp.AddPrintableObject(new PrintableTextObject("Visit Therapy:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                    line++;
                    foreach (string therapyLine in therapy) {
                        pp.AddPrintableObject(new PrintableTextObject(therapyLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                    }
                }
                pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)((line + 2) * 17.56), (int)leftMargin + 680, (int)((line + 2) * 17.56)));
                line++;

                if (line > 50) {
                    page++;
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                    line = 2;
                    pp.AddPrintableObject(new PrintableTextObject(patients.Count + " Patients", headlineFont, Brushes.Black, leftMargin, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableTextObject("SPD", headlineFont, Brushes.Black, leftMargin + 400, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableTextObject(DateTime.Now.ToShortDateString() + " Page: " + page, headlineFont, Brushes.Black, leftMargin + 500, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin + 20, (int)leftMargin + 680, (int)topMargin + 20));
                }
            }
            pd.AddPrintPage(pp);
            pd.DoPrint();
        }

        /// <summary>
        /// Prints the next action list.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <param name="headline">The headline.</param>
        public void PrintPatientList(IList<PatientData> patients, string headline, bool useOpData) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Next Action List";
            pd.Landscape = false;

            Font headlineFont = new Font("Arial", 13.0f, FontStyle.Bold);
            Font dateFont = new Font("Arial", 10.5f, FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Regular);
            Font boldPrintFont = new Font("Arial", 11, FontStyle.Bold);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode) {
                barCodeFont = new Font("Free 3 of 9 Extended", 30, FontStyle.Regular, GraphicsUnit.Point);
            }

            float leftMargin = 65;
            float topMargin = 30;
            int page = 1;
            int line = 2;

            PrintablePage pp = new PrintablePage();

            pp.AddPrintableObject(new PrintableTextObject("SPD  -  " + headline, headlineFont, Brushes.Black, leftMargin, topMargin + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableTextObject("        " + patients.Count + " Patients", printFont, Brushes.Black, leftMargin + 300, topMargin + 3 + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableTextObject(DateTime.Now.ToShortDateString() + " Page: " + page, printFont, Brushes.Black, leftMargin + 545, topMargin + 3 + (float)(0 * 17.56)));
            pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin + 20, (int)leftMargin + 680, (int)topMargin + 20));

            foreach (PatientData patient in patients) {
                pp.AddPrintableObject(new PrintableTextObject("ID: " + patient.Id, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Sex: " + patient.Sex, printFont, Brushes.Black, leftMargin + 100, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Phone: " + patient.Phone, printFont, Brushes.Black, leftMargin + 200, topMargin + (float)(line * 17.56)));
                pp.AddPrintableObject(new PrintableTextObject("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - " + CommonUtilities.StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth) + " years", printFont, Brushes.Black, leftMargin + 450, topMargin + (float)(line * 17.56)));
                line++;
                if (barCodeFont != null) {
                    pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 500, topMargin + (float)(line * 17.56)));
                }
                pp.AddPrintableObject(new PrintableTextObject("Name: " + patient.FirstName + " " + patient.SurName, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                line++;
                
                OperationData operation = this.patComp.GetLastOperationByPatientID(patient.Id);
                VisitData visit = this.patComp.GetLastVisitByPatientID(patient.Id);
                if (operation != null && useOpData) {
                    if (!String.IsNullOrEmpty(operation.Diagnoses)) {
                        List<string> extradiagnoses = new List<string>();
                        extradiagnoses.Add(operation.Diagnoses);
                        extradiagnoses = this.SplitStringsForPrinting(80, extradiagnoses);
                        pp.AddPrintableObject(new PrintableTextObject("OP Diagnoses:", boldPrintFont, Brushes.Black,
                                                                      leftMargin, topMargin + (float) (line*17.56)));
                        line++;
                        foreach (string diagnosesLine in extradiagnoses) {
                            pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black,
                                                                          leftMargin, topMargin + (float) (line*17.56)));
                            line++;
                        }
                    }
                    if (!String.IsNullOrEmpty(operation.Performed)) {
                        List<string> performed = new List<string>();
                        performed.Add(operation.Performed);
                        performed = this.SplitStringsForPrinting(80, performed);
                        pp.AddPrintableObject(new PrintableTextObject("OP Performed:", boldPrintFont, Brushes.Black,
                                                                      leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                        foreach (string performedLine in performed) {
                            pp.AddPrintableObject(new PrintableTextObject(performedLine, printFont, Brushes.Black,
                                                                          leftMargin, topMargin + (float)(line * 17.56)));
                            line++;
                        }
                    }
                    if (!String.IsNullOrEmpty(operation.Team)) {
                        List<string> team = new List<string>();
                        team.Add(operation.Diagnoses);
                        team = this.SplitStringsForPrinting(80, team);
                        pp.AddPrintableObject(new PrintableTextObject("OP Team:", boldPrintFont, Brushes.Black,
                                                                      leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                        foreach (string teamLine in team) {
                            pp.AddPrintableObject(new PrintableTextObject(teamLine, printFont, Brushes.Black,
                                                                          leftMargin, topMargin + (float)(line * 17.56)));
                            line++;
                        }
                    }
                } else {
                    if (visit != null && !String.IsNullOrEmpty(visit.ExtraDiagnosis)) {
                        List<string> extradiagnoses = new List<string>();
                        extradiagnoses.Add(visit.ExtraDiagnosis);
                        extradiagnoses = this.SplitStringsForPrinting(80, extradiagnoses);
                        pp.AddPrintableObject(new PrintableTextObject("Visit Diagnoses:", boldPrintFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                        line++;
                        foreach (string diagnosesLine in extradiagnoses) {
                            pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black, leftMargin, topMargin + (float)(line * 17.56)));
                            line++;
                        }
                    }
                }
                
                pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)((line + 2) * 17.56), (int)leftMargin + 680, (int)((line + 2) * 17.56)));
                line++;

                if (line > 50) {
                    page++;
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                    line = 2;

                    pp.AddPrintableObject(new PrintableTextObject("SPD  -  " + headline, headlineFont, Brushes.Black, leftMargin, topMargin + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableTextObject("        " + patients.Count + " Patients", printFont, Brushes.Black, leftMargin + 300, topMargin + 3 + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableTextObject(DateTime.Now.ToShortDateString() + " Page: " + page, printFont, Brushes.Black, leftMargin + 545, topMargin + 3 + (float)(0 * 17.56)));
                    pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin + 20, (int)leftMargin + 680, (int)topMargin + 20));
                }
            }
            pd.AddPrintPage(pp);
            pd.DoPrint();
        }

        /// <summary>
        /// Prints the labels.
        /// </summary>
        /// <param name="topBordermm">The top bordermm.</param>
        /// <param name="leftBordermm">The left bordermm.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="startline">The startline.</param>
        /// <param name="labelFontSize">Size of the label font.</param>
        /// <param name="patients">The patients.</param>
        public void PrintLabels(int topBordermm, int leftBordermm, int columns, int rows, int startline, int labelFontSize, IList<PatientData> patients) {
            // 827 Pixel Breit = 210mm => 1mm = 3,9380952380952380952380952380952 Pixel
            // 1169 Pixel Hoch = 297mm => 1mm = 3,9360269360269360269360269360269 Pixel

            if (patients == null || patients.Count == 0) {
                return;
            }
            const float pixelMMFactor = 3.937F;
            const float height = 1169;
            const float width = 827;

            float leftBorderpixel = leftBordermm * pixelMMFactor;
            float topBorderpixel = topBordermm * pixelMMFactor;
            float usedplacewidth = width - (2 * leftBorderpixel);
            float usedplaceheight = height - (2 * topBorderpixel);
            float boxheight = usedplaceheight / rows;
            float boxwidth = usedplacewidth / columns;



            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Labels";
            pd.Landscape = false;

            PrintablePage pp = new PrintablePage();

            Font font = new Font("Arial", labelFontSize);

            int line = startline - 1;
            foreach (PatientData patient in patients) {

                if (line >= rows) {
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                    line = 0;
                }

                for (int i = 0; i < columns; i++) {
                    font.GetHeight();
                    float x = leftBorderpixel + 7 + (i * boxwidth);
                    float y1 = topBorderpixel + (line * boxheight) + ((boxheight - (2 * font.GetHeight())) / 3);
                    float y2 = y1 + font.GetHeight();
                    float y3 = y2 + font.GetHeight();
                    pp.AddPrintableObject(new PrintableFillRectangleObject(Brushes.White, (int)(leftBorderpixel + (i * boxwidth)), (int)(topBorderpixel + (line * boxheight)), (int)boxwidth - 1, (int)boxheight));
                    //pp.AddPrintableObject(new PrintableTextObject("ID: " + patient.Id + "   Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth), font, Brushes.Black, x, y1));
                    //pp.AddPrintableObject(new PrintableTextObject(patient.FirstName, font, Brushes.Black, x, y2));
                    //pp.AddPrintableObject(new PrintableTextObject(patient.SurName, font, Brushes.Black, x, y3));

                    pp.AddPrintableObject(new PrintableTextObject(patient.FirstName + " " + patient.SurName, font, Brushes.Black, x, y1));
                    pp.AddPrintableObject(new PrintableTextObject("ID: " + patient.Id + "   Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth), font, Brushes.Black, x, y2));
                    
                }

                line++;
            }

            pd.AddPrintPage(pp);

            pd.DoPrint();
        }

        /// <summary>
        /// Patient Details
        /// </summary>
        [Flags]
        public enum PatientPrintDetails {
            /// <summary>
            /// print Visits?
            /// </summary>
            Visits = 0x01,
            /// <summary>
            /// print operations?
            /// </summary>
            Operations = 0x02,
            /// <summary>
            /// print Final Report
            /// </summary>
            FinalReport = 0x04,
            /// <summary>
            /// print Fotolinks?
            /// </summary>
            Fotolinks = 0x08
        }



        /// <summary>
        /// Prints the patients.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <param name="patientPrintDetails">The patient print details.</param>
        public void PrintPatients(IList<PatientData> patients, PatientPrintDetails patientPrintDetails) {
            if (patients == null || patients.Count == 0) {
                return;
            }

            float leftMargin = 100;
            float topMargin = 100;

            Font headlineFont = new Font("Arial", 18.0f, FontStyle.Underline | FontStyle.Bold);
            Font dateFont = new Font("Arial", 12f, FontStyle.Bold);
            Font finalReportFont = new Font("Arial", 14.0f, FontStyle.Underline | FontStyle.Bold);
            Font printFont = new Font("Arial", 12, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode) {
                barCodeFont = new Font("Free 3 of 9 Extended", 35, FontStyle.Regular, GraphicsUnit.Point);
            }

            //HeadlineFont: 27,59766
            //dateFont: 18,39844
            //finalReportFont: 21,46484
            //printFont: 16,86523

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Patient Data";

            foreach (PatientData patient in patients) {
                PrintablePage pp = new PrintablePage();
                OperationData od = patComp.GetLastOperationByPatientID(patient.Id);

                if (barCodeFont != null) {
                    pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 500, 110));
                }

                List<string> printList = new List<string>();
                printList.Add("Patient ID: " + patient.Id.ToString());
                printList.Add("First name: " + patient.FirstName);
                printList.Add("Surname: " + patient.SurName);
                printList.Add("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth));
                printList.Add("Sex: " + patient.Sex.ToString());
                if (!string.IsNullOrEmpty(patient.Address))
                    printList.Add("Address: " + patient.Address);
                printList.Add("Weight: " + patient.Weight);
                printList.Add("Phone: " + patient.Phone.ToString());

                if ((patientPrintDetails & PatientPrintDetails.Fotolinks) == PatientPrintDetails.Fotolinks) {
                    if (this.patComp.GetImagesByPatientID(patient.Id).Count > 0) {
                        printList.Add("");
                        printList.Add("Image Links:");
                    }
                    foreach (ImageData image in this.patComp.GetImagesByPatientID(patient.Id)) {
                        printList.Add(image.Kommentar);
                        printList.Add(image.Link);
                    }
                }

                if ((patientPrintDetails & PatientPrintDetails.Visits) == PatientPrintDetails.Visits) {
                    foreach (VisitData visit in this.patComp.GetVisitsByPatientID(patient.Id)) {
                        printList.Add("");
                        printList.Add("Visit ID: " + visit.Id.ToString());
                        printList.Add("Visit date: " + visit.VisitDate.ToShortDateString());
                        if (!visit.Cause.Equals(""))
                            printList.Add("Cause: " + visit.Cause);
                        if (!visit.Localis.Equals(""))
                            printList.Add("STATUS localis: " + visit.Localis);
                        if (!visit.ExtraDiagnosis.Equals(""))
                            printList.Add("Diagnosis: " + visit.ExtraDiagnosis);
                        if (!visit.Procedure.Equals(""))
                            printList.Add("Procedure: " + visit.Procedure);
                        if (!visit.ExtraTherapy.Equals(""))
                            printList.Add("Therapy: " + visit.ExtraTherapy);
                        if (!visit.Anesthesiology.Equals(""))
                            printList.Add("Anaesthesia: " + visit.Anesthesiology);
                        if (!visit.Blooddiagnostic.Equals(""))
                            printList.Add("Blooddiagnostic: " + visit.Blooddiagnostic);
                        if (!visit.Radiodiagnostics.Equals(""))
                            printList.Add("Radiodiagnostics: " + visit.Radiodiagnostics);
                        if (!visit.Todo.Equals(""))
                            printList.Add("Todo: " + visit.Todo);
                        if (!visit.Ultrasound.Equals("")) {
                            string ultrasound = visit.Ultrasound;
                            ultrasound = "  " + ultrasound;
                            ultrasound = ultrasound.Replace(Environment.NewLine, Environment.NewLine + "  ");
                            printList.Add("Ultrasound:" + Environment.NewLine + ultrasound);
                        }
                    }
                }

                if ((patientPrintDetails & PatientPrintDetails.Operations) == PatientPrintDetails.Operations) {
                    foreach (OperationData operation in this.patComp.GetOperationsByPatientID(patient.Id)) {
                        printList.Add("");
                        printList.Add("Operation ID: " + operation.OperationId.ToString());
                        printList.Add("Date: " + operation.Date.ToShortDateString());
                        if (!operation.Team.Equals(""))
                            printList.Add("Team: " + operation.Team);
                        if (!operation.Process.Equals(""))
                            printList.Add("Process: " + operation.Process);
                        if (!operation.Diagnoses.Equals(""))
                            printList.Add("Diagnosis: " + operation.Diagnoses);
                        if (!operation.Performed.Equals(""))
                            printList.Add("Performed: " + operation.Performed);
                        if (!operation.Additionalinformation.Equals(""))
                            printList.Add("Additional Information: " + operation.Additionalinformation);
                        if (!operation.Medication.Equals(""))
                            printList.Add("Medication: " + operation.Medication);
                        printList.Add("Intdiagnosis: " + operation.IntDiagnoses.ToString());
                        printList.Add("PP PS: " + operation.Ppps.ToString());
                        printList.Add("Result: " + operation.Result.ToString());
                    }
                }

                if ((patientPrintDetails & PatientPrintDetails.FinalReport) == PatientPrintDetails.FinalReport) {
                    if (!this.patComp.GetFinalReportByPatientId(patient.Id).Equals("")) {
                        printList.Add("");
                        printList.Add("Final Report");
                        printList.Add(this.patComp.GetFinalReportByPatientId(patient.Id));
                    }
                }


                printList = SplitStringsForPrinting(80, printList);

                int lineNo = 0;
                int page = 1;
                float yPos = topMargin;// + (count * printFont.GetHeight(ev.Graphics));

                pp.AddPrintableObject(new PrintableTextObject(patient.FirstName + " " + patient.SurName, printFont, Brushes.Black, leftMargin, topMargin - 20));
                pp.AddPrintableObject(new PrintableTextObject("SPD                                 " + DateTime.Now.ToShortDateString() + "  Page " + page, printFont, Brushes.Black, leftMargin + 300, topMargin - 20));
                pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin - 2, (int)leftMargin + 650, (int)topMargin - 2));

                foreach (string line in printList) {
                    if (lineNo >= 50) { // Neue Seite anfangen
                        pp.AddPrintableObject(new PrintableTextObject("Page " + page, printFont, Brushes.Black, leftMargin, 1069F));
                        lineNo = 0;
                        page++;
                        pd.AddPrintPage(pp);
                        pp = new PrintablePage();
                        yPos = topMargin;
                        pp.AddPrintableObject(new PrintableTextObject(patient.FirstName + " " + patient.SurName, printFont, Brushes.Black, leftMargin, topMargin - 20));
                        pp.AddPrintableObject(new PrintableTextObject("SPD                                 " + DateTime.Now.ToShortDateString() + "  Page " + page, printFont, Brushes.Black, leftMargin + 300, topMargin - 20));
                        pp.AddPrintableObject(new PrintableLineObject(Pens.Black, (int)leftMargin, (int)topMargin - 2, (int)leftMargin + 650, (int)topMargin - 2));
                    }
                    yPos += 16.86523F;
                    if (line.StartsWith("Surname:") || line.StartsWith("Visit ID:") || line.StartsWith("Operation ID:") || line.StartsWith("Final Report") || line.StartsWith("Image Links:")) {
                        pp.AddPrintableObject(new PrintableTextObject(line, boldFont, Brushes.Black, leftMargin, yPos));
                    } else {
                        pp.AddPrintableObject(new PrintableTextObject(line, printFont, Brushes.Black, leftMargin, yPos));
                    }
                    lineNo++;
                }


                pd.AddPrintPage(pp);
            }

            pd.DoPrint();
        }

        private List<string> SplitStringsForPrinting(int charPerLine, List<string> printTextList) {
            int i = 0;
            List<string> helpList = new List<string>();

            foreach (string line in printTextList) {
                if (line.Contains(Environment.NewLine)) {
                    string[] strarr = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string newline in strarr) {
                        helpList.Add(newline);
                    }
                } else {
                    helpList.Add(line);
                }
            }

            printTextList = helpList;

            i = 0;
            while (i < printTextList.Count) {
                if (printTextList[i].Length > charPerLine) {
                    helpList = new List<string>();
                    string[] strArr = printTextList[i].Split(' ');
                    int j = 0;
                    while (j < strArr.Length) {
                        string str = "";
                        while (((str.Length + strArr[j].Length) < charPerLine) && (j < strArr.Length)) {
                            str += " " + strArr[j];
                            j++;
                            if (j >= strArr.Length)
                                break;
                        }
                        helpList.Add(str);
                    }
                    printTextList.RemoveAt(i);
                    printTextList.InsertRange(i, helpList);
                    i += helpList.Count - 1;
                }
                i++;
            }

            for (int j = 0; j < printTextList.Count; j++) {
                printTextList[j] = printTextList[j].Replace(Environment.NewLine, "");
            }

            return printTextList;
        }


        /// <summary>
        /// Prints the next appointment.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="diagnoses">The diagnoses.</param>
        /// <param name="todo">The todo.</param>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <param name="numberOfSheets">The number of sheets.</param>
        public void PrintNextAppointment(PatientData patient, string diagnoses, string todo, string date, string time, int numberOfSheets) {
            if (patient == null) {
                return;
            }

            float leftMargin = 100;
            float topMargin = 100;

            Font headlineFont = new Font("Arial", 18.0f, FontStyle.Bold);
            Font dateFont = new Font("Arial", 12f, FontStyle.Bold);
            Font pointFont = new Font("Arial", 15f, FontStyle.Bold);
            Font printFont = new Font("Arial", 11, FontStyle.Regular);
            Font barCodeFont = null;
            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended") && SPD.GUI.Properties.Settings.Default.Barcode) {
                barCodeFont = new Font("Free 3 of 9 Extended", 35, FontStyle.Regular, GraphicsUnit.Point);
            }

            //HeadlineFont: 27,59766
            //dateFont: 18,39844
            //printFont: 16,86523

            PrintableDocument pd = new PrintableDocument();
            pd.DocumentName = "SPD Next Appointment";

            PrintablePage pp = new PrintablePage();
            OperationData od = patComp.GetLastOperationByPatientID(patient.Id);

            putLetterhead(pp);

            float yPos = (float)topMargin + (float)(4 * 16.86523);

            pp.AddPrintableObject(new PrintableTextObject("NEXT OUTPATIENT APPOINTMENT", headlineFont, Brushes.Red, leftMargin + 100, yPos));
            yPos += 16.86523F;
            yPos += 16.86523F;
            yPos += 16.86523F;
            if (barCodeFont != null) {
                pp.AddPrintableObject(new PrintableTextObject(String.Format("*000000{0}*", patient.Id.ToString()), barCodeFont, Brushes.Black, 500, yPos));
            }
            pp.AddPrintableObject(new PrintableTextObject("Printed: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), printFont, Brushes.Black, leftMargin, yPos));
            yPos += 16.86523F;
            yPos += 16.86523F;
            pp.AddPrintableObject(new PrintableTextObject("Patient ID: " + patient.Id.ToString(), pointFont, Brushes.Black, leftMargin, yPos));
            yPos += 25F;
            pp.AddPrintableObject(new PrintableTextObject("Name: " + patient.FirstName + " " + patient.SurName, pointFont, Brushes.Black, leftMargin, yPos));
            yPos += 25F;
            pp.AddPrintableObject(new PrintableTextObject("Date: " + date, pointFont, Brushes.Black, leftMargin, yPos));
            yPos += 25F;
            pp.AddPrintableObject(new PrintableTextObject("Time: " + time, pointFont, Brushes.Black, leftMargin, yPos));
            yPos += 25F;
            pp.AddPrintableObject(new PrintableTextObject("Place: " + SPD.GUI.Properties.Settings.Default.Location, pointFont, Brushes.Black, leftMargin, yPos));
            yPos += 25F;
            yPos += 16.86523F;
            pp.AddPrintableObject(new PrintableTextObject("Birthdate: " + patient.DateOfBirth.ToShortDateString() + " - Age: " + StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth), printFont, Brushes.Black, leftMargin, yPos));
            yPos += 16.86523F;
            yPos += 16.86523F;
            yPos += 16.86523F;
            pp.AddPrintableObject(new PrintableTextObject("Diagnoses:", dateFont, Brushes.Black, leftMargin, yPos));
            yPos += 16.86523F;

            List<string> diagnosesList = new List<string>();
            diagnosesList.Add(diagnoses);
            diagnosesList = SplitStringsForPrinting(80, diagnosesList);
            foreach (string diagnosesLine in diagnosesList) {
                pp.AddPrintableObject(new PrintableTextObject(diagnosesLine, printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                if (yPos > 1050) {
                    yPos = topMargin;
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                }
            }

            yPos += 16.86523F;
            pp.AddPrintableObject(new PrintableTextObject("TODO:", dateFont, Brushes.Black, leftMargin, yPos));
            yPos += 16.86523F;
            List<string> todoList = new List<string>();
            todoList.Add(todo);
            todoList = SplitStringsForPrinting(80, todoList);
            foreach (string todoLine in todoList) {
                pp.AddPrintableObject(new PrintableTextObject(todoLine, printFont, Brushes.Black, leftMargin, yPos));
                yPos += 16.86523F;
                if (yPos > 1050) {
                    yPos = topMargin;
                    pd.AddPrintPage(pp);
                    pp = new PrintablePage();
                }
            }

            pd.AddPrintPage(pp);

            pd.duplicate(numberOfSheets);

            pd.DoPrint();
            
        }
    }
}
