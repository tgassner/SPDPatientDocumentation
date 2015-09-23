using System;
using System.Collections.Generic;
using System.Text;
using SpeechLib;
using System.Diagnostics;
using SimplePatientDocumentation.CommonObjects;
using SimplePatientDocumentation.BL;

namespace SimplePatientDocumentation.VoiceInfo {

    public enum State {
        init,
        cognitied,
        master,
        lastOperation,
        allOperation,
        lastVisit,
        allVisit
    }

    class VoiceInfoAutomat {

        private State state;
        private const int grammarId = 10;
        //private ISpeechGrammarRule ruleTopLevel;
        //private ISpeechGrammarRule ruleListItemsNames;
        //private ISpeechGrammarRule ruleListItemsIDs;
        //private ISpeechGrammarRule ruleListItemsDefault;
        List<string> patientenNameList;
        List<long> patientIDList;
        IList<PatientData> patientList;
        private PatientData currentPatient;
        private PatientDocumentationComponent patientComponent;


        public VoiceInfoAutomat(List<string> patientenNameList, List<long> patientIDList) {
            state = State.init;
            this.patientenNameList = patientenNameList;
            this.currentPatient = null;
            patientComponent = new PatientDocumentationComponent();
            this.patientenNameList = patientenNameList;
            this.patientIDList = patientIDList;
            patientList = patientComponent.GetAllPatients();
        }

        public State Status {
            get {
                return this.state;
            }
        }

        public State EnterCommand(string command) {
            Debug.WriteLine("EnterCommand " + this.state);
            command.Trim();
            switch(this.state){
                case State.init:
                    if (command.StartsWith("name")) {
                        string patientName = command.Remove(0, 4).Trim();
                        foreach (PatientData patient in patientList) {
                            if (patientName.Equals(patient.FirstName + " " + patient.SurName)) {
                                this.state = State.cognitied;
                                this.currentPatient = patient;
                            }
                        }
                    } else if (command.StartsWith("id")) {
                        long patientID = 0;
                        if (command.Length <= 2) {
                            return this.state;
                        }
                        try {
                            patientID = Int64.Parse(command.Remove(0, 2).Trim());
                        } catch (FormatException) {
                            this.currentPatient = null;
                            return this.state;
                        }
                        foreach (PatientData patient in patientList) {
                            if (patientID == patient.Id) {
                                this.state = State.cognitied;
                                this.currentPatient = patient;
                            }
                        }
                    }
                    break;

                case State.cognitied:
                    if (command.Equals("master")) {
                        this.state = State.master;
                    } else if (command.Equals("operation")) {
                        this.state = State.lastOperation;
                    } else if (command.Equals("visit")) {
                        this.state = State.lastVisit;
                    } else if (command.Equals("reset")) {
                        this.state = State.init;
                    }
                    break;

                case State.master:
                    if (command.Equals("repeat")) {
                        this.state = State.master;
                    } else if (command.Equals("back")) {
                        this.state = State.cognitied;
                    } else if (command.Equals("reset")) {
                        this.state = State.init;
                    } else if (command.Equals("repeat")) {
                        this.state = State.master;
                    }
                    break;

                case State.lastOperation:
                    if (command.Equals("more")) {
                        this.state = State.allOperation;
                    } else if (command.Equals("back")) {
                        this.state = State.cognitied;
                    } else if (command.Equals("reset")) {
                        this.state = State.init;
                    } else if (command.Equals("repeat")) {
                        this.state = State.lastOperation;
                    }
                    break;

                case State.lastVisit:
                    if (command.Equals("more")) {
                        this.state = State.allVisit;
                    } else if (command.Equals("back")) {
                        this.state = State.cognitied;
                    } else if (command.Equals("reset")) {
                        this.state = State.init;
                    } else if (command.Equals("repeat")) {
                        this.state = State.lastVisit;
                    }
                    break;

                case State.allOperation:
                    if (command.Equals("back")) {
                        this.state = State.cognitied;
                    } else if (command.Equals("reset")) {
                        this.state = State.init;
                    } else if (command.Equals("repeat")) {
                        this.state = State.allOperation;
                    }
                    break;

                case State.allVisit:
                    if (command.Equals("back")) {
                        this.state = State.cognitied;
                    } else if (command.Equals("reset")) {
                        this.state = State.init;
                    } else if (command.Equals("repeat")) {
                        this.state = State.allVisit;
                    }
                    break;

                default:

                    break;
            }
            return this.state;
        }

        public bool RebuildGrammar(ISpeechRecoGrammar grammar, bool speechEnabled,
            SpSharedRecoContext objRecoContext, ISpeechGrammarRule ruleListItemsDefault) {

            Debug.WriteLine("RebuildGrammar " + this.state.ToString());

            if (!speechEnabled) {
                return false;
            }

            //grammar = objRecoContext.CreateGrammar(grammarId);
            ////ruleTopLevel = grammar.Rules.Add("TopLevelRule", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);
            object PropValue = "";

            switch (this.state) {
                case State.init:
                    //ruleListItemsNames = grammar.Rules.Add("ListItemsNameRule", SpeechRuleAttributes.SRADynamic, 2);
                    //ruleListItemsIDs = grammar.Rules.Add("ListItemsIDRule", SpeechRuleAttributes.SRADynamic, 3);
                    //ruleListItemsDefault = grammar.Rules.Add("ListItemsDefaultRule", SpeechRuleAttributes.SRADynamic, 2);

                    //SpeechLib.ISpeechGrammarRuleState stateName;
                    //SpeechLib.ISpeechGrammarRuleState stateID;
                    ////SpeechLib.ISpeechGrammarRuleState stateDefault;

                    //stateName = ruleTopLevel.AddState();
                    //stateID = ruleTopLevel.AddState();
                    ////stateDefault = ruleListItemsDefault.AddState();

                    //object PropValue1 = "";
                    //object PropValue2 = "";
                    ////PropValue = "";

                    //ruleTopLevel.InitialState.AddWordTransition(stateName, "name", " ", SpeechGrammarWordType.SGLexical, "", 0, ref PropValue1, 1.0F);
                    //ruleTopLevel.InitialState.AddWordTransition(stateID, "id", " ", SpeechGrammarWordType.SGLexical, "", 0, ref PropValue2, 1.0F);
                    ////ruleTopLevel.InitialState.AddWordTransition(stateDefault, " ", " ", SpeechGrammarWordType.SGLexical, "", 0, ref PropValue, 1.0F);

                    //PropValue1 = "";
                    //PropValue2 = "";
                    ////PropValue = "";

                    //stateName.AddRuleTransition(null, ruleListItemsNames, "", 1, ref PropValue1, 0F);
                    //stateID.AddRuleTransition(null, ruleListItemsIDs, "", 1, ref PropValue2, 0F);
                    ////stateDefault.AddRuleTransition(null, ruleListItemsDefault, "", 1, ref PropValue, 0F);

                    try {
                        //ruleListItemsNames.Clear();
                        //ruleListItemsIDs.Clear();
                        ruleListItemsDefault.Clear();

                        //int i = 0;
                        //foreach (string patientName in patientenNameList) {
                        //    string word = patientName;
                        //    ruleListItemsNames.InitialState.AddWordTransition(null, word, " ", SpeechGrammarWordType.SGLexical, word, i, ref PropValue1, 1F);
                        //    i++;
                        //}

                        //i = 0;
                        //foreach (long patientID in patientIDList) {
                        //    long ID = patientID;
                        //    ruleListItemsIDs.InitialState.AddWordTransition(null, ID.ToString(), " ", SpeechGrammarWordType.SGLexical, ID.ToString(), i, ref PropValue2, 1F);
                        //    i++;
                        //}

                        int i = 0;
                        foreach (string patientName in patientenNameList) {
                            string word = "name " + patientName;
                            ruleListItemsDefault.InitialState.AddWordTransition(null, word, " ", SpeechGrammarWordType.SGLexical, word, i, ref PropValue, 1F);
                            i++;
                        }

                        foreach (long patientID in patientIDList) {
                            string word = "id " + patientID.ToString();
                            ruleListItemsDefault.InitialState.AddWordTransition(null, word, " ", SpeechGrammarWordType.SGLexical, word, i, ref PropValue, 1F);
                            i++;
                        }

                        grammar.Rules.Commit();

                        ////grammar.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                case State.cognitied:
                    //ruleListItemsDefault = grammar.Rules.Add("ListItemsDefaultRule", SpeechRuleAttributes.SRADynamic, 2);

                    //SpeechLib.ISpeechGrammarRuleState stateCognitied;
                    //stateCognitied = ruleTopLevel.AddState();

                    //PropValue = "";

                    //ruleTopLevel.InitialState.AddWordTransition(stateCognitied, "", " ", SpeechGrammarWordType.SGLexical, "", 0, ref PropValue, 1.0F);

                    //PropValue = "";

                    //stateCognitied.AddRuleTransition(null, ruleListItemsDefault, "", 1, ref PropValue, 0F);

                    try {
                        ruleListItemsDefault.Clear();

                        ruleListItemsDefault.InitialState.AddWordTransition(null, "master", " ", SpeechGrammarWordType.SGLexical, "master", 0, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "operation", " ", SpeechGrammarWordType.SGLexical, "operation", 1, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "visit", " ", SpeechGrammarWordType.SGLexical, "visit", 2, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "reset", " ", SpeechGrammarWordType.SGLexical, "reset", 3, ref PropValue, 1F);
                        grammar.Rules.Commit();

                        //grammar.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                case State.master:
                    try {
                        ruleListItemsDefault.Clear();

                        ruleListItemsDefault.InitialState.AddWordTransition(null, "repeat", " ", SpeechGrammarWordType.SGLexical, "master", 0, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "back", " ", SpeechGrammarWordType.SGLexical, "operation", 1, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "reset", " ", SpeechGrammarWordType.SGLexical, "reset", 2, ref PropValue, 1F);
                        grammar.Rules.Commit();

                        //grammar.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                case State.lastOperation:
                    try {
                        ruleListItemsDefault.Clear();

                        ruleListItemsDefault.InitialState.AddWordTransition(null, "repeat", " ", SpeechGrammarWordType.SGLexical, "master", 0, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "back", " ", SpeechGrammarWordType.SGLexical, "operation", 1, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "reset", " ", SpeechGrammarWordType.SGLexical, "reset", 2, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "more", " ", SpeechGrammarWordType.SGLexical, "reset", 3, ref PropValue, 1F);
                        grammar.Rules.Commit();

                        //grammar.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                case State.lastVisit:
                    try {
                        ruleListItemsDefault.Clear();

                        ruleListItemsDefault.InitialState.AddWordTransition(null, "repeat", " ", SpeechGrammarWordType.SGLexical, "master", 0, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "back", " ", SpeechGrammarWordType.SGLexical, "operation", 1, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "reset", " ", SpeechGrammarWordType.SGLexical, "reset", 2, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "more", " ", SpeechGrammarWordType.SGLexical, "reset", 3, ref PropValue, 1F);
                        grammar.Rules.Commit();
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                case State.allOperation:
                    try {
                        ruleListItemsDefault.Clear();

                        ruleListItemsDefault.InitialState.AddWordTransition(null, "repeat", " ", SpeechGrammarWordType.SGLexical, "master", 0, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "back", " ", SpeechGrammarWordType.SGLexical, "operation", 1, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "reset", " ", SpeechGrammarWordType.SGLexical, "reset", 2, ref PropValue, 1F);
                        grammar.Rules.Commit();
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                case State.allVisit:
                    try {
                        ruleListItemsDefault.Clear();

                        ruleListItemsDefault.InitialState.AddWordTransition(null, "repeat", " ", SpeechGrammarWordType.SGLexical, "master", 0, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "back", " ", SpeechGrammarWordType.SGLexical, "operation", 1, ref PropValue, 1F);
                        ruleListItemsDefault.InitialState.AddWordTransition(null, "reset", " ", SpeechGrammarWordType.SGLexical, "reset", 2, ref PropValue, 1F);
                        grammar.Rules.Commit();
                    } catch (Exception e) {
                        System.Windows.Forms.MessageBox.Show(
                            "Exception caught when rebuilding dynamic listbox rule.\r\n\r\n"
                            + e.ToString(),
                            "Error");
                    }
                    break;

                default:

                    break;
            }

            return true;
        }

        public PatientData CurrentPatient{
            get {
                return this.currentPatient;
            }
        }
    }
}
