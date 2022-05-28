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

END AccountPackage;

-- End Code
