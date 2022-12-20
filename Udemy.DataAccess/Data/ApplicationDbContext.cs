using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy.Models;

namespace Udemy.DataAccess;

public class ApplicationDbContext:IdentityDbContext // install Microsoft entity fram work pacage
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) //we are passing the options and we are sending those options to the base class (program.c).
    {

    }
    public DbSet<Category> Categories { get; set; } // this will creat a table Categories in the database
    public DbSet<CoverType> CoverType { get; set; }
    public DbSet<Product> Product { get; set; }
}
