# 📖 Felhasználói kézikönyv – Online Könyvtár

## 🌐 Az alkalmazás megnyitása

Indítás után nyisd meg a böngészőben: **http://localhost:4200**

> ℹ️ Az alkalmazás első indításkor automatikusan feltöltődik 5 szerzővel és 12 könyvvel!

---

## 🧭 Navigáció

A bal oldali zöld sávban három menüpont található:

| Ikon | Menüpont | Leírás |
|---|---|---|
| 📖 | Könyvek | Könyvek listája és kezelése |
| 👥 | Szerzők | Szerzők listája és kezelése |
| ℹ️ | Rólunk | Az alkalmazás bemutatása |

A menüsáv az **Összecsukás** gombbal összecsukható – ilyenkor csak az ikonok látszódnak. A **Dark mód** kapcsolóval sötét témára váltható az alkalmazás.

---

## 📊 Dashboard statisztikák

A Könyvek oldal tetején 4 statisztikai kártya látható:

| Kártya | Leírás |
|---|---|
| 📚 Összes könyv | A könyvtárban lévő könyvek száma |
| ✍️ Szerzők száma | A regisztrált szerzők száma |
| 📅 Legújabb könyv éve | A legfrissebb könyv kiadási éve |
| 🎭 Különböző műfajok | Hány különböző műfaj szerepel |

Alattuk két diagram látható:
- **Műfajok eloszlása** – kördiagram (pie chart)
- **Évek szerinti eloszlás** – oszlopdiagram (bar chart)

---

## 📚 Könyvek kezelése

### Új könyv hozzáadása
1. Töltsd ki az **Új könyv hozzáadása** űrlapot:
   - **Cím** – a könyv neve *(kötelező)*
   - **Szerző** – válassz a legördülő listából
   - **Év** – kiadás éve (pl. 2024)
   - **Műfaj** – pl. Regény, Sci-fi, Thriller
   - **Leírás** – rövid összefoglaló
2. Kattints a **Hozzáadás** gombra
3. Megjelenik egy zöld értesítés: *„Könyv sikeresen hozzáadva!"*

> ⚠️ Könyv hozzáadásához először legalább egy szerzőnek léteznie kell!

### Könyv szerkesztése
1. A könyv sorában kattints a ✏️ **ceruza ikonra**
2. Az űrlap feltöltődik a könyv adataival
3. Módosítsd a kívánt mezőket
4. Kattints a **Mentés** gombra
5. Megjelenik egy zöld értesítés: *„Könyv sikeresen módosítva!"*
6. A módosítás megszakításához kattints a **Mégse** gombra

### Könyv törlése
1. A könyv sorában kattints a 🗑️ **kuka ikonra**
2. Megjelenik egy megerősítő ablak: *„Biztosan törölni akarod?"*
3. Kattints a **Törlés** gombra a megerősítéshez
4. Megjelenik egy értesítés: *„Könyv sikeresen törölve!"*

### Könyv részletes nézete
1. Kattints a könyv **címére** (kék/zöld link)
2. Megjelenik a részletes nézet:
   - Cím és műfaj
   - Szerző neve és nemzetisége
   - Kiadás éve
   - Leírás
3. A **Vissza** gombbal visszatérhetsz a listához

---

## 🔍 Keresés, szűrés és rendezés

A Könyvlista fejlécében három szűrő található:

### Keresés
- Írj be bármit a **Keresés** mezőbe
- Az alkalmazás automatikusan szűri a listát **cím, szerző és műfaj** szerint
- A keresés törléshez kattints az **X** gombra

### Műfaj szűrő
- A **Műfaj szűrő** legördülő menüből válassz egy műfajt
- Csak az adott műfajú könyvek jelennek meg
- Az **Összes műfaj** opcióval visszaállítható az összes könyv

### Rendezés
- A **Rendezés** legördülő menüből válassz szempontot:
  - Cím (A-Z) / Cím (Z-A)
  - Év (régi-új) / Év (új-régi)
  - Szerző (A-Z)

---

## ✍️ Szerzők kezelése

### Új szerző hozzáadása
1. Töltsd ki az **Új szerző hozzáadása** űrlapot:
   - **Név** – a szerző teljes neve *(kötelező)*
   - **Nemzetiség** – pl. Magyar, Angol, Amerikai
   - **Születési év** – pl. 1965
2. Kattints a **Hozzáadás** gombra
3. Megjelenik egy zöld értesítés: *„Szerző sikeresen hozzáadva!"*

### Szerző szerkesztése
1. A szerző sorában kattints a ✏️ **ceruza ikonra**
2. Módosítsd a kívánt mezőket
3. Kattints a **Mentés** gombra

### Szerző törlése
1. A szerző sorában kattints a 🗑️ **kuka ikonra**
2. Megjelenik egy megerősítő ablak
3. Kattints a **Törlés** gombra a megerősítéshez

> ⚠️ Ha egy szerzőhöz könyvek tartoznak, a könyvek szerzője „Ismeretlen" lesz törlés után!

### Keresés szerzők között
- A **Keresés** mezőbe írj nevet vagy nemzetiséget
- Az alkalmazás automatikusan szűri a listát

---

## 🌙 Dark mode

A bal oldali menüsáv alján található a **Dark mód** kapcsoló:
- Bekapcsolva: sötét zöld téma
- Kikapcsolva: világos téma
- A beállítás mentésre kerül – legközelebb is ugyanúgy nyílik meg

---

## 📄 Lapozás

Minden lista alján található a lapozó:
- Beállítható hány elem jelenjen meg oldalanként: **5 / 10 / 20**
- A nyilakkal lapozhatod a listát
- Az első/utolsó oldal gombokkal azonnal ugorhatsz

---

## ℹ️ Rólunk oldal

A bal oldali menüben a **Rólunk** menüpontra kattintva megjelenik:
- Az alkalmazás funkciói
- A fejlesztőcsapat tagjai
- A használt technológiák és verziók

---

## 🔌 API használata (fejlesztőknek)

Az API dokumentáció elérhető: **http://localhost:8080/swagger**

### Keresési végpontok

```
GET /api/books/search?title=harry
GET /api/books/search?genre=fantasy
GET /api/books/search?title=harry&genre=fantasy

GET /api/authors/search?name=rowling
GET /api/authors/search?nationality=brit
```

### Hibaüzenetek

Az API magyar nyelvű hibaüzeneteket ad vissza:

```json
{ "message": "A könyv nem található. ID: ..." }
{ "message": "Érvénytelen ID formátum. A MongoDB ID 24 karakteres hex string." }
{ "message": "A cím megadása kötelező." }
```

---

## 💡 Tippek

- **Első lépés:** Mindig először vegyél fel szerzőket, utána könyveket!
- **Keresés:** A keresés és a műfaj szűrő egyszerre is használható
- **Mobilon:** A menüsáv automatikusan összecsukódik kis képernyőn
- **Minta adatok:** Az alkalmazás első indításkor automatikusan feltölt 5 szerzőt és 12 könyvet
