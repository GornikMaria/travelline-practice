USE BookingCar;

CREATE TABLE Client (
	IdClient INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Client PRIMARY KEY,
	Birthday DATETIME NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Address NVARCHAR(100) NOT NULL,
);

CREATE TABLE BookingData (
    IdBookingData INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Booking_Data PRIMARY KEY,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Pay DECIMAL(10, 2) NOT NULL,
    IdClient int not null CONSTRAINT FK_Booking_Data_Client REFERENCES Client(IdClient)
);

CREATE TABLE Car (
    IdCar INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Ñar PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CreationDate DATE NOT NULL,
    Price INT NOT NULL,
    Rating INT NOT NULL,
    IdClient int not null CONSTRAINT FK_Car_Client REFERENCES Client(IdClient)
);

--3.1 Íàïèñàòü INSERT íà êàæäóþ òàáëèöó
-- Client
INSERT INTO Client (Birthday, Name, Address) VALUES ('2020-12-12', 'Àëåêñàíäð', 'Óñïåíñêàÿ, ä.13');
INSERT INTO Client (Birthday, Name, Address) VALUES ('1940-02-02', 'Âëàäèìèð', 'Êðàéîâñêàÿ, ä.42');
INSERT INTO Client (Birthday, Name, Address) VALUES ('2001-08-04', 'Ïåòð', 'Óëè÷íàÿ, ä.2');

-- BookingData
INSERT INTO BookingData (IdClient, StartDate, EndDate, Pay) VALUES (3, '2014-02-02', '2014-02-03', 222);
INSERT INTO BookingData (IdClient, StartDate, EndDate, Pay) VALUES (2, '2014-02-02', '2014-02-03', 230);
INSERT INTO BookingData (IdClient, StartDate, EndDate, Pay) VALUES (1, '2014-02-02', '2014-02-03', 10);

-- Ñar
INSERT INTO Car(IdClient, Name, CreationDate, Price, Rating) VALUES (1, 'Toyota Camry', '1940-02-02', 20000, 1);
INSERT INTO Car (IdClient, CreationDate, Name, Price, Rating) VALUES (2, 'Honda Civic', '2004-02-02', 30123, 3);
INSERT INTO Car (IdClient, CreationDate, Name, Price, Rating) VALUES (3, 'BMW X5', '1980-02-02', 4123123, 3);

-- 3.2 SELECT (èñïîëüçóÿ êàæäûé ðàññìîòðåííûé íà ïàðå ïðåäèêàò, + ïàðó ëîãè÷åñêèõ îïåðàöèé (and, or, not, ...), íå ìåíåå 8 øòóê)
SELECT * FROM Client WHERE Name = 'Àëåêñàíäð';
SELECT * FROM Client WHERE Address != 'Ìîëîäåæíàÿ, ä. 5';
SELECT * FROM BookingData WHERE Pay > 10;
SELECT * FROM BookingData WHERE StartDate BETWEEN '2014-01-01' AND '2014-03-03';
SELECT * FROM Car WHERE Rating IN (3);
SELECT * FROM Client WHERE Name LIKE '%åò%';
SELECT * FROM Car WHERE Price > 30000 AND Rating = 3;
SELECT * FROM Client WHERE Name = 'Ïåòð' OR Name = 'Àëåêñàíäð';

-- 3.3 UPDATE
UPDATE Client SET Address = 'Ìîëîäåæíàÿ, ä. 5' WHERE IdClient = 1;
UPDATE BookingData SET EndDate = '2014-03-25' WHERE Pay = 230;
UPDATE Car SET Price = 50000 WHERE Name LIKE '%Toyota%';

-- 3.4 DELETE
DELETE FROM BookingData WHERE IdBookingData = 2;

-- 3.5 JOIN
-- LEFT JOIN
SELECT * FROM Car LEFT JOIN Client ON Car.IdClient = Client.IdClient WHERE Car.Price > 20000;
-- RIGHT JOIN
SELECT * FROM Client RIGHT JOIN Car ON Client.IdClient = Car.IdClient WHERE Car.Price > 20000;
-- INNER JOIN
SELECT * FROM BookingData INNER JOIN Car ON BookingData.IdClient = Car.IdClient;
