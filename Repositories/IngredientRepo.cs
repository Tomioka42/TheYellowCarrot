using TheYellowCarrot.Data;
using TheYellowCarrot.Models;

namespace TheYellowCarrot.Repositories;

public class IngredientRepo
{
    private readonly AppDbContext _context;
    public IngredientRepo(AppDbContext context)
    {
        _context = context;
    }

    public void RemoveIngredient(Ingredient ingredientToRemove)
    {
        _context.Ingredients.Remove(ingredientToRemove);
    }
}
