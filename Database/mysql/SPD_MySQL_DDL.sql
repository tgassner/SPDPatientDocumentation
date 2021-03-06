CREATE TABLE `patient` (
	`patientID` BIGINT NOT NULL auto_increment,
	firstname text not null,
	surname text not null,
	birthdate text not null,
	sex varchar(50) not null,
	phone text not null,
	furthertreatment longtext not null,
	address text not null,
	weight BIGINT not null,
	residentOfAsmara BIGINT not null,
	finished BIGINT not null,
	ambulant BIGINT not null,
	linz BIGINT not null,
	waitListStartDate text,
	stoneReport longtext not null,
	PRIMARY KEY (`patientID`)
);


CREATE TABLE `operation` (
	`operationID` BIGINT NOT NULL auto_increment,
	`operationdate` text not null,
	`team` text not null,
	`process` longtext not null,
	`diagnoses` text not null,
	`performed` text not null,
	`patientID` BIGINT not null,
	`additionalinformation` text not null,
	`medication` text not null,
	`intdiagnoses` BIGINT not null,
	`ppps` BIGINT not null,
	`result` BIGINT not null,
	`kathDays` BIGINT not null,
   `organ` BIGINT not null,
	PRIMARY KEY (`operationID`),
	FOREIGN KEY (`patientID`) REFERENCES `patient` (`patientID`)
);

CREATE TABLE `visit` (
	`VisitID` BIGINT NOT NULL auto_increment,
	`cause` text not null,
	`localis` text not null,
	`extradiagnosis` text not null,
	`prozedure` text not null,
	`extratherapy` text not null,
	`patientid` BIGINT not null,
	`visitdate` text not null,
	`anesthesiology` text not null,
	`ultrasound` longtext not null,
	`blooddiagnostic` text not null,
	`todo` text not null,
	`radiodiagnostics` text not null,
	PRIMARY KEY (`VisitID`),
	FOREIGN KEY (`patientid`) REFERENCES `patient` (`patientID`)
);

CREATE TABLE `nextAction` (
	`nextActionID` BIGINT NOT NULL auto_increment,
	`PatientID` BIGINT not null,
   `actionkind` BIGINT not null,
   `actionyear` BIGINT not null,
   `actionhalfyear` BIGINT not null,
	`todo` text not null,
	PRIMARY KEY (`nextActionID`),
	FOREIGN KEY (`PatientID`) REFERENCES `patient` (`patientID`)
);

CREATE TABLE `photo` (
	`PhotoID` BIGINT NOT NULL auto_increment,
	`PatientID` BIGINT not null,
   `Link` text not null,
	`Kommentar` text not null,
	PRIMARY KEY (`PhotoID`),
	FOREIGN KEY (`PatientID`) REFERENCES `patient` (`patientID`)
);

CREATE TABLE `diagnoseGroup` (
	`diagnoseGroupID` BIGINT NOT NULL auto_increment,
   `shortDescr` text not null,
	`longDescr` text not null,
	PRIMARY KEY (`diagnoseGroupID`)
);

CREATE TABLE `patientDiagnoseGroup` (
	`patientID` BIGINT NOT NULL,
   `diagnoseGroupID` BIGINT not null,
	PRIMARY KEY (`patientID`, `diagnoseGroupID`),
	FOREIGN KEY (`PatientID`) REFERENCES `patient` (`patientID`),
	FOREIGN KEY (`diagnoseGroupID`) REFERENCES `diagnoseGroup` (`diagnoseGroupID`)
);