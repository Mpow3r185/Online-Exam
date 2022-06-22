

create or replace PACKAGE DynamicHomePackage AS
--GetALL
PROCEDURE GetALL;
--Update
PROCEDURE UpdateHome(webName VARCHAR, darkLogo VARCHAR, lightLogo VARCHAR, imageSlider1 VARCHAR,
imageSlider2 VARCHAR,imageSlider3 VARCHAR, title01 VARCHAR, subTitle01 VARCHAR,title02 VARCHAR, subTitle02 VARCHAR,
popularParag VARCHAR, footerParag VARCHAR, footerImg VARCHAR, aboutImg VARCHAR, aboutParag VARCHAR, phoneNum VARCHAR,
emaill VARCHAR, webAddress VARCHAR, contactParag VARCHAR, contactImg VARCHAR, headerImg VARCHAR,faviconIconn VARCHAR);

End DynamicHomePackage;



create or replace PACKAGE body DynamicHomePackage AS
PROCEDURE GetALL
as
C_all SYS_REFCURSOR;
begin
open C_all for
SELECT * from DynamicHome;
dbms_sql.return_result(c_all);
end GetALL;

PROCEDURE UpdateHome(webName VARCHAR, darkLogo VARCHAR, lightLogo VARCHAR, imageSlider1 VARCHAR,
imageSlider2 VARCHAR,imageSlider3 VARCHAR, title01 VARCHAR, subTitle01 VARCHAR,title02 VARCHAR, subTitle02 VARCHAR,
popularParag VARCHAR, footerParag VARCHAR, footerImg VARCHAR, aboutImg VARCHAR, aboutParag VARCHAR, phoneNum VARCHAR,
emaill VARCHAR, webAddress VARCHAR, contactParag VARCHAR, contactImg VARCHAR, headerImg VARCHAR,faviconIconn VARCHAR) as
begin
update DynamicHome
set
webSiteName = webName ,
LogoDark = darkLogo ,
LogoLight = lightLogo,
imgslider1 = imageSlider1,
imgslider2 = imageSlider2,
imgslider3 = imageSlider3,
title1 = title01,
subTitle1 = subTitle01,
title2 = title02,
subTitle2 = subTitle02,
popularParagraph = popularParag,
footerParagraph = footerParag,
FooterBackground = footerImg,
aboutBackground = aboutImg,
aboutParagraph = aboutParag,
phoneNumber = phoneNum,
email = emaill,
address = webAddress,
contactparagraph = contactParag,
contactImage = contactImg,
headerbackgroud = headerImg,
faviconIcon = faviconIconn;


end UpdateHome;

End DynamicHomePackage;