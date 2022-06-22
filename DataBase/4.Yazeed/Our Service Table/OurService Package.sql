
-- Package for Table Our Service
--------------------------------------------------------

/* 
*
* * Our Service Package Header 
*
*/

CREATE OR REPLACE PACKAGE OurServicePackage AS
    --Question CRUD operation
    PROCEDURE OurServiceCRUD(
               func IN VARCHAR DEFAULT NULL,
               Sid OurService.id%TYPE, 
	       Stitle OurService.title%TYPE,
	       Stext OurService.text%TYPE);
END OurServicePackage;

