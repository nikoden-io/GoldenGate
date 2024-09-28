- [Unreleased](#unreleased)
- [Released](#released)
  - [v0.2.0 - 2024-28-09](#v020---2024-28-09)
  - [v0.1.0 - 2024-27-09](#v010---2024-27-09)

## [Unreleased]

## [Released]

### [v0.2.0 - 2024-28-09]

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

### [v0.1.0 - 2024-27-09]

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
