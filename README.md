# PRUEBA SANA E-COMMERCE


- [PRUEBA SANA E-COMMERCE](#prueba-sana-e-commerce)
  - [Disclaimers y Aclaraciones](#disclaimers-y-aclaraciones)
    - [Base de datos](#base-de-datos)
    - [Proyecto Back-End](#proyecto-back-end)
  - [Instalación y Configuración](#instalación-y-configuración)
    - [Requisitos Previos](#requisitos-previos)
    - [Configuración](#configuración)

¡Hola!

En este archivo explicaré las cosas que hice, las que no hice y por qué no las hice.

Para empezar, no hice el apartado de Front-End porque no sé React.

En la entrevista inicial me recomendaron que dijera qué sabía y qué no sabía. Y si no sabía algo, era mejor aclararlo en vez de arriesgar y perder.

Sin embargo, estaré capacitandome en React mientras la prueba esté en revisión. Tengo experiencia en otros frameworks de Front-End, como Angular y VueJS, así que no estaré capacitandome totalmente de cero

## Disclaimers y Aclaraciones

### Base de datos

Para la base de datos se utilizó SQL Server.

El diseño del diagrama de la base de datos se realizó en [draw.io](https://app.diagrams.net)


### Proyecto Back-End

* El proyecto en Back-End está basado en .NET Core 8.0

* La arquitectura es una versión simplificada de D.D.D.

* Se usa la clase `DBConnection` para administrar las conexiones con la base de datos

* Los Repositories son las clases que uso para acceder a la base de datos. Se guardan las consultas SQL como constantes para que queden parametrizadas/preparadas y así evitar problemas de seguridad tales como **SQL Injection** (Tambien es una buena práctica el definir tipos de datos explicitos en el controlador y/o definir DTOs dedicados a recibir las peticiones)
  
* Los Domains son las clases que guardan la lógica del negocio. Se encargan de procesamiento de datos y se auxilian de los Repositories para almacenar la información en la base de datos.
  
* Los Controllers son los puntos de entrada al proyecto. Se definen sus endpoints y los verbos HTTP que son requeridos para usarlos además de realizar algunas validaciones a los parámetros que se espera que vengan del Front-End
  
* Se aplicó la inyección de dependencias para asegurar la escalabilidad, testeabilidad y mantenibilidad del proyecto (Aunque este proyecto no tendrá escalas a futuro, es importante recalcar que es una buena práctica)
  * Se decidió usar AddScoped para mantener la aplicación escalable. Pues por cada petición se crea una instancia de lo que se está solicitando, por scope. Este uso se recomienda, por ejemplo, para el contexto de la base de datos (`DBConnection`)
* Se agregaron test unitarios para asegurarse del correcto funcionamiento del endpoint creado. La decisión de agregarlos es netamente por seguir buenas prácticas, más no como requisito de la prueba

No se aplicaron metodologías de GitFlow debido a la complejidad del proyecto (Es muy baja como para implementarlo). Pero tengo claro que cuando se trabaja en una determinada funcionalidad:
1. Es necesario crear una rama a partir de la versión de desarrollo estable.
2. Realiza los cambios
3. Los subes a la nueva rama
4. Realizas merge de tu rama de desarrollo local con la rama de desarrollo que originalmente clonaste
5. De aquí en adelante puede variar, pero usualmente la rama de desarrollo la prueba QA y si es aprobada, se realiza Merge con la versión de producción o master
   
Eso solo un ejemplo de gitflow, depende de la metodología y de cada empresa ver qué se implementa. A lo que voy con esto es que, no implementé gitflow porque no lo consideré necesario, más no porque no sepa

## Instalación y Configuración

### Requisitos Previos

Es estrictamente necesario que tengas instalado lo siguiente:

- .NET SDK (versión 8.0)
- SQL Server (versión 2019 o superior)
- Visual Studio 2022 o Visual Studio Code

### Configuración

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/JuanRobles2164/SanaPrueba.git
   cd tu-carpeta-donde-clonaras

2. Configura la base de datos:

   * Ejecuta el script `Database/script.sql` para crear las tablas en SQL Server.
  
3. Configura la cadena de conexión:

   * Abre el archivo `Backend/WebApplication1/appsettings.json` y modifica la cadena de conexión:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=NombreDeTuBaseDeDatos;Trusted_Connection=True;"
    }
    ```
    _Puedes tambien agregarle a la cadena de conexión el atributo `TrustServerCertificate=true;` para que puedas conectarte localmente o en cualquier entorno de desarrollo sin problemas._

### Instalación y Ejecución

1. Abre una terminal y ejecuta en el proyecto:
   ```bash
   cd Backend
   dotnet restore
   dotnet run
   ```

¡Y listo! ya tendrías el proyecto ejecutandose
