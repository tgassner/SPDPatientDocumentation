CREATE sequence patientsequence
       increment BY 1 start WITH 1 cache 2;

CREATE sequence operationsequence
       increment BY 1 start WITH 1 cache 2;

CREATE sequence visitsequence
       increment BY 1 start WITH 1 cache 2;
       
CREATE sequence photosequence
       increment BY 1 start WITH 1 cache 2;

CREATE sequence nextactionsequence
       increment BY 1 start WITH 1 cache 2;       
 
CREATE sequence diagnosegroupsequence
       increment BY 1 start WITH 1 cache 2;     
       
CREATE TABLE patient (
	patientID number(16,0) NOT NULL ,
	firstname varchar2(255) not null,
	surname varchar2(255) not null,
	birthdate varchar2(255) not null,
	sex varchar(50) not null,
	phone varchar2(255) not null,
	furthertreatment varchar2(4000) not null,
	address varchar2(255) not null,
	weight number(16,0) not null,
    residentOfAsmara number(16,0) not null,
	finished number(16,0) not null,
	ambulant number(16,0) not null,
	linz number(16,0) not null,
	waitListStartDate  varchar2(255),
	PRIMARY KEY (patientID)
);


CREATE TABLE operation (
	operationID  number(16,0) NOT NULL ,
	operationdate varchar2(255) not null,
	team varchar2(255) not null,
	process varchar2(4000) not null,
	diagnoses varchar2(255) not null,
	performed varchar2(255) not null,
	patientID number(16,0) not null,
	additionalinformation varchar2(255) not null,
	medication varchar2(255) not null,
	intdiagnoses number(16,0) not null,
	ppps number(16,0) not null,
	result number(16,0) not null,
	kathDays number(16,0) not null,
  organ number(16,0) not null,
	PRIMARY KEY (operationID),
	FOREIGN KEY (patientID) REFERENCES patient (patientID)
);

CREATE TABLE visit (
	VisitID  number(16,0) NOT NULL ,
	cause varchar2(255) not null,
	localis varchar2(255) not null,
	extradiagnosis varchar2(255) not null,
	prozedure varchar2(255) not null,
	extratherapy varchar2(255) not null,
	patientid number(16,0) not null,
	visitdate varchar2(255) not null,
	anesthesiology varchar2(255) not null,
	ultrasound varchar2(4000) not null,
	blooddiagnostic  varchar2(255) not null,
	todo varchar2(255) not null,
	radiodiagnostics varchar2(255) not null,
	PRIMARY KEY (VisitID),
	FOREIGN KEY (patientid) REFERENCES patient (patientID)
);

CREATE TABLE nextAction (
	nextActionID  number(16,0) NOT NULL ,
	PatientID number(16,0) not null,
   actionkind number(16,0) not null,
   actionyear number(16,0) not null,
   actionhalfyear number(16,0) not null,
	todo varchar2(255) not null,
	PRIMARY KEY (nextActionID),
	FOREIGN KEY (PatientID) REFERENCES patient (patientID)
);

CREATE TABLE photo (
	PhotoID  number(16,0) NOT NULL ,
	PatientID number(16,0) not null,
   Link varchar2(255) not null,
	Kommentar varchar2(255) not null,
	PRIMARY KEY (PhotoID),
	FOREIGN KEY (PatientID) REFERENCES patient (patientID)
);

CREATE TABLE diagnoseGroup (
	diagnoseGroupID number(16,0) NOT NULL,
  shortDescr varchar(255) not null,
	longDescr varchar(255) not null,
	PRIMARY KEY (diagnoseGroupID)
);

CREATE TABLE patientDiagnoseGroup (
	patientID number(16,0) NOT NULL,
  diagnoseGroupID number(16,0) not null,
	PRIMARY KEY (patientID, diagnoseGroupID),
	FOREIGN KEY (PatientID) REFERENCES patient (patientID),
	FOREIGN KEY (diagnoseGroupID) REFERENCES diagnoseGroup (diagnoseGroupID)
);

CREATE TRIGGER patient_t1 BEFORE INSERT ON patient
       REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
Begin
SELECT patientsequence.NEXTVAL number(16,0)O :NEW.patientID FROM DUAL;
End;
/

CREATE TRIGGER operation_t1 BEFORE INSERT ON operation
       REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
Begin
SELECT operationsequence.NEXTVAL number(16,0)O :NEW.operationID FROM DUAL;
End;
/

CREATE TRIGGER visit_t1 BEFORE INSERT ON visit
       REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
Begin
SELECT visitsequence.NEXTVAL number(16,0)O :NEW.VisitID FROM DUAL;
End;
/

CREATE TRIGGER photo_t1 BEFORE INSERT ON photo
       REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
Begin
SELECT photosequence.NEXTVAL number(16,0)O :NEW.PhotoID FROM DUAL;
End;
/

CREATE TRIGGER nextAction_t1 BEFORE INSERT ON nextAction
       REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
Begin
SELECT nextactionsequence.NEXTVAL number(16,0)O :NEW.nextActionID FROM DUAL;
End;
/

CREATE TRIGGER diagnoseGroup_t1 BEFORE INSERT ON diagnoseGroup
       REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
Begin
SELECT diagnosegroupsequence.NEXTVAL number(16,0)O :NEW.diagnoseGroupID FROM DUAL;
End;
/