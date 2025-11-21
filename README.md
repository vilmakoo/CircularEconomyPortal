# Circular Economy Portal

This document describes the implementation of a self-service web portal designed for the management of waste bins, user profiles, and environmental feedback submission. This project was developed as an assignment for a Full Stack Developer position

## Tech Stack

* **Frontend:** React (TypeScript), Vite, Material UI
* **Backend:** .NET 8 Web API (C#)
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
  * Backend API Documentation (Swagger): http://localhost:5232/swagger

To terminate the application and remove the containers, input Ctrl+C in the terminal and then run:
```bash
docker compose down
```

## Design Choices & Assumptions

* Data Management: SQLite was selected for its ease of setup and portability. It requires no external server installation, making this demo easy to run on any machine.

* Architectural Pattern: A Service Layer (e.g., UserService) was established to decouple business logic from API controllers, resulting in cleaner code and a structure conducive to future extensibility.

* Deployment Strategy: Docker Compose was used to simplify the build and runtime environment

* Authentication: For the scope of this demonstration, user authentication is simulated through the use of a hardcoded User ID (1).

* Frontend Framework: Vite was chosen for its rapid compilation speeds during development, and Material UI was used to ensure a clean, accessible, and responsive design without writing custom CSS from scratch.

## AI Assistance

Used AI (Gemini) with the project as a supportive development tool and assistance provider.