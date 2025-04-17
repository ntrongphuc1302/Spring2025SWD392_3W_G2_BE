USE MASTER
CREATE DATABASE METROONEDB
go
USE METROONEDB
GO

-- USERS TABLE
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Password NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20),
    Role NVARCHAR(50)
);
go

-- PASSES TABLE
CREATE TABLE Passes (
    PassID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    PassType NVARCHAR(50),
    StartDate DATE,
    EndDate DATE,
    Price DECIMAL(10, 2),
    RemainingUses INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
go

-- STATIONS TABLE
CREATE TABLE Stations (
    StationID INT PRIMARY KEY IDENTITY,
    StationName NVARCHAR(100),
    StationCode NVARCHAR(20),
    Location NVARCHAR(255),
    OrderInRoute INT
);
go

-- TRAINS TABLE
CREATE TABLE Train (
    TrainID INT PRIMARY KEY IDENTITY,
    TrainName NVARCHAR(100),
    StartStationID INT NOT NULL,
    EndStationID INT NOT NULL,
    EstimatedTime TIME,
    FOREIGN KEY (StartStationID) REFERENCES Stations(StationID),
    FOREIGN KEY (EndStationID) REFERENCES Stations(StationID)
);
go

-- TRIPS TABLE
CREATE TABLE Trips (
    TripID INT PRIMARY KEY IDENTITY,
    TrainID INT NOT NULL,
    DepartureTime DATETIME,
    ArrivalTime DATETIME,
    TrainCode NVARCHAR(20),
    CoachNumber NVARCHAR(20),
    FOREIGN KEY (TrainID) REFERENCES Train(TrainID)
);
go

-- TICKETS TABLE
CREATE TABLE Tickets (
    TicketID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    TripID INT NOT NULL,
    StartStationID INT NOT NULL,
    EndStationID INT NOT NULL,
    BookingTime DATETIME DEFAULT GETDATE(),
    Price DECIMAL(10, 2),
    QRCode NVARCHAR(255),
    Status NVARCHAR(50),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (TripID) REFERENCES Trips(TripID),
    FOREIGN KEY (StartStationID) REFERENCES Stations(StationID),
    FOREIGN KEY (EndStationID) REFERENCES Stations(StationID)
);
go

-- PAYMENT STATUS TABLE
CREATE TABLE PaymentStatus (
    PaymentID INT PRIMARY KEY IDENTITY,
    TicketID INT UNIQUE NOT NULL,
    PaymentMethod NVARCHAR(50),
    Amount DECIMAL(10, 2),
    PaymentTime DATETIME DEFAULT GETDATE(),
    PaymentStatus NVARCHAR(50),
    FOREIGN KEY (TicketID) REFERENCES Tickets(TicketID)
);
go