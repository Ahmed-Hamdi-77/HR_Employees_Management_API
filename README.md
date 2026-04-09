# 🏢 HR Employees Management API

A robust and scalable RESTful API built with **ASP.NET Core** for managing employees, departments, attendance, and leave requests within an organization. The system follows clean architecture principles and includes authentication & authorization using JWT.

---

## 🚀 Features

- 👨‍💼 **Employee Management** (CRUD)
- 🏢 **Department Management** (CRUD)
- ⏱️ **Attendance Tracking**
- 📝 **Leave Requests Management**
- ✅ **Manager & HR Approval Workflow**
- 🔐 **Authentication** using JWT
- 🔑 **Role-Based Authorization** (Admin / HR / Manager / Employee)
- 📦 **Clean Architecture** (Controller → Service → Repository)
- 🗄️ **SQL Server Integration** with Entity Framework Core
- 📑 **Swagger API Documentation**

---

## 🧱 Architecture

The project follows a **layered architecture**:
```
Controllers → Services → Repositories → DbContext → Database
```

### Layers:
- **Controllers**: Handle HTTP requests & responses
- **Services**: Business logic
- **Repositories**: Data access layer
- **Models / DTOs**: Data transfer between layers

---

## 🛠️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Swagger (OpenAPI)

---

## 🔐 Authentication & Authorization

The API uses **JWT (JSON Web Token)** for securing endpoints.

### Features:
- User Registration & Login
- Token-based authentication
- Role-based access control:
  - **Admin**
  - **HR**
  - **Manager**
  - **Employee**

---

## 📌 API Endpoints Overview

### 👨‍💼 Employees
- `GET /api/employees` - Get all employees
- `GET /api/employees/{id}` - Get employee by ID
- `POST /api/employees` - Create new employee
- `PUT /api/employees/{id}` - Update employee
- `DELETE /api/employees/{id}` - Delete employee

### 🏢 Departments
- `GET /api/departments` - Get all departments
- `GET /api/departments/{id}` - Get department by ID
- `POST /api/departments` - Create new department
- `PUT /api/departments/{id}` - Update department
- `DELETE /api/departments/{id}` - Delete department

### ⏱️ Attendance
- `GET /api/Attendances/AllByEmployee/{employeeId}` - Get employee attendances
- `GET /api/attendances/{id}` - Get attendance by ID
- `POST /api/attendances` - Record attendance
- `PUT /api/attendances/{id}` - Update attendance
- `DELETE /api/attendances/{id}` - Delete attendance

### 📝 Leave Requests
- `GET /api/leaveRequests/{employeeId}` - Get employee leave requests
- `GET /api/leaveRequests/ByLeaveId/{LeaveId}` - Get leave request by ID
- `POST /api/leaveRequests` - Create leave request
- `PUT /api/leaveRequests/{id}` - Update leave request

#### Leave Requests Approvals:
- `PUT /api/LeaveRequests/{leaveId}/Approve/Manager/{ManagerId}` - Manager approval
- `PUT /api/LeaveRequests/{leaveId}/Approve/Hr/{HrId}` - HR approval
- `PUT /api/LeaveRequests/{leaveId}/Reject/Manager/{ManagerId}` - Manager rejection
- `PUT /api/LeaveRequests/{leaveId}/Reject/Hr/{HrId}` - HR rejection

---

## ⚙️ Configuration

### 📌 appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HR_API_Proj;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  },
  "JWT": {
    "Key": "secret key will be added later",
    "Issuer": "HR_API",
    "Audience": "HR_API_Users"
  }
}
```

---

## ▶️ Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/your-username/hr-management-api.git
cd hr-management-api
```

### 2️⃣ Update Database
```bash
dotnet ef database update
```

### 3️⃣ Run the project
```bash
dotnet run
```

### 4️⃣ Open Swagger
```
https://localhost:{port}/swagger
```

---

## 🧪 Testing

You can test the API using:
- **Swagger UI**
- **Postman**

---

## 📌 Future Improvements

- 🔔 Notifications system
- 📊 Reports & Analytics
- 📱 Frontend integration (React)
- 📎 File attachments for leave requests

---

## 👨‍💻 Author

**Ahmed Hamdi**

- GitHub: [@Ahmed-Hamdi-77](https://github.com/Ahmed-Hamdi-77)
- LinkedIn: [ahmed-hamdi-dev](https://www.linkedin.com/in/ahmed-hamdi-dev)

---

## 📄 License

This project is for educational purposes and portfolio use.
