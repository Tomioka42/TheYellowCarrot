using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TheYellowCarrot.Data;
using TheYellowCarrot.Models;
using TheYellowCarrot.Repositories;

namespace TheYellowCarrot
{
    /// <summary>
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {

        private List<Ingredient> ingredients = new();
        public AddRecipeWindow()
        {
            InitializeComponent();



            UpdateUi();

        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtRecipeName.Text;
            string? selectedTag = lbSelectedTag.ToString();

            if (string.IsNullOrEmpty(recipeName) || string.IsNullOrEmpty(selectedTag))
            {
                MessageBox.Show("If you want to save the recipe, you need to enter all the fields!");
            }
            else
            {
                using (AppDbContext context = new())
                {
                    Recipe newRecipe = new();
                    newRecipe.Name = recipeName;
                    newRecipe.Ingredients = ingredients;

                    newRecipe.Tag.Name = selectedTag;

                    new RecipeRepo(context).AddRecipe(newRecipe);
                    context.SaveChanges();
                }

                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
        }

        private void btnAddToLvIngredient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient? ingredient = new();

            ingredient.Name = txtIngredientName.Text.Trim();
            ingredient.Quantity = txtIngredientQuantity.Text.Trim();
            ingredients.Add(ingredient);
            txtIngredientName.Clear();
            txtIngredientQuantity.Clear();
            lvIngredients.Items.Clear();

            foreach (Ingredient i in ingredients)
            {
                ListViewItem item = new();
                lvIngredients.Items.Add(item);
                item.Content = i.DisplayString;
                item.Tag = i;
            }


        }



        private void UpdateUi()
        {
            lvIngredients.Items.Clear();
            cbTags.Items.Clear();

            using (AppDbContext context = new())
            {
                List<Tag> tags = context.Tags.ToList();

                foreach (Tag tag in tags)
                {
                    ComboBoxItem cbItem = new();
                    cbItem.Content = tag.Name;
                    cbItem.Tag = tag;

                    cbTags.Items.Add(cbItem);
                }
            }

        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            var selectedTag = cbTags.SelectedItem as Tag;

            lbSelectedTag.Content = cbTags.Text.ToString();
            lbSelectedTag.Tag = selectedTag;
        }
    }
}


//using (AppDbContext context = new())
//{
//    List<Tag> tags = new TagRepo(context).GetTags();

//    foreach (Tag tag in tags)
//    {
//        ComboBoxItem item = new();

//        item.Content = tag.Name;
//        item.Tag = tag;

//        cbTags.Items.Add(item);
//    }
//}
