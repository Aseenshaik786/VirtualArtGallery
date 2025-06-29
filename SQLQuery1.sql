create database VirtualArtGallery;

use  VirtualArtGallery;

CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Biography NVARCHAR(1000),
    BirthDate DATE,
    Nationality NVARCHAR(100),
    Website NVARCHAR(255),
    ContactInfo NVARCHAR(255)
);

CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(1000),
    CreationDate VARCHAR(20),
    Medium NVARCHAR(100),
    ImageURL NVARCHAR(500),
    ArtistID INT NOT NULL,
    FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
);

CREATE TABLE [User] (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DOB DATE,
    ProfilePic NVARCHAR(500)
);

CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(1000),
    Location NVARCHAR(150),
    CuratorID INT NOT NULL,
    OpeningHours NVARCHAR(100),
    FOREIGN KEY (CuratorID) REFERENCES Artist(ArtistID)
);

CREATE TABLE User_Favorite_Artwork (
    UserID INT,
    ArtworkID INT,
    PRIMARY KEY (UserID, ArtworkID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID),
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID)
);

CREATE TABLE Artwork_Gallery (
    ArtworkID INT,
    GalleryID INT,
    PRIMARY KEY (ArtworkID, GalleryID),
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID),
    FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
);
