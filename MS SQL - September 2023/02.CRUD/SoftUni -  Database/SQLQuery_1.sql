USE SoftUniSecondDb

--Updating Projects with NULL EndDate to current date
SELECT * FROM Projects WHERE EndDate IS NULL

UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL