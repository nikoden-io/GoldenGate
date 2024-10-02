# Changelog - Domend


## Table of Contents

- [Unreleased](#unreleased)
- [Released](#released)
    - [v0.1.0 - 2024-30-09](#v010---2024-30-09)

## Unreleased
- Initial project configuration
  - Create empty dotnet 9.0 solution which contains:
    - **API** web api project 
      - Contain our main entry point and API main configurations
      - Contain all controllers, which contains our endpoints
    - **Domain** class library project
      - Contain our entities and repository interfaces
    - **Application** class library project
      - Contain our business logic 
    - **Infrastructure** class library project
      - Contain all services that are related to external APIs 
      - Contain database context
      - Implement repositories
  - Add 3rd-party libraries:
    - Project 'GoldenBack.API':
      - Asp.Versioning.Mvc                                   8.1.0
      - Microsoft.AspNetCore.OpenApi                         9.0.0-preview.6.24328.4
      - Microsoft.EntityFrameworkCore                        8.0.8 
      - Microsoft.EntityFrameworkCore.Design                 8.0.8     
      - Microsoft.EntityFrameworkCore.Tools                  8.0.8 
      - Microsoft.Extensions.Caching.StackExchangeRedis      8.0.8      
      - Microsoft.Extensions.Logging                         8.0.0                
      - Microsoft.Web.RedisSessionStateProvider              5.0.4                 
      - MongoDB.Driver                                       2.29.0           
      - MongoDB.EntityFrameworkCore                          8.1.1
    - Project 'GoldenBack.Domain'
      - MongoDB.Bson         2.29.0
    - Project 'GoldenBack.Infrastructure'
      - Microsoft.EntityFrameworkCore      8.0.8
      - Microsoft.Extensions.Logging       8.0.0   
      - MongoDB.Driver                     2.29.0  
      - MongoDB.EntityFrameworkCore        8.1.1
    - Project 'GoldenBack.Application'
      - AutoMapper                        13.0.1
      - Microsoft.Extensions.Logging      8.0.0
  - Configure **http session** and **Redis** to manage caching sessions on server or local development computer 
  - Configure database context using EntityFramework and MongoDB driver
    - Create **ApplicationDbContext** to manage rules and how entity framework interact with database
  - Create API versioning, currently *v1.0*
  - Create **DemoAtom** first entity implementation
    - Create **DemoAtom** entity
    - Create **DemoAtomController** 
      - Group all entity related endpoints
      - Wrap all endpoints result with **ApiResponse**
    - Create **DemoAtomAppService** and **IDemoAtomAppService** 
      - Application service that run all core business logic
      - Interface helps us in dependency injection for our clean architecture
    - Create **DemoAtomRepository** and **IDemoAtomRepository** 
      - Infrastructure repository that manages all database operations
      - Interface helps us in dependency injection for our clean architecture
        

## Released

### v0.1.0 - 2024-30-09

