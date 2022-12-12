using System.Windows;
using TheYellowCarrot.Models;

namespace TheYellowCarrot;

/// <summary>
/// Interaction logic for DetailsWindow.xaml
/// </summary>
public partial class DetailsWindow : Window
{
    private readonly Recipe? _recipe;

    public DetailsWindow(Recipe? recipe)
    {
        InitializeComponent();

        _recipe = recipe;

        UpdateUi();
    }

    private void btnUnlock_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {

    }

    private void UpdateUi()
    {
        lvDisplayIngredients.Items.Clear();
        cbTags.Items.Clear();

        if (_recipe != null)
        {
            lbCurrentRecipeName.Content = _recipe.Name;


        }
    }
}

//using (AppDbContext context = new())
//{
//    var recipeIngredients = context.Recipes.Include(i => i.Ingredients).FirstOrDefault(r => r.Name == _recipe.Name).ToList();

//    foreach (var ingredient in recipeIngredients)
//    {
//        lvDisplayIngredients.Items.Add(ingredient);
//    }
//}



//lvDisplayIngredients.Items.Add(_recipe.Ingredients.ToList());

//using (AppDbContext context = new())
//{
//    cbTags.Items.Add(context.Tags.ToList());
//}
