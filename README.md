# GoldenGate
>GoldenGate is a full-stack application developed as an educational project to demonstrate the implementation of clean architecture principles in both frontend and backend development. The project consists of a backend API built with .NET 9.0 and a frontend application developed using Angular 18.

## Table of Contents

- [Introduction](#introduction)
- [Tech Stack](#tech-stack)
- [Backend (GoldenBack)](#backend-goldenback)
- [Frontend (GoldenFront)](#frontend-goldenfront)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
- [Changelog](#changelog)
- [Notes](#notes)

## Introduction

GoldenGate aims to provide a robust and scalable application by leveraging modern technologies and best practices in software development. The project emphasizes clean architecture to ensure separation of concerns, maintainability, and testability across the application layers.

## Tech Stack

### Backend (GoldenBack)

#### Language & Framework: 
- C# with .NET 9.0  
#### Software Architecture Principles: 
- Clean Architecture  
#### API Versioning: 
- ASP.NET Core API Versioning (currently v1.0)  
#### Database: 
- MongoDB  
#### Object-Relational Mapping (ORM): 
- Entity Framework Core with MongoDB provider  
#### Caching & Session Management: 
- Redis and HTTP sessions  
#### Logging: 
- Microsoft.Extensions.Logging  
#### Dependencies:
- Asp.Versioning.Mvc for API versioning
- Microsoft.EntityFrameworkCore for ORM capabilities
- MongoDB.Driver and MongoDB.EntityFrameworkCore for MongoDB integration
- AutoMapper for object-object mapping
- Microsoft.Extensions.Caching.StackExchangeRedis for Redis caching
- Microsoft.Web.RedisSessionStateProvider for session state management

### Frontend (GoldenFront)

#### Framework: 
- Angular 18
##### State Management: 
- NgRx
##### Component Library: 
- Storybook
##### Localization/Internationalization: 
- @angular/localize
##### Development Server: 
- Custom Node.js server for serving multiple builds locally
##### Dependencies:
- Angular CLI for project scaffolding and development
- @ngrx/store for reactive state management
- @storybook/angular for isolated component development
- Additional packages for localization and environment management

## Project Structure

### Backend Structure
>The backend solution is organized into separate projects to enforce clean architecture principles:

#### GoldenBack.API
- Entry point of the backend application
- Contains API configurations and controllers
- Manages endpoint routing and middleware setup

#### GoldenBack.Domain
- Defines core business entities and domain models
- Contains repository interfaces for data access abstraction

#### GoldenBack.Application
- Implements business logic and application services
- Contains DTOs (Data Transfer Objects) and mappings
- Utilizes AutoMapper for object transformations

#### GoldenBack.Infrastructure
- Provides implementations for repository interfaces
- Contains the database context (ApplicationDbContext)
- Manages external services and integrations

### Frontend Structure
>The frontend application follows a modular structure for scalability and maintainability:

#### src/app~~
- Contains feature modules, components, services, and routing configurations
- Implements the main application logic and UI components

### src/locale
- Houses localization files for internationalization support
- Includes translation files such as messages.en.xlf, messages.fr.xlf, and messages.nl.xlf

### dev-server
- Custom development server script (server.js) for serving multiple builds
- Facilitates testing of different localization configurations locally

## Getting Started

### Prerequisites

#### Backend:
- .NET 9.0 SDK
- MongoDB server
- Redis server (for caching and session management)

#### Frontend:
- Node.js (version compatible with Angular 18)
- Yarn package manager
- Angular CLI

### Backend Setup

#### Clone the Repository:
```sh
git clone https://github.com/nikoden-io/GoldenGate.git
```
#### Navigate to the Backend Directory:
```sh
cd GoldenGate/GoldenBack
```
#### Restore NuGet Packages:
```sh
dotnet restore
```
#### Update Configuration:
- Modify *appsettings.json* with your MongoDB and Redis connection strings.
- Ensure the MongoSettings section includes your database configuration.
#### Run the Application:
```sh
dotnet run
```
#### Access the API:
- The API will be accessible at http://localhost:5166/v1.0/

### Frontend Setup

#### Navigate to the Frontend Directory:
```sh
cd GoldenGate/GoldenFront
```
#### Install Dependencies:
```sh
yarn install
```
#### Run the Development Server:
```shell
yarn start
```
#### Access the Application:
- The frontend application will be running at http://localhost:4200
#### Localization:
- To extract translation files, use:
```sh
yarn extract-i18n
```
- Translations can be managed in the src/locale directory.
#### Using Storybook:
- To start Storybook for component development:
```sh
yarn storybook
```

## Changelog
- For detailed information about updates and changes, please refer to the **CHANGELOG.md** file.

## Notes
- Educational Purpose: This project is developed for educational purposes to demonstrate full-stack application development using modern technologies and architectural patterns.
- No External Contributions: As this is a school project, external contributions are not being accepted.
- Clean Architecture with pragmatic choices: Emphasis has been placed on clean architecture to ensure the separation of concerns, making the codebase maintainable and scalable, pragmatic choices are made to scale principles to the project size.
- By following the instructions in this README, you should be able to set up and run both the backend and frontend applications successfully. The project showcases the integration of various technologies and serves as a practical example of implementing clean architecture in a full-stack application.
