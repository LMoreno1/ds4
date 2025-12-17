CREATE DATABASE LaborSocialDB;

USE LaborSocialDB;

CREATE TABLE Estudiantes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Carrera VARCHAR(50) NOT NULL,
    Semestre INT NOT NULL
);

CREATE TABLE Actividades (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Fecha DATETIME NOT NULL,
    CupoMaximo INT NOT NULL,
    Lugar VARCHAR(100),
    Estado VARCHAR(20) DEFAULT 'Disponible'
);

CREATE TABLE Inscripciones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EstudianteId INT NOT NULL,
    ActividadId INT NOT NULL,
    FechaInscripcion DATETIME DEFAULT GETDATE(),
    Estado VARCHAR(20) DEFAULT 'Activa',
    
    FOREIGN KEY (EstudianteId) REFERENCES Estudiantes(Id),
    FOREIGN KEY (ActividadId) REFERENCES Actividades(Id),
    
    CONSTRAINT UC_EstudianteActividad UNIQUE(EstudianteId, ActividadId)
);
