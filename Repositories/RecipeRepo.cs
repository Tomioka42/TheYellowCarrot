using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
        return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Tags).FirstOrDefault(r => r.RecipeId == id);
    }

    // Hämtar ingredients och Tag från recipe
    public List<Recipe> GetRecipes()
    {
        return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Tags).ToList();
    }

    // Lägger till ingrediens till recipe
    public void AddIngredientToRecipe(Ingredient ingredientToAdd)
    {
        try
        {
            _context.Recipes.Add(GetRecipe(ingredientToAdd.RecipeId));
        }
        catch (NullReferenceException ex)
        {
            MessageBox.Show($"Error {ex.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

    }

    // Lägger till recipe
    public void AddRecipe(Recipe recipeToAdd)
    {
        _context.Recipes.Add(recipeToAdd);
    }

    // uppdaterar valda recipe
    public void UpdateRecipe(Recipe recipeToUpdate)
    {
        _context.Recipes.Update(recipeToUpdate);
    }

    // Tar bort recept från databasen
    public void DeleteRecipe(Recipe recipeToRemove)
    {
        _context.Recipes.Remove(recipeToRemove);
    }
}


