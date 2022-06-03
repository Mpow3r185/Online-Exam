

CREATE OR REPLACE PACKAGE BODY InvoicePackage AS
    
    -- CRUD Procedures
    -- Get Invoices Procedure
    PROCEDURE GetInvoices AS
        ref_cursor SYS_REFCURSOR;
    BEGIN
        OPEN ref_cursor FOR
        SELECT *
        FROM Invoice;
        
        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END GetInvoices;
    
    -- Create Invoice Procedure
    PROCEDURE CreateInvoice(
        createDate IN invoice.creationdate%type,
        exam_id IN invoice.examid%type,
        acc_id IN invoice.accountid%type) AS
        BEGIN
            INSERT INTO Invoice
            (CreationDate, ExamId, AccountId)
            VALUES(createDate, exam_id, acc_id);
        commit;
        END CreateInvoice;
    
    -- Update Invoice Procedure
    PROCEDURE UpdateInvoice(
        invoiceID IN invoice.ID%type,
        createDate IN invoice.creationdate%type,
        exam_id IN invoice.examid%type,
        acc_id IN invoice.accountid%type) AS
        BEGIN
            UPDATE Invoice SET 
                CreationDate = createDate,
                examid = exam_id,
                accountid = acc_id
               
            WHERE id = invoiceID;
            commit;
        END UpdateInvoice;
        
    -- Delete Invoice Procedure
    PROCEDURE DeleteInvoice(invoiceID IN invoice.id%type) AS
    BEGIN
        DELETE from Invoice WHERE id = invoiceID;
        commit;
    END DeleteInvoice;

     --Obtains Financial
    PROCEDURE ObtainsFinancial AS O_all sys_refcursor;
    BEGIN
        open O_all for
        select SUM(E.cost) as Profit,CAST(AVG(E.cost) AS DECIMAL(10,2))  As AVGOfProfit,COUNT(I.id) as NumberOfInvoice 
        from Invoice I
        JOIN Exam E
        on I.examid = E.id;
        DBMS_SQL.RETURN_RESULT(O_all);
    END ObtainsFinancial;

END InvoicePackage;
