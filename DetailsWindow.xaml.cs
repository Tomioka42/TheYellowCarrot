using System.Windows;
using System.Windows.Controls;
using TheYellowCarrot.Data;
using TheYellowCarrot.Models;
using TheYellowCarrot.Repositories;

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

        btnAddIngredient.IsEnabled = false;
        btnDelete.IsEnabled = false;
        btnSave.IsEnabled = false;

        UpdateUi();

        // TODO Du ska göra så att delete och add knappen ska komma in

    }

    private void btnUnlock_Click(object sender, RoutedEventArgs e)
    {
        btnSave.IsEnabled = true;
        btnAddIngredient.IsEnabled = true;
    }

    private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
    {

        var ingredientName = txtNewIngredient.Text.Trim();
        var ingredientQuantity = txtNewQuantity.Text.Trim();


        Ingredient ingredient = new();
        ingredient.Name = ingredientName;
        ingredient.Quantity = ingredientQuantity;
        ingredient.RecipeId = _recipe.RecipeId;
        ingredient.recipes = _recipe;

        _recipe.Ingredients.Add(ingredient);

        using (AppDbContext context = new())
        {
            new IngredientRepo(context).AddIngredient(ingredient);
            new RecipeRepo(context).AddIngredientToRecipe(ingredient);
        }

        UpdateUi();
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        using (AppDbContext context = new())
        {
            new RecipeRepo(context).GetRecipe(_recipe.RecipeId);
            context.SaveChanges();
        }
    }

    // Tar bort ingrediensen från Databasen
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        ListViewItem? selectedItem = lvDisplayIngredients.SelectedItem as ListViewItem;

        Ingredient? selectedIngredient = selectedItem.Tag as Ingredient;

        if (selectedItem != null)
        {
            _recipe.Ingredients.Remove(selectedIngredient);

            using (AppDbContext context = new())
            {
                context.Ingredients.Remove(selectedIngredient);
            }

            UpdateUi();
        }

    }

    // Exitar Details window och återvänder till mainwindow utan att ändra något
    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new();
        mainWindow.Show();

        Close();
    }

    // uppdaterar Ui
    private void UpdateUi()
    {
        lvDisplayIngredients.Items.Clear();

        if (_recipe != null)
        {
            lbCurrentRecipeName.Content = _recipe.Name;

            foreach (Ingredient ingredient in _recipe.Ingredients)
            {
                ListViewItem item = new ListViewItem();

                item.Content = ingredient.DisplayString;
                item.Tag = ingredient;

                lvDisplayIngredients.Items.Add(item);
            }
        }
        if (_recipe?.Tag != null)
        {
            lbTag.Content = _recipe.Tag.Name.ToString();
        }
    }

    private void lvDisplayIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        btnDelete.IsEnabled = true;
    }
}


