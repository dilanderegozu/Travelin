<div align="center">

# 🌍 Travelin
### Modern Tur & Rezervasyon Yönetim Platformu

> **Travelin**, gezginlerin hayallerindeki turları keşfetmesini, rezervasyon yapmasını ve tüm seyahat süreçlerini yönetmesini sağlayan; modern, güvenli ve dinamik bir ASP.NET Core MVC platformudur.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![MongoDB](https://img.shields.io/badge/MongoDB-7.0-47A248?style=flat-square&logo=mongodb)](https://www.mongodb.com/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=flat-square&logo=bootstrap)](https://getbootstrap.com/)
[![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-3-06B6D4?style=flat-square&logo=tailwindcss)](https://tailwindcss.com/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)

</div>

---

## 🚀 Öne Çıkan Özellikler

### 🔐 Kimlik Doğrulama & Yetkilendirme
- **ASP.NET Core Identity** ile role-based access control (Admin / User)
- Kayıt olan her kullanıcıya otomatik **"User"** rolü atanır
- Giriş sonrası role göre yönlendirme: Admin → Admin Panel, User → Dashboard
- `[Authorize]` ve `[Authorize(Roles = "Admin")]` ile uç nokta koruması
- Cookie tabanlı kimlik doğrulama ve password hashing

 <img width="1876" height="863" alt="Ekran görüntüsü 2026-06-25 234120" src="https://github.com/user-attachments/assets/bb6eca24-ad64-4173-bce8-69a7e618be9c" />
<img width="1877" height="870" alt="Ekran görüntüsü 2026-06-25 234135" src="https://github.com/user-attachments/assets/06f30a37-ae40-4c56-a1da-9a102d98d54e" />


### 🧳 Müşteri Paneli
- **Tur Listesi** — Pagination, sıralama ve çoklu filtreleme (şehir, kategori, süre)
- **Tur Detayı** — Açıklama, program, harita, dahil/hariç hizmetler, yıldız değerlendirmesi
- **Rezervasyon Motoru** — Kişi sayısına göre anlık fiyat hesaplama (JavaScript DOM)
- **Rezervasyonlarım** — Aktif rezervasyonları görüntüleme ve iptal etme
- **Yorum Sistemi** — Sadece giriş yapmış kullanıcılar yorum yapabilir; admin onayından sonra yayına girer

### 🛠️ Admin Paneli
- **Dashboard** — Anlık istatistikler: müşteri, rezervasyon, bekleyen, onaylanan
- **Aylık Grafik** — Chart.js ile 6 ay / 1 yıl rezervasyon analizi
- **Kategori Dağılımı** — Rezervasyon × Tur join'iyle hesaplanan kategori yüzdesi
- **Tur Yönetimi** — Tam CRUD, aktif/pasif durum toggle
- **Tur Takvimi** — Aylık takvim görünümü, ay navigasyonu, tur popup detayı
- **Rezervasyon Yönetimi** — Onayla / Beklemede / İptal Et
- **Müşteri Yönetimi** — Kullanıcı listesi, tur sayısı, son rezervasyon tarihi
- **Yorum Moderasyonu** — Bekleyen/yayınlanan durum, onay ve silme
- **Kategori Yönetimi** — CRUD + kategoriye ait tur sayısı
- **Ayarlar** — Admin profili, şifre değiştirme, iletişim, sosyal medya

### ✨ Teknik Özellikler
- **Tüm veritabanı işlemleri** `async/await` ile asenkron
- **AutoMapper** ile Entity ↔ DTO dönüşümleri
- **ViewComponent** mimarisi ile modüler ve bağımsız UI bileşenleri
- **MongoDB** ile esnek NoSQL veri yönetimi
- **Service Layer** pattern ile temiz kod mimarisi
- **Türkçe / İngilizce** dil desteği (`localStorage` tabanlı)

---

## 📸 Kimlik Doğrulama

> 💡 **Login ve Register görsellerini buraya ekle:**
> GitHub'da bu README'yi düzenlerken aşağıdaki satırların altına,
> görselleri sürükle-bırak ile yükle veya Issues üzerinden upload et.

<!-- LOGIN GÖRSELİNİ BURAYA EKLE -->
<!-- <img src="BURAYA_LOGIN_GORSEL_URL" width="49%" /> -->

<!-- REGISTER GÖRSELİNİ BURAYA EKLE -->
<!-- <img src="BURAYA_REGISTER_GORSEL_URL" width="49%" /> -->

---

## 📸 Müşteri Sitesi

<img src="https://github.com/user-attachments/assets/2c39c7ad-5043-47f5-8582-e755e406ca07" width="49%" /> <img src="https://github.com/user-attachments/assets/aa0ab554-e36c-4517-a733-22801be9ae23" width="49%" />
<img src="https://github.com/user-attachments/assets/11763786-9f33-42e4-8e6e-b9a6bb0ffab9" width="49%" /> <img src="https://github.com/user-attachments/assets/2561bbc6-b8f7-4991-8cef-51986f0d994f" width="49%" />
<img src="https://github.com/user-attachments/assets/4f722129-269f-434e-822e-c7f6600bc537" width="49%" /> <img src="https://github.com/user-attachments/assets/2a3444f5-92e4-42e7-9bb8-2026153d1dee" width="49%" />
<img src="https://github.com/user-attachments/assets/2bf545b6-820c-486d-b54b-80cbb1aba3d2" width="49%" /> <img src="https://github.com/user-attachments/assets/cad55629-e37e-4d86-9070-0ed178d7f11f" width="49%" />
<img src="https://github.com/user-attachments/assets/a9f4d59d-91ac-43d3-83ef-ab3f70efdc79" width="49%" /> <img src="https://github.com/user-attachments/assets/5e6373c5-60a7-407e-b256-a5397adf4fc0" width="49%" />
<img src="https://github.com/user-attachments/assets/f17299c6-7e4c-4110-8ba1-30c26fd859c6" width="49%" /> <img src="https://github.com/user-attachments/assets/08deb57c-96e7-4348-a0be-b4cbc9770893" width="49%" />
<img src="https://github.com/user-attachments/assets/25e719bc-ab0b-4f79-9847-87a7bf6b03bc" width="49%" /> <img src="https://github.com/user-attachments/assets/c004afbc-08f5-4610-b27d-30b420cf5be0" width="49%" />
<img src="https://github.com/user-attachments/assets/47d7b77f-41c8-40a9-9a89-b04fdc188bea" width="49%" /> <img src="https://github.com/user-attachments/assets/ecf355ae-d02c-439a-b356-dfb9786d8456" width="49%" />
<img src="https://github.com/user-attachments/assets/4b4e3e57-7b11-4b99-b50a-1ee305581e36" width="49%" /> <img src="https://github.com/user-attachments/assets/070861bb-1054-494d-804b-2bb901c5667f" width="49%" />
<img src="https://github.com/user-attachments/assets/5464906b-5efa-4098-a59c-3e45d9e21589" width="49%" /> <img src="https://github.com/user-attachments/assets/70e58097-a025-4758-af36-649112334609" width="49%" />

---

## 📸 Admin Dashboard

<img src="https://github.com/user-attachments/assets/bba2a678-baeb-4ff2-ba1e-a81f96584c7e" width="49%" /> <img src="https://github.com/user-attachments/assets/3cc1ea7b-127d-4406-aa89-f3ac3513093f" width="49%" />
<img src="https://github.com/user-attachments/assets/f0947432-3d1a-4eb2-9470-052d4c7b6fbc" width="49%" /> <img src="https://github.com/user-attachments/assets/6654f24c-b31a-48af-84c0-53a15ee28c6d" width="49%" />
<img src="https://github.com/user-attachments/assets/8f6a09b2-0386-4eea-9127-881a0c0ad978" width="49%" /> <img src="https://github.com/user-attachments/assets/e488ea85-0d0c-40a3-a6a0-186dd7d2912a" width="49%" />
<img src="https://github.com/user-attachments/assets/b8a68d31-0636-4920-bcd9-f2046f555f82" width="49%" /> <img src="https://github.com/user-attachments/assets/8f98586f-e52e-44fa-88fd-329d1cca96de" width="49%" />
<img src="https://github.com/user-attachments/assets/8bbd8b00-351a-490f-a3d4-76410a80ec00" width="100%" />

---

## 🏗️ Teknoloji Stack'i

| Katman | Teknoloji |
|---|---|
| Backend | ASP.NET Core MVC (.NET 8) |
| Veritabanı | MongoDB |
| Mapping | MongoDB.Driver + AutoMapper |
| Kimlik Doğrulama | ASP.NET Core Identity (MongoDbCore) |
| Frontend (Müşteri) | Bootstrap 5, Custom CSS, FontAwesome |
| Frontend (Admin) | Tailwind CSS, Material Symbols, Chart.js |
| Mimari | Service Layer, ViewComponent, DTO Pattern |
| Dil Desteği | Türkçe / İngilizce (localStorage) |

---

## 📁 Proje Yapısı

```
Project3Travelin/
├── Controllers/
│   ├── AccountController.cs       # Login, Register, Logout
│   ├── AdminTourController.cs     # Tüm admin işlemleri
│   ├── CommentController.cs       # Yorum oluşturma
│   ├── DashboardController.cs     # Müşteri ana sayfa
│   ├── ReservationController.cs   # Rezervasyon CRUD
│   └── TourController.cs          # Tur listesi, detay, rota
├── DTOs/
│   ├── AccountDtos/               # LoginDto, RegisterDto, UpdateProfileDto
│   ├── CategoryDtos/              # Result, Create, Update
│   ├── CommentDtos/               # Result, Create, Update, GetById
│   ├── ReservationDtos/           # Result, Create
│   └── TourDtos/                  # Result, Create, Update, GetById
├── Entities/
│   ├── AppUser.cs                 # Genişletilmiş Identity kullanıcısı
│   ├── AppRole.cs
│   ├── Tour.cs
│   ├── Category.cs
│   ├── Comment.cs
│   └── Reservation.cs
├── Services/
│   ├── TourServices/
│   ├── CategoryServices/
│   ├── CommentServices/
│   └── ReservationServices/
├── ViewComponents/
│   ├── AdminNavbarViewComponent.cs
│   ├── NavbarUserViewComponent.cs
│   └── _AdminLastReservationComponentPartial.cs
├── Views/
│   ├── Account/                   # Login, Register
│   ├── AdminTour/                 # Index, TourList, CreateTour, UpdateTour...
│   ├── Dashboard/
│   ├── Reservation/               # Index, Create
│   ├── Tour/                      # TourList, TourDetail, TourDestination
│   └── Shared/
│       ├── _TravelinLayout.cshtml
│       ├── _AdminTourLayout.cshtml
│       └── Components/
├── Settings/
│   └── DatabaseSettings.cs
└── appsettings.json
```

---

## ⚙️ Kurulum

### Gereksinimler
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community)

### 1. Repoyu klonla
```bash
git clone https://github.com/yourusername/Project3Travelin.git
cd Project3Travelin
```

### 2. Veritabanı yapılandırması
`appsettings.json` dosyasını güncelle:
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

### 3. Çalıştır
```bash
dotnet run
```

### 4. Varsayılan admin bilgileri
| Alan | Değer |
|---|---|
| Kullanıcı Adı | `admin` |
| Şifre | `Admin123!` |
| Rol | Admin |

> ⚠️ İlk girişten sonra Ayarlar sayfasından şifreyi değiştir.

---

## 🔐 Rol Tabanlı Erişim

| Rol | Giriş Sonrası Yönlendirme | Erişim |
|---|---|---|
| `Admin` | `/AdminTour/Index` | Tam admin paneli |
| `User` | `/Dashboard/Index` | Müşteri sitesi |

---

## 💬 Yorum Akışı

```
Kullanıcı yorum gönderir  →  IsStatus = false (beklemede)
            ↓
Admin, Yorum Yönetimi'nden onaylar
            ↓
IsStatus = true (yayında)  →  Tur Detay sayfasında görünür
```

## 🗓️ Rezervasyon Akışı

```
Tur Detayı → "Rezervasyon Yap"
            ↓
Rezervasyon oluşturulur  →  Durum: "Beklemede"
            ↓
Admin onaylar  →  Durum: "Onaylandı"
            ↓
Kullanıcı "Rezervasyonlarım"da güncellenen durumu görür
```

---

## 📦 NuGet Paketleri

```
AspNetCore.Identity.MongoDbCore
MongoDB.Driver
AutoMapper.Extensions.Microsoft.DependencyInjection
```

---

<div align="center">

❤️ ile **ASP.NET Core MVC** & **MongoDB** kullanılarak geliştirildi

</div>
