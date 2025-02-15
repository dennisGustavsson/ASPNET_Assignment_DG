# EcomWebApp

## Overview
EcomWebApp is a ASP.NET Core MVC e-commerce web application built on .NET 9.0. The application allows users to browse products, register accounts, and manage their shopping carts. It also includes an admin interface for managing products and user accounts.

## Features
- User Registration and Authentication
- Product Management
- Shopping Cart
- Contact Form
- Admin Interface

## Technologies Used
- .NET 9.0
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft Identity
- FluentResults

## Project Structure
- **EcomWebApp.csproj**: Project file containing package references and build configurations.
- **Views**: Contains Razor views for different parts of the application.
  - **ProductsManager**: Views for managing products.
  - **Partials**: Partial views used across the application.
  - **Register**: Views for user registration.
  - **Admin**: Views for admin functionalities.
  - **Products**: Views for displaying product details.
- **ViewModels**: Contains view models used in the application.
- **Models**: Contains entity and identity models.

## Setup Instructions
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Update the database connection string in `appsettings.json`.
5. Run the application.

## Dependencies
- FluentResults (3.16.0)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (9.0.0)
- Microsoft.AspNetCore.Identity.UI (9.0.0)
- Microsoft.EntityFrameworkCore (9.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (9.0.0)
- Microsoft.EntityFrameworkCore.Tools (9.0.0)

## License
This project is licensed under the MIT License.
![Skärmbild 2025-02-15 114121](https://github.com/user-attachments/assets/5f6c6c02-1e2a-4341-9ac2-ec3c00fa4aae)
