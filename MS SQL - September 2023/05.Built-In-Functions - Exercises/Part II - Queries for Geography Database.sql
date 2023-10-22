--Problem 12: Countries holding 'A' 3 or more times
SELECT CountryName AS [Country Name], IsoCode AS [Iso Code]
From Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode ASC

--Problem 13: Mix of Peak and RiverName
SELECT p.PeakName, r.RiverName, 
	LOWER(CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName)-1), SUBSTRING(RiverName, 1, LEN(RiverName)))) AS [Mix]
FROM Peaks AS p, Rivers AS R
WHERE RIGHT(PeakName, 1) = LEFT(RiverName,1)
ORDER BY Mix