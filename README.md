
# 🌍 Travelin — Travel & Tour Booking Platform

> A full-stack travel and tour booking web application built with **ASP.NET Core MVC**, **MongoDB**, and **Tailwind CSS**. Features a modern customer-facing site and a complete admin dashboard.

---

## 📸 Preview

| Customer Site | Admin Dashboard |
|---|---|
| Tour listing, detail, reservation | Reservation management, analytics |

---

## 🚀 Features

### 🧳 Customer Panel
- **Tour Listing** — Browse all active tours with pagination, sorting and filtering (city, category, duration)
- **Tour Detail** — Full tour info: description, itinerary, map, included/excluded services, reviews
- **Reservation System** — Book tours with personal info and person count; real-time price calculation
- **My Reservations** — View and cancel personal reservations
- **Review System** — Authenticated users can submit star-rated reviews; awaits admin approval before publishing
- **Authentication** — Register / Login with role-based redirection (Admin → Admin Panel, User → Dashboard)
- **Multi-language UI** — Turkish / English toggle via localStorage

### 🛠️ Admin Panel
- **Dashboard** — Live stats: total customers, reservations, pending bookings, approved bookings
- **Monthly Chart** — Bar chart for reservation analytics (6 months / 1 year toggle)
- **Category Distribution** — Donut-style breakdown of reservations by tour category
- **Tour Management** — Full CRUD: create, update, delete tours; active/passive status toggle
- **Tour Calendar** — Monthly calendar view showing tours by date with detail popup
- **Reservation Management** — Approve, set pending, or cancel any reservation
- **Customer Management** — List all registered users with tour count and last reservation date
- **Comment Moderation** — Approve or delete user reviews; pending/published status
- **Category Management** — Add, edit, delete tour categories with tour count per category
- **Settings** — Admin profile, password change, contact info, social media links

---

## 🏗️ Tech Stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core MVC (.NET 8) |
| Database | MongoDB |
| ORM / Mapping | MongoDB.Driver + AutoMapper |
| Identity | ASP.NET Core Identity (MongoDbCore) |
| Frontend (Customer) | Bootstrap 5, custom CSS, FontAwesome |
| Frontend (Admin) | Tailwind CSS, Material Symbols, Chart.js |
| Architecture | Service Layer, Repository Pattern, ViewComponents, DTOs |

---

## 📁 Project Structure

```
Project3Travelin/
├── Controllers/
│   ├── AccountController.cs       # Login, Register, Logout
│   ├── AdminTourController.cs     # All admin operations
│   ├── CommentController.cs       # Comment creation
│   ├── DashboardController.cs     # Customer home
│   ├── ReservationController.cs   # Reservation CRUD
│   └── TourController.cs          # Tour list, detail, destination
│
├── DTOs/
│   ├── AccountDtos/               # LoginDto, RegisterDto, UpdateProfileDto
│   ├── CategoryDtos/              # Result, Create, Update
│   ├── CommentDtos/               # Result, Create, Update, GetById
│   ├── ReservationDtos/           # Result, Create
│   └── TourDtos/                  # Result, Create, Update, GetById
│
├── Entities/
│   ├── AppUser.cs                 # Extended Identity user
│   ├── AppRole.cs                 # Identity role
│   ├── Tour.cs
│   ├── Category.cs
│   ├── Comment.cs
│   └── Reservation.cs
│
├── Services/
│   ├── TourServices/
│   ├── CategoryServices/
│   ├── CommentServices/
│   └── ReservationServices/
│
├── ViewComponents/
│   ├── AdminNavbarViewComponent.cs
│   ├── NavbarUserViewComponent.cs
│   └── _AdminLastReservationComponentPartial.cs
│
├── Views/
│   ├── Account/                   # Login, Register
│   ├── AdminTour/                 # Index, TourList, CreateTour, UpdateTour, ...
│   ├── Dashboard/
│   ├── Reservation/               # Index, Create
│   ├── Tour/                      # TourList, TourDetail, TourDestination
│   └── Shared/
│       ├── _TravelinLayout.cshtml
│       ├── _AdminTourLayout.cshtml
│       └── Components/
│
├── Settings/
│   └── DatabaseSettings.cs
└── appsettings.json
```

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community) (local or Atlas)

### 1. Clone the repository
```bash
git clone https://github.com/yourusername/Project3Travelin.git
cd Project3Travelin
```

### 2. Configure database
Update `appsettings.json`:
```json
{
  "DatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "Travelin",
    "TourCollectionName": "Tours",
    "CommentCollectionName": "Comments",
    "CategoryCollectionName": "Categories"
  }
}
```

### 3. Run the application
```bash
dotnet run
```

### 4. Default admin account
On first run, the application automatically creates:
- **Username:** `admin`
- **Password:** `Admin123!`
- **Role:** Admin

> ⚠️ Change the default password after first login via the Settings page.

---

## 🔐 Role-Based Access

| Role | Redirect After Login | Access |
|---|---|---|
| `Admin` | `/AdminTour/Index` | Full admin panel |
| `User` | `/Dashboard/Index` | Customer site |

---

## 📊 Admin Dashboard Highlights

- **Real-time stats** pulled from MongoDB on every request
- **Monthly reservation chart** with 6-month / 1-year toggle (Chart.js)
- **Category distribution** calculated from reservation × tour join
- **Top 5 tours** displayed from database
- **Last reservations** shown with live status badges

---

## 💬 Review Flow

```
User submits review
       ↓
IsStatus = false  (pending)
       ↓
Admin approves in Comment Management
       ↓
IsStatus = true  (published)
       ↓
Visible on Tour Detail page
```

---

## 🗓️ Reservation Flow

```
Tour Detail → "Rezervasyon Yap"
       ↓
Reservation/Create (pre-filled with user info)
       ↓
Status: "Beklemede"
       ↓
Admin approves → Status: "Onaylandı"
       ↓
User sees updated status in "Rezervasyonlarım"
```

---

## 🌐 Multi-Language Support

Language preference is stored in `localStorage`. Switching between **Türkçe** and **English** applies translations client-side via a JavaScript translation object — no page reload required.

---

## 📦 NuGet Packages

```
AspNetCore.Identity.MongoDbCore
MongoDB.Driver
AutoMapper.Extensions.Microsoft.DependencyInjection
```

---

## 🤝 Contributing

This project was built for learning and portfolio purposes. Feel free to fork and extend it.

---

## 📄 License

MIT License — free to use for personal and commercial projects.

---

<div align="center">
  Built with ❤️ using ASP.NET Core MVC & MongoDB
</div>

<img width="1894" height="871" alt="Ekran görüntüsü 2026-06-25 231304" src="https://github.com/user-attachments/assets/2c39c7ad-5043-47f5-8582-e755e406ca07" />
<img width="1907" height="866" alt="Ekran görüntüsü 2026-06-25 231317" src="https://github.com/user-attachments/assets/aa0ab554-e36c-4517-a733-22801be9ae23" />

<img width="1882" height="868" alt="Ekran görüntüsü 2026-06-25 231336" src="https://github.com/user-attachments/assets/11763786-9f33-42e4-8e6e-b9a6bb0ffab9" />
<img width="1885" height="869" alt="Ekran görüntüsü 2026-06-25 231328" src="https://github.com/user-attachments/assets/2561bbc6-b8f7-4991-8cef-51986f0d994f" />
<img width="1897" height="871" alt="Ekran görüntüsü 2026-06-25 231344" src="https://github.com/user-attachments/assets/4f722129-269f-434e-822e-c7f6600bc537" />

<img width="1877" height="871" alt="Ekran görüntüsü 2026-06-25 231403" src="https://github.com/user-attachments/assets/2a3444f5-92e4-42e7-9bb8-2026153d1dee" />
<img width="1913" height="866" alt="Ekran görüntüsü 2026-06-25 231410" src="https://github.com/user-attachments/assets/2bf545b6-820c-486d-b54b-80cbb1aba3d2" />

<img width="1889" height="871" alt="Ekran görüntüsü 2026-06-25 231421" src="https://github.com/user-attachments/assets/cad55629-e37e-4d86-9070-0ed178d7f11f" />
<img width="1893" height="875" alt="Ekran görüntüsü 2026-06-25 231443" src="https://github.com/user-attachments/assets/a9f4d59d-91ac-43d3-83ef-ab3f70efdc79" />
<img width="1912" height="870" alt="Ekran görüntüsü 2026-06-25 231458" src="https://github.com/user-attachments/assets/5e6373c5-60a7-407e-b256-a5397adf4fc0" />

<img width="1888" height="870" alt="Ekran görüntüsü 2026-06-25 232943" src="https://github.com/user-attachments/assets/f17299c6-7e4c-4110-8ba1-30c26fd859c6" />

<img width="1890" height="866" alt="Ekran görüntüsü 2026-06-25 232952" src="https://github.com/user-attachments/assets/08deb57c-96e7-4348-a0be-b4cbc9770893" />

<img width="1898" height="864" alt="Ekran görüntüsü 2026-06-25 233002" src="https://github.com/user-attachments/assets/25e719bc-ab0b-4f79-9847-87a7bf6b03bc" />
<img width="1880" height="865" alt="Ekran görüntüsü 2026-06-25 233013" src="https://github.com/user-attachments/assets/c004afbc-08f5-4610-b27d-30b420cf5be0" />
<img width="1888" height="865" alt="Ekran görüntüsü 2026-06-25 233022" src="https://github.com/user-attachments/assets/47d7b77f-41c8-40a9-9a89-b04fdc188bea" />

<img width="1884" height="866" alt="Ekran görüntüsü 2026-06-25 233055" src="https://github.com/user-attachments/assets/ecf355ae-d02c-439a-b356-dfb9786d8456" />
<img width="1884" height="871" alt="Ekran görüntüsü 2026-06-25 233104" src="https://github.com/user-attachments/assets/4b4e3e57-7b11-4b99-b50a-1ee305581e36" />
<img width="1883" height="864" alt="Ekran görüntüsü 2026-06-25 233117" src="https://github.com/user-attachments/assets/070861bb-1054-494d-804b-2bb901c5667f" />
<img width="1892" height="875" alt="Ekran görüntüsü 2026-06-25 233158" src="https://github.com/user-attachments/assets/5464906b-5efa-4098-a59c-3e45d9e21589" />
<img width="1894" height="870" alt="Ekran görüntüsü 2026-06-25 233206" src="https://github.com/user-attachments/assets/70e58097-a025-4758-af36-649112334609" />







