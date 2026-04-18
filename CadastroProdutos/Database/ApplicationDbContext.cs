using System;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Produto> Produtos { get; set; }
}