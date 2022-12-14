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
	public DbSet<Tag> Tags { get; set; }
	public DbSet<Ingredient> Ingredients { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TheYellowCarrotDb;Trusted_Connection=True;");
	}

	// Creatar alla ingredienser,Tags och recept när databasen skapas
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Ingredient>().HasData(new Ingredient()
		{
			IngredientId = 1,
			Name = "Cheese",
			Quantity = "100g",
			RecipeId = 1
		}, new Ingredient()
		{
			IngredientId = 2,
			Name = "Bread",
			Quantity = "2 Skivor",
			RecipeId = 1
		}, new Ingredient()
		{
			IngredientId = 3,
			Name = "Butter",
			Quantity = "30g",
			RecipeId = 1
		}, new Ingredient()
		{
			IngredientId = 4,
			Name = "Macaroni",
			Quantity = "150g",
			RecipeId = 2
		}, new Ingredient()
		{
			IngredientId = 5,
			Name = "Meatballs",
			Quantity = "100g",
			RecipeId = 2
		});

		modelBuilder.Entity<Tag>().HasData(new Tag()
		{
			TagId = 1,
			Name = "Vegetarian"
		}, new Tag()
		{
			TagId = 2,
			Name = "Vegan"
		}, new Tag()
		{
			TagId = 3,
			Name = "Glutenfri"
		}, new Tag()
		{
			TagId = 4,
			Name = "Laktosfri"
		});


		modelBuilder.Entity<Recipe>().HasData(new Recipe()
		{
			RecipeId = 1,
			Name = "Grilled Cheese Sandwich",
			CookTime = "15 min"

		}, new Recipe()
		{
			RecipeId = 2,
			Name = "Macaroni n Meatballs",
			CookTime = "30 min",
			TagId = 4
		});
	}
}
