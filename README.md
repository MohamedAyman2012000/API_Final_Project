#  Bug Tracking API

This is a Web API built with ASP.NET Core for managing users, projects, and bugs. It supports user authentication (JWT-based), role-based authorization, project/bug management, and attachment handling.

## Authentication & Authorization

- **Authentication**: JWT token is generated at login and must be included in the `Authorization` header as `Bearer <token>`.
- **Roles**:
  - `Developer`: Can add projects, bugs, and attachments.
  - `Manager`: Can view project and bug details, assign users, and manage attachments.

---

##  Endpoints

###  Users

#### `POST api/Users/Register`
Registers a new user.

- **Body**:
  ```json
  {
    "UserName": "MoAyman",
    "Email": "xx304@example.com",
    "PhoneNumber": "1234567890",
    "Password": "StrongPassword123!"
  }
  ```

#### `GET api/Users/Login`
Logs in a user and returns a JWT token.

- **Body**:
  ```json
  {
    "UserName": "johndoe",
    "Password": "StrongPassword123!"
  }
  ```

- **Returns**:  
  ```json
  {
    "token": "jwt-token",
    "expireDate": "2025-04-30T12:00:00"
  }
  ```

---

### Projects

> Requires Authorization

#### `GET api/Projects`
Returns a list of all projects.  
**Roles**: Any authenticated user.

#### `POST api/Projects`
Adds a new project.  
**Roles**: Developer only.

- **Body**:
  ```json
  {
    "Name":"ASP.Net MVC"
  }
  ```

#### `GET api/Projects/{id}`
Returns details of a specific project.  
**Roles**: Manager only.

---

### Bugs

> Requires Authorization

#### `GET api/Bugs`
Returns a list of all bugs.  
**Roles**: Any authenticated user.

#### `POST api/Bugs`
Adds a new bug.  
**Roles**: Developer only.

- **Body**:
  ```json
  {
    "Title": "Null Reference Exception",
    "Description": "This is Bug 1 Description",
    "ProjectID": 1
  }
  ```

#### `GET api/Bugs/{id}`
Returns details of a specific bug.  
**Roles**: Manager only.

---

### Bug Assignees

#### `POST api/Bugs/{id}/assignees`
Assigns a user to a bug.  
**Roles**: Developer only.

- **Body**:
  ```json
  {
        "UserId": "0d94e629-b882-4b78-b671-e81a0d604e2e"
  }
  ```

#### `DELETE api/Bugs/{id}/assignees/{userId}`
Removes a user from a bug.  
**Roles**: Manager only.

---

### Attachments

#### `GET api/Bugs/{id}/attachments`
Returns all attachments for a bug.  
**Roles**: Manager only.

#### `POST api/Bugs/{id}/attachments`
Adds a new attachment to a bug.  
**Roles**: Developer only.

- **Body**:
  ```json
  {
    "FileName": "screenshot.png",
    "bugId": 1,
    "FilePath": "base64string"
  }
  ```

#### `DELETE api/Bugs/{id}/attachments/{attachmentId}`
Deletes an attachment from a bug.  
**Roles**: Manager only.

---

## Testing & Headers

- Always include:
  ```http
  Authorization: Bearer {your-token}
  Content-Type: application/json
  ```

---

## Tech Stack

- ASP.NET Core Web API
- Identity + JWT for authentication
- Role-based authorization
- Entity Framework Core
- RESTful API principles
