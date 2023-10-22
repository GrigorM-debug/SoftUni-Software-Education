--Problem 05: invoices by Amount and Date
SELECT
    Number, Currency
FROM Invoices
ORDER BY Amount DESC, DueDate ASC

--Problem 06: Products by Category
SELECT 
    p.Id, p.Name, p.Price, c.Name AS CategoryName
FROM Products AS p
JOIN Categories AS c ON p.CategoryId = c.Id
WHERE c.Name IN ('ADR', 'Others')
ORDER BY p.Price DESC

--Problem 07: Clients without product
SELECT
    c.Id, c.Name AS Client, CONCAT_WS(', ', CONCAT_WS(' ', a.StreetName, a.StreetNumber), a.City, a.PostCode, ct.Name) AS Address
FROM Clients AS c
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN Countries AS ct ON a.CountryId = ct.Id
LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
WHERE pc.ClientId IS NULL
ORDER BY c.Name ASC

--Problem 08: First 7 Invoices
SELECT TOP (7)
    i.Number, i.Amount, c.Name AS Client
FROM Invoices AS i
JOIN Clients AS c ON i.ClientId = c.Id
WHERE i.IssueDate < '2023-01-01' AND i.Currency = 'EUR' OR i.Amount > 500.00 AND c.NumberVAT LIKE 'DE%'
ORDER BY i.Number ASC, i.Amount DESC

--Problem 09: Client with VAT
SELECT 
    c.Name AS Client, MAX(p.Price) AS Price, c.NumberVAT AS [VAT Number]
FROM Clients AS c
JOIN ProductsClients AS pc ON c.Id = pc.ClientId
JOIN Products AS p ON pc.ProductId = p.Id
GROUP BY c.Name, c.NumberVAT
HAVING c.Name NOT LIKE '%KG'
ORDER BY MAX(p.Price) DESC

--Problem 10: Clients by Price
SELECT
    c.Name AS Client, CAST(FLOOR(AVG(p.Price)) AS INT) AS [Average Price]
FROM Clients AS c
JOIN ProductsClients AS pc ON c.Id = pc.ClientId
JOIN Products AS p ON pc.ProductId = p.Id
JOIN Vendors AS v ON p.VendorId = v.Id
WHERE v.NumberVAT LIKE '%FR%'
GROUP BY c.Name
ORDER BY AVG(p.Price) ASC, c.Name DESC

