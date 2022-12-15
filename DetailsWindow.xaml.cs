using System;
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

    }

    // Låser upp alla knappar
    private void btnUnlock_Click(object sender, RoutedEventArgs e)
    {
        btnSave.IsEnabled = true;
        btnAddIngredient.IsEnabled = true;
    }

    // Lägger till nya ingredienser i receptet och displayar den till listviewn
    private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
    {
        try
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
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    // Sparar alla ändringar till databasen
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (txtNewRecipeName.Text.Length > 3)
            {
                string newName = txtNewRecipeName.Text;

                if (newName != null)
                {
                    _recipe!.Name = newName;

                    using (AppDbContext context = new())
                    {
                        new RecipeRepo(context).UpdateRecipe(_recipe);
                        context.SaveChanges();
                    }
                }
            }
        }
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    // Tar bort ingrediensen från Databasen
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            ListViewItem? selectedItem = lvDisplayIngredients.SelectedItem as ListViewItem;

            Ingredient? selectedIngredient = selectedItem?.Tag as Ingredient;

            if (selectedItem != null)
            {
                _recipe?.Ingredients.Remove(selectedIngredient!);

                using (AppDbContext context = new())
                {
                    new IngredientRepo(context).RemoveIngredient(selectedIngredient!);
                    context.SaveChanges();
                }

                UpdateUi();
            }
        }
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
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
        try
        {
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
            if (_recipe?.Tags != null)
            {
                lbTag.Content = _recipe.Tags.Name.ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


    }

    // Sätter delete appen till enabled när man selectar ett item i listviewn
    private void lvDisplayIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        btnDelete.IsEnabled = true;
    }
}


