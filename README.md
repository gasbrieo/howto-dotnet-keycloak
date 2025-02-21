# HowTo.NET.Keycloak

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_howto-dotnet-keycloak?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_howto-dotnet-keycloak?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/gasbrieo/howto-dotnet-keycloak?style=for-the-badge)
![GitHub Release](https://img.shields.io/github/v/release/gasbrieo/howto-dotnet-keycloak?style=for-the-badge)

## Overview

**HowTo.NET.Keycloak** serves as a step-by-step guide to integrating Keycloak authentication in .NET applications, including configuration, setup, and best practices.

## Features

- GitHub Actions Workflow

  - Static analysis with SonarCloud

- Basic .NET Project Structure
  - Authentication and Authorization using Keycloak
  - Swagger for testing authentication flow
  - Unit and Functional Tests

## Getting Started

### Prerequisites

Before setting up, ensure you have a running Keycloak instance. You can run Keycloak via Docker:

`docker run -d --name keycloak -p 18080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak start-dev`

### Setup

1. Login to Keycloak Admin Console:

Open `http://localhost:18080` and log in using the admin credentials.

2. Create a Realm:

- Navigate to `Realm Settings` > `Create Realm`
- Enter a name (e.g., `howto`) and click Save
- Go to `Realm Settings` > `Login`
- Enable User Registration

3. Create a Client:

- Go to `Clients` > `Create Client`
- Set Client ID to `howtoclient`
- Keep Client Authentication enabled
- Set Valid Redirect URIs to `http://localhost:5001/*`
- Set Web Origins to `http://localhost:5001`
- Click Save

4. Configure Audience Client Scope:

- Navigate to `Clients` > `howtoclient` > `Client Scopes` > `howtoclient-dedicated`
- Click on Add Mapper
- Select By Configuration
- Choose `Audience`
- Set Name as `audience`
- In Included Client Audience, select `howtoclient`
- Click Save

5. Configure Role Client Scope:

- Navigate to `Clients` > `howtoclient` > `Client Scopes` > `howtoclient-dedicated`
- Click on Add Mapper
- Select By Configuration
- Choose `User Client Roles`
- Set Name as `roles`
- In Client Id, select `howtoclient`
- Set Token Claim Name as `roles`

6. Start the .NET application:

- Ensure `appsettings.json` matches the Keycloak Host/Realm/Client:

```
 "Keycloak": {
     "AuthServerUrl": "http://localhost:18080",
     "Realm": "howto",
     "ClientId": "howtoclient"
 }
```

- Open Swagger at `http://localhost:5001/swagger`
- Click on Authorize
- In the form, enter:
  - Client ID: `howto-client`
  - Client Secret: Obtain from `Clients` > `howto-client` > `Credentials` > `Client Secret`
- Click Authorize, which will open the Keycloak login page.
- Create a new account if not registered, or log in with existing credentials.
- After logging in, Keycloak will redirect back to Swagger with the credentials saved.
- Test restricted endpoints with the Bearer token.

7. Configure Client Roles:

- Navigate to `Clients` > `howtoclient` > `Roles`
- Click on Create Role
- Set Name as `reader`
- Click Save
- Create another with name as `writer`

8. Link User to Role:

- Navigate to `Users` > `your user` > `Role Mapping`
- Click on Assigned role
- Choose one or both of the created roles
- Do the Swagger test again on the endpoints that are Role Based

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
