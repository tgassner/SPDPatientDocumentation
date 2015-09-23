using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using SimplePatientDocumentation.CommonObjects;
using SimplePatientDocumentation.BL;
using System.Diagnostics;

namespace SimplePatientDocumentation.VoiceInfo {

    public partial class VoiceInfoMainForm : Form {

        #region locals

        private PatientDocumentationComponent patientComponent;
        private SpVoice voice = new SpVoice();
        private SpSharedRecoContext objRecoContext;
        List<string> patientenNameList;
        List<long> patientenIDList;
        private ISpeechRecoGrammar grammar;
        private bool speechEnabled;
        private bool speechInitialized = false;
        private VoiceInfoAutomat voiceInfoAutomat;
        private SpeechLib.ISpeechGrammarRule ruleTopLevel;
        private ISpeechGrammarRule ruleListItemsDefault;

        #endregion

        #region constructor

        public VoiceInfoMainForm() {
            InitializeComponent();
            patientenNameList = new List<string>();
            patientenIDList = new List<long>();
            patientComponent = new PatientDocumentationComponent();
            foreach(PatientData patient in patientComponent.GetAllPatients()){
                patientenNameList.Add(patient.FirstName + " " + patient.SurName);
                patientenIDList.Add(patient.Id);
            }
            voiceInfoAutomat = new VoiceInfoAutomat(this.patientenNameList, this.patientenIDList);
            this.SpeechEnabled = true;
            speechEnabled = true;
        }

        #endregion

        #region Speech

        //private void initSpeech() {
        //    //Debug.WriteLine("Initializing SAPI");
        //    try {
        //        //create Main context Obj
        //        objRecoContext = new SpSharedRecoContext();
        //        objRecoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(objRecoContext_Recognition);
        //        grammar = objRecoContext.CreateGrammar(0);
        //        string path = "Grammar.xml";
                
        //        grammar.CmdLoadFromFile(path, SpeechLoadOption.SLODynamic);
        //        //activate Top Level Rule
        //        grammar.CmdSetRuleIdState(0, SpeechRuleState.SGDSActive);
        //        //speechInitialized = true;
        //    } catch (Exception e) {
        //        logOut("Exception: " + e.ToString());
        //    }
        //}

        private void InitializeSpeech() {
            Debug.WriteLine("Initializing SAPI objects...");

            try {
                // First of all, let's create the main reco context object. 
                // In this sample, we are using shared reco context. Inproc reco
                // context is also available. Please see the document to decide
                // which is best for your application.
                objRecoContext = new SpeechLib.SpSharedRecoContext();

                // Then, let's set up the event handler. We only care about
                // Hypothesis and Recognition events in this sample.
                objRecoContext.Hypothesis += new
                    _ISpeechRecoContextEvents_HypothesisEventHandler(
                    RecoContext_Hypothesis);

                objRecoContext.Recognition += new
                    _ISpeechRecoContextEvents_RecognitionEventHandler(
                    RecoContext_Recognition);

                // Now let's build the grammar.
                // The top level rule consists of two parts: "select <items>". 
                // So we first add a word transition for the "select" part, then 
                // a rule transition for the "<items>" part, which is dynamically 
                // built as items are added or removed from the listbox.
                //grammar = objRecoContext.CreateGrammar(grammarId);
                //ruleTopLevel = grammar.Rules.Add("TopLevelRule",
                //    SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);
                //ruleListItems = grammar.Rules.Add("ListItemsRule",
                //    SpeechRuleAttributes.SRADynamic, 2);

                //SpeechLib.ISpeechGrammarRuleState stateAfterSelect;
                //stateAfterSelect = ruleTopLevel.AddState();

                //object PropValue = "";
                //ruleTopLevel.InitialState.AddWordTransition(stateAfterSelect,
                //    PreCommandString, " ", SpeechGrammarWordType.SGLexical,
                //    "", 0, ref PropValue, 1.0F);

                //PropValue = "";
                //stateAfterSelect.AddRuleTransition(null, ruleListItems, "",
                //    1, ref PropValue, 0F);

                // Now add existing list items to the ruleListItems


                grammar = objRecoContext.CreateGrammar(10);
                ruleTopLevel = grammar.Rules.Add("TopLevelRule", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);
                ruleListItemsDefault = grammar.Rules.Add("ListItemsRule", SpeechRuleAttributes.SRADynamic, 2);

                SpeechLib.ISpeechGrammarRuleState stateAfterSelect;
                stateAfterSelect = ruleTopLevel.AddState();

                object PropValue = "";
                ruleTopLevel.InitialState.AddWordTransition(stateAfterSelect, "", " ", SpeechGrammarWordType.SGLexical, "", 0, ref PropValue, 1.0F);

                PropValue = "";
                stateAfterSelect.AddRuleTransition(null, ruleListItemsDefault, "", 1, ref PropValue, 0F);

                voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);

                // Now we can activate the top level rule. In this sample, only 
                // the top level rule needs to activated. The ListItemsRule is 
                // referenced by the top level rule.
                
                grammar.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
                speechInitialized = true;
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(
                    "Exception caught when initializing SAPI."
                    + " This application may not run correctly.\r\n\r\n"
                    + e.ToString(),
                    "Error");
            }
        }


        //void objRecoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result) {
        //    //Debug.WriteLine("Recognition: " + Result.PhraseInfo.GetText(0, -1, true) + ", " + StreamNumber + ", " + StreamPosition);
        //    ISpeechPhraseElement elem0 = Result.PhraseInfo.Elements.Item(0);
        //    ISpeechPhraseElement elem1 = Result.PhraseInfo.Elements.Item(1);
        //    if (elem0 != null) {
                //if (elem0.DisplayText == "Color" && elem1 != null) {
                //    if (elem1.DisplayText == "Red") {
                //        this.lineColor = Color.Red;
                //        drawShape();
                //    }
                //    if (elem1.DisplayText == "Blue") {
                //        this.lineColor = Color.Blue;
                //        drawShape();
                //    }
                //    if (elem1.DisplayText == "Green") {
                //        this.lineColor = Color.Green;
                //        drawShape();
                //    }
                //}
                //if (elem0.DisplayText == "Shape" && elem1 != null) {
                //    if (elem1.DisplayText == "Rectangle") {
                //        this.shape = ShapeType.Rectangle;
                //        drawShape();
                //    }
                //    if (elem1.DisplayText == "Line") {
                //        this.shape = ShapeType.Line;
                //        drawShape();
                //    }
                //    if (elem1.DisplayText == "Oval") {
                //        this.shape = ShapeType.Oval;
                //        drawShape();
                //    }
                //}
        //    }
        //}

        private bool EnableSpeech() {
            Debug.Assert(speechEnabled, "speechEnabled must be true in EnableSpeech");

            if (this.DesignMode)
                return false;

            if (speechInitialized == false) {
                InitializeSpeech();
            } else {
                voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
            }

            objRecoContext.State = SpeechRecoContextState.SRCS_Enabled;
            return true;
        }

        private bool DisableSpeech() {
            if (this.DesignMode)
                return false;

            Debug.Assert(speechInitialized, "speech must be initialized in DisableSpeech");

            if (speechInitialized) {
                // Putting the recognition context to disabled state will 
                // stop speech recognition. Changing the state to enabled 
                // will start recognition again.
                objRecoContext.State = SpeechRecoContextState.SRCS_Disabled;
            }

            return true;
        }

        private bool SpeechEnabled {
            get {
                return speechEnabled;
            }
            set {
                if (speechEnabled != value) {
                    speechEnabled = value;
                    if (this.DesignMode)
                        return;

                    if (speechEnabled) {
                        EnableSpeech();
                    } else {
                        DisableSpeech();
                    }
                }
            }
        }

        public void RecoContext_Hypothesis(int StreamNumber, object StreamPosition, ISpeechRecoResult Result) {
            Debug.WriteLine("Hypothesis: " + Result.PhraseInfo.GetText(0, -1, true) + ", " +
                StreamNumber + ", " + StreamPosition);
            if (voiceInfoAutomat.Status == State.init) {
                this.understandet(Result.PhraseInfo.GetText(0, -1, true));
            }
        }

        public void RecoContext_Recognition(int StreamNumber, object StreamPosition,
                    SpeechRecognitionType RecognitionType, ISpeechRecoResult Result) {
            Debug.WriteLine("Recognition: " + Result.PhraseInfo.GetText(0, -1, true) + ", " +
                StreamNumber + ", " + StreamPosition);
            this.understandet(Result.PhraseInfo.GetText(0, -1, true));
            //ISpeechPhraseProperty oItem;
        }

        private void understandet(string command) {
            this.EnterCommand(command);
        }

        private void EnterCommand(string command) {
            command.Trim();
            State oldstate = voiceInfoAutomat.Status;
            voiceInfoAutomat.EnterCommand(command);
            switch (oldstate) {
                case State.init:
                    if (voiceInfoAutomat.Status == State.cognitied) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk("patientnumber: " + voiceInfoAutomat.CurrentPatient.Id + ", " + voiceInfoAutomat.CurrentPatient.FirstName + ", " + voiceInfoAutomat.CurrentPatient.SurName + ", recognited.");
                        talk(" say master for masterdata, operation for operation, visit for visit, reset for entering a new patient.");
                    }
                    break;

                case State.cognitied:
                    if (voiceInfoAutomat.Status == State.master) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talkPatient(voiceInfoAutomat.CurrentPatient);
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient.");
                    } else if (voiceInfoAutomat.Status == State.lastOperation) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talkOperation(patientComponent.GetLastOperationByPatientID(voiceInfoAutomat.CurrentPatient.Id));
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient, more for all operations of this patient.");
                    } else if (voiceInfoAutomat.Status == State.lastVisit) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talkVisit(patientComponent.GetLastVisitByPatientID(voiceInfoAutomat.CurrentPatient.Id));
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient, more for all operations of this patient.");
                    } else if (voiceInfoAutomat.Status == State.init) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk(" say name and the patientname, or id ant patientid for choosing a patient.");
                    }  
                    break;

                case State.master:
                    if ((voiceInfoAutomat.Status == State.master) && (command.Equals("repeat"))) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talkPatient(voiceInfoAutomat.CurrentPatient);
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient.");
                    } else if (voiceInfoAutomat.Status == State.cognitied) {
                        talk("patientnumber: " + voiceInfoAutomat.CurrentPatient.Id + ", " + voiceInfoAutomat.CurrentPatient.FirstName + ", " + voiceInfoAutomat.CurrentPatient.SurName + ".");
                        talk(" say master for masterdata, operation for operation, visit for visit, reset for entering a new patient.");
                    } else if (voiceInfoAutomat.Status == State.init) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk(" say name and the patientname, or id ant patientid for choosing a patient.");
                    }  
                    break;

                case State.lastOperation:
                    if (voiceInfoAutomat.Status == State.cognitied) {
                        talkPatient(voiceInfoAutomat.CurrentPatient);
                        talk("patientnumber: " + voiceInfoAutomat.CurrentPatient.Id + ", " + voiceInfoAutomat.CurrentPatient.FirstName + ", " + voiceInfoAutomat.CurrentPatient.SurName + ".");
                        talk(" say master for masterdata, operation for operation, visit for visit, reset for entering a new patient.");
                    } else if (voiceInfoAutomat.Status == State.init) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk(" say name and the patientname, or id ant patientid for choosing a patient.");
                    } else if ((voiceInfoAutomat.Status == State.lastOperation) && (command.Equals("repeat"))) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talkOperation(patientComponent.GetLastOperationByPatientID(voiceInfoAutomat.CurrentPatient.Id));
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient, more for all operations of this patient.");
                    } else if (voiceInfoAutomat.Status == State.allOperation) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        IList<OperationData> operations = patientComponent.GetOperationsByPatientID(voiceInfoAutomat.CurrentPatient.Id);
                        foreach (OperationData operation in operations) {
                            talkOperation(operation);
                        }
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient.");
                    }
                    break;

                case State.lastVisit:
                    if (voiceInfoAutomat.Status == State.cognitied) {
                        talkPatient(voiceInfoAutomat.CurrentPatient);
                        talk("patientnumber: " + voiceInfoAutomat.CurrentPatient.Id + ", " + voiceInfoAutomat.CurrentPatient.FirstName + ", " + voiceInfoAutomat.CurrentPatient.SurName + ".");
                        talk(" say master for masterdata, operation for operation, visit for visit, reset for entering a new patient.");
                    } else if (voiceInfoAutomat.Status == State.init) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk(" say name and the patientname, or id ant patientid for choosing a patient.");
                    } else if ((voiceInfoAutomat.Status == State.lastVisit) && (command.Equals("repeat"))) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talkVisit(patientComponent.GetLastVisitByPatientID(voiceInfoAutomat.CurrentPatient.Id));
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient, more for all visits of this patient.");
                    } else if (voiceInfoAutomat.Status == State.allVisit) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        IList<VisitData> visits = patientComponent.GetVisitsByPatientID(voiceInfoAutomat.CurrentPatient.Id);
                        foreach (VisitData visit in visits) {
                            talkVisit(visit);
                        }
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient.");
                    }
                    break;

                case State.allOperation:
                    if (voiceInfoAutomat.Status == State.cognitied) {
                        talkPatient(voiceInfoAutomat.CurrentPatient);
                        talk("patientnumber: " + voiceInfoAutomat.CurrentPatient.Id + ", " + voiceInfoAutomat.CurrentPatient.FirstName + ", " + voiceInfoAutomat.CurrentPatient.SurName + ".");
                        talk(" say master for masterdata, operation for operation, visit for visit, reset for entering a new patient.");
                    } else if (voiceInfoAutomat.Status == State.init) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk(" say name and the patientname, or id ant patientid for choosing a patient.");
                    } else if ((voiceInfoAutomat.Status == State.allOperation) && (command.Equals("repeat"))) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        IList<OperationData> operations = patientComponent.GetOperationsByPatientID(voiceInfoAutomat.CurrentPatient.Id);
                        foreach (OperationData operation in operations) {
                            talkOperation(operation);
                        }
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient.");
                    }
                    break;

                case State.allVisit:
                    if (voiceInfoAutomat.Status == State.cognitied) {
                        talkPatient(voiceInfoAutomat.CurrentPatient);
                        talk("patientnumber: " + voiceInfoAutomat.CurrentPatient.Id + ", " + voiceInfoAutomat.CurrentPatient.FirstName + ", " + voiceInfoAutomat.CurrentPatient.SurName + ".");
                        talk(" say master for masterdata, operation for operation, visit for visit, reset for entering a new patient.");
                    } else if (voiceInfoAutomat.Status == State.init) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        talk(" say name and the patientname, or id ant patientid for choosing a patient.");
                    } else if ((voiceInfoAutomat.Status == State.allVisit) && (command.Equals("repeat"))) {
                        voiceInfoAutomat.RebuildGrammar(this.grammar, this.speechEnabled, this.objRecoContext, ruleListItemsDefault);
                        IList<VisitData> visits = patientComponent.GetVisitsByPatientID(voiceInfoAutomat.CurrentPatient.Id);
                        foreach (VisitData visit in visits) {
                            talkVisit(visit);
                        }
                        talk(" say repeat for repeat the data, back for choosing more date of this patient, reset for choosing a new patient.");
                    }
                    break;

                default:

                    break;
            }
        }

        #endregion

        #region Talk

        private void talk(string text) {
            try {
                logOut("Talk: " + text);
                SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                voice.Volume = this.trackBarVolume.Value;
                voice.Rate = this.trackBarRate.Value;
                //if (checkBoxSaveToWavFile.Checked) {
                //    SaveFileDialog sfd = new SaveFileDialog();
                //    sfd.Filter = "All Files (*.*)|*.*| wav Files (*.wav)|*.wav";
                //    sfd.Title = "Save to Wav File";
                //    sfd.FilterIndex = 2;
                //    sfd.RestoreDirectory = true;
                //    if (sfd.ShowDialog() == DialogResult.OK) {
                //        SpeechStreamFileMode spFileMode = SpeechStreamFileMode.SSFMCreateForWrite;
                //        SpFileStream spFileStream = new SpFileStream();
                //        spFileStream.Open(sfd.FileName, spFileMode, false);
                //        voice.AudioOutputStream = spFileStream;
                //        voice.Speak(textBoxSpeekText.Text, spFlags);
                //        voice.WaitUntilDone(100);
                //        spFileStream.Close();
                //    }
                //} else{ 
                voice.Speak(text, spFlags);
                //voice.WaitUntilDone(100);
                //spFileStream.Close();
                //}
            } catch (Exception error) {
                logOut("Error: " + error.Message);
            }
        }

        private void talkPatient(PatientData patient){
            if (patient == null) {
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("patient number: ");
            sb.Append(patient.Id);
            sb.Append(". ");

            sb.Append("firstname: ");
            sb.Append(patient.FirstName);
            sb.Append(". ");

            sb.Append("surname: ");
            sb.Append(patient.SurName);
            sb.Append(". ");

            sb.Append("birthdate: ");
            sb.Append(patient.DateOfBirth.ToLongDateString());
            sb.Append(". ");

            sb.Append("weight: ");
            sb.Append(patient.Weight);
            sb.Append(". ");

            sb.Append("sex: ");
            sb.Append(patient.Sex.ToString());
            sb.Append(". ");

            sb.Append("phone: ");
            sb.Append(patient.Phone);
            sb.Append(". ");

            sb.Append("address: ");
            sb.Append(patient.Address);
            sb.Append(". ");

            talk(sb.ToString());
        }

        private void talkVisit(VisitData visit) {
            if (visit == null) {
                return;
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("visit id: ");
            sb.Append(visit.Id);
            sb.Append(". ");

            sb.Append("cause: ");
            sb.Append(visit.Cause);
            sb.Append(". ");

            sb.Append("localis: ");
            sb.Append(visit.Localis);
            sb.Append(". ");

            sb.Append("diagnosis: ");
            sb.Append(visit.ExtraDiagnosis);
            sb.Append(". ");

            sb.Append("prozedure: ");
            sb.Append(visit.Procedure);
            sb.Append(". ");

            sb.Append("therapy: ");
            sb.Append(visit.ExtraTherapy);
            sb.Append(". ");

            sb.Append("date: ");
            sb.Append(visit.VisitDate);
            sb.Append(". ");

            talk(sb.ToString());
        }

        private void talkOperation(OperationData operation) {
            if (operation == null) {
                return;
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("operation id: ");
            sb.Append(operation.OperationId);
            sb.Append(". ");

            sb.Append("date: ");
            sb.Append(operation.Date.ToLongDateString());
            sb.Append(". ");

            sb.Append("team: ");
            sb.Append(operation.Team);
            sb.Append(". ");

            sb.Append("process: ");
            sb.Append(operation.Process);
            sb.Append(". ");

            sb.Append("diagnoses: ");
            sb.Append(operation.Diagnoses);
            sb.Append(". ");

            sb.Append("performed: ");
            sb.Append(operation.Performed);
            sb.Append(". ");
            
            talk(sb.ToString());
        }

        #endregion

        #region GUI

        private void buttonStart_Click(object sender, EventArgs e) {
            List<PatientData> patients = (List<PatientData>)patientComponent.GetAllPatients();
            talkPatient(patients.ToArray()[0]);

        }

        private void VoiceInfoMainForm_Load(object sender, EventArgs e) {
            voice.Rate = 0; //zwischen -10 und +10
            voice.Volume = 50; //zwisachen 0 und 100
            foreach (ISpeechObjectToken token in voice.GetVoices(string.Empty, string.Empty)) {
                comboBoxStimmen.Items.Add(token.GetDescription(0));
            }
            comboBoxStimmen.SelectedIndex = 0;
            //initSpeech()
            InitializeSpeech();
            //talk(" say name and the patientname, or id ant patientid for choosing a patient.");
        }

        private void comboBoxStimmen_SelectedIndexChanged(object sender, EventArgs e) {
            voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(comboBoxStimmen.SelectedIndex);
        }

        private void checkBoxSpeechEnabled_CheckedChanged(object sender, EventArgs e) {
            this.SpeechEnabled = checkBoxSpeechEnabled.Checked;
        }

        #endregion

        #region Tools

        private void logOut(string message) {
            this.textBoxLog.Text = message + "\r\n" + this.textBoxLog.Text;
        }

        #endregion
    }
}