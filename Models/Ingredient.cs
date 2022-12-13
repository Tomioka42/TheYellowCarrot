using System.ComponentModel.DataAnnotations;

namespace TheYellowCarrot.Models;

public class Ingredient
{
    [Key]
    public int IngredientId { get; set; }
    public string Name { get; set; } = null!;
    public string Quantity { get; set; } = null!;

    public string DisplayString => $"{Name} / {Quantity}";
    public int RecipeId { get; set; }
    public Recipe? recipes { get; set; }
}
