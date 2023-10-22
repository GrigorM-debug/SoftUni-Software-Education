<<<<<<< HEAD
USE Bank
--Problem 01: Create table Logs
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

CREATE TRIGGER tr_AddLogsOnAccountUpdata
ON Accounts FOR UPDATE 
AS	
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT
		i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance

BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance = Balance + 100
	WHERE Id = 1
ROLLBACK

--Problem 02: Create table Emails
CREATE TABLE NotificationEmails(
    Id INT PRIMARY KEY IDENTITY,
    Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
    [Subject] VARCHAR(50) NOT NULL,
    Body VARCHAR(100) NOT NULL
)

CREATE OR ALTER TRIGGER tr_AddEmailWhenNewRecordISInserted
ON Logs FOR INSERT
AS  
    INSERT INTO NotificationEmails(Recipient, [Subject], Body)
    VALUES
    (
        (SELECT AccountId FROM inserted),
        (SELECT 'Balance change for account: ' + CAST(AccountId AS VARCHAR(255)) FROM inserted),
        (SELECT 'On ' + 
                FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt') + 
                ' your balance was changed from ' + 
                CAST(OldSum AS VARCHAR(255)) + 
                ' to ' + 
                CAST(NewSum AS VARCHAR(255)) + 
                '.' 
        FROM inserted)
    )


--Problem 03: Deposit Money
CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS  
    IF(@MoneyAmount < 0) THROW 50001, 'Invalid amount', 1
    UPDATE Accounts
    SET Balance += @MoneyAmount
    WHERE ID = @AccountId


EXEC usp_DepositMoney 1, -22

--Problem 04: Withdraw Money Procedure
CREATE OR ALTER PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
    IF(@MoneyAmount < 0) THROW 50001, 'Invalid amount', 1
    UPDATE Accounts
    SET Balance -= @MoneyAmount
    WHERE Id = @AccountId

EXEC usp_WithdrawMoney 1, -10


--Problem 05: Money Transfer
CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
    BEGIN TRANSACTION
        EXEC usp_DepositMoney @ReceiverId, @Amount
        EXEC usp_WithdrawMoney @SenderId, @Amount
=======
USE Bank
--Problem 01: Create table Logs
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

CREATE TRIGGER tr_AddLogsOnAccountUpdata
ON Accounts FOR UPDATE 
AS	
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT
		i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance

BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance = Balance + 100
	WHERE Id = 1
ROLLBACK

--Problem 02: Create table Emails
CREATE TABLE NotificationEmails(
    Id INT PRIMARY KEY IDENTITY,
    Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
    [Subject] VARCHAR(50) NOT NULL,
    Body VARCHAR(100) NOT NULL
)

CREATE OR ALTER TRIGGER tr_AddEmailWhenNewRecordISInserted
ON Logs FOR INSERT
AS  
    INSERT INTO NotificationEmails(Recipient, [Subject], Body)
    VALUES
    (
        (SELECT AccountId FROM inserted),
        (SELECT 'Balance change for account: ' + CAST(AccountId AS VARCHAR(255)) FROM inserted),
        (SELECT 'On ' + 
                FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt') + 
                ' your balance was changed from ' + 
                CAST(OldSum AS VARCHAR(255)) + 
                ' to ' + 
                CAST(NewSum AS VARCHAR(255)) + 
                '.' 
        FROM inserted)
    )


--Problem 03: Deposit Money
CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS  
    IF(@MoneyAmount < 0) THROW 50001, 'Invalid amount', 1
    UPDATE Accounts
    SET Balance += @MoneyAmount
    WHERE ID = @AccountId


EXEC usp_DepositMoney 1, -22

--Problem 04: Withdraw Money Procedure
CREATE OR ALTER PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
    IF(@MoneyAmount < 0) THROW 50001, 'Invalid amount', 1
    UPDATE Accounts
    SET Balance -= @MoneyAmount
    WHERE Id = @AccountId

EXEC usp_WithdrawMoney 1, -10


--Problem 05: Money Transfer
CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
    BEGIN TRANSACTION
        EXEC usp_DepositMoney @ReceiverId, @Amount
        EXEC usp_WithdrawMoney @SenderId, @Amount
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
    COMMIT