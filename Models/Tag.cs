using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheYellowCarrot.Models;

public class Tag
{
    [Key]
    public int TagId { get; set; }
    public string Name { get; set; } = null!;
    public List<Recipe> Recipes { get; set; } = new();
}
