# Product Management System

## Live Preview [Go To Live Preview](https://productcatalog.runasp.net/)

## Overview
The **Product Management System** is a web-based application built using ASP.NET MVC. It allows administrators to manage products. 
## The project uses the **Unit of Work** and **Repository Pattern** for efficient data access and clean architecture.

---

## Features
- **Product Management**:
  - Add, Edit, Delete, and View Products.
  - Display all products ONLY FOR Admin
- **Product Browsing**:
  - Display product based on their availability duration FOR ALL Users.
  - Details Page for each product
  - Filter Products by category
- **Categories**:
  -  Products has category for search and filtering 
- **Role-Based Access**:
  - Admin-only access for product management.
- **Error Handling**:
  - Graceful handling of missing or invalid data with a "Not Found" page.
  - Graceful handling access not allowed resources with "Access Denied" page.
- **Responsive Design**:
  - Utilizes Bootstrap for a user-friendly interface.

---

## Technologies Used
- **Framework**: ASP.NET Core MVC (.net 8) 
- **Architecture**: Unit of Work and Repository Pattern
- **Database**: SQL Server with EF as ORM
- **Design**: Bootstrap 5
- **Authentication and Authorization**: ASP.NET Identity
