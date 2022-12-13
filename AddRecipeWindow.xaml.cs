using System.Collections.Generic;
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
        public AddRecipeWindow()
        {
            InitializeComponent();


            UpdateUi();
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddToLvIngredient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateUi()
        {
            lvIngredients.Items.Clear();
            cbTags.Items.Clear();

            using (AppDbContext context = new())
            {
                List<Tag> tags = new TagRepo(context).GetTags();

                foreach (Tag tag in tags)
                {
                    ComboBoxItem item = new();

                    item.Content = tag.Name;
                    item.Tag = tag;

                    cbTags.Items.Add(item);
                }
            }
        }
    }
}
