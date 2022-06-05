create or replace PACKAGE InvoicePackage AS
    
    -- CRUD Procedures
    PROCEDURE InvoiceCRUD (
    func IN VARCHAR DEFAULT NULL,
        invoiceID IN invoice.ID%type DEFAULT NULL,
        createDate IN invoice.creationdate%type DEFAULT NULL,
        exam_id IN invoice.examid%type DEFAULT NULL,
        acc_id IN invoice.accountid%type DEFAULT NULL);

    PROCEDURE ObtainsFinancial;

END InvoicePackage;
