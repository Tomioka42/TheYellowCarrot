using System;
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


        // Click event som lägger till ett recept i databasen
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ingredients.Count == 0 && txtRecipeName.Text.Length == 0)
                {
                    MessageBox.Show("You need to enter a name and some ingredients to add the recipe");
                }
                else if (ingredients.Count > 0 && txtRecipeName.Text.Length > 0)
                {

                    if (cbTags.SelectedItem == null)
                    {
                        string recipeName = txtRecipeName.Text;

                        using (AppDbContext context = new())
                        {
                            Recipe newRecipe = new();
                            newRecipe.Name = recipeName;
                            newRecipe.Ingredients = ingredients;

                            newRecipe.TagId = null;

                            new RecipeRepo(context).AddRecipe(newRecipe);
                            context.SaveChanges();

                            MainWindow mainWindow = new();
                            mainWindow.Show();
                            Close();
                        }

                    }
                    else if (cbTags.SelectedItem != null)
                    {
                        string recipeName = txtRecipeName.Text;
                        Tag selectedTag = (Tag)((ComboBoxItem)cbTags.SelectedItem).Tag;

                        if (string.IsNullOrEmpty(recipeName) || selectedTag != null)
                        {
                            using (AppDbContext context = new())
                            {
                                Recipe newRecipe = new();
                                newRecipe.Name = recipeName;
                                newRecipe.Ingredients = ingredients;

                                newRecipe.TagId = selectedTag.TagId;

                                new RecipeRepo(context).AddRecipe(newRecipe);
                                context.SaveChanges();

                                MainWindow mainWindow = new();
                                mainWindow.Show();
                                Close();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnAddToLvIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Om man lägger till en ingrediens som inte har ett namn eller quantity
            // så blir det en tom sträng i ingredients listan. Dessa är tänkt att göra så att usern kan dela upp sitt recept
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }



        private void UpdateUi()
        {
            lvIngredients.Items.Clear();
            cbTags.Items.Clear();
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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



