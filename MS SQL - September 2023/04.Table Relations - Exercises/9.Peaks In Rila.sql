<<<<<<< HEAD
USE Geography

--First way
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks as p 
JOIN Mountains as m ON m.Id = 17 AND  p.MountainId = 17
ORDER BY p.Elevation DESC

--Other way
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
=======
USE Geography

--First way
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks as p 
JOIN Mountains as m ON m.Id = 17 AND  p.MountainId = 17
ORDER BY p.Elevation DESC

--Other way
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
ORDER BY p.Elevation DESC