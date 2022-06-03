-- Start Code

-- Account Test Data
INSERT INTO Account
VALUES(100, 'admin', '12345678', 'admin@admin.com', 'Admin Admin',
       'N/A', '05-FEB-00', 'Jordan', 'OK', 'Admin', 'admin.png');
       
       
INSERT INTO Account
VALUES(101, 'abdalhameed', 'dalgamouni', 'dabdalhammed6@gmail.com',
'Abd Al Hameed Mohammed Nayif Al-Dalgamouni', 'Male', '05-FEB-00', 
'Jordan, Irbid', 'OK', 'Student', 'default.png');


-- CreditCard Test Data
INSERT INTO CreditCard VALUES(100, 1234567890, 432.25, 101);


-- PhoneNumber Test Data
INSERT INTO PhoneNumber VALUES (100, '+962775158103', 101);
INSERT INTO PhoneNumber VALUES (101, '+962797597550', 101);

INSERT INTO PhoneNumber VALUES (102, '+962777777777', 100);

-- Course Test Data
INSERT INTO Course VALUES(300, 'Python', 'Python Programming Language',
                          'ENABLE', 'python.png');
                          
INSERT INTO Course VALUES(301, 'C++', 'C++ Programming Language', 
                          'ENABLE', 'cplusplus.png');


-- Exam Test Data
INSERT INTO Exam
VALUES(200, 300, 'Python Basics', 'GFSQWEQR',
'Python Programming Language Basic Exam', 'Beginner',
50, 35.32, '03-FEB-22', '04-FEB-22', 'ENABLE', '03-FEB-22');

INSERT INTO Exam
VALUES(201, 300, 'Python OOP', 'F12WEQWR',
'Python Programming Language OOP Exam', 'Intermediate',
60.6, 50, '03-FEB-22', '04-FEB-22', 'ENABLE', '03-FEB-22');

INSERT INTO Exam
VALUES(202, 301, 'C++ OOP', 'GEEWWER',
'C++ Programming Language OOP Exam', 'Intermediate', 
60, 124.213, '03-FEB-22', '04-FEB-22', 'ENABLE', '03-FEB-22');

INSERT INTO Exam 
VALUES(203, 301, 'C++ Basics', 'KHJBFGH', 
'C++ Programming Language Basic Exam', 'Beginner',
50, 25, '03-FEB-22', '04-FEB-22', 'ENABLE', '03-FEB-22');

COMMIT;

-- End Code