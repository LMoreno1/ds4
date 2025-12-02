USE [Luis Moreno]

CREATE TABLE LM_Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    ContraseñaHash VARCHAR(255) NOT NULL,
    NombreCompleto VARCHAR(200) NOT NULL,
    Rol VARCHAR(20) CHECK (Rol IN ('Administrador', 'Abogado', 'Asistente')),
    Email VARCHAR(150),
    Telefono VARCHAR(20),
    Activo BIT DEFAULT 1,
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE LM_Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Identificacion VARCHAR(50) UNIQUE,
    Telefono VARCHAR(20),
    Email VARCHAR(150),
    Direccion TEXT,
    TipoCliente VARCHAR(50),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE LM_Casos (
    CasoID INT PRIMARY KEY IDENTITY(1,1),
    NumeroCaso VARCHAR(50) UNIQUE NOT NULL,
    Titulo VARCHAR(200) NOT NULL,
    Descripcion TEXT,
    FechaInicio DATE NOT NULL,
    FechaVencimiento DATE,
    Estado VARCHAR(50) DEFAULT 'Activo',
    Prioridad VARCHAR(20) CHECK (Prioridad IN ('Alta', 'Media', 'Baja')),
    AbogadoID INT FOREIGN KEY REFERENCES LM_Usuarios(UsuarioID),
    ClienteID INT FOREIGN KEY REFERENCES LM_Clientes(ClienteID),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME
);

CREATE TABLE LM_Documentos (
    DocumentoID INT PRIMARY KEY IDENTITY(1,1),
    NombreArchivo VARCHAR(255) NOT NULL,
    RutaArchivo VARCHAR(500) NOT NULL,
    TipoDocumento VARCHAR(100),
    Descripcion TEXT,
    CasoID INT FOREIGN KEY REFERENCES LM_Casos(CasoID),
    UsuarioID INT FOREIGN KEY REFERENCES LM_Usuarios(UsuarioID),
    FechaSubida DATETIME DEFAULT GETDATE(),
    TamanoArchivo BIGINT
);

CREATE TABLE LM_Calendario (
    EventoID INT PRIMARY KEY IDENTITY(1,1),
    TituloEvento VARCHAR(200) NOT NULL,
    Descripcion TEXT,
    FechaHora DATETIME NOT NULL,
    TipoEvento VARCHAR(50) CHECK (TipoEvento IN ('Audiencia', 'Reunion', 'Vencimiento', 'Otro')),
    CasoID INT FOREIGN KEY REFERENCES LM_Casos(CasoID),
    UsuarioID INT FOREIGN KEY REFERENCES LM_Usuarios(UsuarioID),
    Notificado BIT DEFAULT 0,
    FechaRecordatorio DATETIME
);

CREATE TABLE LM_Seguimiento (
    SeguimientoID INT PRIMARY KEY IDENTITY(1,1),
    CasoID INT FOREIGN KEY REFERENCES LM_Casos(CasoID),
    Descripcion TEXT NOT NULL,
    UsuarioID INT FOREIGN KEY REFERENCES LM_Usuarios(UsuarioID),
    FechaCambio DATETIME DEFAULT GETDATE(),
    TipoCambio VARCHAR(50)
);