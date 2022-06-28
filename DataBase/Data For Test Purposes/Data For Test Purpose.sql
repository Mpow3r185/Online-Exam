--- Start Code

-- Account Test Data
INSERT INTO Account
VALUES(100, 'admin', '12345678', 'admin@admin.com', 'Admin Admin',
       'N/A', '05-FEB-00', 'Jordan', 'OK', 'Admin', 'person-three.jpg');
       
INSERT INTO Account
VALUES(101, 'abdalhameed', 'dalgamouni', 'dabdalhammed6@gmail.com',
'Abd Al Hameed Mohammed Nayif Al-Dalgamouni', 'Male', '05-FEB-00', 
'Jordan, Irbid', 'OK', 'Student', 'person-two.jpg');

INSERT INTO Account
VALUES(102, 'yazeed', '123456789', 'yazeed@gmail.com',
'Yazeed Bani-Ata', 'Male', '07-JUN-1999', 
'Jordan, Irbid', 'OK', 'Student', 'user2.jpg');

INSERT INTO Account
VALUES(103, 'haneen', '123456789', 'haneen@gmail.com',
'Haneen Al-Momani', 'Female', '25-OCT-1996', 
'Jordan, Ajloun', 'OK', 'Student', 'person-one.jpg');

INSERT INTO Account
VALUES(104, 'mahmoud', '123456789', 'mahmoud@gmail.com',
'Mahmoud Hamarsheh', 'Male', '01-MAY-1998', 
'Jordan, Amman', 'OK', 'Student', 'person-three.jpg');

COMMIT;

-- CreditCard Test Data
INSERT INTO CreditCard VALUES(100, 1234567890, 432.25, 101);


-- PhoneNumber Test Data
INSERT INTO PhoneNumber VALUES (100, '+962775158103', 101);
INSERT INTO PhoneNumber VALUES (101, '+962797597550', 101);

INSERT INTO PhoneNumber VALUES (102, '+962777777777', 100);

COMMIT;

-- Course Test Data
INSERT INTO Course VALUES(300, 'python', 'Python Programming Language',
                          'ENABLE', 'python-course.jpeg');
                          
INSERT INTO Course VALUES(301, 'c++', 'C++ Programming Language', 
                          'ENABLE', 'cPlusPlus-course.png');
                          
INSERT INTO Course VALUES(302, 'english', 'English Language (USA)', 
                          'ENABLE', 'english-course.png');
                          
INSERT INTO Course VALUES(303, 'physics', 'Physics Theory', 
                          'ENABLE', 'physics-course.jpg');
                          
INSERT INTO Course VALUES(303, 'math', 'Math Theory', 
                          'ENABLE', 'math-course.png');

COMMIT;

-- Exam Test Data
INSERT INTO Exam
VALUES(200, 300, 'python pasics', 'GFSQWEQR',
'Python Programming Language Basic Exam', 'Beginner',
50, 35, 35.32, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'python-exam.jpeg', '03-FEB-22');

INSERT INTO Exam
VALUES(201, 300, 'python oop', 'F12WEQWR',
'Python Programming Language OOP Exam', 'Intermediate',
60.6, 70, 50, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'python-exam.jpeg', '03-FEB-22');

INSERT INTO Exam
VALUES(202, 301, 'c++ oop', 'GEEWWER',
'C++ Programming Language OOP Exam', 'Intermediate', 
60, 60, 124.213, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'cPlusPlus-exam.png', '03-FEB-22');

INSERT INTO Exam 
VALUES(203, 301, 'C++ Basics', 'KHJBFGH', 
'C++ Programming Language Basic Exam', 'Beginner',
50, 20, 25, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'cPlusPlus-exam.png', '03-FEB-22');

INSERT INTO Exam 
VALUES(204, 302, 'english basics', 'KHJBFDGH', 
'English Basics Language Speaking, Writing and Grammer', 'Beginner',
50, 20, 25, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'english-exam.png', '03-FEB-22');

INSERT INTO Exam 
VALUES(205, 302, 'english writing', 'KHJBFCGH', 
'English writing in advance', 'Advanced',
70, 28, 56, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'english-exam.png', '03-FEB-22');

INSERT INTO Exam 
VALUES(206, 302, 'English Speaking', 'KHJBFSGH', 
'English speaking in expert', 'Expert',
80, 35, 125, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'english-exam.png', '03-FEB-22');

INSERT INTO Exam 
VALUES(207, 302, 'english grammer', 'KHJBVS', 
'English grammer in advance', 'Advanced',
70, 25, 79, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'english-exam.png', '03-FEB-22');

INSERT INTO Exam 
VALUES(208, 303, 'atomic physics', 'KHJCGH', 
'English grammer in advance', 'Expert',
85, 65, 79, '03-FEB-22', '04-FEB-22', 'HIDE', 'ENABLE'
, 'physics-exam.jpg', '03-FEB-22');

COMMIT;


-- Invoice Test Data
INSERT INTO Invoice (id, examId, accountId)
VALUES (9000, 203, 101);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9001, 203, 103);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9002, 203, 102);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9003, 202, 101);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9004, 201, 101);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9005, 201, 103);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9006, 200, 102);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9007, 200, 101);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9008, 200, 104);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9009, 203, 104);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9010, 204, 103);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9011, 205, 102);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9012, 207, 101);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9013, 208, 103);

INSERT INTO Invoice (id, examId, accountId)
VALUES (9014, 208, 104);

COMMIT;


-- Testimonial Test Data
INSERT INTO Testimonial (id, accountId, message, status)
VALUES(10001, 101, 'A testimonial is an honest endorsement of your product or service that usually comes from a customer, colleague, or peer who has benefited from or experienced success as a result of the work you did for them.', 'ACCEPTED');

INSERT INTO Testimonial (id, accountId, message, status)
VALUES(10002, 102, 'But effective testimonials go beyond a simple quote that proclaims your greatness. They need to resonate with your target audience and the people who could also potentially benefit from the work you do in the future. That"s why great.', 'ACCEPTED');

INSERT INTO Testimonial (id, accountId, message, status)
VALUES(10003, 103, 'Your testimonial page serves as a platform to show off how others have benefited from your product or service, making it a powerful tool for establishing trust and encouraging potential buyers to take action.', 'REJECTED');

INSERT INTO Testimonial (id, accountId, message, status)
VALUES(10004, 104, 'Plus, having a testimonial page serves as yet another indexed page on your website. It contains content covering product features, pain points, and keywords your marketing team is trying to rank for in search.', 'ACCEPTED');

INSERT INTO Testimonial (id, accountId, message, status)
VALUES(10005, 100, 'Testimonials come in different formats, but there are a few distinct qualities that all good testimonials have. Here’s how to write a testimonial that inspires and motivates readers.', 'PENDING');

COMMIT;


-- End Code