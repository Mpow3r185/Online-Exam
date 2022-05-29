-- Start Code

CREATE OR REPLACE PACKAGE BODY AccountPackage AS
    
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
        st IN account.status%type,
        rName IN account.roleName%type,
        profileImg IN account.profilePicture%type) AS
        BEGIN
            INSERT INTO Account
            (username, password, email, fullName, gender,
            bod, address, status, roleName, profilePicture)

            VALUES(LOWER(uName), passw, LOWER(mail), fName, sex, birthOfDate,
                   addr, UPPER(st), rName, profileImg);

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
        st IN account.status%type,
        rName IN account.roleName%type,
        profileImg IN account.profilePicture%type) AS
        BEGIN
            UPDATE Account SET 
                username = LOWER(uName),
                password = passw,
                email = LOWER(mail),
                fullName = fName,
                gender = sex,
                bod = birthOfDate,
                address = addr,
                status = UPPER(st),
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

    -- Get Block Accounts Procedure
    PROCEDURE GetBlockAccounts AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Account
        WHERE status = 'BLOCK';

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetBlockAccounts;

    -- Get Blocked Usernames
    PROCEDURE GetBlockedUsernames AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT username
        FROM Account
        WHERE status = 'BLOCK';

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetBlockedUsernames;

    -- Block User By Id, Username Or Email Procedure
    PROCEDURE BlockUser(
        accid IN account.id%type,
        uName IN account.username%type,
        mail IN account.email%type) AS
    BEGIN
        UPDATE Account SET status = 'BLOCK'
        WHERE (accid IS  NULL OR id = accid)
        AND (uName IS NULL OR username = uName)
        AND (mail IS  NULL OR email = mail);

        commit;
    END BlockUser;

    -- Unblock User By Id, Username Or Email Procedure
    PROCEDURE UnblockUser(
        accid IN account.id%type,
        uName IN account.username%type,
        mail IN account.email%type) AS
    BEGIN
        UPDATE Account SET status = 'OK'
        WHERE (accid IS  NULL OR id = accid)
        AND (uName IS NULL OR username = uName)
        AND (mail IS  NULL OR email = mail);

        commit;
    END UnblockUser;
    
    -- Login Procedure
    PROCEDURE Login(
        uName IN account.username%type,
        mail IN account.email%type,
        passw IN account.password%type) AS
        
            ref_cursor SYS_REFCURSOR;
        BEGIN
            OPEN ref_cursor FOR
            SELECT *
            FROM Account
            WHERE ((uName IS NULL AND mail IS NOT NULL AND email = mail)
            OR (uName IS NOT NULL AND mail IS NULL AND username = uName))
            AND password = passw;
            
            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END Login;

END AccountPackage;

-- End Code