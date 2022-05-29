-- Start Code

-- Account Test Data
INSERT INTO Account
(id, username, password, email, fullname, gender, rolename,profilePicture)
VALUES(100, 'admin', '12345678', 'admin@admin.com', 'Admin Admin',
       'N/A', 'Admin', 'admin.png');
       
       
INSERT INTO Account
(id, username, password, email, fullname, gender, rolename,profilePicture)
VALUES(101, 'abdalhameed', '12345678', 'dabdalhammed6@gmail.com',
'Abd Al Hameed', 'Male', 'Student', 'default.png');


-- CreditCard Test Data
INSERT INTO CreditCard VALUES(100, 1234567890, 432.25, 101);


-- PhoneNumber Test Data
INSERT INTO PhoneNumber VALUES (100, '+962775158103', 101);
INSERT INTO PhoneNumber VALUES (101, '+962797597550', 101);

INSERT INTO PhoneNumber VALUES (102, '+962777777777', 100);

-- Course Test Data
INSERT INTO Course (id, courseName) VALUES(100, 'Python');
INSERT INTO Course (id, courseName) VALUES(101, 'C++');


-- Exam Test Data
INSERT INTO Exam (id, courseId, title, passcode, examLevel, successMark, cost, startDate, endDate)
VALUES(100, 100, 'Python Basics', 'GFSQWEQR', 'Beginner', 50, 354.23, '29-MAY-22', '30-JUN-22');

INSERT INTO Exam (id, courseId, title, passcode, examLevel, successMark, startDate, endDate)
VALUES(101, 100, 'Python Data Science', 'F12WEQWR', 'Expert', 80, '30-MAY-22', '01-JUN-22');

INSERT INTO Exam (id, courseId, title, passcode, examLevel, successMark, startDate, endDate)
VALUES(102, 101, 'C++ OOP', 'GEEWWER', 'Intermediate', 75.4, '28-MAY-22', '01-JUN-22');

INSERT INTO Exam (id, courseId, title, passcode, examLevel, successMark, startDate, endDate)
VALUES(103, 101, 'C++ Basics', 'KHJBFGH', 'Beginner', 50, '04-JUN-22', '5-JUN-22');


-- Question Test Data
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (100, 'How do you insert COMMENTS in Python code?', 'Single', 2, 100);

INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (101, 'Which one is NOT a legal variable name?', 'Multiple', 2.5, 100);


-- Question Option Test Data
INSERT INTO QuestionOption VALUES(101, '// This is comment', 100); -- Single
INSERT INTO QuestionOption VALUES(102, '/* This is comment', 100); -- Single
INSERT INTO QuestionOption VALUES(103, '# This is comment', 100); -- Single
INSERT INTO QuestionOption VALUES(104, '-- This is comment', 100); -- Single

INSERT INTO QuestionOption VALUES(100, 'my#var', 101); -- Multiple
INSERT INTO QuestionOption VALUES(105, '_myvar', 101); -- Multiple
INSERT INTO QuestionOption VALUES(106, 'myVar', 101); -- Multiple
INSERT INTO QuestionOption VALUES(107, 'my-var', 101); -- Multiple
INSERT INTO QuestionOption VALUES(108, 'Myvar', 101); -- Multiple
INSERT INTO QuestionOption VALUES(109, 'my_var', 101); -- Multiple


-- CorrectAnswer Test Data
INSERT INTO CorrectAnswer VALUES(101, 103); -- For Single Question

INSERT INTO CorrectAnswer VALUES(102, 106); -- For Multiple Question
INSERT INTO CorrectAnswer VALUES(103, 109); -- For Multiple Question


-- Result Test Data
INSERT INTO Result VALUES(100, 105, 101); -- Multiple Question
INSERT INTO Result VALUES(101, 106, 101); -- Multiple Question
INSERT INTO Result VALUES(102, 109, 101); -- Multiple Question

INSERT INTO Result VALUES(103, 103, 101); -- Single Question

-- End Code