# 🎨 ArtStore - Modern E-Commerce Platform (.NET 9)

> A full-stack, cloud-native ready e-commerce solution for selling art prints. Built with cutting-edge .NET technologies, Clean Architecture, and a modular design.

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![Blazor](https://img.shields.io/badge/Blazor-WASM-purple)
![Status](https://img.shields.io/badge/status-active-success)

## 🚀 Overview

**ArtStore** demonstrates how to build a scalable, maintainable enterprise application using the latest Microsoft stack. It features a decoupled backend API implementing **CQRS** pattern and a responsive **Blazor WebAssembly** frontend with **MudBlazor** UI components.

The system handles product catalog management, user authentication (JWT), shopping cart logic with database persistence, and order processing simulation.

---

## ✨ Key Features

### 🛒 Shopping Experience
- **Dynamic Catalog:** Filter artwork by Category (Living, Stationary), Price range, and Frame type.
- **Product Details:** High-quality image zoom, artist bio, and related works.
- **Persistent Cart:** Shopping cart items are stored in the database, allowing users to switch devices without losing data.
- **Search & Filtering:** Advanced server-side filtering logic.

### 🔐 User & Security
- **Registration & Login:** Secure identity system with hashed passwords.
- **Role-Based Access:** (Prepared for Admin/User roles).
- **Token Management:** Automatic JWT token handling in HTTP headers.

### ⚙️ Developer Experience (DX)
- **Automatic Seeding:** The database is automatically populated with sample data (Van Gogh, Monet) on startup.
- **Global Error Handling:** Centralized exception handling middleware.
- **Repository Pattern:** Generic and specific repositories for data access abstraction.

---

🗺️ Roadmap & Future Plans

Payment Gateway: Integration with Stripe for real transactions.

Admin Panel: Dashboard for managing products and orders.

Email Notifications: Background service (Worker) for sending order confirmations using RabbitMQ.

Containerization: Docker support for easy deployment.

.NET Aspire: Orchestration for cloud-native development.
