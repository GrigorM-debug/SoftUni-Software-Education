<<<<<<< HEAD
INSERT INTO Tourists ([Name], PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Agla�', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan M�ller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);

UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate <= '2023-12-31';

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

DELETE FROM Bookings
WHERE TouristId IN (SELECT Id FROM Tourists WHERE CHARINDEX('Smith', Name, 1) > 0);

DELETE FROM Tourists
=======
INSERT INTO Tourists ([Name], PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Agla�', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan M�ller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);

UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate <= '2023-12-31';

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

DELETE FROM Bookings
WHERE TouristId IN (SELECT Id FROM Tourists WHERE CHARINDEX('Smith', Name, 1) > 0);

DELETE FROM Tourists
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
WHERE CHARINDEX('Smith', Name, 1) > 0;