--  Phone Number PACKAGE

CREATE OR REPLACE PACKAGE PhoneNumberPackage AS


    -- Phone Number CRUD Operations
    PROCEDURE PhoneNumberCRUD(
        func IN VARCHAR DEFAULT NULL,
        phNumId PhoneNumber.ID%TYPE DEFAULT NULL,
        PhNum PhoneNumber.PHONENUM%TYPE DEFAULT NULL,
        accId PHONENUMBER.ACCOUNTID%TYPE DEFAULT NULL );
   
END PhoneNumberPackage;
