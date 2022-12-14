using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheYellowCarrot.Models;

public class Recipe
{
    [Key]
    public int RecipeId { get; set; }
    public string Name { get; set; } = null!;
    public string? CookTime { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new();
    public int? TagId { get; set; }
    public Tag? Tags { get; set; }

}
