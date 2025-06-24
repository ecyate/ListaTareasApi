# TareasApi

Una API REST construida en .NET para gestionar tareas personales con autenticación mediante JWT y persistencia de datos en MongoDB Atlas.

---

## 🧱 Estructura del Proyecto

## 🧱 Estructura del Proyecto

- **Application/**
  - Repositories/
    - ITareaRepository.cs
    - IUsuarioRepository.cs
  - Services/
    - TareaService.cs
    - UsuarioService.cs
- **Domain/**
  - Entities/
    - Tarea.cs
    - Usuario.cs
- **Infrastructure/**
  - Data/
    - MongoDbContext.cs
    - TareaRepository.cs
    - UsuarioRepository.cs
- **Presentation/**
  - Controllers/
    - TareaController.cs
    - UsuarioController.cs
- **Security/**
  - JwtGenerator.cs
- Program.cs
- appSettings.json
- .gitignore
- README.md


---

## 🔐 Autenticación

Esta API implementa autenticación JWT manualmente, sin usar inyección de dependencias.

- El token se genera en `UsuarioController.cs` mediante la clase `JwtGenerator`.
- Las claves y configuración están centralizadas en `appSettings.json`.

---

## ⚙️ Configuración

### appSettings.json

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://<usuario>:<contraseña>@cluster0.mongodb.net/?retryWrites=true&w=majority",
    "DatabaseName": "TaskAppDb"
  },
  "JwtSettings": {
    "Key": "clave_super_super_secreta_para_jwt",
    "Issuer": "TareasApi",
    "Audience": "TareasApiUsers"
  }
}
 Endpoints principales
Autenticación
POST /api/Usuario/registrar
Registra un nuevo usuario.

POST /api/Usuario/login
Devuelve un token JWT válido.

Tareas

GET /api/Tarea/{usuarioId}
Devuelve todas las tareas de un usuario.

POST /api/Tarea
Crea una nueva tarea.

DELETE /api/Tarea/{id}
Elimina una tarea.

🛠️ Tecnologías Usadas
.NET 9

MongoDB Atlas

JWT (JSON Web Tokens)

Postman (para pruebas)

Visual Studio / Visual Studio Code

Notas
Las contraseñas se almacenan como hash SHA256.

MongoDB almacena los datos de Usuario y Tarea en colecciones separadas.

El proyecto sigue una arquitectura por capas básica sin inyección de dependencias para mayor simplicidad.
