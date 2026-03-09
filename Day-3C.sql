CREATE TABLE Books 
(
    BookId SERIAL PRIMARY KEY,
    Title VARCHAR(200),
    Genre VARCHAR(100),
    PublicationYear INT,
    TotalCopies INT,
    AvailableCopies INT
);

CREATE TABLE Members 
(
    MemberId SERIAL PRIMARY KEY,
    FullName VARCHAR(150),
    Phone VARCHAR(20),
    Email VARCHAR(150),
    MembershipDate DATE
);

CREATE TABLE Borrowings 
(
    BorrowingId SERIAL PRIMARY KEY,
    BookId INT REFERENCES Books(BookId),
    MemberId INT REFERENCES Members(MemberId),
    BorrowDate DATE,
    DueDate DATE,
    ReturnDate DATE,
    Fine DECIMAL(10,2)
);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Война и мир', 'Роман', 1869, 10, 10);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Преступление и наказание', 'Роман', 1866, 8, 8);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Мастер и Маргарита', 'Фантастика', 1967, 12, 12);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Анна Каренина', 'Роман', 1877, 9, 9);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Евгений Онегин', 'Поэма', 1833, 7, 7);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Отцы и дети', 'Роман', 1862, 6, 6);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Обломов', 'Роман', 1859, 5, 5);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Идиот', 'Роман', 1869, 8, 8);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Ревизор', 'Комедия', 1836, 4, 4);

INSERT INTO Books (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
VALUES ('Тихий Дон', 'Роман', 1928, 10, 10);


INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Иван Иванов', '1234567890', 'ivanov@example.com', '2023-01-15');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Петр Петров', '0987654321', 'petrov@example.com', '2023-02-20');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Сергей Сергеев', '5551234567', 'sergeev@example.com', '2023-03-05');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Алексей Смирнов', '7778889990', 'smirnov@example.com', '2023-04-10');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Мария Козлова', '2223334445', 'kozlova@example.com', '2023-05-15');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Екатерина Соколова', '1112223334', 'sokolova@example.com', '2023-06-01');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Дмитрий Федоров', '9998887776', 'fedorov@example.com', '2023-07-20');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Ольга Николаева', '4445556667', 'nikolaeva@example.com', '2023-08-05');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Анастасия Лебедева', '3334445556', 'lebedeva@example.com', '2023-09-10');

INSERT INTO Members (FullName, Phone, Email, MembershipDate)
VALUES ('Виктория Морозова', '8887776665', 'morozova@example.com', '2023-10-01');


INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (1, 1, '2023-04-01', '2023-04-08', NULL, 0.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (2, 2, '2023-04-03', '2023-04-10', '2023-04-11', 5.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (3, 3, '2023-04-05', '2023-04-12', NULL, 0.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (4, 4, '2023-04-07', '2023-04-14', '2023-04-15', 3.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (5, 5, '2023-04-09', '2023-04-16', NULL, 0.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (6, 6, '2023-04-11', '2023-04-18', '2023-04-20', 4.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (7, 7, '2023-04-13', '2023-04-20', NULL, 0.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (8, 8, '2023-04-15', '2023-04-22', '2023-04-23', 2.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (9, 9, '2023-04-17', '2023-04-24', NULL, 0.00);

INSERT INTO Borrowings (BookId, MemberId, BorrowDate, DueDate, ReturnDate, Fine)
VALUES (10, 10, '2023-04-19', '2023-04-26', '2023-04-27', 1.00);