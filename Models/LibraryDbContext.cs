using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Reflection.Emit;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public IEnumerable<Book> GetBooksByAuthor(int authorId)
    {
        return Database.SqlQuery<Book>("GetBooksByAuthor @AuthorId", new SqlParameter("@AuthorId", authorId));
    }
    
}
