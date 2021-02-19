CREATE TABLE Rentals(
	RentalID int PRIMARY KEY IDENTITY (1,1),
	CarID int,
	CustomerID int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY(CarID) REFERENCES Cars(CarID),
	FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

