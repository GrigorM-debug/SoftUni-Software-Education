<<<<<<< HEAD
USE [Geography]

--Problem 21: All Mountain Peaks
SELECT PeakName FROM Peaks 
ORDER BY PeakName ASC

--Problem 22: Biggest countries by population
SELECT TOP(30) CountryName, Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC, 
CountryName ASC


--Problem 23: Countries and currency (Euro/Not euro)
SELECT CountryName, CountryCode,
    CASE
        WHEN CurrencyCode = 'EUR' THEN 'Euro'
        ELSE 'Not Euro'
    END AS Currency
FROM Countries
ORDER BY CountryName ASC


=======
USE [Geography]

--Problem 21: All Mountain Peaks
SELECT PeakName FROM Peaks 
ORDER BY PeakName ASC

--Problem 22: Biggest countries by population
SELECT TOP(30) CountryName, Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC, 
CountryName ASC


--Problem 23: Countries and currency (Euro/Not euro)
SELECT CountryName, CountryCode,
    CASE
        WHEN CurrencyCode = 'EUR' THEN 'Euro'
        ELSE 'Not Euro'
    END AS Currency
FROM Countries
ORDER BY CountryName ASC


>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
