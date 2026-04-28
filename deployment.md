# 🚀 Telepítési útmutató – Online Könyvtár

## 📋 Rendszerkövetelmények

| Eszköz | Minimum verzió | Letöltés |
|---|---|---|
| Docker Desktop | 4.0+ | https://www.docker.com/products/docker-desktop/ |
| Git | bármely | https://git-scm.com/ |
| Node.js *(opcionális)* | 18+ | https://nodejs.org/ |
| .NET SDK *(opcionális)* | 10.0 | https://dotnet.microsoft.com/download |
| Minikube *(opcionális)* | 1.30+ | https://minikube.sigs.k8s.io/docs/start/ |
| kubectl *(opcionális)* | 1.27+ | https://kubernetes.io/docs/tasks/tools/ |

---

## 1️⃣ Módszer – Docker Compose (Ajánlott)

Ez a leggyorsabb módszer – csak Docker Desktop szükséges!

### 1. Repo klónozása
```bash
git clone https://github.com/Werbygbr/library-app.git
cd library-app
```

### 2. Alkalmazás indítása
```bash
docker-compose up --build
```

> ⏳ Az első indítás 5-10 percet vehet igénybe amíg letölti az image-eket és buildeli az alkalmazást.

> ℹ️ Az alkalmazás automatikusan feltöltődik minta adatokkal (5 szerző, 12 könyv) az első indításkor!

### 3. Megnyitás böngészőben

| Szolgáltatás | URL |
|---|---|
| 🌐 Frontend | http://localhost:4200 |
| 📡 Backend Swagger | http://localhost:8080/swagger |
| 🗄️ MongoDB | localhost:27017 |

### 4. Leállítás
```bash
# Leállítás (adatok megmaradnak)
docker-compose down

# Leállítás + adatok törlése
docker-compose down -v
```

### ⚠️ Gyakori hibák

**Port ütközés:**
```bash
# Ellenőrizd melyik program használja a portot
netstat -ano | findstr :4200
netstat -ano | findstr :8080
```

**Régi konténer ütközés:**
```bash
docker stop mongodb
docker rm mongodb
docker-compose up --build
```

**npm ci hiba (package-lock.json hiányzik):**
```bash
cd library-frontend
npm install
cd ..
docker-compose up --build
```

**PowerShell script tiltás:**
```powershell
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned
```

---

## 2️⃣ Módszer – Lokális fejlesztés

### 1. MongoDB indítása
```bash
docker run -d -p 27017:27017 --name mongodb mongo:8
```

### 2. Backend indítása
```bash
cd LibraryApi
dotnet run
```
Backend elérhető: **http://localhost:5138/swagger**

### 3. Frontend indítása
```bash
cd library-frontend
npm install
ng serve
```
Frontend elérhető: **http://localhost:4200**

> ℹ️ Lokális fejlesztésnél a `src/environments/environment.ts` fájlban az `apiUrl` értéke `http://localhost:5138` legyen.

---

## 3️⃣ Módszer – Kubernetes (Minikube)

### 1. Minikube indítása
```bash
minikube start
```

### 2. Alkalmazás deployolása
```bash
cd library-app
kubectl apply -f k8s/
```

### 3. Pod-ok állapotának ellenőrzése
```bash
kubectl get pods -w
```
Várj amíg minden pod `Running` állapotba kerül.

### 4. Alkalmazás megnyitása
```bash
minikube service frontend
```

> ⚠️ A terminált nyitva kell tartani amíg használod az alkalmazást!

### 5. Leállítás
```bash
kubectl delete -f k8s/
minikube stop
```

---

## 4️⃣ ArgoCD telepítése (GitOps CD)

### 1. ArgoCD névtér és telepítés
```bash
kubectl create namespace argocd
kubectl apply -n argocd -f https://raw.githubusercontent.com/argoproj/argo-cd/stable/manifests/install.yaml
```

### 2. Várakozás amíg minden pod elindul
```bash
kubectl get pods -n argocd -w
```

### 3. ArgoCD UI elérése
```bash
kubectl port-forward svc/argocd-server -n argocd 8091:443
```
Megnyitás: **https://localhost:8091**

### 4. Admin jelszó lekérése (PowerShell)
```powershell
$encoded = kubectl -n argocd get secret argocd-initial-admin-secret -o jsonpath="{.data.password}"
[System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($encoded))
```

### 5. ArgoCD Application deployolása
```bash
kubectl apply -f k8s/argocd-application.yaml
```

Az ArgoCD ezután automatikusan szinkronizálja a GitHub repo-ból a Kubernetes manifesteket. Ha minden működik, az alkalmazás állapota **Healthy** és **Synced** lesz.

---

## 🔄 CI/CD Pipeline

### GitHub Actions (CI)
Minden `main` branch-re push után automatikusan:
1. Buildeli a backend Docker image-et
2. Buildeli a frontend Docker image-et
3. Feltölti a `ghcr.io/werbygbr/library-app` registry-be

Pipeline állapot: **https://github.com/Werbygbr/library-app/actions**

> ⚠️ A GitHub Personal Access Token-nek `repo` és `workflow` jogosultság szükséges a push-oláshoz!

---

## 🔧 Hibaelhárítás

### Docker nem indul
```bash
# Ellenőrizd fut-e a Docker Desktop
docker ps
```

### Konténer névütközés
```bash
docker stop mongodb
docker rm mongodb
docker-compose up --build
```

### Kubernetes pod nem indul
```bash
# Pod részletes állapot
kubectl describe pod POD_NEVE

# Pod logok
kubectl logs POD_NEVE
```

### Backend nem csatlakozik MongoDB-hez
```bash
# Ellenőrizd fut-e a MongoDB konténer
docker ps | grep mongodb

# Ha nem fut
docker start mongodb
```

### Frontend nem látja a backendet
Ellenőrizd a `nginx.conf` fájlt – a `/api` proxy a backendre mutat:
```nginx
location /api {
    proxy_pass http://backend:8080;
}
```

---

## 📁 Fontos fájlok

| Fájl | Leírás |
|---|---|
| `docker-compose.yml` | Lokális Docker környezet |
| `LibraryApi/Dockerfile` | Backend image |
| `library-frontend/Dockerfile` | Frontend image |
| `library-frontend/nginx.conf` | Nginx proxy konfiguráció |
| `k8s/*.yaml` | Kubernetes manifestek |
| `.github/workflows/ci.yml` | GitHub Actions CI pipeline |
| `src/environments/environment.ts` | Frontend dev konfiguráció |
| `src/environments/environment.prod.ts` | Frontend prod konfiguráció |
