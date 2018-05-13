
--1
CREATE TABLE Hospital (
  Branch_Id              INT           NOT NULL    IDENTITY,
  H_Address          VARCHAR(100)  NOT NULL,
  PRIMARY KEY (Branch_Id)
);


--7

CREATE TABLE Department  (
  Dpt_id              INT           NOT NULL    IDENTITY   PRIMARY KEY,
  Dpt_Name          VARCHAR(100)  NOT NULL,
  Branch_id         INT               NOT NULL,
  FOREIGN KEY (Branch_id)
    REFERENCES Hospital (Branch_Id)
 );

--2  changed
CREATE TABLE Patient  (
  P_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  P_Name          VARCHAR(100)  NOT NULL,
  P_Gender  VARCHAR(100) NOT NULL,
  P_Age             INT           NOT NULL, 
  P_CNIC  VARCHAR(100) NOT NULL,
  Dpt_Id              INT           NOT NULL ,
  Brnch_Id             int not null,
  	FOREIGN KEY (Brnch_Id)
    REFERENCES Hospital (Branch_Id),
  CONSTRAINT FK_Patient FOREIGN KEY (Dpt_Id)
    REFERENCES Department (Dpt_id),
);

--3 changed
CREATE TABLE Doctor  (
  D_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  D_Name          VARCHAR(100)  NOT NULL,
  D_Gender  VARCHAR(100) NOT NULL,
  D_Age             INT           NOT NULL, 
  D_CNIC  VARCHAR(100) NOT NULL,
  D_DeptID              INT           NOT NULL ,
  D_Salary              INT           NOT NULL ,
  D_designation  VARCHAR(100) NOT NULL,
  Brnch_Id             int not null,
  	FOREIGN KEY (Brnch_Id)
    REFERENCES Hospital (Branch_Id),
  CONSTRAINT FK_Doct FOREIGN KEY (D_DeptID )
    REFERENCES Department (Dpt_id)
	
);

----19
--create table Doc_Pay(
--Pay_Id int not null identity primary key,
--Pay_date datetime not null,
--Doctor_Id int not null,
--pay_status int not null,
-- CONSTRAINT FK_docPay FOREIGN KEY (Doctor_Id )
--    REFERENCES Doctor (D_Id),
--	CONSTRAINT FK_Paystatus FOREIGN KEY (pay_status )
--    REFERENCES P_Status (PayStatusId)
--);


--4 changed
CREATE TABLE Staff   (
 S_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
 S_Name          VARCHAR(100)  NOT NULL,
 S_Gender  VARCHAR(100) NOT NULL,
 S_Age             INT           NOT NULL , 
 S_CNIC  VARCHAR(100) NOT NULL,
 S_Salary              INT           NOT NULL ,
 Brnch_Id             int not null,
 	FOREIGN KEY (Brnch_Id)
   REFERENCES Hospital (Branch_Id),
);

----20
--create table Staff_Pay(
--Pay_Id int not null identity primary key,
--Pay_date datetime not null,
--Staff_Id int not null,
--pay_status int not null,
-- CONSTRAINT FK_dochPay FOREIGN KEY (Staff_Id )
--    REFERENCES Staff (S_Id),
--	CONSTRAINT FK_Paystatvus FOREIGN KEY (pay_status )
--    REFERENCES P_Status (PayStatusId)
--);


--17
--CREATE TABLE Accessibility  (
  --Access_Id              INT           NOT NULL    IDENTITY   PRIMARY KEY,
  --Functionality        VARCHAR(100)  NOT NULL,
 --);

----6
--CREATE TABLE UserLogin   (
--  U_LoginId         VARCHAR(100)  NOT NULL PRIMARY KEY,
--  U_Password         VARCHAR(100)  NOT NULL,
-- );

--5  changed
CREATE TABLE H_User(
  U_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  U_Name          VARCHAR(100)  NOT NULL,
  U_Gender  VARCHAR(100) NOT NULL,
  U_Age             INT           NOT NULL , 
  U_CNIC  VARCHAR(100) NOT NULL,
  U_Salary              INT           NOT NULL ,
  Access_Id             INT           NOT NULL ,   --admin=1, receptionist=0
  U_LoginId            VARCHAR(100)           NOT NULL ,
  U_Password         VARCHAR(100)  NOT NULL,
   Brnch_Id             int not null,
  
  	FOREIGN KEY (Brnch_Id)
    REFERENCES Hospital (Branch_Id)
);


--8
CREATE TABLE Bills   (
  B_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  Patient_Id              INT           NOT NULL,
  B_Amount              INT           NOT NULL,
  B_Date          datetime  NOT NULL,
  No_of_Days  INT NOT NULL,
  Med_Charges             INT           NOT NULL ,
  D_Age             INT           NOT NULL , 
  Room_Charges             INT           NOT NULL , 
  Total_Bill              INT            Not null,   -- total of all charges of individual patient 
  CONSTRAINT FK_Bills FOREIGN KEY (Patient_Id )
    REFERENCES Patient (P_Id) 
);
--  Maham yay bill ka table fill krna hai tumhay. baki ho gia hai

--10 wars = rooms
CREATE TABLE wards (
  Ward_Id              INT           NOT NULL    IDENTITY   PRIMARY KEY,
  WardName  VARCHAR(100) NOT NULL,  
  Charges_per_day              INT           NOT NULL ,
 );


--9
CREATE TABLE Bed (
  Bed_Id              INT           NOT NULL    IDENTITY PRIMARY KEY,
  ward_Id             INT           NOT NULL ,
  Bed_Status  VARCHAR(100) NOT NULL, --(free or occupied)
   CONSTRAINT FK_Bedd FOREIGN KEY (ward_Id )
    REFERENCES wards (Ward_Id)
);

--11
--only for pharmacy
CREATE TABLE Medicine  (
  Med_Id             INT           NOT NULL    IDENTITY   PRIMARY KEY,
  Med_Name  VARCHAR(100) NOT NULL,
  MCost_Per_Unit              INT           NOT NULL ,
 );

 --12
 --for visits use following query
 -- select count(*) as Num_visits from Examined_Patient group by Patient_Id having Patient_Id=getPatientID(comboBox2.Selected.,Item())

 CREATE TABLE Examined_Patient    (
  InP_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  visit               INT           DEFAULT             0,     
  Patient_Id              INT           NOT NULL,
  --R_Id              INT           NOT NULL,
  Date_Of_Exam          datetime  NOT NULL,
  --Date_Of_Dis          datetime  NOT NULL,
 -- B_Id              INT           NOT NULL,  -- 1 for Regular, 0 for admitted
  PatientStatus        INT            NOT NULL, -- 1 for admitted 2 for regular
  CONSTRAINT FK_AdmitPatientAkb FOREIGN KEY (Patient_Id )
    REFERENCES Patient (P_Id)
);
 --Admit Patient
--Regular Patient
-- craete patientroombed
 --(
--int pID not null,
--int roomId not null,
--int bedID not null
 -- )
--22
create table doctor_examinedPatient(
 doc_Id int not null,
 pat_Id int not null,
 FOREIGN KEY (doc_Id )
    REFERENCES Doctor (D_Id),
	 FOREIGN KEY (pat_Id )
    REFERENCES Patient (P_Id),
);
--13
--make a table for AdmittedPatient
--//attributes(id,p_id,ward_Id,bed_Id,admitted_date)
create table AdmittedPatient(
 id int not null,
 p_id int not null,
 ward_Id int not null,
 bed_Id int not null,
 admitted_date datetime not null,
  FOREIGN KEY (p_id )
    REFERENCES Patient (P_Id),
 FOREIGN KEY (ward_Id )
    REFERENCES wards (Ward_Id),
    FOREIGN KEY (bed_Id )
    REFERENCES Bed (Bed_Id)
);




--14
-- ++++++++++++++++++++++++++++KHUNSHA say current date ka puchna hai+++++++++++++++++++++++++
-- add another attribute for billId
 CREATE TABLE OutPatient     (
  OP_Id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  Patient_Id              INT           NOT NULL,
  O_Date        datetime  NOT NULL,
  Doctor_Id              INT           NOT NULL,
  patient_charges        int           not null,
  CONSTRAINT FK_AdmitPatientA FOREIGN KEY (Patient_Id )
    REFERENCES Patient (P_Id), 
	CONSTRAINT FK_AdmitPatientC FOREIGN KEY (Doctor_Id )
    REFERENCES Doctor (D_Id),
);



----18
--create table AttendenceStatus(
--Status_Id int not null identity primary key,
--Status_Name VARCHAR(100) not null
--);
--15
--create table DoctorAttendance(
--Attendance_Id int not null identity primary key,
-- Doctor_Id int not null, 
-- D_Date date not null,
--  Status_Id int not null,
--  constraint FK_DAttendanceA foreign key (Doctor_Id)
--  references Doctor (D_Id),
--  constraint FK_DAttendanceB foreign key (Status_Id)
--  references AttendenceStatus (Status_Id)
--);


----16
--create table StaffAttendance(
--Attendance_Id int not null identity primary key,
-- Staff_Id int not null, 
-- S_Date date not null,
--  Status_Id int not null,
--  constraint FK_DAttendancedA foreign key (Staff_Id)
--  references Staff (S_Id),
--  constraint FK_DAttendancedB foreign key (Status_Id)
--  references AttendenceStatus (Status_Id)
--);
create table DocRegistry
(
docID int not null,
docRegNo varchar(100) not null,
docPassword varchar(100) not null,
foreign key(docID)
references Doctor(D_Id)
);

-- ++++++++++++++++++++++++++++KHUNSHA say foreign key ka puchna hai+++++++++++++++++++++++++



CREATE TABLE disease
(
  diseaseId int not null identity primary key,
  diseaseName varchar(100) not null,
);

create table patientdisease(
pat_Id int not null,
diseaseId int not null,
FOREIGN KEY (diseaseId )
    REFERENCES disease (diseaseId),
   FOREIGN KEY (pat_Id )
    REFERENCES Patient (P_Id),

);

CREATE TABLE priscription
(
  priscriptionId int not null identity primary key,
  prisccriptionName varchar(100) not null,  -- it would be a medicine name
);

-- ++++++++++++++++++++++++++++KHUNSHA say foreign key ka puchna hai+++++++++++++++++++++++++
create table patient_priscription
  (
     priscriptionId int not null, --  forieign + primary key
     patientId      int not null,  -- foreign key + primary key
     FOREIGN KEY (priscriptionId )
    REFERENCES priscription (priscriptionId),
   FOREIGN KEY (patientId )
    REFERENCES Patient (P_Id),
    );

              

