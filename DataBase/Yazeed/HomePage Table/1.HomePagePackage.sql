--------------------------------------------------------
-- Package for Table HomePage
--------------------------------------------------------

/* 
*
* * HomePage Package Header 
*
*/

CREATE OR REPLACE PACKAGE HomePagePackage AS
    --get Info from Home Page
    PROCEDURE GetHomePage;
    --Update Course
    PROCEDURE UpdateInfo(
            H_id IN Homepage.id%TYPE, 
            H_Name IN Homepage.Sitename%TYPE, 
            H_email IN Homepage.Siteemail%TYPE, 
            H_phoneNum IN Homepage.Sitephonenumber%TYPE);
END HomePagePackage;