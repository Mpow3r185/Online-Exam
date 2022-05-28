CREATE OR REPLACE PACKAGE InvoicePackage AS
    
    -- CRUD Procedures
    -- Get Invoices Procedure
    PROCEDURE GetInvoices;
    
    -- Create Invoice Procedure
    PROCEDURE CreateInvoice(
        createDate IN invoice.creatiodate%type,
        exam_id IN invoice.examid%type,
        acc_id IN invoice.accountid%type);
    
    -- Update Invoice Procedure
    PROCEDURE UpdateInvoice (
        invoiceID IN invoice.ID%type,
        createDate IN invoice.creatiodate%type,
        exam_id IN invoice.examid%type,
        acc_id IN invoice.accountid%type);
        
    -- Delete Invoice Procedure
    PROCEDURE DeleteInvoice(invoiceID IN invoice.id%type);

END InvoicePackage;

