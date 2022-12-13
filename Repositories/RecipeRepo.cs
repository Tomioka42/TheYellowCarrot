using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheYellowCarrot.Data;
using TheYellowCarrot.Models;

namespace TheYellowCarrot.Repositories;

public class RecipeRepo
{
    private readonly AppDbContext _context;

    public RecipeRepo(AppDbContext context)
    {
        _context = context;
    }

    // Get's RecipeId, Tag and Ingredients
    public Recipe? GetRecipe(int id)
    {
        return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Tag).FirstOrDefault(r => r.RecipeId == id);
    }

    // Hämtar ingredients och Tag från recipe
    public List<Recipe> GetRecipes()
    {
        return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Tag).ToList();
    }

    public void AddRecipe(Recipe recipeToAdd)
    {
        _context.Recipes.Add(recipeToAdd);
    }
}


