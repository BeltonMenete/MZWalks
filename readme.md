# MZWalks API

A RESTful Web API built with **.NET 9**, originally based on the **NZWalks** course project. Renamed to **MZWalks** to reflect the Mozambican context.

## 🌍 Overview

MZWalks is an API for managing walks, regions, and difficulty levels in Mozambique. It demonstrates core Web API concepts such as:

- CRUD operations
- Entity Framework Core with SQL Server
- Repository pattern
- DTOs(contracts)
- JWT Authentication & Authorization
- Input validation

## 🔧 Tech Stack

- .NET 9
- Entity Framework Core
- SQL Server
- JWT Authentication
- ScalarUI&SwaggerUI (API documentation)

## 🚀 Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/BeltonMenete/MZWalks.git
   ```

2. **Configure the database**\
   Update the `appsettings.json` file with your local SQL Server connection string.

3. **Apply migrations** *(if needed)*

   ```bash
   dotnet ef database update
   ```

4. **Run the API**

   ```bash
   dotnet run
   ```

5. **Explore the API** Open your browser and navigate to your Scalar documentation URL (e.g.):

   ```
   https://localhost:{port}/scalar
   ```

## 📂 API Endpoints

- **Regions**: `/api/regions`
- **Walks**: `/api/walks`
- **Auth**: `/api/auth`

## ✍️ Notes

- This is a modified version of the NZWalks project by TechieEdi (or other course creator).
- All geographic references and naming have been adapted to Mozambique.

---

Feel free to contribute or extend the project!

