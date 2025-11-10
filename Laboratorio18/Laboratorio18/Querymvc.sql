CREATE DATABASE laboratoriomvc;

USE laboratoriomvc;

CREATE TABLE [User] (
    id INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(100) NOT NULL,
    password VARCHAR(50) NOT NULL
);