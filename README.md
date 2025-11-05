Currency Converter API (ASP.NET Core 8) 💱

📘 Project Description
Currency Converter API is a lightweight and efficient ASP.NET Core 8 Web API that allows users to convert amounts between different currencies using real-time exchange rates.
It automatically stores the last 10 conversions in a local SQLite database for quick reference.
This project follows clean architecture principles, focusing on maintainability, simplicity, and scalability.

🚀 Features
🔄Convert currencies — Get real-time conversion results between supported currencies.

💾 Store last 10 conversions — The system automatically keeps the last 10 conversions in the local database.

📊 Historical data (optional) — Retrieve exchange rates for the last 7 days.

🧹 Clean architecture — Organized structure with Models, Repositories, and Controllers.

🧠 Auto timestamps — CreatedAt handled automatically in BaseEntity.

📘 Swagger documentation — All API endpoints are documented and testable through Swagger UI.


🧰 Tech Stack

Backend: ASP.NET Core 8 Web API

Database: SQLite (via Entity Framework Core)

ORM: Entity Framework Core 8

Documentation: Swagger / OpenAPI

Language: C#

Architecture: Layered with Repository pattern

Tools: Visual Studio 2022 / Visual Studio Code

⚙️ Installation & Setup
1️⃣ Clone the repository
git clone https://github.com/Sylvia-hany/Currency-Converter-API-ASP.NET-Core-8.git

2️⃣Navigate to the project folder
cd Currency-Converter-API-ASP.NET-Core-8

3️⃣Install dependencies (NuGet packages)
Run these commands in your terminal or NuGet console:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
