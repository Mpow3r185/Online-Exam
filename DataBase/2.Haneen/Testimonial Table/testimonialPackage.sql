-- Start Code

create or replace PACKAGE TestimonialPackage AS
    
    -- Testimonial CRD Operations
    PROCEDURE TestimonialCRD(
        func IN VARCHAR DEFAULT NULL,
        tstId IN Testimonial.id%type DEFAULT NULL,
        accid IN Testimonial.accountId%type DEFAULT NULL,
        msg IN Testimonial.Message%type DEFAULT NULL,
        stat IN Testimonial.status%type DEFAULT NULL);

END TestimonialPackage;

-- End Code








