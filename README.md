# Proyecto Vacunacion Grupo 3

## Integrantes:
Oscar Steve Santos Saravia 00380119
Edwin Bladimir Gomez Cortez 00400519
Salvador Marcelo Mejía Hernández 00072020 
Manuel Alejandro Madriz López 00026220

### Link del repositorio de trabajo anterior 
https://github.com/Salvamar22/PROYECTO_POO

### Version de framework / Paquetes NuGet
.NET 5.0
Microsoft.EntityFrameworkCore v5.0.7
Microsoft.EntityFrameworkCore.Design v5.0.7
Microsoft.EntityFrameworkCore.SqlServer v5.0.7

### Sistema Operativo
Windows 10 x64

## Patrones implementados
Se utilizo el patron ViewModel para la representacion y manejo de recurso de datos 
en las tablas de los formularios. Lo que nos permite poder mostrar al usuario unicamente
los datos necesario para el correto flujo de trabajo, y no datos que podrian afectar 
de alguna manera la vulneracion o extracion de datos personales o de la propia estructura del programa.


### Inicio
Para correr el programa es necesario contar con la base de datos y con algunos inserts 
escenciales para el funcionamiento del programa.
Se utilizo SQLServer como gestor de base de datos.
Se debe correr el scripr "ProyectoVacunacionSQLv3.sql"
El script "ProyectoInsercionesSQLv3" posee algunos inserts de muestra.

Si la base de datos fue creada correctamente y posee los datos seeds iniciales el programa podra ser ejecutado 
al compilar la solucion. 
Nota: 
Los nombres de usuarios y contraseñas deberan ser insertados desde la base de datos ya que no es funcionalidad 
en el contexto del programa el crear nuevo registros de Gestores, Empleados, Cabinas.