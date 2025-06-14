# 🎵 Backend Application for a MusicStore

A lightweight and modular backend solution for a digital music store, designed using modern .NET practices.  
This project follows the CQRS pattern via MediatR and Entity Framework Core, enabling scalable and maintainable development of e-commerce-like functionality.

---

## 🧠 Features at a Glance

- 🎸 Manage music albums, genres, and artists
- 📦 Create and track orders
- 🔐 User authentication with JWT-based access and refresh tokens
- ⚙️ Clean architecture using CQRS with MediatR
- 🧪 Expandable structure for unit testing and integration testing
- 📁 EF Core code-first migrations

---

## 💻 Tech Stack

- **.NET (Core/6/7)** – backend framework  
- **C#** – main programming language  
- **Entity Framework Core** – ORM for database access  
- **MediatR** – CQRS pattern implementation  
- **SQL Server / LocalDB** – persistent storage  
- **ASP.NET MVC/Web API** – request routing & controllers

---

## ⚙️ Requirements

- .NET SDK 6.0 or newer  
- Visual Studio 2022+ or VS Code  
- SQL Server or LocalDB (or SQLite for local development)  
- Optional: Postman or Swagger for testing endpoints

---

## 🧱 Architecture: CQRS with MediatR

The application follows the **Command-Query Responsibility Segregation** principle:

- 🔹 `Commands` handle data modifications (e.g., create/update album)
- 🔹 `Queries` handle data retrieval
- 🔹 `Handlers` process these requests via **MediatR**, reducing controller complexity
- 🔹 Controllers are *thin*, only forwarding requests to the appropriate handlers

Directory structure:
```
Features/
├── Albums/
│   ├── Commands/
│   ├── Queries/
│   ├── Handlers/
│   └── Validators/
├── Authentication/
│   ├── Commands/
│   ├── Queries/
│   ├── Handlers/
│   └── Dtos/
```

---

## 📚 Functionalities

- Add / edit / delete albums
- Retrieve artist and album data
- Filter music by genre or artist
- Create and manage customer orders
- Authenticate users and generate JWT access + refresh tokens
- Database migrations using EF Core
- Command & Query validation with FluentValidation (optional)

---

## 🚧 Roadmap

- ✅ Implement JWT authentication with refresh token support
- 🧪 Implement xUnit/NUnit tests for CQRS handlers
- 🌐 Add Swagger for API documentation
- 🛠️ Add logging (Serilog or similar)
- 🧾 Role-based access control (Admin & User)

---

## 👤 Author

**Adam Wojciechowski “Wojownik20”**

GitHub: [@Wojownik20](https://github.com/Wojownik20)  
Shoutout to the project mentor **Mr Ivan**

Project created for educational purposes and as a backend architecture showcase.

