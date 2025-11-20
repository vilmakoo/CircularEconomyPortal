# Circular Economy Portal

A self-service portal for managing waste bins, user profiles, and feedback. Built as an assignment for a Full Stack Developer position.

## Tech Stack

* **Frontend:** React (TypeScript), Vite, Material UI
* **Backend:** .NET 8 Web API (C#)
* **Database:** SQLite (Entity Framework Core)
* **Architecture:** REST API with a decoupled frontend

## How to Run the Application

### Prerequisites

* .NET SDK 8.0
* Node.js & npm

### 1. Start the Backend

The backend handles the database and API logic.
```bash
cd backend/CircularPortal.API
dotnet restore
dotnet run
```
The API will listen on http://localhost:5234 (or similar). Swagger UI is available at `/swagger`.

### 2. Start the Frontend

Open a new terminal to run the React interface.
```bash
cd frontend
npm install
npm run dev
```
Navigate on your browser to http://localhost:5173 to use the app.

## Design Choices & Assumptions

* Database: Used SQLite for simplicity and portability. It requires no external server installation, making this demo easy to run on any machine.

* Authentication: Per the requirements, authentication is simulated. The app assumes the current user has ID = 1.

* Frontend Tooling: Used Vite instead of Create-React-App for faster build times and better TypeScript support.

* Styling: Used Material UI to ensure a clean, accessible, and responsive design without writing custom CSS from scratch.

## AI Assistance

Used AI (Gemini) with the project.