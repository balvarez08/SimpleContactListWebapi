CREATE TABLE [dbo].[ContactList] (
    [ContactID]        INT           IDENTITY (1, 1) NOT NULL,
    [ContactName]      VARCHAR (100) NULL,
    [ContactPhone]     VARCHAR (12)  NULL,
    [ContactDateAdded] DATETIME      NULL,
    CONSTRAINT [pk_customerId] PRIMARY KEY CLUSTERED ([ContactID] ASC) WITH (FILLFACTOR = 90)
);

