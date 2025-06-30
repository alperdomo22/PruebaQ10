# PruebaQ10

El proyecto se encuentra divido en 2 proyectos principales, el API que est[a encargada de toda la parte del Backend con DDD y la Web que es la parte del front con Razor Pages, ya se encuentra configurada la solucion para ser ejecutada y correr los 2 proyectos mencionados anteriormente.
La base de datos se realizo con SQL Server, para iniciar la base de datos se debe crear en la base de datos PruebaQ10, posterior a esto en la consola del administrador de paquetes y seleccionando como proyecto por defecto "Infraestructure" se deben ejecutar los siguientes comandos en el orden respectivo:
1. add-Migration Prueba -StartupProject PruebaQ10API
2. update-database -StartupProject PruebaQ10API

Estos comandos crean las tablas necesarias en la base de datos que se encuentran configuradas en el API y se crean por medio de migraciones.
