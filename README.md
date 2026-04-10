# 🎨 ArtStore - Modern E-Commerce Platform (.NET 9)

> A full-stack, cloud-native ready e-commerce solution for selling art prints. Built with cutting-edge .NET technologies, Clean Architecture, and a modular design.

## 🚀 Overview

**ArtStore** demonstrates how to build a scalable, maintainable enterprise application using the latest Microsoft stack. It features backend API implementing **CQRS** pattern and responsive **Blazor WebAssembly** frontend with **MudBlazor** UI components.
The system handles product catalog management, user authentication (JWT), shopping cart logic with database persistence, and order processing simulation.

This project demonstrates the full software development lifecycle: from business analysis (BRD) and UX/UI design, through software architecture (SAD), to complete .NET/C# implementation.

---

## 📊 Documentation (Business & Architecture)
As part of this project, I performed a system gap analysis and documented the transition. For compare purposes, the old version before analysis is waiting for you in branch called "OLD-VERSION".
* [📄 Business Requirements Document (BRD)](docs/Artstore_BRD.md) - Focuses on "What" and "Why" (Business Goals, System Capabilities, SEO requirements).
* [📐 Software Architecture Document (SAD)](docs/Artstore_SAD.md) - Focuses on "How" (Database Schema, API refactoring, DTOs, Blazor Routing).
* 

---

## 🎨 UI / UX Design
The cooperation with graphic designer give a touch of ART to design of the shop. The new frontend was completely redesigned before implementation. Here's the leak of change for home page.

### Homepage Redesign (Before & After)
<p align="center">
  <img src="docs/assets/old_ui.png" width="45%" title="Old UI">
  <img src="docs/assets/new_ui.png" width="45%" title="New UI built in Figma">
</p>

## ✨ Key Features

### 🛒 Shopping Experience
- **Dynamic Catalog:** Filter artwork by Category, Collection, Price range, and Frame type.
- **Product Details:** High-quality image zoom, artist bio, and related works.
- **Persistent Cart:** Shopping cart items are stored in the database, allowing users to switch devices without losing data.

### 🔐 User & Security
- **Registration & Login:** Secure identity system with hashed passwords.
- **Role-Based Access:** (Prepared for Admin/User roles).
- **Token Management:** Automatic JWT token handling in HTTP headers.

### ⚙️ Developer Experience (DX)
- **Automatic Seeding:** The database is automatically populated with sample data (Van Gogh, Monet) on startup.
- **Global Error Handling:** Centralized exception handling middleware.

---

🗺️ Roadmap & Future Plans

Payment Gateway: Integration with Stripe for real transactions.

Admin Panel: Dashboard for managing products and orders.

Email Notifications: Background service (Worker) for sending order confirmations using RabbitMQ.

Containerization: Docker support for easy deployment.

.NET Aspire: Orchestration for cloud-native development.
