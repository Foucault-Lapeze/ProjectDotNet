using Microsoft.EntityFrameworkCore;

namespace ProjetDotNet.Models;

public class BDDContext : DbContext
{
    public BDDContext(DbContextOptions<BDDContext> options) : base(options)
    {
        
    }
    public DbSet<ToDoItem> TodoItems { get; set; }
    public DbSet<Voiture> Voitures { get; set; }
}