USE METROONEDB
GO

-- USERS
INSERT INTO Users (FullName, Password, Email, Phone, Role, Status) VALUES
(N'ADMIN', '$2a$12$UmKL0sykY8/HjkzR78d0P.BCkQhFex2qLZTiXu2TlTVXVc3BycnXW', 'admin@gmail.com', '0694204090', 'Admin', 'Active'), --123456
(N'Passenger', '$2a$12$a.wVeVicxGJG/KH0OMR2qeaefFwqlP5A52t2rdf6fo3j1RYUYpsUK', 'pass@gmail.com', '0694204090', 'Passenger','Active'),--123456
(N'Kazei', '$2a$12$FuMXAuzQLrHCsFoHbjfPYeCdLLBMQYJ0miwKAD9I2A97gO.i4QCEK', 'kz@gmail.com', '0694204090', 'Passen','Active');
-- STATIONS
INSERT INTO Stations (StationName, StationCode, Location, OrderInRoute) VALUES
(N'Ben Thanh', 'BTN', N'District 1', 1),
(N'Ba Son', 'BSN', N'District 1', 2),
(N'Tan Cang', 'TCG', N'Binh Thanh', 3),
(N'Thu Duc', 'TDC', N'Thu Duc City', 4),
(N'Suoi Tien', 'STN', N'Thu Duc City', 5);

-- TRAINS
INSERT INTO Train (TrainName, StartStationID, EndStationID, EstimatedTime) VALUES
(N'Saigon Metro 01', 1, 5, '00:45:00'),
(N'Saigon Metro 02', 2, 4, '00:30:00');

-- TRIPS
INSERT INTO Trips (TrainID, DepartureTime, ArrivalTime, TrainCode, CoachNumber) VALUES
(1, '2025-04-17 07:00:00', '2025-04-17 07:45:00', 'SGM01-001', 'A1'),
(2, '2025-04-17 09:00:00', '2025-04-17 09:30:00', 'SGM02-001', 'B1');

-- PASSES
INSERT INTO Passes (UserID, PassType, StartDate, EndDate, Price, RemainingUses) VALUES
(1, 'Monthly', '2025-04-01', '2025-04-30', 300000, 25),
(2, 'Weekly', '2025-04-10', '2025-04-17', 100000, 7);

-- TICKETS
INSERT INTO Tickets (UserID, TripID, StartStationID, EndStationID, BookingTime, Price, QRCode, Status) VALUES
(1, 1, 1, 5, GETDATE(), 25000, 'QR00112233', 'Confirmed'),
(2, 2, 2, 4, GETDATE(), 20000, 'QR00445566', 'Confirmed');

-- PAYMENT STATUS
INSERT INTO PaymentStatus (TicketID, PaymentMethod, Amount, PaymentTime, PaymentStatus) VALUES
(1, 'Momo', 25000, GETDATE(), 'Success'),
(2, 'ZaloPay', 20000, GETDATE(), 'Success');

select * from Users