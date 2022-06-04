-- Start Code

-- Create Course Procedure Test
DECLARE
  CNAME VARCHAR2(30);
  DES VARCHAR2(300);
  ST VARCHAR2(7);
  CIMAGE VARCHAR2(255);
BEGIN
  CNAME := 'TestCourse';
  DES := 'Hello World';
  ST := 'ENABLE';
  CIMAGE := 'test.png';

  COURSEPACKAGE.CREATECOURSE(
    CNAME => CNAME,
    DES => DES,
    ST => ST,
    CIMAGE => CIMAGE
  );
--rollback; 
END;
/

-- Get Course By Id Procedure Test
DECLARE
  CID NUMBER;
BEGIN
  CID := 1;

  COURSEPACKAGE.GETCOURSEBYID(
    CID => CID
  );
--rollback; 
END;
/

-- Get Course Bt Name Procedure Test
DECLARE
  CNAME VARCHAR2(30);
BEGIN
  CNAME := 't';

  COURSEPACKAGE.GETCOURSEBYNAME(
    CNAME => CNAME
  );
--rollback; 
END;
/

-- Get Courses Procedure Test
BEGIN
  COURSEPACKAGE.GETCOURSES();
--rollback; 
END;
/

-- Get Courses Names Procedure Test
BEGIN
  COURSEPACKAGE.GETCOURSESNAMES();
--rollback; 
END;
/

-- Update Course Procedure Test
DECLARE
  CID NUMBER;
  CNAME VARCHAR2(30);
  DES VARCHAR2(300);
  ST VARCHAR2(7);
  CIMAGE VARCHAR2(255);
BEGIN
  CID := 7;
  CNAME := 'C++';
  DES := 'Updated';
  ST := 'DISABLE';
  CIMAGE := 'tt.png';

  COURSEPACKAGE.UPDATECOURSE(
    CID => CID,
    CNAME => CNAME,
    DES => DES,
    ST => ST,
    CIMAGE => CIMAGE
  );
--rollback; 
END;
/

-- Delete Course Procedure Test
DECLARE
  CID NUMBER;
BEGIN
  CID := 7;

  COURSEPACKAGE.DELETECOURSE(
    CID => CID
  );
--rollback; 
END;
/

-- End Code