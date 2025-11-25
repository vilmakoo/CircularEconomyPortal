# Circular Economy Portal

This project is a self-service web portal designed for the management of waste bins, user profiles, and environmental feedback submission. It was developed as an assignment for a Full Stack Developer position.

## Tech Stack

* **Frontend:** React (TypeScript), Vite, Material UI
* **Backend:** .NET 8 Web API (C#), Kestrel
* **Database:** SQLite (Entity Framework Core)
* **Architecture:** REST API with a decoupled frontend, Docker Containerized

## How to Run the Application (Docker Compose)

This project is fully containerized for easy setup.

### Prerequisites

* Docker and Docker Compose must be installed 

### Execution Procedure

1. Navigate to the root directory of the project (`CircularEconomyPortal/`).

2. Execute the following command to build the necessary container images and initiate all services:
```bash
docker compose up --build
```

3. Upon successful startup, the application endpoints are accessible via a web browser:
  * Frontend Application: http://localhost:5173
  * Backend API (Swagger): http://localhost:5232/swagger

To terminate the application and remove the containers, input Ctrl+C in the terminal and then run:
```bash
docker compose down
```

## Design Choices & Assumptions

* Data Management: SQLite was selected for its ease of setup and portability. It requires no external server installation, making this demo easy to run on any machine.

* Architectural Pattern: A Service Layer (e.g., UserService) was implemented to enforce Separation of Concerns.

* Deployment Strategy: Docker Compose was used to simplify the build and runtime environment.

* Authentication: User authentication is simulated through the use of a hardcoded User ID (1) in the controllers, as per the assignment's instruction to skip full authentication setup.

* Frontend Framework: Vite was chosen for its rapid compilation speeds during development, and Material UI was used to ensure a clean design without writing custom CSS from scratch.

* Typing (TypeScript): Used on the frontend to improve code quality.

## AI Assistance

AI (Gemini) was used with the project as a supportive development tool and assistance provider. Gemini provided code snippets and helped with debugging the Docker environment. The final code and architectural choices were reviewed and understood manually.

## Time Spent On The Project

The estimated time spent on the project, including documentation and environment debugging, was approximately 3 to 4 hours.

## Optional Tasks

All mandatory tasks + Docker containerization and form validation (basic server-side check for empty feedback message) are completed.

The following optional features were skipped due to focusing on core requirements:

* Adding features to create and update waste bins.

* CI setup.
