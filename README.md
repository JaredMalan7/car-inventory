# Introduction 
Group Member Names:
Jared Malan
Nate Hathaway
Stephen Port 
Gavin Holway


# CarInventory – Blazor Server Application

## Overview

**CarInventory** is a Blazor Server web application built with ASP.NET Core and Entity Framework Core.  
The application allows an administrator to manage a list of cars, including adding, editing, deleting, searching, and viewing car details.

Authentication is intentionally simple and designed for **demo purposes only**.

---

## Technologies Used

- ASP.NET Core
- Blazor Server
- Entity Framework Core
- SQLite
- Bootstrap (for styling)

---

## Features

- Admin login system
- View car inventory
- Add new cars
- Edit existing cars
- Delete cars
- Search cars by make or model
- Upload and display car images
- Restrict inventory access to logged-in users only

---

## Login Information (Demo)

This project uses a **pre-seeded admin user** for demonstration purposes.

**Username:** `superadmin`  
**Password:** `admin123`

⚠️ **Note:** Passwords are stored in plain text for demo simplicity.  
This is **not secure** and should never be done in a production application.

---

## How to Run the Application

### Prerequisites

- .NET 7 or newer
- SQLite (handled automatically by the application)
- Visual Studio or VS Code (recommended)

### Steps

1. Clone or download the project
2. Open a terminal in the project root
3. Run the application:

```bash
dotnet run
```
---
## How to Use the Application

### Login
- Click **Login** in the navigation menu
- Enter the admin credentials
- On successful login, you will be redirected to the **Inventory** page

### Inventory Page
- View all cars in the system
- Use the search bar to filter cars by make or model
- Click **Add New Car** to create a new entry
- Use **Edit** to update a car
- Use **Delete** to remove a car

### Images
- When adding or editing a car, an image can be uploaded
- Uploaded images are stored in `wwwroot/images`
- If no image is available, a placeholder message is shown

### Logout
- Click **Logout** to end the session
- Inventory access will be restricted after logout


## Limitations
- Authentication is session-based and stored in memory
- No password hashing
- No role management beyond admin access
- Intended strictly for educational/demo purposes

## Future Improvements
- Password hashing and secure authentication
- Role-based authorization
- Persistent login using cookies or authentication state
- Improved validation and error handling
- Pagination for large inventories