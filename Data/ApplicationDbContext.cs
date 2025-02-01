namespace mvc.Data;

using Microsoft.EntityFrameworkCore;
using mvc.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<BooksEntity> Books { get; set; }
}