CREATE DATABASE  Proyecto_Vacunacion;
USE Proyecto_Vacunacion;
SET LANGUAGE us_english;
DROP DATABASE Proyecto_Vacunacion;
CREATE TABLE EMPLOYEE (
	id INT PRIMARY KEY,
	[name] VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	type_employee VARCHAR(50) NOT NULL,
	id_address INT NOT NULL
);

CREATE TABLE MANAGER(
	id INT PRIMARY KEY,
	username VARCHAR(50),
	password VARCHAR(50),
	id_employee INT NOT NULL
);

CREATE TABLE CABIN(
	id INT PRIMARY KEY IDENTITY,
	phone_number CHAR(12) UNIQUE NOT NULL,
	email VARCHAR(50) NOT NULL,
	id_manager INT NOT NULL,
	id_address INT NOT NULL 
);

CREATE TABLE APPOINTMENT(
	id INT PRIMARY KEY IDENTITY,
	date_hour_schedule DATETIME,
	date_hour_vaccination DATETIME,
	date_hour_processed DATETIME,
	id_cabin INT NOT NULL,
	dui_citizen INT NOT NULL
);

CREATE TABLE CITIZEN(
	DUI INT PRIMARY KEY,
	[name] VARCHAR(50),
	phone_number CHAR(12) UNIQUE NOT NULL,
	email VARCHAR(50) NOT NULL,
	date_of_birth DATE,
	id_address INT NOT NULL,
	id_institution INT NOT NULL
);

CREATE TABLE ADDRESS(
	id INT PRIMARY KEY IDENTITY,
	[state] VARCHAR(20),
	id_city INT NOT NULL,
);
CREATE TABLE CITY(
	id INT PRIMARY KEY IDENTITY,
	city VARCHAR(20)
);

CREATE TABLE USER_DISEASE(
	id_chronicle_disease INT NOT NULL,
	dui_citizen INT NOT NULL,
	CONSTRAINT PK_user_disease PRIMARY KEY(id_chronicle_disease,dui_citizen)
);

CREATE TABLE CHRONICLE_DISEASE(
	id INT PRIMARY KEY IDENTITY,
	chronicle_disease VARCHAR(50)
);

CREATE TABLE APPOINTMENT_EFFECT(
	id INT PRIMARY KEY IDENTITY,
	[minute] INT,
	id_secundary_effect INT NOT NULL,
	id_appointment INT NOT NULL
);

CREATE TABLE SECUNDARY_EFFECT(
	id INT PRIMARY KEY IDENTITY,
	secundary_effect VARCHAR(50)
);

CREATE TABLE MANAGERxCABIN(
	id_manager INT NOT NULL,
	id_cabin INT NOT NULL,
	datetime_login DATETIME NOT NULL,
	CONSTRAINT PK_managerxcabin PRIMARY KEY(id_manager,id_cabin)
);

CREATE TABLE INSTITUTION(
	id INT PRIMARY KEY IDENTITY,
	institution VARCHAR(30)
)

ALTER TABLE CITIZEN ADD FOREIGN KEY (id_institution) REFERENCES INSTITUTION (id);

--DEFINIENDO RELACIONES
ALTER TABLE ADDRESS ADD FOREIGN KEY (id_city) REFERENCES CITY (id);
ALTER TABLE EMPLOYEE ADD FOREIGN KEY (id_address) REFERENCES ADDRESS (id);
ALTER TABLE MANAGER ADD FOREIGN KEY (id_employee) REFERENCES EMPLOYEE (id);
ALTER TABLE CABIN ADD FOREIGN KEY (id_manager) REFERENCES MANAGER (id);
ALTER TABLE CABIN ADD FOREIGN KEY (id_address) REFERENCES ADDRESS (id);
ALTER TABLE APPOINTMENT ADD FOREIGN KEY (id_cabin) REFERENCES CABIN (id);
ALTER TABLE APPOINTMENT ADD FOREIGN KEY (dui_citizen) REFERENCES CITIZEN (DUI);
ALTER TABLE CITIZEN ADD FOREIGN KEY (id_address) REFERENCES ADDRESS (id);
ALTER TABLE USER_DISEASE ADD FOREIGN KEY (id_chronicle_disease) REFERENCES CHRONICLE_DISEASE (id);
ALTER TABLE USER_DISEASE ADD FOREIGN KEY (dui_citizen) REFERENCES CITIZEN (DUI);
ALTER TABLE MANAGERxCABIN ADD FOREIGN KEY (id_manager) REFERENCES MANAGER (id);
ALTER TABLE MANAGERxCABIN ADD FOREIGN KEY (id_cabin ) REFERENCES CABIN (id);
ALTER TABLE APPOINTMENT_EFFECT ADD FOREIGN KEY (id_secundary_effect) REFERENCES SECUNDARY_EFFECT (id);
ALTER TABLE APPOINTMENT_EFFECT ADD FOREIGN KEY (id_appointment) REFERENCES APPOINTMENT (id);

INSERT INTO INSTITUTION (institution) VALUES ('Ciudadano')
INSERT INTO INSTITUTION (institution) VALUES ('Educaci�n')
INSERT INTO INSTITUTION (institution) VALUES ('Salud')
INSERT INTO INSTITUTION (institution) VALUES ('PNC')
INSERT INTO INSTITUTION (institution) VALUES ('Fuerza Armada')
INSERT INTO INSTITUTION (institution) VALUES ('Cuerpo de Socorro')
INSERT INTO INSTITUTION (institution) VALUES ('Personal Fronterizo')
INSERT INTO INSTITUTION (institution) VALUES ('Personal Centro Penales')
INSERT INTO INSTITUTION (institution) VALUES ('Periodismo')
INSERT INTO INSTITUTION (institution) VALUES ('Gobierno')

INSERT INTO CITY (city) VALUES ('La Libertad')
INSERT INTO CITY (city) VALUES ('Sonsonate')
INSERT INTO CITY (city) VALUES ('Morazan')
INSERT INTO CITY (city) VALUES ('Ahuachapan')
INSERT INTO CITY (city) VALUES ('La Union')
INSERT INTO CITY (city) VALUES ('Caba�as')
INSERT INTO CITY (city) VALUES ('Cuscatlan')
INSERT INTO CITY (city) VALUES ('Santa Ana')
INSERT INTO CITY (city) VALUES ('San Salvador')
INSERT INTO CITY (city) VALUES ('San Miguel')
INSERT INTO CITY (city) VALUES ('La Paz')
INSERT INTO CITY (city) VALUES ('San Vicente')
INSERT INTO CITY (city) VALUES ('Usulutan')
INSERT INTO CITY (city) VALUES ('Chalatenango')

INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Tecla',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nuevo Cuscatlan',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Salvador',9)

SELECT * FROM CITIZEN 
SELECT * FROM CITY