# HowTo.Net.Keycloak

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_howto-dotnet-keycloak?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_howto-dotnet-keycloak?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/gasbrieo/howto-dotnet-keycloak?style=for-the-badge)

## Overview

**HowTo.Net.Keycloak** serves as a implementation of authentication and authorization using Keycloak in .NET.

## Features

- GitHub Actions Workflow

  - Static analysis with SonarCloud

- Basic .NET Project Structure
  - Authentication and Authorization using Keycloak
  - Swagger for testing authentication flow
  - Unit and Functional Tests

## Getting Started

### Prerequisites

- A [Keycloak](https://www.keycloak.org) instance.

### Setup

Update the `appsettings.json` Keycloak configurations:

```
 "Keycloak": {
     "AuthServerUrl": "http://localhost:18080",
     "Realm": "howto",
     "ClientId": "howtoclient"
 }
```

2. Run the application:
   
Open Swagger at http://localhost:5001/swagger to test authentication

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
