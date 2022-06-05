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
  ACCID := 5;
  UNAME := 'TESTTEST';
  PASSW := '1234567890';
  MAIL := 'LOL@lol.com';
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

-- Get Blocked Usernames Procedure Test
BEGIN
  ACCOUNTPACKAGE.GETBLOCKEDUSERNAMES();
--rollback; 
END;
/

-- Block User Procedure Test
DECLARE
  ACCID NUMBER;
  UNAME VARCHAR2(12);
  MAIL VARCHAR2(320);
BEGIN
  ACCID := 1;
  UNAME := NULL;
  MAIL := NULL;

  ACCOUNTPACKAGE.BLOCKUSER(
    ACCID => ACCID,
    UNAME => UNAME,
    MAIL => MAIL
  );
--rollback; 
END;
/

-- Unblock User Procedure Test
DECLARE
  ACCID NUMBER;
  UNAME VARCHAR2(12);
  MAIL VARCHAR2(320);
BEGIN
  ACCID := 1;
  UNAME := NULL;
  MAIL := NULL;

  ACCOUNTPACKAGE.UNBLOCKUSER(
    ACCID => ACCID,
    UNAME => UNAME,
    MAIL => MAIL
  );
--rollback; 
END;
/

-- Login Procedure Test
DECLARE
  UNAME VARCHAR2(200);
  PASSW VARCHAR2(15);
BEGIN
  UNAME := 'admin@admin.com';
  PASSW := '12345678';

  ACCOUNTPACKAGE.LOGIN(
    UNAME => UNAME,
    PASSW => PASSW
  );
--rollback; 
END;

/

-- End Code