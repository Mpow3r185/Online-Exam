create or replace PACKAGE BODY InvoicePackage AS
    
    -- CRUD Procedures    
    PROCEDURE InvoiceCRUD(
        func IN VARCHAR DEFAULT NULL,
        invoiceID IN invoice.ID%type DEFAULT NULL,
        createDate IN invoice.creationdate%type DEFAULT NULL,
        exam_id IN invoice.examid%type DEFAULT NULL,
        acc_id IN invoice.accountid%type DEFAULT NULL) AS
        
        ref_cursor SYS_REFCURSOR;
    BEGIN
    -- Create 
        IF func = 'CREATE' THEN
            INSERT INTO Invoice
            (CreationDate, ExamId, AccountId)
            VALUES(createDate, exam_id, acc_id);

        COMMIT;
    -- Update 
    ELSIF func = 'UPDATE' THEN
            UPDATE Invoice SET 
                CreationDate = createDate,
                examid = exam_id,
                accountid = acc_id

            WHERE id = invoiceID;

            COMMIT;

    -- Delete 
    ELSIF func = 'DELETE' THEN
        DELETE from Invoice WHERE id = invoiceID;

        COMMIT;
    ELSE
    -- Get 
        OPEN ref_cursor FOR
        SELECT *
        FROM Invoice;

        DBMS_SQL.RETURN_RESULT(ref_cursor);
    END IF;
END InvoiceCRUD;

PROCEDURE ObtainsFinancial AS O_all sys_refcursor;
    BEGIN
        open O_all for
        select SUM(E.cost) as Profit,CAST(AVG(E.cost) AS DECIMAL(10,2))  As AVGOfProfit,COUNT(I.id) as NumberOfInvoice 
        from Invoice I
        JOIN Exam E
        on I.examid = E.id;
        DBMS_SQL.RETURN_RESULT(O_all);
    END ObtainsFinancial;

PROCEDURE getInvoiceByUserId(uid IN account.id%type DEFAULT NULL) AS O_all sys_refcursor;
    BEGIN
        open O_all for
        select I.creationdate as creationDate,E.title As examName,E.examlevel as examLevel, E.cost As examCost 
        from Invoice I
        JOIN Account A ON I.accountid = A.id
        JOIN Exam E on I.examid = E.id
        WHERE I.accountid = uid;
        DBMS_SQL.RETURN_RESULT(O_all);
    END getInvoiceByUserId;
    
    
PROCEDURE getInvoicesDetails AS O_all sys_refcursor;
    BEGIN
        open O_all for
        select A.fullname as FullName,A.email as Email , E.title As examName, E.cost As examCost ,I.creationdate as creationDate 
        from Invoice I
        JOIN Account A ON I.accountid = A.id
        JOIN Exam E on I.examid = E.id;
        DBMS_SQL.RETURN_RESULT(O_all);
    END getInvoicesDetails;    

END InvoicePackage;
