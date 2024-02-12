# CDN-WebAPI

This is a dummy project that consists of two projects:
- CDN_Web for the front end 
- CDN_WebAPI for the RESTful API.

## Features
This project contains basic CRUD operations for freelancers on Complete Developer Network (CDN), a fictional company. A freelancer(users) will have multiple skill sets or hobbies.

The system allows us to:

Users:
- List all users
- Add new user
- Edit existing info of a user
- Delete an existing user

Skill sets:
- List all skill sets of a user
- Add a skill set of a user
- Edit existing skill set of a user
- Delete all or one skill set of a user

Hobbies:
- List all hobbies of a user
- Add a hobby of a user
- Edit existing hobby of a user
- Delete all or one hobby of a user

## Requirement
Tools that are needed to run this project:

- .NET8 SDK
- Visual Studio 2022 (Support .NET8)
- MS SQL Server

## Project Setup 

### CDN_WebAPI Project
### Database Setup
In this project, we will use the Entity Framework Code First approach based on the models that have already been created. 

We will create a database inside our local and migrate sample data into the database to run this project. 

1. Open MS SQL Server and connect with your local server
2. Create an empty database under the Database tabs
3. Open Visual Studio 2022 and open Package Manager Console
4. Add migrations to create the database schema based on your entity classes
```bash
Add-Migration InitialCreate
```
5. Apply the migration to create the database
```bash
Update-Database
```
6. Migrate the sample data into the database through data seeding. Open the Terminal and run this 
```bash
cd CDN_WebAPI
```
7. Run this code inside the terminal to initiate the seeding.
```bash
dotnet run seeddata
```
8. Refresh the database inside MS SQL Server and the sample data will be available inside the database.
9. Run the project to test the API by using Swagger.

### CDN_Web Project
Run the project alongside with CDN_WebAPI project to ensure the project works fine.
