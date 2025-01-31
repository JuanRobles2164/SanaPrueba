# PRUEBA SANA E-COMMERCE

¡Hola!

En este archivo explicaré las cosas que hice, las que no hice y por qué no las hice.

Para empezar, no hice el apartado de Front-End porque no sé React.

En la entrevista inicial me recomendaron que dijera qué sabía y qué no sabía. Y si no sabía algo, era mejor aclararlo en vez de arriesgar y perder.

Sin embargo, estaré capacitandome en React mientras la prueba esté en revisión. Tengo experiencia en otros frameworks de Front-End, como Angular y VueJS, así que no estaré capacitandome totalmente de cero

### Base de datos

Para la base de datos se utilizó SQL Server.

El diseño del diagrama de la base de datos se realizó en [draw.io](https://app.diagrams.net)


## Proyecto Back-End

* El proyecto en Back-End está basado en .NET Core 8.0

* La arquitectura es una versión simplificada de D.D.D.

* Se usa la clase `DBConnection` para administrar las conexiones con la base de datos

* Los Repositories son las clases que uso para acceder a la base de datos. Se guardan las consultas SQL como constantes para que queden parametrizadas/preparadas y así evitar problemas de seguridad tales como **SQL Injection** (Tambien es una buena práctica el definir tipos de datos explicitos en el controlador y/o definir DTOs dedicados a recibir las peticiones)
  
* Los Domains son las clases que guardan la lógica del negocio. Se encargan de procesamiento de datos y se auxilian de los Repositories para almacenar la información en la base de datos.
  
* Los Controllers son los puntos de entrada al proyecto. Se definen sus endpoints y los verbos HTTP que son requeridos para usarlos además de realizar algunas validaciones a los parámetros que se espera que vengan del Front-End
  
* Se aplicó la inyección de dependencias para asegurar la escalabilidad, testeabilidad y mantenibilidad del proyecto (Aunque este proyecto no tendrá escalas a futuro, es importante recalcar que es una buena práctica)
  * Se decidió usar AddScoped para mantener la aplicación escalable. Pues por cada petición se crea una instancia de lo que se está solicitando, por scope. Este uso se recomienda, por ejemplo, para el contexto de la base de datos (`DBConnection`)
* Se agregaron test unitarios para asegurarse del correcto funcionamiento del endpoint creado. La decisión de agregarlos es netamente por seguir buenas prácticas, más no como requisito de la prueba
