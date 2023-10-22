<<<<<<< HEAD
USE [Geography]

CREATE VIEW v_HighestPeak AS SELECT TOP 1 * FROM Peaks ORDER BY Elevation DESC

=======
USE [Geography]

CREATE VIEW v_HighestPeak AS SELECT TOP 1 * FROM Peaks ORDER BY Elevation DESC

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
SELECT * FROM v_HighestPeak