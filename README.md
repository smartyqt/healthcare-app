# Healthcare App

## Overview
This is a healthcare-focused web application built using **.NET Core 6+ Web API**, **Angular 17+**, and **SQL Server**. The system allows users to securely log in, manage patients, and track healthcare recommendations such as allergy checks and screenings.

## Features
- **Authentication & Authorization**: Secure login with JWT-based authentication and role-based access control (Admin & Healthcare Professional).
- **Patient Management**: Search, filter, and view patients with pagination.
- **Recommendations**: Assign, track, and mark recommendations as completed.
- **Security Enhancements**: CSRF protection, secure headers, anti-XSS, and SQL Injection prevention.
- **Swagger API Documentation**: API follows RESTful principles with OpenAPI documentation.

---

## Setup Guide

### Prerequisites
Ensure you have the following installed:
- **.NET Core 6+ SDK**
- **Node.js 18+ & npm**
- **Angular CLI**
- **SQL Server**
- **Git**

### Clone the Repository
```sh
git clone https://github.com/smartyqt/healthcare-app.git
cd healthcare-app
```

## Backend Setup (.NET Core API)

### 1. Navigate to the backend folder:
```sh
cd backend
```

### 2. Restore dependencies:
```sh 
dotnet restore
```

### 3. Configure the database connection in appsettings.json:
#### **Finding Your SQL Server Name**
If you're using **SQL Server locally**, follow these steps to find your server name:
1. Open **SQL Server Management Studio (SSMS)**.
2. On the **login screen**, look at the **"Server name"** field.
3. Copy the **full name** (e.g., `DESKTOP-XXXXXXX\SQLEXPRESS` or `localhost`).

#### **Updating the Connection String**
Once you have your server name, open **`backend/appsettings.json`** and update:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=HealthcareDB;Trusted_Connection=True;"
}
```
> Replace `YOUR_SERVER_NAME` with your actual SQL Server name.

### 4. Apply database migrations:
```sh
dotnet ef database update
```
> If `dotnet ef` is not installed, install it using:
> ```sh
> dotnet tool install --global dotnet-ef
> ```

### 5. Run the API:
```sh
dotnet run
```
The backend should now be running at:
```
http://localhost:5085
```

### 6. Verify API is Running:
- Open your browser and go to:
  ```
  http://localhost:5085/swagger/index.html
  ```
- If you see the **Swagger UI**, the API is working correctly.

---

## Frontend Setup (Angular 17+)

### 1. Navigate to the frontend folder:
```sh
cd frontend
```

### 2. Install dependencies:
```sh
npm install
```

### 3. Start the Angular development server:
```sh
ng serve --host 0.0.0.0 --port 4200
```

### 4. Open the app in the browser:
```
http://localhost:4200
```

---

## Architecture Overview
### Technologies Used
- **Backend**: ASP.NET Core 6+, Entity Framework Core, JWT Authentication
- **Frontend**: Angular 17+, Angular Material, SCSS
- **Database**: SQL Server
- **Deployment**: Docker support (optional)

### System Flow
1. **User Authentication**
   - Login with JWT-based authentication.
   - CSRF protection and secure headers applied.
2. **Patient Management**
   - Fetch, search, and paginate through patient records.
   - Add and edit patient details securely.
3. **Recommendations System**
   - View patient-specific recommendations.
   - Mark recommendations as completed.
4. **Role-Based Access Control**
   - Admin can manage all data.
   - Healthcare professionals have restricted access to relevant sections.

---

## API Documentation (Swagger/OpenAPI)
Once the backend is running, visit:
```
http://localhost:5085/swagger/index.html
```

### Sample Endpoints
#### Authentication
- **Login**: `POST /api/auth/login`
```json
{
   "username": "admin",
   "password": "password"
}
```
#### Patients
- **Get Patients**: `GET /api/patients`
- **Add Patient**: `POST /api/patients`
```json
{
   "name": "John Doe",
   "dateOfBirth": "1990-05-10",
   "gender": "Male",
   "contactInfo": "123-456-7890"
}
```
#### Recommendations
- **Get Recommendations for Patient**: `GET /api/recommendations/patient/{patientId}`
- **Mark Recommendation as Completed**: `PUT /api/recommendations/{id}/complete`

---

## Security Best Practices Implemented
- **CSRF Protection**: Enforced using AntiForgery Tokens.
- **XSS Protection**: Input validation and Angular’s built-in sanitization.
- **SQL Injection Prevention**: Using parameterized queries in Entity Framework.
- **Secure Headers**: Applied Content Security Policy (CSP), HSTS, and Referrer-Policy.

---

## Deployment
### Docker Support (Optional)
To run the project in a containerized environment:
1. **Build & Run Backend**
   ```sh
   docker build -t healthcare-api ./backend
   docker run -p 5085:80 healthcare-api
   ```
2. **Build & Run Frontend**
   ```sh
   docker build -t healthcare-frontend ./frontend
   docker run -p 4200:80 healthcare-frontend
   ```

---

## Author
*Alexander Rusin*

---

## License
MIT License
