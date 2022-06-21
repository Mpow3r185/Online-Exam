-- Start Code


--------------------------------------------------------
--  DDL for Table Course
--------------------------------------------------------
CREATE TABLE Course
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  courseName VARCHAR(30) UNIQUE NOT NULL,
  description VARCHAR(300),
  
  status VARCHAR(7)
  DEFAULT('ENABLE')
  CHECK (Status IN ('ENABLE', 'DISABLE'))
  NOT NULL,
  
  courseImage VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL
);


--------------------------------------------------------
--  DDL for Table Exam
--------------------------------------------------------
CREATE TABLE Exam 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY NOT NULL PRIMARY KEY,
  courseId NUMBER,
  title VARCHAR2(50) UNIQUE NOT NULL,
  passcode VARCHAR(8) UNIQUE NOT NULL,
  description VARCHAR2(300),
  
  examLevel VARCHAR2(12) CHECK(examLevel IN ('Beginner',
                                         'Advanced',
                                         'Intermediate',
                                         'Expert')) NOT NULL,
  
  successMark FLOAT CHECK(successMark > 0) NOT NULL,
  
  cost FLOAT 
  DEFAULT(0) 
  CHECK(cost >= 0) NOT NULL,
                                            
  startDate TIMESTAMP NOT NULL,
  endDate TIMESTAMP NOT NULL,
  
  status VARCHAR(7)
  DEFAULT('ENABLE')
  CHECK (Status IN ('ENABLE', 'DISABLE'))
  NOT NULL, 
  
  creationDate TIMESTAMP DEFAULT(CURRENT_TIMESTAMP) NOT NULL, 
  
  CONSTRAINT course_exam_fk
  FOREIGN KEY (courseId) 
  REFERENCES course(ID) 
  ON DELETE SET NULL
);


--------------------------------------------------------
--  DDL for Table Question
--------------------------------------------------------
CREATE TABLE Question 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  questionContent VARCHAR(500) NOT NULL,
  
  type VARCHAR(8) 
  DEFAULT('Single')
  CHECK (type IN ('Single', 'Multiple', 'Fill'))
  NOT NULL,
  
  score FLOAT
  DEFAULT(0)
  CHECK(score >= 0),
  
  status VARCHAR(7)
  DEFAULT('ENABLE')
  CHECK (Status IN ('ENABLE', 'DISABLE'))
  NOT NULL,
  
  examId NUMBER NOT NULL,
  
  CONSTRAINT exam_question_fk
  FOREiGN KEY (examId)
  REFERENCES exam(Id) ON DELETE CASCADE
);


--------------------------------------------------------
--  DDL for Table ACCOUNT
--------------------------------------------------------
CREATE TABLE Account 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  
  username VARCHAR(12)
  UNIQUE
  NOT NULL
  CHECK(LENGTH(username) >= 5),
  
  password VARCHAR(15) 
  NOT NULL
  CHECK (LENGTH(password) >= 8),
  
  email VARCHAR(320) UNIQUE NOT NULL,
  
  fullName VARCHAR(60)
  NOT NULL
  CHECK (LENGTH(fullName) >= 6),
  
  gender VARCHAR(6)
  DEFAULT('N/A')
  NOT NULL
  CHECK (gender IN ('Male', 'Female', 'N/A')),
  
  boD DATE,
  address VARCHAR(255),
  
  status VARCHAR(5)
  DEFAULT ('OK')
  CHECK(status IN ('OK', 'BLOCK'))
  NOT NULL,
  
  roleName VARCHAR(7)
  DEFAULT('Student')
  NOT NULL
  CHECK (roleName IN ('Admin', 'Student')),
  
  profilePicture VARCHAR(255) NOT NULL
);

--------------------------------------------------------
--  DDL for Table PhoneNumber
--------------------------------------------------------
CREATE TABLE PhoneNumber
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  phoneNum VARCHAR(20) UNIQUE NOT NULL,
  accountId NUMBER NOT NULL,
  
  CONSTRAINT account_phoneNumber_fk
  FOREIGN KEY(accountId)
  REFERENCES account(id)
  ON DELETE CASCADE
);

--------------------------------------------------------
--  DDL for Table QuestionOption
--------------------------------------------------------
CREATE TABLE QuestionOption
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  optionContent VARCHAR(300) NOT NULL,
  questionId NUMBER NOT NULL,
  
  CONSTRAINT question_option_fk
  FOREIGN KEY(questionId)
  REFERENCES question(id)
  ON DELETE CASCADE
);

--------------------------------------------------------
--  DDL for Table CorrectAnswer
--------------------------------------------------------
CREATE TABLE CorrectAnswer
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  QuestionOptionId NUMBER NOT NULL,
  
  CONSTRAINT questionOption_correctAnswer_fk
  FOREIGN KEY(QuestionOptionId)
  REFERENCES questionOption(id)
  ON DELETE CASCADE
);

--------------------------------------------------------
--  DDL for Table Result
--------------------------------------------------------
CREATE TABLE Result 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  QuestionOptionId NUMBER,
  AccountId NUMBER NOT NULL,
  
  CONSTRAINT option_result_fk
  FOREIGN KEY(QuestionOptionId)
  REFERENCES QuestionOption(id)
  ON DELETE SET NULL,
  
  CONSTRAINT account_result_fk
  FOREIGN KEY(AccountId)
  REFERENCES account(id)
  ON DELETE CASCADE,
  
  CONSTRAINT Result_Unique
  UNIQUE(questionOptionId, accountId)
);

--------------------------------------------------------
--  DDL for Table Invoice
--------------------------------------------------------
CREATE TABLE Invoice 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  creationDate TIMESTAMP DEFAULT(CURRENT_TIMESTAMP) NOT NULL,
  examId NUMBER,
  accountId NUMBER NOT NULL,
  
  CONSTRAINT exam_invoice_fk
  FOREIGN KEY(examId)
  REFERENCES exam(id)
  ON DELETE SET NULL,
  
  CONSTRAINT account_invoice_fk
  FOREIGN KEY (accountId)
  REFERENCES account(id)
  ON DELETE CASCADE,
  
  CONSTRAINT Invoice_Unique
  UNIQUE(examId, AccountId)
);

--------------------------------------------------------
--  DDL for Table Certificate
--------------------------------------------------------
CREATE TABLE Certificate
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  creatioDate TIMESTAMP DEFAULT(CURRENT_TIMESTAMP) NOT NULL,
  examId NUMBER,
  accountId NUMBER NOT NULL,
  
  CONSTRAINT exam_certificate_fk
  FOREIGN KEY(examId)
  REFERENCES exam(id)
  ON DELETE SET NULL,
  
  CONSTRAINT account_certificate_fk
  FOREIGN KEY(accountId)
  REFERENCES account(id)
  ON DELETE CASCADE,
  
  CONSTRAINT Certificate_Unique
  UNIQUE(examId, AccountId)
);

--------------------------------------------------------
--  DDL for Table CreditCard
--------------------------------------------------------
CREATE TABLE CreditCard 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  cardNumber NUMBER UNIQUE NOT NULL,
  
  balance FLOAT
  DEFAULT(0)
  CHECK (balance >= 0)
  NOT NULL,
  
  accountId NUMBER NOT NULL,
  
  CONSTRAINT account_creditCard_fk
  FOREIGN KEY(accountId)
  REFERENCES account(id)
  ON DELETE CASCADE
);

--------------------------------------------------------
--  DDL for Table SCORE
--------------------------------------------------------
CREATE TABLE SCORE 
(
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  
  grade FLOAT
  CHECK (grade >= 0)
  NOT NULL,
  
  status VARCHAR(10)
  CHECK (status IN ('Successful', 'Fail'))
  NOT NULL,
  
  examId NUMBER,
  accountId NUMBER NOT NULL,
  
  CONSTRAINT exam_score_fk
  FOREIGN KEY(examId)
  REFERENCES exam(id)
  ON DELETE SET NULL,
  
  CONSTRAINT account_score_fk
  FOREIGN KEY(accountId)
  REFERENCES account(id)
  ON DELETE CASCADE,
  
  CONSTRAINT Score_Unique
  UNIQUE (examId, accountId)
);

--------------------------------------------------------
--  DDL for Table FillResult
--------------------------------------------------------
CREATE TABLE FillResult(
    ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    answer VARCHAR(255),
    questionId NUMBER,
    accountId NUMBER,
    
    CONSTRAINT Question_FillResult_FK
    FOREIGN KEY(questionId)
    REFERENCES Question(id)
    ON DELETE CASCADE,
    
    CONSTRAINT Account_FillResult_FK
    FOREIGN KEY(accountId)
    REFERENCES account(id)
    ON DELETE CASCADE,
    
    CONSTRAINT FillResult_Unique
    UNIQUE(questionId, accountId)
);
--------------------------------------------------------
--  DDL for Table dynamic_home
--------------------------------------------------------

create table DynamicHome(
ID NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  
webSiteName VARCHAR(100) NOT NULL,
logoDark VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
logoLight VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
  
imgSlider1 VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
imgSlider2 VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
imgSlider3 VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
  
title1 VARCHAR(255) NOT NULL,
subTitle1 VARCHAR(255) NOT NULL,
title2 VARCHAR(255) NOT NULL,
subTitle2 VARCHAR(255) NOT NULL,
  
popularParagraph VARCHAR(255) NOT NULL,
footerParagraph VARCHAR(255) NOT NULL,
footerBackground VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
aboutBackground VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
aboutParagraph VARCHAR(255) NOT NULL,
  
phoneNumber VARCHAR(20) NOT NULL,
email VARCHAR(255) NOT NULL,
address VARCHAR(255) NOT NULL,
  
contactParagraph VARCHAR(255) NOT NULL,
contactImage VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL,
secondaryBackground VARCHAR(255) DEFAULT('C_01.SVG') NOT NULL
);


-- End Code