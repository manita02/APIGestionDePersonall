<h1 align="center">🏢API Gestión del Personal🧑‍💼</h1>
<section align="center">
  <img src="https://imgfz.com/i/R72Wx16.png" alt="api">
</section>
<section align="center">
  <img src="https://img.shields.io/badge/STATE-FINISHED-green" alt="Estado del Proyecto">
</section>


# Índice
- [Sobre API Gestión del Personal :post_office::man_office_worker:](#sobre-api-gestión-del-personal-post_officeman_office_worker)

- [Programas necesarios :memo:](#white_check_mark-programas-necesariosmemo)

- [Descargar proyecto :inbox_tray:](#white_check_mark-descargar-proyectoinbox_tray)

- [Ejecutar el proyecto :rocket:](#white_check_mark-ejecutar-el-proyectorocket)

- [Tecnologías utilizadas :hammer:](#tecnologías-utilizadas-hammer)

- [Autores :black_nib:](#autores-black_nib)


## Sobre API Gestión del Personal :post_office::man_office_worker:
<p align="justify">
Prueba técnica🔧 realizada para la empresa BeProactive para el puesto de trabajo <i>Programador Full Stack Sr, Ssr</i>. La práctica consistía en lo siguiente: 

<br><i><b>Situación</b></i>
<br>Una empresa necesita un servicio en el que pueda realizar la gestión del personal. Éste debe permitirle a los usuarios la opción de consultar, crear, modificar y borrar usuarios mediante diferentes endpoints. 
Actualmente cuentan con una API para leer información y crear nuevos usuarios. 

<i><b>Configuración técnica del servicio</b></i></p>
<ul>
    <li>.NET 8</li>
    <a href="https://github.com/praeclarum/sqlite-net/wiki/Getting-Started" target="_blank"><li>SQLite</li></a>
    <a href="https://serilog.net/" target="_blank"><li>Serilog</li></a>
    <li>Swagger</li>
</ul>

<p align="justify">
<i><b>Tareas a desarrollar</b></p></i>
<ul>
    <li>Separar la lógica del controlador</li>
    <li>Crear los endpoint necesarios para realizar CRUD de usuarios</li>
    <li>Utilizar el patrón Options para configurar, por ejemplo, la cadena de conexión a la base de datos</li>
    <li>Implementar manejo de excepciones en, al menos, un método; que además realice logs con detalles acerca de un eventual error</li>
    <li>Documentar cada endpoint</li>
</ul>

## :white_check_mark: `Programas necesarios`:memo:
- Descargar e Instalar :arrow_down_small: 
  - <a href="https://dotnet.microsoft.com/es-es/download/visual-studio-sdks" target="_blank">.NET 8</a> 
  - <a href="https://visualstudio.microsoft.com/es/" target="_blank"> 
        Visual Studio Code
    </a> 
- Verificar si el SDK .NET 8 se instaló correctamente✅:
  - Abrir una terminal y ejecutar el siguiente comando:
    ```bash
    dotnet --version
    ```

### :white_check_mark: `Descargar proyecto`:inbox_tray:
- [Download](https://github.com/manita02/APIGestionDePersonall/archive/refs/heads/main.zip):anger: 


### :white_check_mark: `Ejecutar el proyecto`:rocket:
- Descomprimir el archivo .ZIP🤐 descargado anteriormente. 
- Abrir la carpeta descomprimida📁 con Visual Studio Code
- Abrir una nueva <a href="https://damiandeluca.com.ar/como-usar-la-terminal-integrada-de-visual-studio-code" target="_blank">terminal💾</a> y ejecutar los siguientes comandos: 
  - Restaurar paquetes📦: 
    ```bash
    dotnet restore
    ```
  - Verificar que el proyecto se compile correctamente✔️:
    ```bash
    dotnet build
    ```
  - Ejecutar el proyecto♻️:
    ```bash
    dotnet run
    ```
    <section align="center">
    <img src="https://imgfz.com/i/8m2dDLh.png" alt="run">
    </section>
  - Copiar el enlace generado🔗, pegarlo en el buscador🔎 de su navegador de Internet🌐, y añadirle <b><i> /swagger </i></b> 
    ```bash
    http://localhost:5035/swagger
    ```
  - De esta forma podremos interactuar con cada uno de los endpoints🟢: 
    <section align="center">
    <img src="https://imgfz.com/i/iDFcC5Z.png" alt="endpoints">
    </section>


## Tecnologías utilizadas :hammer:
<section align="center">
<a href="https://learn.microsoft.com/es-es/dotnet/csharp/tour-of-csharp/" target="_blank"> <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/bd/Logo_C_sharp.svg/1200px-Logo_C_sharp.svg.png" alt="c#" width="70" height="80"/> </a> 🗯️
<a href="https://dotnet.microsoft.com/es-es/learn/dotnet/what-is-dotnet" target="_blank"> <img class="img" src="https://seeklogo.com/images/1/net-logo-681E247422-seeklogo.com.png" alt=".net" width="80" height="80"/> </a> 🗯️
<a href="https://swagger.io/" target="_blank"> <img class="img" src="https://upload.wikimedia.org/wikipedia/commons/a/ab/Swagger-logo.png" alt="swagger" width="80" height="80"/> </a> 🗯️
<a href="https://code.visualstudio.com/" target="_blank"> <img class="img" src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Visual_Studio_Code_1.35_icon.svg/2048px-Visual_Studio_Code_1.35_icon.svg.png" alt="vscode" width="80" height="80"/> </a>
</section>

## Autores :black_nib:
| [<img src="https://avatars.githubusercontent.com/u/70881992?v=4" width=115><br><sub>ezequiel1409</sub>](https://github.com/ezequiel1409) | [<img src="https://i.pinimg.com/564x/52/8b/e2/528be26d9ee3c751a3c6e070598f9034.jpg" width=115><br><sub>Ana Lucia Juarez</sub>](https://github.com/manita02) | 
| :---: | :---: |
