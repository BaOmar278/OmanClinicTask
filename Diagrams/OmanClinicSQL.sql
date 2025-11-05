

CREATE TABLE Specialty (
    SpecialtyId INT IDENTITY(1,1) PRIMARY KEY,
    SpecialtyName NVARCHAR(100) NOT NULL
);

CREATE TABLE Patient (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    PatientPhone NVARCHAR(20),
    NationalId NVARCHAR(20) UNIQUE,
    FullName NVARCHAR(100) NOT NULL
);


CREATE TABLE Appointment (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentDate DATETIME NOT NULL,
    PatientId INT NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE Doctor (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    DoctorPhone NVARCHAR(20),
    SpecialtyId INT NOT NULL,
    AppointmentId INT NULL,
    FOREIGN KEY (SpecialtyId) REFERENCES Specialty(SpecialtyId)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (AppointmentId) REFERENCES Appointment(AppointmentId)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

