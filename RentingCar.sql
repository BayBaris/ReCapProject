
CREATE TABLE Colors(
	ColorID int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(15),
)


CREATE TABLE Brands(
	BrandID int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(15),
)

CREATE TABLE Cars(
	CarID int PRIMARY KEY IDENTITY(1,1),
	BrandID int,
	ColorID int,
	CarName nvarchar(25),
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
)


INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Gri');


INSERT INTO Brands(BrandName)
VALUES
	('Tesla'),
	('Mercedes'),
	('Volkswagen');

INSERT INTO Cars(BrandID,ColorID,CarName,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','Roadstar','2018','300','Otomatik - Elektrik'),
	('1','3','Model X','2015','450','Otomatik - Elektrik'),
	('2','1','E-234','2017','500','Otomatik - Hybrid'),
	('3','3','Golf','2014','250','Manuel - Dizel'),
	('2','3','Avatar','2019','1000','Otomatik - Hybrid'),
	('3','2','Passat','2015','400','Otomatik Hybrid');