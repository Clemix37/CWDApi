# 🧠 CWD API — Tasks, Notes & Habits Management API

> A modular and modern REST API built with **.NET Core**, **Entity Framework Core**, and **PostgreSQL**.  
> Designed to demonstrate clean architecture, code reusability, and production-grade patterns for real-world applications.

---

## 🚀 Overview

**CWD API** is a personal yet extensible project combining:
- 🗒 **Notes**
- ✅ **Tasks**
- 🔁 **Habits**

Each resource is handled through a **generic service and repository architecture**, providing:
- DRY (Don’t Repeat Yourself) principles
- Easy scalability
- Consistent CRUD operations
- Maintainability and flexibility

---

## 🧩 Key features

- **.NET Core 8** API following RESTful standards  
- **Entity Framework Core + PostgreSQL** for modern relational persistence  
- **Generic Repository & Service pattern** to minimize boilerplate  
- **Automapper** integration for clean DTO mapping  
- **Dependency Injection (DI)** and **Interface-based abstraction**  
- **Swagger UI** for documentation and live API testing  
- **Ready for deployment** (Docker, Railway, Render, or Azure)

---

## 🏗 Architecture overview

CWD.API/  
├── Controllers/  
│ ├── HabitController.cs  
│ ├── NotesController.cs  
│ └── TasksController.cs  
├── Data/  
│ └── ApiContext.cs  
├── Dtos/  
│ ├── HabitDto.cs  
│ ├── NoteDto.cs  
│ └── TaskDto.cs  
├── Entities/  
│ └── Habit.cs  
│ └── Note.cs  
│ └── TaskItem.cs  
├── Migrations/  
├── Services/  
│ ├── GenericService.cs  
│ ├── HabitService.cs  
│ ├── NoteService.cs  
│ ├── TaskService.cs  
├── Repositories/  
│ ├── GenericRepository.cs  
│ ├── HabitRepository.cs  
│ ├── NoteRepository.cs  
│ ├── TaskRepository.cs  
├── Program.cs  
└── appsettings.json  

**Principles applied:**
- Separation of Concerns (SoC)
- Single Responsibility Principle (SRP)
- Interface-driven design
- Testable and loosely coupled components

---

## ⚙ Installation & Setup

### 1. Clone the repository
```bash
git clone https://github.com/Clemix37/cwd-api.git
cd cwd-api
```

 ### 2. Configure the environment
 Edit `appsettings.json`

 ```C#
"ConnectionStrings": {
  "DefautlConnection": "",
}
```

### 3. Run database migrations
```bash
dotnet ef database update
```

### 4. Get AutoMapper API License
Go to [AutoMapper website](https://automapper.io/) and get a license.  
You can add it on Program.cs:
```C#
 [...]cfg.LicenseKey = "YOUR-LICENSE"
```

### 5. Run the API
```bash
dotnet run
```

The API will be available at [http://localhost:500](http://localhost:500).

## 📘 Documentation

Swagger is integrated by default and available at: [http://localhost:5000/swagger](http://localhost:5000/swagger).  
You can test every endpoint direclty from the UI.
