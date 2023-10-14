INSERT INTO Products([Name], Price, CategoryId, VendorId)
VALUES
	('SCANIA Oil Filter XD01', 78.69, 1, 1),
	('MAN Air Filter XD01', 97.38, 1, 5),
	('DAF Light Bulb 05FG87', 55.00, 2, 13),
	('ADR Shoes 47-47.5', 49.85, 3, 5),	
	('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices(Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
	('1219992181', '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
	('1729252340', '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
	('1950101013', '2023-02-17', '2023-04-18', 615.15, 'USD', 19)



UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE DATEPART(MONTH, DueDate) = 11 AND DATEPART(YEAR, DueDate) = 2022
    
UPDATE Clients
SET AddressId = 3
WHERE [Name] LIKE '%CO%'


DECLARE @clientId INT = 
(
    SELECT Id 
    FROM Clients 
    WHERE NumberVAT LIKE 'IT%'
)

DELETE ProductsClients
WHERE ClientId = @clientId

DELETE Invoices
WHERE ClientId = @clientId

DELETE Clients
WHERE NumberVAT LIKE 'IT%'
