-- Start Code

/*Basic C++ Questions*/

SET DEFINE OFF;

-- Q1 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2000, 'What is a correct syntax to output "Hello World" in C++?',
'Single', 2, 203);

-- Q1 Questions Options
INSERT INTO QuestionOption VALUES(4000, 'print ("Hello World");', 2000);
INSERT INTO QuestionOption VALUES(4001, 'Console.WriteLine("Hello World");', 2000);
INSERT INTO QuestionOption VALUES(4002, 'System.out.println("Hello World");', 2000);
INSERT INTO QuestionOption VALUES(4003, 'cout << "Hello World";', 2000);

-- Q1 Correct Answer
INSERT INTO CorrectAnswer VALUES(5000, 4003);


-----------------------------------------------------------
-- Q2 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2001, 'C++ is an alias of C#',
'Single', 2, 203);

-- Q2 Questions Options
INSERT INTO QuestionOption VALUES(4004, 'False', 2001);
INSERT INTO QuestionOption VALUES(4005, 'True', 2001);

-- Q2 Correct Answer
INSERT INTO CorrectAnswer VALUES(5001, 4004);


-----------------------------------------------------------
-- Q3 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2002, 'How do you insert COMMENTS in C++ code?',
'Single', 2, 203);

-- Q3 Questions Options
INSERT INTO QuestionOption VALUES(4006, '// This is a comment', 2002);
INSERT INTO QuestionOption VALUES(4007, '/* This is a comment', 2002);
INSERT INTO QuestionOption VALUES(4008, '# This is a comment', 2002);

-- Q3 Correct Answer
INSERT INTO CorrectAnswer VALUES(5002, 4006);


-----------------------------------------------------------
-- Q4 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2003, 'Which data type is used to create a variable that should store text?',
'Single', 2, 203);

-- Q4 Questions Options
INSERT INTO QuestionOption VALUES(4009, 'String', 2003);
INSERT INTO QuestionOption VALUES(4010, 'Txt', 2003);
INSERT INTO QuestionOption VALUES(4011, 'string', 2003);
INSERT INTO QuestionOption VALUES(4012, 'myString', 2003);

-- Q4 Correct Answer
INSERT INTO CorrectAnswer VALUES(5003, 4011);


-----------------------------------------------------------
-- Q5 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2004, 'How do you create a variable with the numeric value 5?',
'Single', 2, 203);

-- Q5 Questions Options
INSERT INTO QuestionOption VALUES(4013, 'x = 5;', 2004);
INSERT INTO QuestionOption VALUES(4014, 'int x = 5;', 2004);
INSERT INTO QuestionOption VALUES(4015, 'double x = 5;', 2004);
INSERT INTO QuestionOption VALUES(4016, 'num x = 5', 2004);

-- Q5 Correct Answer
INSERT INTO CorrectAnswer VALUES(5004, 4014);


-----------------------------------------------------------
-- Q6 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2005, 'How do you create a variable with the floating number 2.8?',
'Single', 2, 203);

-- Q6 Questions Options
INSERT INTO QuestionOption VALUES(4017, 'x = 2.8;', 2005);
INSERT INTO QuestionOption VALUES(4018, 'int x = 2.8;', 2005);
INSERT INTO QuestionOption VALUES(4019, 'double x = 2.8;', 2005);
INSERT INTO QuestionOption VALUES(4020, 'byte x = 2.8', 2005);

-- Q6 Correct Answer
INSERT INTO CorrectAnswer VALUES(5005, 4019);


-----------------------------------------------------------
-- Q7 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2006, 'Which method can be used to find the length of a string?',
'Single', 2, 203);

-- Q7 Questions Options
INSERT INTO QuestionOption VALUES(4021, 'getLength()', 2006);
INSERT INTO QuestionOption VALUES(4022, 'getSize();', 2006);
INSERT INTO QuestionOption VALUES(4023, 'length()', 2006);
INSERT INTO QuestionOption VALUES(4024, 'len()', 2006);

-- Q7 Correct Answer
INSERT INTO CorrectAnswer VALUES(5006, 4023);


-----------------------------------------------------------
-- Q8 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2007, 'Which operator is used to add together two values?',
'Single', 2, 203);

-- Q8 Questions Options
INSERT INTO QuestionOption VALUES(4025, 'The * sign', 2007);
INSERT INTO QuestionOption VALUES(4026, 'The & sign;', 2007);
INSERT INTO QuestionOption VALUES(4027, 'The + sign', 2007);

-- Q8 Correct Answer
INSERT INTO CorrectAnswer VALUES(5007, 4027);


-----------------------------------------------------------
-- Q9 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2008, 'The value of a string variable can be surrounded by single quotes.',
'Single', 2, 203);

-- Q9 Questions Options
INSERT INTO QuestionOption VALUES(4028, 'False', 2008);
INSERT INTO QuestionOption VALUES(4029, 'True', 2008);

-- Q9 Correct Answer
INSERT INTO CorrectAnswer VALUES(5008, 4028);


-----------------------------------------------------------
-- Q10 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2009, 'Which header file lets us work with input and output objects?',
'Single', 2, 203);

-- Q10 Questions Options
INSERT INTO QuestionOption VALUES(4030, '#include <iosstring>', 2009);
INSERT INTO QuestionOption VALUES(4031, '#include <stream>', 2009);
INSERT INTO QuestionOption VALUES(4032, '#include <iostream>', 2009);
INSERT INTO QuestionOption VALUES(4033, '#include <inputstr>', 2009);

-- Q10 Correct Answer
INSERT INTO CorrectAnswer VALUES(5009, 4032);


-----------------------------------------------------------
-- Q11 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2010, 'Which operator can be used to compare two values?',
'Single', 2, 203);

-- Q11 Questions Options
INSERT INTO QuestionOption VALUES(4034, '==', 2010);
INSERT INTO QuestionOption VALUES(4035, '<>', 2010);
INSERT INTO QuestionOption VALUES(4036, '><', 2010);
INSERT INTO QuestionOption VALUES(4037, '=', 2010);

-- Q11 Correct Answer
INSERT INTO CorrectAnswer VALUES(5010, 4034);


-----------------------------------------------------------
-- Q12 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2011, 'To declare an array in C++, define the variable type with:',
'Single', 2, 203);

-- Q12 Questions Options
INSERT INTO QuestionOption VALUES(4040, '()', 2011);
INSERT INTO QuestionOption VALUES(4038, '[]', 2011);
INSERT INTO QuestionOption VALUES(4039, '{}', 2011);

-- Q12 Correct Answer
INSERT INTO CorrectAnswer VALUES(5011, 4038);


-----------------------------------------------------------
-- Q13 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2012, 'Array indexes start with:',
'Single', 2, 203);

-- Q13 Questions Options
INSERT INTO QuestionOption VALUES(4041, '1', 2012);
INSERT INTO QuestionOption VALUES(4042, '0', 2012);

-- Q13 Correct Answer
INSERT INTO CorrectAnswer VALUES(5012, 4042);


-----------------------------------------------------------
-- Q14 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2013, 'How do you create a function in C++?',
'Single', 2, 203);

-- Q14 Questions Options
INSERT INTO QuestionOption VALUES(4043, 'functionName.', 2013);
INSERT INTO QuestionOption VALUES(4044, 'functionName()', 2013);
INSERT INTO QuestionOption VALUES(4045, 'functionName[]', 2013);
INSERT INTO QuestionOption VALUES(4046, '(functionName)', 2013);

-- Q14 Correct Answer
INSERT INTO CorrectAnswer VALUES(5013, 4044);


-----------------------------------------------------------
-- Q15 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2014, 'How do you call a function in C++?',
'Single', 2, 203);

-- Q15 Questions Options
INSERT INTO QuestionOption VALUES(4047, 'functionName;', 2014);
INSERT INTO QuestionOption VALUES(4048, 'functionName();', 2014);
INSERT INTO QuestionOption VALUES(4049, 'functionName[];', 2014);
INSERT INTO QuestionOption VALUES(4050, '(functionName);', 2014);

-- Q15 Correct Answer
INSERT INTO CorrectAnswer VALUES(5014, 4048);


-----------------------------------------------------------
-- Q16 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2015, 'Which keyword is used to create a class in C++?',
'Single', 2, 203);

-- Q16 Questions Options
INSERT INTO QuestionOption VALUES(4051, 'MyClass', 2015);
INSERT INTO QuestionOption VALUES(4052, 'class()', 2015);
INSERT INTO QuestionOption VALUES(4053, 'class', 2015);
INSERT INTO QuestionOption VALUES(4054, 'className', 2015);

-- Q16 Correct Answer
INSERT INTO CorrectAnswer VALUES(5015, 4053);


-----------------------------------------------------------
-- Q17 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2016, 'What is the correct way to create an object called myObj of MyClass?',
'Single', 2, 203);

-- Q17 Questions Options
INSERT INTO QuestionOption VALUES(4055, 'class MyClass = new myObj();', 2016);
INSERT INTO QuestionOption VALUES(4056, 'class myObj = new MyClass();', 2016);
INSERT INTO QuestionOption VALUES(4057, 'MyClass myObj;	', 2016);
INSERT INTO QuestionOption VALUES(4058, 'new myObj = MyClass();', 2016);

-- Q17 Correct Answer
INSERT INTO CorrectAnswer VALUES(5016, 4057);


-----------------------------------------------------------
-- Q18 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2017, 'In C++, it is possible to inherit attributes and methods from one class to another.',
'Single', 2, 203);

-- Q18 Questions Options
INSERT INTO QuestionOption VALUES(4059, 'True', 2017);
INSERT INTO QuestionOption VALUES(4060, 'False', 2017);

-- Q18 Correct Answer
INSERT INTO CorrectAnswer VALUES(5017, 4059);


-----------------------------------------------------------
-- Q19 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2018, 'Which method can be used to find the highest value of x and y?',
'Single', 2, 203);

-- Q19 Questions Options
INSERT INTO QuestionOption VALUES(4061, 'max(x, y)', 2018);
INSERT INTO QuestionOption VALUES(4062, 'maxNum(x, y)', 2018);
INSERT INTO QuestionOption VALUES(4063, 'maximum(x, y)', 2018);
INSERT INTO QuestionOption VALUES(4064, 'largest(x, y)', 2018);

-- Q19 Correct Answer
INSERT INTO CorrectAnswer VALUES(5018, 4061);


-----------------------------------------------------------
-- Q20 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2019, 'Which operator is used to multiply numbers?',
'Single', 2, 203);

-- Q20 Questions Options
INSERT INTO QuestionOption VALUES(4065, '*', 2019);
INSERT INTO QuestionOption VALUES(4066, '%', 2019);
INSERT INTO QuestionOption VALUES(4067, '#', 2019);
INSERT INTO QuestionOption VALUES(4068, 'x', 2019);

-- Q20 Correct Answer
INSERT INTO CorrectAnswer VALUES(5019, 4065);

-----------------------------------------------------------
-- Q21 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2021, 'How do you create a reference variable of an existing variable?',
'Single', 2, 203);

-- Q21 Questions Options
INSERT INTO QuestionOption VALUES(4069, 'With the & operator', 2021);
INSERT INTO QuestionOption VALUES(4070, 'With the ref word', 2021);
INSERT INTO QuestionOption VALUES(4071, 'With the * operator', 2021);
INSERT INTO QuestionOption VALUES(4072, 'With the REF keyword', 2021);

-- Q21 Correct Answer
INSERT INTO CorrectAnswer VALUES(5020, 4069);


-----------------------------------------------------------
-- Q22 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2022, 'How do you start writing an if statement in C++?',
'Single', 2, 203);

-- Q22 Questions Options
INSERT INTO QuestionOption VALUES(4073, 'if(x > y)', 2022);
INSERT INTO QuestionOption VALUES(4074, 'if x > y', 2022);
INSERT INTO QuestionOption VALUES(4075, 'if x > then:', 2022);

-- Q22 Correct Answer
INSERT INTO CorrectAnswer VALUES(5021, 4073);


-----------------------------------------------------------
-- Q23 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2023, 'How do you start writing a while loop in C++?',
'Single', 2, 203);

-- Q23 Questions Options
INSERT INTO QuestionOption VALUES(4076, 'x > y while {', 2023);
INSERT INTO QuestionOption VALUES(4077, 'while x > y {', 2023);
INSERT INTO QuestionOption VALUES(4078, 'while (x > y)', 2023);
INSERT INTO QuestionOption VALUES(4079, 'while x > y:', 2023);

-- Q23 Correct Answer
INSERT INTO CorrectAnswer VALUES(5022, 4078);


-----------------------------------------------------------
-- Q24 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2024, 'Which keyword is used to return a value inside a method?',
'Single', 2, 203);

-- Q24 Questions Options
INSERT INTO QuestionOption VALUES(4080, 'return {', 2024);
INSERT INTO QuestionOption VALUES(4081, 'get', 2024);
INSERT INTO QuestionOption VALUES(4082, 'void', 2024);
INSERT INTO QuestionOption VALUES(4083, 'break', 2024);

-- Q24 Correct Answer
INSERT INTO CorrectAnswer VALUES(5023, 4080);


-----------------------------------------------------------
-- Q25 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2025, 'Which statement is used to stop a loop?',
'Single', 2, 203);

-- Q25 Questions Options
INSERT INTO QuestionOption VALUES(4084, 'exit {', 2025);
INSERT INTO QuestionOption VALUES(4085, 'return', 2025);
INSERT INTO QuestionOption VALUES(4086, 'break', 2025);
INSERT INTO QuestionOption VALUES(4087, 'stop', 2025);

-- Q25 Correct Answer
INSERT INTO CorrectAnswer VALUES(5024, 4086);

-----------------------------------------------------------
-- Q26 Questions
INSERT INTO Question (id, questionContent, type, score, examId)
VALUES (2026, 'Integer data type in c++ is called',
'Fill', 1.5, 203);

-- Q26 Questions Options
INSERT INTO QuestionOption VALUES(4089, 'int', 2026);


COMMIT;

-- End Code