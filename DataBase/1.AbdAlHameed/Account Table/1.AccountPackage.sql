-- Start Code

CREATE OR REPLACE PACKAGE AccountPackage AS
    
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
        profileImg IN account.profilePicture%type DEFAULT NULL);

    -- Get Usernames Procedure
    PROCEDURE GetUsernames;

    -- Get Full Names Procedure
    PROCEDURE GetFullNames;

    -- Get Emails
    PROCEDURE GetEmails;

    -- Get Accounts By UserName, Email, Full Name and Role Name Procedure
    PROCEDURE SearchAccount(
        uName IN account.username%type DEFAULT NULL,
        mail IN account.email%type DEFAULT NULL,
        fName IN account.fullName%type DEFAULT NULL,
        rName IN account.roleName%type DEFAULT NULL);

    -- Get Blocked Accounts Procedure
    PROCEDURE GetBlockedAccounts;

    -- Get Blocked Usernames
    PROCEDURE GetBlockedUsernames;

    -- Block User By Id, Username Or Email Procedure
    PROCEDURE BlockUser(
        accid IN account.id%type,
        uName IN account.username%type,
        mail IN account.email%type);

    -- Unblock User By Id, Username Or Email Procedure
    PROCEDURE UnblockUser(
        accid IN account.id%type,
        uName IN account.username%type,
        mail IN account.email%type);

    -- Login Procedure
    PROCEDURE Login(
        uName IN VARCHAR,
        passw IN account.password%type);
        
    -- Get Account By Id Procedure
    PROCEDURE GetAccountById(accid IN account.id%type);

END AccountPackage;

-- End Code