CREATE Schema Auth



CREATE TABLE Auth.Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    PhoneNumber BIGINT NULL
);

INSERT INTO Auth.Users (Name, Email, Password, PhoneNumber)
VALUES 
('John Doe', 'johndoe@example.com', 'P@ssword123', 9876543210),
('Jane Smith', 'janesmith@example.com', 'S3cur3P@ss', 9876543211),
('Alice Johnson', 'alice@example.com', 'P@ssAlice', 9876543212),
('Bob Brown', 'bob@example.com', 'Bob$ecureP@ss', 9876543213),
('Charlie White', 'charlie@example.com', 'Charlie123#', 9876543214),
('David Black', 'david@example.com', 'D@vidB123', 9876543215),
('Emma Green', 'emma@example.com', 'Emma#P@ss', 9876543216),
('Frank Ocean', 'frank@example.com', 'Fr@nkSecure', 9876543217),
('Grace Kelly', 'grace@example.com', 'Gr@ceP@ss!', 9876543218),
('Henry Ford', 'henry@example.com', 'Henry!123', 9876543219);

SELECT * FROM Auth.Users
