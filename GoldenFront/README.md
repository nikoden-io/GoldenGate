# GoldenFront

## Description

This project is the frontend part of the Golden project. It is a web application that's realized for an Ephec high-school project.
Currently, the project is in exploration phase, mainly starting to design software architecture, analyze the requirements and discover the latest evolutions of Angular framework.

## Software architecture

The software architecture is based on clean architecture principles. Each feature is clearly separated from the others, and the business logic is isolated from the ui layer. Pragmatic choices are made, like relying on NgRx for state management and include it in the application layer, entities in domain layer are also tight to NgRx for another pragmatic reason, having access to NgRx adapters that created normalized entities (id/values dictionaries)

## Installation

1. Clone the repository
2. Run `npm install` to install the dependencies
3. Configure your own environments files in `src/environments/` (ex: `environment.ts` and `environment.production.ts`), also edit the `angular.json` file to mirror your own environments files
4. Run

```shell
npm start:xxx
``` 

to start the server in xxx mode where xxx is the name of your environment, for example

```sh 
  npm start:dev
```
