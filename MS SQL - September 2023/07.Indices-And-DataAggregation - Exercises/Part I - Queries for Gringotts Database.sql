-- Problem 01 - Records' Count
SELECT COUNT(*) AS [Count] FROM WizzardDeposits 

--Problem 02: Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMegicWand FROM WizzardDeposits

--Problem 03: Longest Magic Wand per Deposit Group
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMegicWand FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 04: Smallest Deposit group per magic wand size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--Problem 05: Deposit Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 06: Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 07: Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--Problem 08: Deposit Charge
SELECT
    DepositGroup,
    MagicWandCreator,
    MIN(DepositCharge) AS MinimumDepositCharge
FROM
    WizzardDeposits
GROUP BY
    DepositGroup,
    MagicWandCreator
ORDER BY
    MagicWandCreator ASC,
    DepositGroup ASC;

--Problem 09: Age Groups
SELECT AgeGroups, COUNT(*) AS WizardCount
	FROM(
		SELECT FirstName, Age,
		CASE
			WHEN AGE BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN AGE BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN AGE BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN AGE BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN AGE BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN AGE BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroups
		FROM WizzardDeposits
	) AS AgeGrouped
GROUP BY AgeGroups

--Problem 10: FirstLetter
SELECT FirstLetter FROM
	(SELECT LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest') AS subq
GROUP BY FirstLetter
ORDER BY FirstLetter

--Problem 11: Average Interest
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--Problem 12: Rich Wizard, Poor Wizard
SELECT SUM((CurrentLead - NextRow)) AS SumDifference
	FROM (SELECT DepositAmount AS CurrentLead,
	LEAD(DepositAmount, 1, NULL) OVER (ORDER BY Id) AS NextRow FROM WizzardDeposits) AS Subq

SELECT SUM(w1.DepositAmount - w2.DepositAmount) AS SumDifference
FROM WizzardDeposits AS w1
JOIN WizzardDeposits AS w2 ON w1.Id = w2.Id - 1