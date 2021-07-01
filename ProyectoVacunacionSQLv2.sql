CREATE DATABASE  Proyecto_Vacunacion;
USE Proyecto_Vacunacion;
SET LANGUAGE us_english;
--DROP DATABASE Proyecto_Vacunacion; 

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


CREATE TABLE [ADDRESS](
	id INT PRIMARY KEY IDENTITY,
	[location] VARCHAR(100),
	id_city INT NOT NULL
);

CREATE TABLE CITY(
	id INT PRIMARY KEY IDENTITY,
	city VARCHAR(30),
	id_state INT NOT NULL
);

CREATE TABLE [STATE](
	id INT PRIMARY KEY IDENTITY,
	[state] VARCHAR(20)
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
	id INT PRIMARY KEY IDENTITY,
	id_manager INT NOT NULL,
	id_cabin INT NOT NULL,
	datetime_login DATETIME NOT NULL
);

CREATE TABLE INSTITUTION(
	id INT PRIMARY KEY IDENTITY,
	institution VARCHAR(30)
)

--DEFINIENDO RELACIONES
ALTER TABLE CITIZEN ADD FOREIGN KEY (id_institution) REFERENCES INSTITUTION (id);
ALTER TABLE ADDRESS ADD FOREIGN KEY (id_city) REFERENCES CITY (id);
ALTER TABLE CITY ADD FOREIGN KEY (id_state) REFERENCES STATE (id);
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

--Dataseed
--Insertando instituciones
INSERT INTO INSTITUTION (institution) VALUES ('Ciudadano')
INSERT INTO INSTITUTION (institution) VALUES ('Educación')
INSERT INTO INSTITUTION (institution) VALUES ('Salud')
INSERT INTO INSTITUTION (institution) VALUES ('PNC')
INSERT INTO INSTITUTION (institution) VALUES ('Fuerza Armada')
INSERT INTO INSTITUTION (institution) VALUES ('Cuerpo de Socorro')
INSERT INTO INSTITUTION (institution) VALUES ('Personal Fronterizo')
INSERT INTO INSTITUTION (institution) VALUES ('Personal Centro Penales')
INSERT INTO INSTITUTION (institution) VALUES ('Periodismo')
INSERT INTO INSTITUTION (institution) VALUES ('Gobierno')

--Insertando enfermedades cronicas
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('Insuficiencia Renal')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('Diabetes')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('Cancer')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('Hepatitis')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('VIH/SIDA')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('EPOC')
INSERT INTO CHRONICLE_DISEASE (chronicle_disease) VALUES ('Insuficiencia Cardiaca')

--Insertano efectos secundarios
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('fatiga')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('dolor y/o sensibilidad en la inyeccion')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('dolor de cabeza')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('enrojecimiento en la inyeccion')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('fiebre')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('anafilaxia')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('artralgia')
INSERT INTO SECUNDARY_EFFECT (secundary_effect) VALUES ('mialga')

--Insertando Departamentos
INSERT INTO [STATE] ([state]) VALUES ('La Libertad')--1
INSERT INTO [STATE] ([state]) VALUES ('Sonsonate')--2
INSERT INTO [STATE] ([state]) VALUES ('Morazan')--3
INSERT INTO [STATE] ([state]) VALUES ('Ahuachapan')--4
INSERT INTO [STATE] ([state]) VALUES ('La Union')--5
INSERT INTO [STATE] ([state]) VALUES ('Cabañas')--6
INSERT INTO [STATE] ([state]) VALUES ('Cuscatlan')--7
INSERT INTO [STATE] ([state]) VALUES ('Santa Ana')--8
INSERT INTO [STATE] ([state]) VALUES ('San Salvador')--9
INSERT INTO [STATE] ([state]) VALUES ('San Miguel')--10
INSERT INTO [STATE] ([state]) VALUES ('La Paz')--11
INSERT INTO [STATE] ([state]) VALUES ('San Vicente')--12
INSERT INTO [STATE] ([state]) VALUES ('Usulutan')--13
INSERT INTO [STATE] ([state]) VALUES ('Chalatenango')--14

--LA LIBERTAD
INSERT INTO CITY(city,id_state) VALUES ('Santa Tecla',1)
INSERT INTO CITY(city,id_state) VALUES ('Nuevo Cuscatlan',1)
INSERT INTO CITY(city,id_state) VALUES ('Chiltiupán',1)
INSERT INTO CITY(city,id_state) VALUES ('Ciudad Arce',1)
INSERT INTO CITY(city,id_state) VALUES ('Antiguo Cuscatlán',1)
INSERT INTO CITY(city,id_state) VALUES ('Colón',1)
INSERT INTO CITY(city,id_state) VALUES ('Comasagua',1)
INSERT INTO CITY(city,id_state) VALUES ('Huizúcar',1)
INSERT INTO CITY(city,id_state) VALUES ('Jayaque',1)
INSERT INTO CITY(city,id_state) VALUES ('Jicalapa',1)
INSERT INTO CITY(city,id_state) VALUES ('La Libertad',1)
INSERT INTO CITY(city,id_state) VALUES ('Quezaltepeque',1)
INSERT INTO CITY(city,id_state) VALUES ('San Juan Opico',1)
INSERT INTO CITY(city,id_state) VALUES ('Sacacoyo',1)
INSERT INTO CITY(city,id_state) VALUES ('San José Villanueva',1)
INSERT INTO CITY(city,id_state) VALUES ('San Matías',1)
INSERT INTO CITY(city,id_state) VALUES ('San Pablo Tacachico',1)
INSERT INTO CITY(city,id_state) VALUES ('Talnique',1)
INSERT INTO CITY(city,id_state) VALUES ('Tamanique',1)
INSERT INTO CITY(city,id_state) VALUES ('Teotepeque',1)
INSERT INTO CITY(city,id_state) VALUES ('Tepecoyo',1)
INSERT INTO CITY(city,id_state) VALUES ('Zaragoza',1)

--SONSONATE
INSERT INTO CITY(city,id_state) VALUES ('Sonsonate',2)
INSERT INTO CITY(city,id_state) VALUES ('Acajutla',2)
INSERT INTO CITY(city,id_state) VALUES ('Armenia',2)
INSERT INTO CITY(city,id_state) VALUES ('Caluco',2)
INSERT INTO CITY(city,id_state) VALUES ('Cuisnahuat',2)
INSERT INTO CITY(city,id_state) VALUES ('Izalco',2)
INSERT INTO CITY(city,id_state) VALUES ('Juayúa',2)
INSERT INTO CITY(city,id_state) VALUES ('Nahuizalco',2)
INSERT INTO CITY(city,id_state) VALUES ('Nahulingo',2)
INSERT INTO CITY(city,id_state) VALUES ('Salcoatitán',2)
INSERT INTO CITY(city,id_state) VALUES ('San Antonio del Monte',2)
INSERT INTO CITY(city,id_state) VALUES ('San Julián',2)
INSERT INTO CITY(city,id_state) VALUES ('Santa Catarina Masahuat',2)
INSERT INTO CITY(city,id_state) VALUES ('Santa Isabel Ishuatán',2)
INSERT INTO CITY(city,id_state) VALUES ('Santo Domingo de Guzmán',2)
INSERT INTO CITY(city,id_state) VALUES ('Sonzacate',2)

--MORAZAN
INSERT INTO CITY(city,id_state) VALUES ('San Francisco Gotera',3)
INSERT INTO CITY(city,id_state) VALUES ('Arambala',3)
INSERT INTO CITY(city,id_state) VALUES ('Cacaopera',3)
INSERT INTO CITY(city,id_state) VALUES ('Chilanga',3)
INSERT INTO CITY(city,id_state) VALUES ('Corinto',3)
INSERT INTO CITY(city,id_state) VALUES ('Delicias de Concepción',3)
INSERT INTO CITY(city,id_state) VALUES ('El Divisadero',3)
INSERT INTO CITY(city,id_state) VALUES ('El Rosario',3)
INSERT INTO CITY(city,id_state) VALUES ('Gualococti',3)
INSERT INTO CITY(city,id_state) VALUES ('Guatajiagua',3)
INSERT INTO CITY(city,id_state) VALUES ('Joateca',3)
INSERT INTO CITY(city,id_state) VALUES ('Jocoaitique',3)
INSERT INTO CITY(city,id_state) VALUES ('Jocoro',3)
INSERT INTO CITY(city,id_state) VALUES ('Lolotiquillo',3)
INSERT INTO CITY(city,id_state) VALUES ('Meanguera',3)
INSERT INTO CITY(city,id_state) VALUES ('Osicala',3)
INSERT INTO CITY(city,id_state) VALUES ('Perquín',3)
INSERT INTO CITY(city,id_state) VALUES ('San Carlos',3)
INSERT INTO CITY(city,id_state) VALUES ('San Fernando',3)
INSERT INTO CITY(city,id_state) VALUES ('San Isidro',3)
INSERT INTO CITY(city,id_state) VALUES ('San Simón',3)
INSERT INTO CITY(city,id_state) VALUES ('Sensembra',3)
INSERT INTO CITY(city,id_state) VALUES ('Sociedad',3)
INSERT INTO CITY(city,id_state) VALUES ('Torola',3)
INSERT INTO CITY(city,id_state) VALUES ('Yamabal',3)
INSERT INTO CITY(city,id_state) VALUES ('Yoloaiquín',3)

--AHUACHAPAN
INSERT INTO CITY(city,id_state) VALUES ('Ahuachapán',4)
INSERT INTO CITY(city,id_state) VALUES ('Apaneca',4)
INSERT INTO CITY(city,id_state) VALUES ('Atiquizaya',4)
INSERT INTO CITY(city,id_state) VALUES ('Concepción de Ataco',4)
INSERT INTO CITY(city,id_state) VALUES ('El Refugio',4)
INSERT INTO CITY(city,id_state) VALUES ('Guaymango',4)
INSERT INTO CITY(city,id_state) VALUES ('Jujutla',4)
INSERT INTO CITY(city,id_state) VALUES ('San Francisco Menéndez',4)
INSERT INTO CITY(city,id_state) VALUES ('San Lorenzo',4)
INSERT INTO CITY(city,id_state) VALUES ('San Pedro Puxtla',4)
INSERT INTO CITY(city,id_state) VALUES ('Tacuba',4)
INSERT INTO CITY(city,id_state) VALUES ('Turín',4)

--LA UNION
INSERT INTO CITY(city,id_state) VALUES ('La Unión ',5)
INSERT INTO CITY(city,id_state) VALUES ('Anamorós',5)
INSERT INTO CITY(city,id_state) VALUES ('Bolívar',5)
INSERT INTO CITY(city,id_state) VALUES ('Concepción de Oriente',5)
INSERT INTO CITY(city,id_state) VALUES ('Conchagua',5)
INSERT INTO CITY(city,id_state) VALUES ('El Carmen',5)
INSERT INTO CITY(city,id_state) VALUES ('El Sauce',5)
INSERT INTO CITY(city,id_state) VALUES ('Intipucá',5)
INSERT INTO CITY(city,id_state) VALUES ('Lislique',5)
INSERT INTO CITY(city,id_state) VALUES ('Meanguera del Golfo',5)
INSERT INTO CITY(city,id_state) VALUES ('Nueva Esparta',5)
INSERT INTO CITY(city,id_state) VALUES ('Pasaquina',5)
INSERT INTO CITY(city,id_state) VALUES ('Polorós',5)
INSERT INTO CITY(city,id_state) VALUES ('San Alejo',5)
INSERT INTO CITY(city,id_state) VALUES ('San José',5)
INSERT INTO CITY(city,id_state) VALUES ('Santa Rosa de Lima',5)
INSERT INTO CITY(city,id_state) VALUES ('Yayantique',5)
INSERT INTO CITY(city,id_state) VALUES ('Yucuaiquín',5)

--CABAÑAS
INSERT INTO CITY(city,id_state) VALUES ('Sensuntepeque',6)
INSERT INTO CITY(city,id_state) VALUES ('Cinquera',6)
INSERT INTO CITY(city,id_state) VALUES ('Dolores',6)
INSERT INTO CITY(city,id_state) VALUES ('Guacotecti',6)
INSERT INTO CITY(city,id_state) VALUES ('Ilobasco',6)
INSERT INTO CITY(city,id_state) VALUES ('Jutiapa',6)
INSERT INTO CITY(city,id_state) VALUES ('San Isidro',6)
INSERT INTO CITY(city,id_state) VALUES ('Tejutepeque',6)
INSERT INTO CITY(city,id_state) VALUES ('Victoria',6)

--CUSCATLAN
INSERT INTO CITY(city,id_state) VALUES ('Cojutepeque',7)
INSERT INTO CITY(city,id_state) VALUES ('Candelaria',7)
INSERT INTO CITY(city,id_state) VALUES ('El Carmen',7)
INSERT INTO CITY(city,id_state) VALUES ('El Rosario',7)
INSERT INTO CITY(city,id_state) VALUES ('Monte San Juan',7)
INSERT INTO CITY(city,id_state) VALUES ('Oratorio de Concepción',7)
INSERT INTO CITY(city,id_state) VALUES ('San Bartolomé Perulapía',7)
INSERT INTO CITY(city,id_state) VALUES ('San Cristóbal',7)
INSERT INTO CITY(city,id_state) VALUES ('San José Guayabal',7)
INSERT INTO CITY(city,id_state) VALUES ('San Pedro Perulapán',7)
INSERT INTO CITY(city,id_state) VALUES ('San Rafael Cedros',7)
INSERT INTO CITY(city,id_state) VALUES ('San Ramón',7)
INSERT INTO CITY(city,id_state) VALUES ('Santa Cruz Analquito',7)
INSERT INTO CITY(city,id_state) VALUES ('Santa Cruz Michapa',7)	
INSERT INTO CITY(city,id_state) VALUES ('Suchitoto',7)
INSERT INTO CITY(city,id_state) VALUES ('Tenancingo',7)	

--SANTA ANA
INSERT INTO CITY(city,id_state) VALUES ('Santa Ana ',8)
INSERT INTO CITY(city,id_state) VALUES ('Candelaria de la Frontera',8)
INSERT INTO CITY(city,id_state) VALUES ('Chalchuapa',8)	
INSERT INTO CITY(city,id_state) VALUES ('Coatepeque',8)
INSERT INTO CITY(city,id_state) VALUES ('El Congo',8)
INSERT INTO CITY(city,id_state) VALUES ('El Porvenir',8)
INSERT INTO CITY(city,id_state) VALUES ('Masahuat',8)
INSERT INTO CITY(city,id_state) VALUES ('Metapán',8)	
INSERT INTO CITY(city,id_state) VALUES ('San Antonio Pajonal',8)
INSERT INTO CITY(city,id_state) VALUES ('San Sebastián Salitrillo',8)
INSERT INTO CITY(city,id_state) VALUES ('Santa Rosa Guachipilín',8)	
INSERT INTO CITY(city,id_state) VALUES ('Santiago de la Frontera',8)
INSERT INTO CITY(city,id_state) VALUES ('Texistepeque',8)


--SAN SALVADOR
INSERT INTO CITY(city,id_state) VALUES ('San Salvador',9)
INSERT INTO CITY(city,id_state) VALUES ('Aguilares',9)
INSERT INTO CITY(city,id_state) VALUES ('Apopa',9)
INSERT INTO CITY(city,id_state) VALUES ('Ayutuxtepeque',9)
INSERT INTO CITY(city,id_state) VALUES ('Ciudad Delgado',9)
INSERT INTO CITY(city,id_state) VALUES ('Cuscatancingo',9)
INSERT INTO CITY(city,id_state) VALUES ('El Paisnal',9)
INSERT INTO CITY(city,id_state) VALUES ('Guazapa',9)
INSERT INTO CITY(city,id_state) VALUES ('Ilopango',9)
INSERT INTO CITY(city,id_state) VALUES ('Mejicanos',9)
INSERT INTO CITY(city,id_state) VALUES ('Nejapa',9)
INSERT INTO CITY(city,id_state) VALUES ('Panchimalco',9)
INSERT INTO CITY(city,id_state) VALUES ('Rosario de Mora',9)
INSERT INTO CITY(city,id_state) VALUES ('San Marcos',9)
INSERT INTO CITY(city,id_state) VALUES ('San Martín',9)
INSERT INTO CITY(city,id_state) VALUES ('Santiago Texacuangos',9)
INSERT INTO CITY(city,id_state) VALUES ('Santo Tomás',9)
INSERT INTO CITY(city,id_state) VALUES ('Soyapango',9)
INSERT INTO CITY(city,id_state) VALUES ('Tonacatepeque',9)

--SAN MIGUEL
INSERT INTO CITY(city,id_state) VALUES ('San Miguel',10)
INSERT INTO CITY(city,id_state) VALUES ('Carolina',10)
INSERT INTO CITY(city,id_state) VALUES ('Chapeltique',10)
INSERT INTO CITY(city,id_state) VALUES ('Chinameca',10)
INSERT INTO CITY(city,id_state) VALUES ('Chirilagua',10)
INSERT INTO CITY(city,id_state) VALUES ('Ciudad Barrios',10)
INSERT INTO CITY(city,id_state) VALUES ('Comacarán',10)
INSERT INTO CITY(city,id_state) VALUES ('El Tránsito',10)
INSERT INTO CITY(city,id_state) VALUES ('Lolotique',10)
INSERT INTO CITY(city,id_state) VALUES ('Moncagua',10)
INSERT INTO CITY(city,id_state) VALUES ('Nueva Guadalupe',10)
INSERT INTO CITY(city,id_state) VALUES ('Nuevo Edén de San Juan',10)
INSERT INTO CITY(city,id_state) VALUES ('Quelepa',10)
INSERT INTO CITY(city,id_state) VALUES ('San Antonio',10)
INSERT INTO CITY(city,id_state) VALUES ('San Gerardo',10)
INSERT INTO CITY(city,id_state) VALUES ('San Jorge',10)
INSERT INTO CITY(city,id_state) VALUES ('San Luis de la Reina',10)
INSERT INTO CITY(city,id_state) VALUES ('San Rafael Oriente',10)
INSERT INTO CITY(city,id_state) VALUES ('Sesori',10)
INSERT INTO CITY(city,id_state) VALUES ('Uluazapa',10)

--LA PAZ
INSERT INTO CITY(city,id_state) VALUES ('Zacatecoluca ',11)
INSERT INTO CITY(city,id_state) VALUES ('Cuyultitán',11)
INSERT INTO CITY(city,id_state) VALUES ('El Rosario',11)
INSERT INTO CITY(city,id_state) VALUES ('Jerusalén',11)
INSERT INTO CITY(city,id_state) VALUES ('Mercedes La Ceiba',11)
INSERT INTO CITY(city,id_state) VALUES ('Olocuilta',11)
INSERT INTO CITY(city,id_state) VALUES ('Paraíso de Osorio',11)
INSERT INTO CITY(city,id_state) VALUES ('San Antonio Masahuat',11)
INSERT INTO CITY(city,id_state) VALUES ('San Emigdio',11)
INSERT INTO CITY(city,id_state) VALUES ('San Francisco Chinameca',11)
INSERT INTO CITY(city,id_state) VALUES ('San Pedro Masahuat',11)
INSERT INTO CITY(city,id_state) VALUES ('San Juan Nonualco',11)
INSERT INTO CITY(city,id_state) VALUES ('San Juan Talpa',11)
INSERT INTO CITY(city,id_state) VALUES ('San Juan Tepezontes',11)
INSERT INTO CITY(city,id_state) VALUES ('San Luis La Herradura',11)
INSERT INTO CITY(city,id_state) VALUES ('San Luis Talpa',11)
INSERT INTO CITY(city,id_state) VALUES ('San Miguel Tepezontes',11)
INSERT INTO CITY(city,id_state) VALUES ('San Pedro Nonualco',11)
INSERT INTO CITY(city,id_state) VALUES ('San Rafael Obrajuelo',11)	
INSERT INTO CITY(city,id_state) VALUES ('Santa María Ostuma',11)
INSERT INTO CITY(city,id_state) VALUES ('Santiago Nonualco',11)	
INSERT INTO CITY(city,id_state) VALUES ('Tapalhuaca',11)

--SAN VICENTE
INSERT INTO CITY(city,id_state) VALUES ('San Vicente ',12)
INSERT INTO CITY(city,id_state) VALUES ('Apastepeque',12)
INSERT INTO CITY(city,id_state) VALUES ('Guadalupe',12)	
INSERT INTO CITY(city,id_state) VALUES ('San Cayetano Istepeque',12)
INSERT INTO CITY(city,id_state) VALUES ('San Esteban Catarina',12)	
INSERT INTO CITY(city,id_state) VALUES ('San Ildefonso',12)
INSERT INTO CITY(city,id_state) VALUES ('San Lorenzo',12)
INSERT INTO CITY(city,id_state) VALUES ('San Sebastián',12)
INSERT INTO CITY(city,id_state) VALUES ('Santa Clara',12)	
INSERT INTO CITY(city,id_state) VALUES ('Santo Domingo',12)
INSERT INTO CITY(city,id_state) VALUES ('Tecoluca',12)	
INSERT INTO CITY(city,id_state) VALUES ('Tepetitán',12)
INSERT INTO CITY(city,id_state) VALUES ('Verapaz',12)

--USULUTAN
INSERT INTO CITY(city,id_state) VALUES ('Usulután',13)	
INSERT INTO CITY(city,id_state) VALUES ('Alegría',13)
INSERT INTO CITY(city,id_state) VALUES ('Berlín',13)	
INSERT INTO CITY(city,id_state) VALUES ('California',13)
INSERT INTO CITY(city,id_state) VALUES ('Concepción Batres',13)
INSERT INTO CITY(city,id_state) VALUES ('El Triunfo',13)	
INSERT INTO CITY(city,id_state) VALUES ('Ereguayquín',13)
INSERT INTO CITY(city,id_state) VALUES ('Estanzuelas',13)	
INSERT INTO CITY(city,id_state) VALUES ('Jiquilisco',13)
INSERT INTO CITY(city,id_state) VALUES ('Jucuapa',13)
INSERT INTO CITY(city,id_state) VALUES ('Jucuarán',13)	
INSERT INTO CITY(city,id_state) VALUES ('Mercedes Umaña',13)
INSERT INTO CITY(city,id_state) VALUES ('Nueva Granada',13)	
INSERT INTO CITY(city,id_state) VALUES ('Ozatlán',13)
INSERT INTO CITY(city,id_state) VALUES ('Puerto El Triunfo',13)
INSERT INTO CITY(city,id_state) VALUES ('San Agustín',13)
INSERT INTO CITY(city,id_state) VALUES ('San Buenaventura',13)
INSERT INTO CITY(city,id_state) VALUES ('San Dionisio',13)	
INSERT INTO CITY(city,id_state) VALUES ('San Francisco Javier',13)
INSERT INTO CITY(city,id_state) VALUES ('Santa Elena',13)	
INSERT INTO CITY(city,id_state) VALUES ('Santa María',13)
INSERT INTO CITY(city,id_state) VALUES ('Santiago de María',13)
INSERT INTO CITY(city,id_state) VALUES ('Tecapán',13)

--CHALATENANGO
INSERT INTO CITY(city,id_state) VALUES ('Chalatenango',14)	
INSERT INTO CITY(city,id_state) VALUES ('Agua Caliente',14)
INSERT INTO CITY(city,id_state) VALUES ('Arcatao',14)	
INSERT INTO CITY(city,id_state) VALUES ('Azacualpa',14)
INSERT INTO CITY(city,id_state) VALUES ('Cancasque',14)
INSERT INTO CITY(city,id_state) VALUES ('Citalá',14)
INSERT INTO CITY(city,id_state) VALUES ('Comalapa',14)	
INSERT INTO CITY(city,id_state) VALUES ('Concepción Quezaltepeque',14)
INSERT INTO CITY(city,id_state) VALUES ('Dulce Nombre de María',14)	
INSERT INTO CITY(city,id_state) VALUES ('El Carrizal',14)
INSERT INTO CITY(city,id_state) VALUES ('El Paraíso',14)
INSERT INTO CITY(city,id_state) VALUES ('La Laguna',14)
INSERT INTO CITY(city,id_state) VALUES ('La Palma',14)	
INSERT INTO CITY(city,id_state) VALUES ('La Reina',14)
INSERT INTO CITY(city,id_state) VALUES ('Las Flores',14)	
INSERT INTO CITY(city,id_state) VALUES ('Las Vueltas',14)
INSERT INTO CITY(city,id_state) VALUES ('Nombre de Jesús',14)
INSERT INTO CITY(city,id_state) VALUES ('Nueva Concepción ',14)
INSERT INTO CITY(city,id_state) VALUES ('Nueva Trinidad',14)	
INSERT INTO CITY(city,id_state) VALUES ('Ojos de Agua',14)
INSERT INTO CITY(city,id_state) VALUES ('Potonico',14)	
INSERT INTO CITY(city,id_state) VALUES ('San Antonio de la Cruz',14)
INSERT INTO CITY(city,id_state) VALUES ('San Antonio Los Ranchos',14)
INSERT INTO CITY(city,id_state) VALUES ('San Fernando',14)
INSERT INTO CITY(city,id_state) VALUES ('San Francisco Lempa',14)	
INSERT INTO CITY(city,id_state) VALUES ('San Francisco Morazán',14)
INSERT INTO CITY(city,id_state) VALUES ('San Ignacio',14)	
INSERT INTO CITY(city,id_state) VALUES ('San Isidro Labrador',14)
INSERT INTO CITY(city,id_state) VALUES ('San Luis del Carmen',14)
INSERT INTO CITY(city,id_state) VALUES ('San Miguel de Mercedes',14)
INSERT INTO CITY(city,id_state) VALUES ('San Rafael',14)
INSERT INTO CITY(city,id_state) VALUES ('Santa Rita',14)
INSERT INTO CITY(city,id_state) VALUES ('San Miguel de Mercedes',14)

SELECT * FROM STATE
SELECT c.id, c.city, s.state FROM CITY c LEFT JOIN [STATE] s ON s.id = c.id_state
ORDER BY c.city;

--Añadiendo empleados que son gestores
--Primero se inserta la direccion, despues el emplado, y por ultimo el gestor
INSERT INTO [ADDRESS](location, id_city) VALUES ('casa no15, pasaje barrios, barrio el centro', 2)--1
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--1
		VALUES (1, 'Luis Alonso Serrano', 'luis.serrano@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (1, 1, '1', '1')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo El Centro Cl Alberto Masferrer Ote No 1-4', 23)--2
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--2
		VALUES (2, 'Juan Alberto Masferrer', 'jauno@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (2, 2, 'user2', '2')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo De Honduras 1 Cl Pte No 3-3', 39)--3
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--3
		VALUES (3, 'Francisco Antonio Gota', 'frankgota@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (3, 3, 'user3', '123')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo Las Flores 2 Cl Ote No 1-4', 65)--4
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--4
		VALUES (4, 'Aurelio Humberto Lopez', 'auhum@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (4, 4, 'user4', 'cuatro')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Colonia San Francisco Av Las Dalias y Av Los Espliegos No 1-A', 80)--5
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--5
		VALUES (5, 'Concepcion Oria', 'maria.oria@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (5, 5, 'user5', 'password')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo Concepción Av José Simeón Cañas No 8', 103)--6
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--6
		VALUES (6, 'Victoria Mercedes Paredes', 'vickymer@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (6, 6, 'user6', 'user6')
INSERT INTO [ADDRESS](location, id_city) VALUES ('11 Cl Pte Y 3 Av Nte No 220', 107)--7
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--7
		VALUES (7, 'Teresa del Rosario Ramirez', 'teresa.ramirez@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (7, 7, 'user7', '7')
INSERT INTO [ADDRESS](location, id_city) VALUES ('1 Cl Ote Y 7 Av Sur', 120)--8
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--8
		VALUES (8, 'Ana Samanta Gutierrez', 'anasamanta@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (8, 8, 'user8', '8')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Col San Benito Av Las Palmas No 161', 133)--9
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--9
		VALUES (9, 'Salvador Marcelo Carbajal', 'salvamar@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (9, 9, 'user9', '9')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo El Calvario 9 Cl Ote No 304Bis', 152)--10
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--10
		VALUES (10, 'Miguel Angel Romero', 'miguel.romero@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (10, 10, 'user10', '10')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Rpto Las Alamedas Políg F Pje 6 No 19', 183)--11
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--11
		VALUES (11, 'Juan Santiago Sosa', 'juansanti@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (11, 11, 'user11', '11')
INSERT INTO [ADDRESS](location, id_city) VALUES ('7 Cl Pte Y Av España Cond Central E Loc 1', 194)--12
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--12
		VALUES (12, 'Sandra Victoria Gallego', 'sanvicky@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (12, 12, 'user12', '12')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo La Parroquia 6 Av Nte No 9', 207)--13
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--13
		VALUES (13, 'Ursula Marina Tanase', 'ursulatanase@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (13, 13, 'user13', '13')
INSERT INTO [ADDRESS](location, id_city) VALUES ('Bo San José 3 Cl Pte No 6', 230)--14
	INSERT INTO EMPLOYEE(id, name, email, type_employee, id_address)--14
		VALUES (14, 'Domingo Teodaro Chacon', 'chacondomingo@gob.sv', 'Gestor', SCOPE_IDENTITY())
	INSERT INTO MANAGER(id, id_employee, username, [password]) VALUES (14, 14, 'user14', '14')

SELECT * FROM EMPLOYEE e
SELECT *
	FROM EMPLOYEE e 
	LEFT JOIN MANAGER m ON e.Id = m.id_employee

--Insertando un par de cabinas
INSERT INTO [ADDRESS] (location, id_city) VALUES ('Hospital Nacional San Rafael, Carr. Panamericana 15', 1)
	INSERT INTO CABIN (phone_number, email, id_manager, id_address)
		VALUES ('61616161', 'mecamail@gob.com', 1, SCOPE_IDENTITY())
INSERT INTO [ADDRESS] (location, id_city) VALUES ('Hospital Centro Medico Sonsonate, Barrio El Pilar, 5A Avenida Norte 3-6', 23)
	INSERT INTO CABIN (phone_number, email, id_manager, id_address)
		VALUES ('61616171', 'robomail@gob.com', 2, SCOPE_IDENTITY())
INSERT INTO [ADDRESS] (location, id_city) VALUES ('Hospital El Salvador, Salón Centro Americano, Avenida De La Revolucion 222,', 133)
	INSERT INTO CABIN (phone_number, email, id_manager, id_address)
		VALUES ('61617171', 'electromail@gob.com', 9, SCOPE_IDENTITY())

--Insertando n ciudano y una cita
INSERT INTO CITIZEN (DUI, [name], phone_number, email, date_of_birth, id_address, id_institution)
	VALUES (987654321, 'Matias Herculano Saca', '61617172', 'heracles@gmail.com', '2000-10-10', 1, 1)
INSERT INTO APPOINTMENT (date_hour_schedule, id_cabin, dui_citizen)
	VALUES ('2021-07-01', 1, 987654321)
