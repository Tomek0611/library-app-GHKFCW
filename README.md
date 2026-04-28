# 📚 Online Könyvtár

<div align="center">

![Angular](https://img.shields.io/badge/Angular-21-DD0031?style=for-the-badge&logo=angular&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-8-47A248?style=for-the-badge&logo=mongodb&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![Kubernetes](https://img.shields.io/badge/Kubernetes-Minikube-326CE5?style=for-the-badge&logo=kubernetes&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-CI/CD-2088FF?style=for-the-badge&logo=githubactions&logoColor=white)
![ArgoCD](https://img.shields.io/badge/ArgoCD-GitOps-EF7B4D?style=for-the-badge&logo=argo&logoColor=white)

**Teljes stack könyvtárkezelő alkalmazás – Angular frontend, ASP.NET backend, MongoDB adatbázis**

[🚀 Gyors indítás](#-gyors-indítás) · [📖 Funkciók](#-funkciók) · [🏗️ Architektúra](#️-architektúra) · [📡 API](#-api-végpontok)

</div>

---

## 📖 Funkciók

### 📚 Könyvkezelés
- ✅ Könyvek hozzáadása, szerkesztése, törlése
- ✅ Részletes könyvnézet (szerző, év, műfaj, leírás)
- ✅ Keresés cím, szerző és műfaj alapján
- ✅ Szűrés műfaj szerint
- ✅ Rendezés (cím, év, szerző szerint)
- ✅ Lapozás (5/10/20 elem oldalanként)

### ✍️ Szerzőkezelés
- ✅ Szerzők hozzáadása, szerkesztése, törlése
- ✅ Keresés név és nemzetiség alapján
- ✅ Lapozás

### 📊 Dashboard
- ✅ Statisztikai kártyák (könyvek, szerzők, legújabb év, műfajok)
- ✅ Műfajok eloszlása – Pie chart
- ✅ Évek szerinti eloszlás – Bar chart

### 🎨 UI/UX
- ✅ Dark mode / Light mode kapcsoló
- ✅ Törlés megerősítő dialog
- ✅ Snackbar értesítések (mentés, törlés után)
- ✅ Responsive design (mobil + desktop)
- ✅ Modern zöld Angular Material dizájn
- ✅ Smooth animációk és hover effektek
- ✅ Rólunk oldal (csapat, funkciók, technológiák)

### 🔌 Backend API
- ✅ Keresési végpontok (`/api/books/search`, `/api/authors/search`)
- ✅ Magyar Swagger dokumentáció
- ✅ ID validáció (MongoDB 24 karakteres hex)
- ✅ Magyar hibaüzenetek
- ✅ Automatikus seed data (5 szerző, 12 könyv)

---

## 🏗️ Architektúra

```
┌─────────────────┐     ┌─────────────────┐     ┌─────────────────┐
│                 │     │                 │     │                 │
│  Angular 21     │────▶│  ASP.NET 10     │────▶│  MongoDB 8      │
│  Frontend       │     │  REST API       │     │  Adatbázis      │
│  (Port 4200)    │     │  (Port 8080)    │     │  (Port 27017)   │
│                 │     │                 │     │                 │
└─────────────────┘     └─────────────────┘     └─────────────────┘
```

### Technológiai stack

| Réteg | Technológia |
|---|---|
| 🌐 Frontend | Angular 21 + Angular Material + Chart.js |
| ⚙️ Backend | ASP.NET 10 Web API |
| 🗄️ Adatbázis | MongoDB 8 |
| 🐳 Konténerizálás | Docker + Docker Compose |
| ☸️ Orchestráció | Kubernetes (Minikube) |
| 🔄 CI Pipeline | GitHub Actions |
| 🚀 CD Pipeline | ArgoCD (GitOps) |

---

## 🚀 Gyors indítás

### 🐳 Docker Compose (Ajánlott)

> Csak Docker Desktop szükséges!

```bash
# 1. Klónozd a repo-t
git clone https://github.com/Werbygbr/library-app.git
cd library-app

# 2. Indítsd el
docker-compose up --build
```

| Szolgáltatás | URL |
|---|---|
| 🌐 Alkalmazás | http://localhost:4200 |
| 📡 API Swagger | http://localhost:8080/swagger |

> ℹ️ Az alkalmazás automatikusan feltöltődik minta adatokkal (5 szerző, 12 könyv) az első indításkor!

```bash
# Leállítás
docker-compose down

# Leállítás + adatok törlése
docker-compose down -v
```

---

### 💻 Lokális fejlesztés

```bash
# MongoDB
docker run -d -p 27017:27017 --name mongodb mongo:8

# Backend
cd LibraryApi
dotnet run
# → http://localhost:5138/swagger

# Frontend
cd library-frontend
npm install
ng serve
# → http://localhost:4200
```

---

### ☸️ Kubernetes (Minikube)

```bash
# Cluster indítása
minikube start

# Deploy
kubectl apply -f k8s/

# Állapot ellenőrzés
kubectl get pods -w

# Megnyitás
minikube service frontend
```

---

### 🔄 CI/CD Pipeline

#### GitHub Actions (CI)
Minden `main` branch push után automatikusan:
1. 🏗️ Backend Docker image build
2. 🏗️ Frontend Docker image build
3. 📦 Push → `ghcr.io/werbygbr/library-app`

#### ArgoCD (CD – GitOps)
```bash
# ArgoCD UI elérése
kubectl port-forward svc/argocd-server -n argocd 8091:443
# → https://localhost:8091

# Admin jelszó (PowerShell)
$encoded = kubectl -n argocd get secret argocd-initial-admin-secret -o jsonpath="{.data.password}"
[System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($encoded))
```

---

## 📁 Projekt struktúra

```
library-app/
├── 📂 LibraryApi/                 # ASP.NET 10 Backend
│   ├── Controllers/               # REST API végpontok
│   ├── Models/                    # Book, Author modellek
│   ├── Services/                  # CRUD + Seed logika
│   ├── Settings/                  # MongoDB beállítások
│   ├── Dockerfile
│   └── appsettings.json
├── 📂 library-frontend/           # Angular 21 Frontend
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/        # Book, Author, Navbar, About
│   │   │   ├── models/            # TypeScript interfészek
│   │   │   └── services/          # HTTP + Theme service
│   │   └── environments/          # Dev/prod konfiguráció
│   ├── Dockerfile
│   └── nginx.conf
├── 📂 k8s/                        # Kubernetes manifestek
│   ├── mongodb-deployment.yaml
│   ├── backend-deployment.yaml
│   ├── frontend-deployment.yaml
│   └── argocd-application.yaml
├── 📂 docs/                       # Dokumentáció
│   ├── deployment.md              # Telepítési útmutató
│   └── userguide.md               # Felhasználói kézikönyv
├── 📂 .github/workflows/
│   └── ci.yml                     # GitHub Actions CI
└── docker-compose.yml
```

---

## 📡 API végpontok

### 📚 Könyvek `/api/books`

| Method | Endpoint | Leírás |
|---|---|---|
| `GET` | `/api/books` | Összes könyv listázása |
| `GET` | `/api/books/search?title=&genre=` | Keresés cím/műfaj alapján |
| `GET` | `/api/books/{id}` | Egy könyv lekérése |
| `POST` | `/api/books` | Új könyv létrehozása |
| `PUT` | `/api/books/{id}` | Könyv módosítása |
| `DELETE` | `/api/books/{id}` | Könyv törlése |

### ✍️ Szerzők `/api/authors`

| Method | Endpoint | Leírás |
|---|---|---|
| `GET` | `/api/authors` | Összes szerző listázása |
| `GET` | `/api/authors/search?name=&nationality=` | Keresés név/nemzetiség alapján |
| `GET` | `/api/authors/{id}` | Egy szerző lekérése |
| `POST` | `/api/authors` | Új szerző létrehozása |
| `PUT` | `/api/authors/{id}` | Szerző módosítása |
| `DELETE` | `/api/authors/{id}` | Szerző törlése |

---
