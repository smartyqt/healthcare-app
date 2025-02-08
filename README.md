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
git clone <your-repo-url>
cd healthcare-app
