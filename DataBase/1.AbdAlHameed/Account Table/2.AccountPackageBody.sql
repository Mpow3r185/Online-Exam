-- Start Code

CREATE OR REPLACE PACKAGE BODY AccountPackage AS
    
    -- Account CRUD Operations
    PROCEDURE AccountCRUD(
        func IN VARCHAR DEFAULT NULL,
        accid IN account.id%type DEFAULT NULL,
        uName IN account.username%type DEFAULT NULL,
        passw IN account.password%type DEFAULT NULL,
        mail IN account.email%type DEFAULT NULL,
        fName IN account.fullName%type DEFAULT NULL,
        sex IN account.gender%type DEFAULT NULL,
        birthOfDate IN account.bod%type DEFAULT NULL,
        addr IN account.address%type DEFAULT NULL,
        st IN account.status%type DEFAULT NULL,
        rName IN account.roleName%type DEFAULT NULL,
        profileImg IN account.profilePicture%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
        IF func = 'CREATE' THEN
            INSERT INTO Account
            (username, password, email, fullName, gender,
            bod, address, status, roleName, profilePicture)
            VALUES(LOWER(uName), passw, LOWER(mail), fName, sex, birthOfDate,
                   addr, UPPER(st), rName, profileImg);

            COMMIT;            
        ELSIF func = 'UPDATE' THEN
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

            COMMIT;
        ELSIF func = 'DELETE' THEN
            DELETE Account WHERE id = accid;

            COMMIT;
        ELSE
            OPEN ref_cursor FOR
            SELECT *
            FROM Account;

            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END IF;
    END AccountCRUD;

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
        uName IN account.username%type DEFAULT NULL,
        mail IN account.email%type DEFAULT NULL,
        fName IN account.fullName%type DEFAULT NULL,
        rName IN account.roleName%type DEFAULT NULL) AS

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

    -- Get Blocked Accounts Procedure
    PROCEDURE GetBlockedAccounts AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Account
        WHERE status = 'BLOCK';

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetBlockedAccounts;

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
        uName IN VARCHAR,
        passw IN account.password%type) AS

            ref_cursor SYS_REFCURSOR;
        BEGIN
            OPEN ref_cursor FOR
            SELECT *
            FROM Account
            WHERE (email = uName OR username = uName)
            AND password = passw;

            DBMS_SQL.RETURN_RESULT(ref_cursor);
        END Login;
        
    -- Get Account By Id Procedure
    PROCEDURE GetAccountById(accid IN account.id%type) AS 
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Account
        WHERE id = accid;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetAccountById;

END AccountPackage;

-- End Code