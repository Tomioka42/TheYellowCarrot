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

	// Get All Ingrediens form recipe

	public void GetIngrediensFromRecipe(Recipe ingredientsToAdd)
	{
		_context.Recipes.Add(ingredientsToAdd);
	}
}
