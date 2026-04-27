using LibraryApi.Models;

namespace LibraryApi.Services;

public class SeedService
{
    private readonly BookService _bookService;
    private readonly AuthorService _authorService;

    public SeedService(BookService bookService, AuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    public async Task SeedAsync()
    {
        var existingBooks = await _bookService.GetAllAsync();
        if (existingBooks.Count > 0) return;

        var authors = new List<Author>
        {
            new Author { Name = "J.K. Rowling", Nationality = "Brit", BirthYear = 1965 },
            new Author { Name = "George Orwell", Nationality = "Brit", BirthYear = 1903 },
            new Author { Name = "Stephen King", Nationality = "Amerikai", BirthYear = 1947 },
            new Author { Name = "Agatha Christie", Nationality = "Brit", BirthYear = 1890 },
            new Author { Name = "Tolkien", Nationality = "Brit", BirthYear = 1892 },
        };

        var createdAuthors = new List<Author>();
        foreach (var author in authors)
            createdAuthors.Add(await _authorService.CreateAsync(author));

        var books = new List<Book>
        {
            new Book { Title = "Harry Potter és a bölcsek köve", AuthorId = createdAuthors[0].Id!, Year = 1997, Genre = "Fantasy", Description = "Egy fiatal varázsló kalandjai Roxfortban." },
            new Book { Title = "Harry Potter és a titkok kamrája", AuthorId = createdAuthors[0].Id!, Year = 1998, Genre = "Fantasy", Description = "Harry Potter második éve Roxfortban." },
            new Book { Title = "Harry Potter és az azkabani fogoly", AuthorId = createdAuthors[0].Id!, Year = 1999, Genre = "Fantasy", Description = "Egy veszélyes fogoly megszökik Azkabanból." },
            new Book { Title = "1984", AuthorId = createdAuthors[1].Id!, Year = 1949, Genre = "Disztópia", Description = "Egy totalitárius társadalom rémálma." },
            new Book { Title = "Állatfarm", AuthorId = createdAuthors[1].Id!, Year = 1945, Genre = "Szatíra", Description = "Egy farm állatainak forradalma." },
            new Book { Title = "A ragyogás", AuthorId = createdAuthors[2].Id!, Year = 1977, Genre = "Horror", Description = "Egy elszigetelt szálloda sötét titkai." },
            new Book { Title = "It", AuthorId = createdAuthors[2].Id!, Year = 1986, Genre = "Horror", Description = "Gyerekek harca egy ősi gonosz ellen." },
            new Book { Title = "Tíz kicsi néger", AuthorId = createdAuthors[3].Id!, Year = 1939, Genre = "Krimi", Description = "Tíz idegen egy szigeten – ki a gyilkos?" },
            new Book { Title = "Poirot karácsonya", AuthorId = createdAuthors[3].Id!, Year = 1938, Genre = "Krimi", Description = "Hercule Poirot ünnepi nyomozása." },
            new Book { Title = "A Gyűrűk Ura – A Gyűrű szövetsége", AuthorId = createdAuthors[4].Id!, Year = 1954, Genre = "Fantasy", Description = "Egy hobbit elindul megmenteni a világot." },
            new Book { Title = "A Gyűrűk Ura – A két torony", AuthorId = createdAuthors[4].Id!, Year = 1954, Genre = "Fantasy", Description = "A szövetség szétválik, a háború közeleg." },
            new Book { Title = "A Hobbit", AuthorId = createdAuthors[4].Id!, Year = 1937, Genre = "Fantasy", Description = "Bilbo Baggins nagy kalandja a sárkánnyal." },
        };

        foreach (var book in books)
            await _bookService.CreateAsync(book);
    }
}
