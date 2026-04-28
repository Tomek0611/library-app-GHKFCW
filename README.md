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
... (136 sor maradt)
