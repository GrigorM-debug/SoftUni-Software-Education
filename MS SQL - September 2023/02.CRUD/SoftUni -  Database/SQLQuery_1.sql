<<<<<<< HEAD
USE SoftUniSecondDb

--Updating Projects with NULL EndDate to current date
SELECT * FROM Projects WHERE EndDate IS NULL

UPDATE Projects
SET EndDate = GETDATE()
=======
USE SoftUniSecondDb

--Updating Projects with NULL EndDate to current date
SELECT * FROM Projects WHERE EndDate IS NULL

UPDATE Projects
SET EndDate = GETDATE()
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
WHERE EndDate IS NULL