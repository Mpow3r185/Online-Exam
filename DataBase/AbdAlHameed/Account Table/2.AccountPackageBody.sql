create or replace PACKAGE BODY AccountPackage AS
    
    -- CRUD Procedures
    -- Get Accounts Procedure
    PROCEDURE GetAccounts AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Account;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetAccounts;

    -- Create Account Procedure
    PROCEDURE CreateAccount(
        uName IN account.username%type,
        passw IN account.password%type,
        mail IN account.email%type,
        fName IN account.fullName%type,
        sex IN account.gender%type,
        birthOfDate IN account.bod%type,
        addr IN account.address%type,
        rName IN account.roleName%type,
        profileImg IN account.profilePicture%type) AS
        BEGIN
            INSERT INTO Account
            (username, password, email, fullName, gender,
            bod, address, roleName, profilePicture)

            VALUES(uName, passw, mail, fName, sex, birthOfDate,
                   addr, rName, profileImg);

        commit;
        END CreateAccount;

    -- Update Account Procedure
    PROCEDURE UpdateAccount(
        accid IN account.id%type,
        uName IN account.username%type,
        passw IN account.password%type,
        mail IN account.email%type,
        fName IN account.fullName%type,
        sex IN account.gender%type,
        birthOfDate IN account.bod%type,
        addr IN account.address%type,
        rName IN account.roleName%type,
        profileImg IN account.profilePicture%type) AS
        BEGIN
            UPDATE Account SET 
                username = uName,
                password = passw,
                email = mail,
                fullName = fName,
                gender = sex,
                bod = birthOfDate,
                address = addr,
                roleName = rName,
                profilePicture = profileImg
            WHERE id = accid;

            commit;
        END UpdateAccount;

    -- Delete Account Procedure
    PROCEDURE DeleteAccount(accid IN account.id%type) AS
    BEGIN
        DELETE Account WHERE id = accid;

        commit;
    END DeleteAccount;
    -- CRUD Procedures

    -- Get Usernames Procedure
    PROCEDURE GetUsernames AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT username
        FROM Account;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetUsernames;

    -- Get Full Names Procedure
    PROCEDURE GetFullNames AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT fullName
        FROM Account;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetFullNames;

    -- Get Emails
    PROCEDURE GetEmails AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT email
        FROM Account;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetEmails;

    -- Get Accounts By UserName, Email, Full Name and Role Name Procedure
    PROCEDURE SearchAccount(
        uName IN account.username%type,
        mail IN account.email%type,
        fName IN account.fullName%type,
        rName IN account.roleName%type) AS

        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Account
        WHERE (uName IS NULL OR username LIKE '%' || uName || '%')
        AND (mail IS NULL OR email LIKE '%' || mail || '%')
        AND (fName IS NULL OR fullName LIKE '%' || fName || '%')
        AND (rName IS NULL OR roleName LIKE '%' || rName || '%');

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END SearchAccount;

END AccountPackage;

-- End Code
