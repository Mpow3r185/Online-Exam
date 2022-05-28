-- Start Code

-- Create Account Procedure Test
DECLARE
  UNAME VARCHAR2(12);
  PASSW VARCHAR2(15);
  MAIL VARCHAR2(320);
  FNAME VARCHAR2(60);
  SEX VARCHAR2(6);
  BIRTHOFDATE DATE;
  ADDR VARCHAR2(255);
  ST VARCHAR(5);
  RNAME VARCHAR2(7);
  PROFILEIMG VARCHAR2(255);
BEGIN
  UNAME := 'Test123';
  PASSW := '123456789';
  MAIL := 'Test@test.com';
  FNAME := 'Test Test';
  SEX := 'N/A';
  BIRTHOFDATE := NULL;
  ADDR := NULL;
  ST := 'OK';
  RNAME := 'Student';
  PROFILEIMG := 'test.png';

  ACCOUNTPACKAGE.CREATEACCOUNT(
    UNAME => UNAME,
    PASSW => PASSW,
    MAIL => MAIL,
    FNAME => FNAME,
    SEX => SEX,
    BIRTHOFDATE => BIRTHOFDATE,
    ADDR => ADDR,
    ST => ST,
    RNAME => RNAME,
    PROFILEIMG => PROFILEIMG
  );
--rollback; 
END;
/

-- Get Account Procedure Test
BEGIN
  ACCOUNTPACKAGE.GETACCOUNTS();
--rollback; 
END;
/

-- Get Emails Procedure Test
BEGIN
  ACCOUNTPACKAGE.GETEMAILS();
--rollback; 
END;
/

-- Get Full Names Procedure Test
BEGIN
  ACCOUNTPACKAGE.GETFULLNAMES();
--rollback; 
END;
/

-- Get Usernames Procedure Test
BEGIN
  ACCOUNTPACKAGE.GETUSERNAMES();
--rollback; 
END;
/

-- Update Account Procedure Test
DECLARE
  ACCID NUMBER;
  UNAME VARCHAR2(12);
  PASSW VARCHAR2(15);
  MAIL VARCHAR2(320);
  FNAME VARCHAR2(60);
  SEX VARCHAR2(6);
  BIRTHOFDATE DATE;
  ADDR VARCHAR2(255);
  ST VARCHAR(5);
  RNAME VARCHAR2(7);
  PROFILEIMG VARCHAR2(255);
BEGIN
  ACCID := 2;
  UNAME := 'testtest';
  PASSW := '1234567890';
  MAIL := 'lol@lol.com';
  FNAME := 'Ahmad Mohammed';
  SEX := 'Male';
  BIRTHOFDATE := NULL;
  ADDR := NULL;
  ST := 'OK';
  RNAME := 'Admin';
  PROFILEIMG := 'ss.png';

  ACCOUNTPACKAGE.UPDATEACCOUNT(
    ACCID => ACCID,
    UNAME => UNAME,
    PASSW => PASSW,
    MAIL => MAIL,
    FNAME => FNAME,
    SEX => SEX,
    BIRTHOFDATE => BIRTHOFDATE,
    ADDR => ADDR,
    ST => ST,
    RNAME => RNAME,
    PROFILEIMG => PROFILEIMG
  );
--rollback; 
END;
/

-- Search Account Procedure Test
DECLARE
  UNAME VARCHAR2(12);
  MAIL VARCHAR2(320);
  FNAME VARCHAR2(60);
  RNAME VARCHAR2(7);
BEGIN
  UNAME := 'min';
  MAIL := 'z';
  FNAME := NULL;
  RNAME := NULL;

  ACCOUNTPACKAGE.SEARCHACCOUNT(
    UNAME => UNAME,
    MAIL => MAIL,
    FNAME => FNAME,
    RNAME => RNAME
  );
--rollback; 
END;
/

-- Delete Account Procedure Test
DECLARE
  ACCID NUMBER;
BEGIN
  ACCID := 2;

  ACCOUNTPACKAGE.DELETEACCOUNT(
    ACCID => ACCID
  );
--rollback; 
END;
/

-- Get Block Accounts Procedure Test
BEGIN
  ACCOUNTPACKAGE.GETBLOCKACCOUNTS();
--rollback; 
END;
/

-- Get Blocked Usernames
BEGIN
  ACCOUNTPACKAGE.GETBLOCKEDUSERNAMES();
--rollback; 
END;
/

-- End Code