# RNR
# Breakdown Create Application

This document provides a comprehensive guide for setting up and running the Breakdown Create Application, which includes an ASP.NET Core backend and a React frontend.

## Prerequisites

Before you begin, ensure you have the following installed:
- Node.js: Necessary for running the frontend. Download from [Node.js official website](https://nodejs.org/).
- .NET 5.0 SDK or later: Required for the backend. Available on the [.NET official website](https://dotnet.microsoft.com/download).
- SQL Server: Or any EF Core supported database for backend data storage.

## Project Setup

### Clone the Repository (RNRAPP1{ASP.NET} and rnrview{React}) 

Note: The poject is in two separated Repositories for frontend and backend code separated and it is required to run both projects.

Start by cloning the repository to get the project code:

```bash
git clone [repository-url]  # Replace [repository-url] with your repository's URL.
```
Install Backend Dependencies
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.11
dotnet add package Newtonsoft.Json --version 13.0.3
dotnet add package Swashbuckle.AspNetCore --version 6.2.3

Additional Note
Swagger Integration: The use of Swagger in this setup provides a UI for interacting with the API, making it easier to test and document the API endpoints. Swagger UI is accessible when the app is running in development mode, typically at the /swagger endpoint.


Install React Dependencies
npm install @testing-library/jest-dom@^5.17.0 
@testing-library/react@^13.4.0 
@testing-library/user-event@^13.5.0 
axios@^1.7.7 react@^18.3.1 
react-datepicker@^7.5.0 r
eact-dom@^18.3.1 
react-router-dom@^6.27.0 
react-scripts@5.0.1 
web-vitals

Run the React application:
npm start

To add a new migration, use the following command in the Package Manager Console.
PM> Add-Migration MigrationName
PM> update-database
