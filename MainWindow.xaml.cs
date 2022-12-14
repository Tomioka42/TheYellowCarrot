using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TheYellowCarrot.Data;
using TheYellowCarrot.Models;
using TheYellowCarrot.Repositories;

namespace TheYellowCarrot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            btnDetails.IsEnabled = false;
            btnDeleteRecipe.IsEnabled = false;

            UpdateUi();
        }

        // Sends User to Add Recipe Window
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new();
            addRecipeWindow.Show();

            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem? selectedItem = lvDisplayRecipes.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                Recipe? recipe = selectedItem.Tag as Recipe;
                DetailsWindow detailsWindow = new(recipe);
                detailsWindow.Show();
                Close();
            }
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)((ListViewItem)lvDisplayRecipes.SelectedItem).Tag;

            if (selectedRecipe == null)
            {
                MessageBox.Show("you need to select a recipe to delete it");
            }
            else
            {
                using (AppDbContext context = new())
                {
                    context.Recipes.Remove(selectedRecipe);
                    context.SaveChanges();
                }

                UpdateUi();
            }
        }

        // Uppdaterar Ui
        private void UpdateUi()
        {
            lvDisplayRecipes.Items.Clear();

            using (AppDbContext context = new())
            {
                List<Recipe> recipes = new RecipeRepo(context).GetRecipes();

                foreach (Recipe recipe in recipes)
                {
                    ListViewItem item = new();

                    item.Content = recipe.Name;
                    item.Tag = recipe;

                    lvDisplayRecipes.Items.Add(item);
                }
            }
        }

        private void lvDisplayRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDetails.IsEnabled = true;
            btnDeleteRecipe.IsEnabled = true;
        }
    }
}
