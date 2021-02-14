Insert Into Users(FirstName,LastName,Email,Password)
VALUES
	('Barış','Karakaya','baybarisk@outlook.com','12345678'),
	('Umut Can','Karaoğlan','canumut13@gmail.com','2314515'),
	('Murat','Karakaya','yolcu45@gmail.com','yolcuyolcu');

Insert Into Customers(UserID,CompanyName)
VALUES
	('2','BOORIS'),
	('1','HOOPE');

Insert Into Rentals(CarID,CustomerID,RentDate,ReturnDate)
VALUES
	('2','1','20200210 10:23:12 AM','20200211 5:00:20 PM'),
	('3','2','20200213 11:30:39 AM','');