using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TheYellowCarrot.Data;
using TheYellowCarrot.Models;

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

        }

        private void UpdateUi()
        {
            lvDisplayRecipes.Items.Clear();

            using (AppDbContext context = new())
            {
                List<Recipe> recipes = context.Recipes.ToList();

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
