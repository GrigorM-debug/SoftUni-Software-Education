<<<<<<< HEAD
-- Problem 12: Highest Peaks in Bulgaria
SELECT 
	c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains as m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13: Count Mountain Ranges
SELECT
	c.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
FROM Countries AS c
JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN('BG', 'RU', 'US')
GROUP BY c.CountryCode

--Problem 14: Countries with or without rivers
SELECT 
	TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN Continents AS ct ON c.ContinentCode = ct.ContinentCode
WHERE ct.ContinentName = 'Africa'
ORDER BY c.CountryName

--Problem 15: Continents and Currencies
SELECT 
	r.ContinentCode, 
	r.CurrencyCode, 
	r.CurrencyUsage
FROM 
(
	SELECT 
      c.ContinentCode,
	  c.CurrencyCode,
	  COUNT(c.CurrencyCode) AS CurrencyUsage,
	  DENSE_RANK() OVER
	  (
		PARTITION BY c.ContinentCode
		ORDER BY COUNT(c.CurrencyCode) DESC
	  ) AS CurrencyRank
	  FROM Countries AS c
	  GROUP BY c.ContinentCode,c.CurrencyCode
	  HAVING COUNT(c.CurrencyCode) > 1
) AS r
WHERE r.CurrencyRank = 1
ORDER BY r.ContinentCode

--Problem 16: Countries Without any Mountains
SELECT 
	 COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL

--Problem 17: Highest Peak and longest River by Country
SELECT
	TOP(5) PeakData.CountryName, 
	HighestPeakElevation, LongestRiverLength
FROM (
	SELECT 
		c.CountryName,
		MAX(p.Elevation) AS HighestPeakElevation
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
    LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	GROUP BY C.CountryName
) AS PeakData
JOIN(
	SELECT 
			c.CountryName,
			MAX(r.Length) AS LongestRiverLength
		FROM Countries AS c
		LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
		GROUP BY c.CountryName
) AS RiverData
ON PeakData.CountryName = RiverData.CountryName
ORDER BY PeakData.HighestPeakElevation DESC, RiverData.LongestRiverLength DESC;

--Problem 18: Highest Peak Name and Elevation by Country
SELECT TOP(5)
	[Country],
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	    END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	    END AS [Highest Peak Elevation],
	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	    END AS [Mountain]

FROM
(
	SELECT 
		c.CountryName AS Country,
		m.MountainRange,
		p.PeakName,
		p.Elevation,
		DENSE_RANK() OVER
		(
			PARTITION BY c.CountryName
			ORDER BY p.Elevation DESC
		) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON p.MountainId = m.Id
) AS PeakRankingTable
WHERE PeakRank = 1
ORDER BY Country, [Highest Peak Name] 
=======
-- Problem 12: Highest Peaks in Bulgaria
SELECT 
	c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains as m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13: Count Mountain Ranges
SELECT
	c.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
FROM Countries AS c
JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN('BG', 'RU', 'US')
GROUP BY c.CountryCode

--Problem 14: Countries with or without rivers
SELECT 
	TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN Continents AS ct ON c.ContinentCode = ct.ContinentCode
WHERE ct.ContinentName = 'Africa'
ORDER BY c.CountryName

--Problem 15: Continents and Currencies
SELECT 
	r.ContinentCode, 
	r.CurrencyCode, 
	r.CurrencyUsage
FROM 
(
	SELECT 
      c.ContinentCode,
	  c.CurrencyCode,
	  COUNT(c.CurrencyCode) AS CurrencyUsage,
	  DENSE_RANK() OVER
	  (
		PARTITION BY c.ContinentCode
		ORDER BY COUNT(c.CurrencyCode) DESC
	  ) AS CurrencyRank
	  FROM Countries AS c
	  GROUP BY c.ContinentCode,c.CurrencyCode
	  HAVING COUNT(c.CurrencyCode) > 1
) AS r
WHERE r.CurrencyRank = 1
ORDER BY r.ContinentCode

--Problem 16: Countries Without any Mountains
SELECT 
	 COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL

--Problem 17: Highest Peak and longest River by Country
SELECT
	TOP(5) PeakData.CountryName, 
	HighestPeakElevation, LongestRiverLength
FROM (
	SELECT 
		c.CountryName,
		MAX(p.Elevation) AS HighestPeakElevation
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
    LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	GROUP BY C.CountryName
) AS PeakData
JOIN(
	SELECT 
			c.CountryName,
			MAX(r.Length) AS LongestRiverLength
		FROM Countries AS c
		LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
		GROUP BY c.CountryName
) AS RiverData
ON PeakData.CountryName = RiverData.CountryName
ORDER BY PeakData.HighestPeakElevation DESC, RiverData.LongestRiverLength DESC;

--Problem 18: Highest Peak Name and Elevation by Country
SELECT TOP(5)
	[Country],
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	    END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	    END AS [Highest Peak Elevation],
	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	    END AS [Mountain]

FROM
(
	SELECT 
		c.CountryName AS Country,
		m.MountainRange,
		p.PeakName,
		p.Elevation,
		DENSE_RANK() OVER
		(
			PARTITION BY c.CountryName
			ORDER BY p.Elevation DESC
		) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON p.MountainId = m.Id
) AS PeakRankingTable
WHERE PeakRank = 1
ORDER BY Country, [Highest Peak Name] 
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
