/*
*
* * HomePage Package Body 
*
*/

CREATE OR REPLACE PACKAGE Body HomePagePackage AS
    --Body For get Info from Home Page
    PROCEDURE GetHomePage AS c_all sys_refcursor;
    BEGIN
        open c_all for
        select * from Homepage;
        DBMS_SQL.RETURN_RESULT(c_all);
    END GetHomePage;

    --Body For UpdateInfo
    PROCEDURE UpdateInfo( 
            H_id IN Homepage.id%TYPE, 
            H_Name IN Homepage.Sitename%TYPE, 
            H_email IN Homepage.Siteemail%TYPE, 
            H_phoneNum IN Homepage.Sitephonenumber%TYPE) AS        
    BEGIN
    UPDATE Homepage SET Sitename=H_Name, Siteemail=H_email, Sitephonenumber=H_phoneNum 
    WHERE id = H_id;
    COMMIT;
    END UpdateInfo;
End HomePagePackage;  