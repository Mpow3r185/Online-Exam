-- Start Code

CREATE OR REPLACE PACKAGE AccountPackage AS
    
    -- CRUD Procedures
    -- Get Accounts Procedure
    PROCEDURE GetAccounts;

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
        profileImg IN account.profilePicture%type);

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
        profileImg IN account.profilePicture%type);

    -- Delete Account Procedure
    PROCEDURE DeleteAccount(accid IN account.id%type);
    -- CRUD Procedures

    -- Get Usernames Procedure
    PROCEDURE GetUsernames;

    -- Get Full Names Procedure
    PROCEDURE GetFullNames;

    -- Get Emails
    PROCEDURE GetEmails;

    -- Get Accounts By UserName, Email, Full Name and Role Name Procedure
    PROCEDURE SearchAccount(
        uName IN account.username%type,
        mail IN account.email%type,
        fName IN account.fullName%type,
        rName IN account.roleName%type);

    -- Get Block Accounts Procedure
    PROCEDURE GetBlockAccounts;

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

END AccountPackage;

-- End Code