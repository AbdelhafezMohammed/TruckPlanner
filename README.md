# TruckPlanner


# How to run the solution:

 **Start backend using Dotnet CLI:**
 
 1- Navigate to the solution root folder
 
 2- Using Terminal or CMD run the command `dotnet restore` to retore nuget packages
 
 3- Navigate to backend\Webshop.API
 
 4- Using Terminal or CMD run the command `dotnet run`

 **Start backend using  Visual Studio:**
 
 1-Open the solution file using Visual Studio
 
 2-Build the solution that will automatically restore Nuget packages
 
 3-Run the project using F5 or from Solution Explorer right click on TruckPlan.API >Debug>Start New Instance


 **Start Database:**
 
 - using docker
   
   
 1- Navigate to the solution root folder
 
 2-  Using the terminal or cmd run command `docker compose up`
 
 
 -Local SQL Server
 
1- Install SQL server locally and set password for sql server `sa` user from `SqlServerConnectionString` in appsettings.json in TruckPlan.API


 **How to test:**
 
- Use your browser to open http://localhost:5150/swagger/index.html for API documentation and testing

- Use your browser to open http://localhost:5090 for front-end

# Technology stack

Backend: C#, Asp.Net WebAPI, Entity Framework Core, SQL Server

Frontend:  Blazor WebAssembly


# Tooling

VSCode, Visual Studio

MS SQL Server

Redis

Docker

Dotnet SDK V 8.0.202

Dotnet CLI


 

