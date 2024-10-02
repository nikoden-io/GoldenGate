# Changelog - GoldenGate


## Table of Contents

- [Unreleased](#unreleased)
- [Released](#released)
  - [v0.3.0 - 2024-10-02](#v030---2024-10-02)
  - [v0.2.0 - 2024-28-09](#v020---2024-28-09)
  - [v0.1.0 - 2024-27-09](#v010---2024-27-09)

## Unreleased


## Released

### v0.3.0 - 2024-10-02

#### GoldenBack
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

### v0.2.0 - 2024-28-09

#### GoldenFront
- Development
  - Add **dev-server/server.js** to serve the 3 builds locally when checking localization
- Components management
  - Add **storybook** to manage components library
- Localisation / Internationalisation
  - Add **@angular/localize** for localisation / internationalisation
  - Create **src/locale** directory that contains all localisation files
    - Generate **messages.xlf** file using **ng extract-i18n** command or **yarn extract-i18n** script
    - Add **messages.en.xlf** for English language
    - Add **messages.fr.xlf** for French language
    - Add **messages.nl.xlf** for Dutch language
  - Test dummy translation in project html and ts files
- Package management
  - Remove **package-lock.json** file
  - Switch to **yarn** package manager
  - Add **yarn.lock** file

### v0.1.0 - 2024-27-09

#### GoldenFront
- Environment
  - Add 3 environments
    - **development** environment
    - **production** environment
    - **staging** environment
- Features
  - Create basic **messages** feature to design the software architecture
- Framework & 3rd-party libraries
  - Initial empty **Angular 18** project
  - Install and configure **NgRx** for state management
- Project structure
  - Create directories structure based on clean architecture principles
