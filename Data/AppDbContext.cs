using Microsoft.EntityFrameworkCore;
using TheYellowCarrot.Models;

namespace TheYellowCarrot.Data;

public class AppDbContext : DbContext
{
	public AppDbContext()
	{

	}

	public AppDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<Recipe> Recipes { get; set; }
	public DbSet<Tags> Tags { get; set; }
	public DbSet<Ingredient> Ingredients { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TheYellowCarrotDb;Trusted_Connection=True;");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

	}
}
