<<<<<<< HEAD
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

INSERT INTO CITY (city) VALUES ('La Libertad')--1
INSERT INTO CITY (city) VALUES ('Sonsonate')--2
INSERT INTO CITY (city) VALUES ('Morazan')--3
INSERT INTO CITY (city) VALUES ('Ahuachapan')--4
INSERT INTO CITY (city) VALUES ('La Union')--5
INSERT INTO CITY (city) VALUES ('Caba�as')--6
INSERT INTO CITY (city) VALUES ('Cuscatlan')--7
INSERT INTO CITY (city) VALUES ('Santa Ana')--8
INSERT INTO CITY (city) VALUES ('San Salvador')--9
INSERT INTO CITY (city) VALUES ('San Miguel')--10
INSERT INTO CITY (city) VALUES ('La Paz')--11
INSERT INTO CITY (city) VALUES ('San Vicente')--12
INSERT INTO CITY (city) VALUES ('Usulutan')--13
INSERT INTO CITY (city) VALUES ('Chalatenango')--14

--LA LIBERTAD
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Tecla',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nuevo Cuscatlan',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Chiltiup�n',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Ciudad Arce',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Antiguo Cuscatl�n',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Col�n',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Comasagua',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Huiz�car',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jayaque',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jicalapa',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('La Libertad',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Quezaltepeque',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Juan Opico',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Sacacoyo',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Jos� Villanueva',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Mat�as',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Pablo Tacachico',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Talnique',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tamanique',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Teotepeque',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tepecoyo',1)
INSERT INTO ADDRESS([state],id_city) VALUES ('Zaragoza',1)

--SONSONATE
INSERT INTO ADDRESS([state],id_city) VALUES ('Sonsonate',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Acajutla',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Armenia',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Caluco',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cuisnahuat',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Izalco',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Juay�a',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nahuizalco',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nahulingo',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Salcoatit�n',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Antonio del Monte',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Juli�n',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Catarina Masahuat',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Isabel Ishuat�n',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santo Domingo de Guzm�n',2)
INSERT INTO ADDRESS([state],id_city) VALUES ('Sonzacate',2)

--MORAZAN
INSERT INTO ADDRESS([state],id_city) VALUES ('San Francisco Gotera',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Arambala',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cacaopera',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Chilanga',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Corinto',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Delicias de Concepci�n',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Divisadero',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Rosario',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Gualococti',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Guatajiagua',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Joateca',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jocoaitique',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jocoro',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Lolotiquillo',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Meanguera',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Osicala',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Perqu�n',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Carlos',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Fernando',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Isidro',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Sim�n',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Sensembra',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Sociedad',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Torola',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Yamabal',3)
INSERT INTO ADDRESS([state],id_city) VALUES ('Yoloaiqu�n',3)

--AHUACHAPAN
INSERT INTO ADDRESS([state],id_city) VALUES ('Ahuachap�n',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Apaneca',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Atiquizaya',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Concepci�n de Ataco',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Refugio',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Guaymango',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jujutla',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Francisco Men�ndez',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Lorenzo',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Pedro Puxtla',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tacuba',4)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tur�n',4)

--LA UNION
INSERT INTO ADDRESS([state],id_city) VALUES ('La Uni�n ',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Anamor�s',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Bol�var',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Concepci�n de Oriente',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Conchagua',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Carmen',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Sauce',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Intipuc�',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Lislique',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Meanguera del Golfo',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nueva Esparta',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Pasaquina',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Polor�s',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Alejo',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Jos�',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Rosa de Lima',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Yayantique',5)
INSERT INTO ADDRESS([state],id_city) VALUES ('Yucuaiqu�n',5)

--CABA�AS
INSERT INTO ADDRESS([state],id_city) VALUES ('Sensuntepeque',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cinquera',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Dolores',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Guacotecti',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Ilobasco',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jutiapa',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Isidro',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tejutepeque',6)
INSERT INTO ADDRESS([state],id_city) VALUES ('Victoria',6)

--CUSCATLAN
INSERT INTO ADDRESS([state],id_city) VALUES ('Cojutepeque',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('Candelaria',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Carmen',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Rosario',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('Monte San Juan',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('Oratorio de Concepci�n',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Bartolom� Perulap�a',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Crist�bal',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Jos� Guayabal',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Pedro Perulap�n',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Rafael Cedros',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Ram�n',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Cruz Analquito',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Cruz Michapa',7)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Suchitoto',7)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tenancingo',7)	

--SANTA ANA
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Ana ',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('Candelaria de la Frontera',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('Chalchuapa',8)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Coatepeque',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Congo',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Porvenir',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('Masahuat',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('Metap�n',8)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Antonio Pajonal',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Sebasti�n Salitrillo',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Rosa Guachipil�n',8)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Santiago de la Frontera',8)
INSERT INTO ADDRESS([state],id_city) VALUES ('Texistepeque',8)


--SAN SALVADOR
INSERT INTO ADDRESS([state],id_city) VALUES ('San Salvador',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Aguilares',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Apopa',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Ayutuxtepeque',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Ciudad Delgado',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cuscatancingo',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Paisnal',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Guazapa',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Ilopango',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Mejicanos',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nejapa',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Panchimalco',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Rosario de Mora',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Marcos',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Mart�n',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santiago Texacuangos',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santo Tom�s',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Soyapango',9)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tonacatepeque',9)

--SAN MIGUEL
INSERT INTO ADDRESS([state],id_city) VALUES ('San Miguel',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Carolina',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Chapeltique',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Chinameca',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Chirilagua',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Ciudad Barrios',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Comacar�n',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Tr�nsito',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Lolotique',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Moncagua',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nueva Guadalupe',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nuevo Ed�n de San Juan',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Quelepa',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Antonio',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Gerardo',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Jorge',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Luis de la Reina',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Rafael Oriente',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Sesori',10)
INSERT INTO ADDRESS([state],id_city) VALUES ('Uluazapa',10)

--LA PAZ
INSERT INTO ADDRESS([state],id_city) VALUES ('Zacatecoluca ',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cuyultit�n',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Rosario',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jerusal�n',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('Mercedes La Ceiba',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('Olocuilta',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('Para�so de Osorio',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Antonio Masahuat',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Emigdio',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Francisco Chinameca',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Pedro Masahuat',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Juan Nonualco',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Juan Talpa',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Juan Tepezontes',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Luis La Herradura',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Luis Talpa',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Miguel Tepezontes',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Pedro Nonualco',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Rafael Obrajuelo',11)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Mar�a Ostuma',11)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santiago Nonualco',11)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Tapalhuaca',11)

--SAN VICENTE
INSERT INTO ADDRESS([state],id_city) VALUES ('San Vicente ',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('Apastepeque',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('Guadalupe',12)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Cayetano Istepeque',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Esteban Catarina',12)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Ildefonso',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Lorenzo',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Sebasti�n',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Clara',12)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Santo Domingo',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tecoluca',12)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Tepetit�n',12)
INSERT INTO ADDRESS([state],id_city) VALUES ('Verapaz',12)

--USULUTAN
INSERT INTO ADDRESS([state],id_city) VALUES ('Usulut�n',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Alegr�a',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Berl�n',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('California',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Concepci�n Batres',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Triunfo',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Ereguayqu�n',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Estanzuelas',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Jiquilisco',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jucuapa',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Jucuar�n',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Mercedes Uma�a',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nueva Granada',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Ozatl�n',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Puerto El Triunfo',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Agust�n',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Buenaventura',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Dionisio',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Francisco Javier',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Elena',13)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Mar�a',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santiago de Mar�a',13)
INSERT INTO ADDRESS([state],id_city) VALUES ('Tecap�n',13)

--CHALATENANGO
INSERT INTO ADDRESS([state],id_city) VALUES ('Chalatenango',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Agua Caliente',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Arcatao',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Azacualpa',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cancasque',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Cital�',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Comalapa',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Concepci�n Quezaltepeque',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Dulce Nombre de Mar�a',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('El Carrizal',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('El Para�so',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('La Laguna',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('La Palma',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('La Reina',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Las Flores',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Las Vueltas',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nombre de Jes�s',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nueva Concepci�n ',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Nueva Trinidad',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('Ojos de Agua',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Potonico',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Antonio de la Cruz',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Antonio Los Ranchos',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Fernando',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Francisco Lempa',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Francisco Moraz�n',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Ignacio',14)	
INSERT INTO ADDRESS([state],id_city) VALUES ('San Isidro Labrador',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Luis del Carmen',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Miguel de Mercedes',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Rafael',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('Santa Rita',14)
INSERT INTO ADDRESS([state],id_city) VALUES ('San Miguel de Mercedes',14)

INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Covid19')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Diabetes')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Sifilis')
INSERT INTO CHRONICLE_DISEASE(chronicle_disease)  VALUES('VIH')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Epatitis')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Insuficiencia Renal')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Alzheimer')
INSERT INTO CHRONICLE_DISEASE(chronicle_disease)  VALUES('Gripe')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Cancer')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Hpertensi�n')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES('Epilepsia')


SELECT * FROM CITIZEN 
SELECT * FROM USER_DISEASE
=======
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
>>>>>>> 7563b62cbc626783b3bb2f63af975d291a3b0d40
SELECT * FROM CITY