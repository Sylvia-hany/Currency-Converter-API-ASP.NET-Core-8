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


📂 5. Project Structure (Folders)

CurrencyConvertor/
│
├── Controllers/
│   └── CurrencyController.cs
│
├── Services/
│   ├── ICurrencyService.cs
│   ├── CurrencyService.cs
│   ├── IConversionHistoryService.cs 
│   ├── ConversionHistoryService.cs
│   ├── IExchangeRateService.cs
│   ├── ExchangeRateService.cs
│   └── Implementations...
│
├── Repository/
│   └── IConversionRepository.cs
│   └── ConversionRepository.cs
│   └── IGenericRepository.cs
│   └── GenericRepository.cs
│
├── Models/
│   └── Conversion.cs
│
├── Dto/
│   ├── ConvertRequestDto.cs
│   ├── ConvertResponseDto.cs
│   ├── ConversionHistoryDto.cs
│   └── HistoricalRatesDto.cs
│
├── Mapping/
│   └── MappingProfile.cs
│
└── appsettings.json


🧾 Test Scenarios

1️⃣ Convert Currency

Endpoint:
POST /api/exchange/convert

| # | Test Case             | Input Example                                   | Expected Result                              |
| - | --------------------- | ----------------------------------------------- | -------------------------------------------- |
| 1 | Valid Conversion      | `{ "from": "USD", "to": "EUR", "amount": 100 }` | Returns converted amount (e.g., 92.45 EUR)   |
| 2 | Invalid Currency Code | `{ "from": "XYZ", "to": "USD", "amount": 100 }` | Returns `400 Bad Request` with error message |
| 3 | Negative Amount       | `{ "from": "USD", "to": "EUR", "amount": -5 }`  | Returns `400 Bad Request`                    |



2️⃣ Get Supported Currencies

Endpoint:
GET /api/exchange/symbols

Description:
Retrieves a list of all supported currency codes and their names.

Test Cases:

| # | Test Case       | Input Example | Expected Result                               |
| - | --------------- | ------------- | --------------------------------------------- |
| 1 | Get All Symbols | –             | Returns JSON list of all supported currencies |
| 2 | Invalid Request | wrong URL     | Returns `404 Not Found`                       |


3️⃣ Get Historical Rates

Endpoint:
GET /api/exchange/historical?from=USD&to=EGP&days=7

Description:
Fetches historical exchange rates between two currencies for the last N days.

Test Case:

| # | Test Case            | Input Example            | Expected Result                          |
| - | -------------------- | ------------------------ | ---------------------------------------- |
| 1 | Valid Request        | `from=USD&to=EGP&days=7` | Returns 7-day rates in dictionary format |
| 2 | Missing Parameter    | `from=USD` only          | Returns `400 Bad Request`                |
| 3 | Invalid Days Value   | `days=-5`                | Returns `400 Bad Request`                |
| 4 | Unsupported Currency | `from=XXX&to=USD`        | Returns `400 Bad Request`                |




🧰 Tools Used

Postman → for API testing
Swagger UI → for interactive documentation























