using FMS_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FMS_BLL;

namespace FMS_PLL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        static CreatePage1 createPage1;
        static CreatePage2 createPage2;
        Film newFilm;

        public CreateWindow()
        {
            InitializeComponent();

            createPage1 = new CreatePage1();
            createPage2 = new CreatePage2();

            frmCreate.NavigationService.Navigate(createPage1);
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmCreate.Content = createPage1;
            btnBack.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            btnFinish.Visibility = Visibility.Hidden;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategories = string.Empty;
            #region Category
            List<MyCheckboxClass> selectedCatList = createPage1.categories.Where(item => item.IsSelected == true).ToList();
            foreach (var item in selectedCatList)
            {
                if(selectedCategories == string.Empty)
                    selectedCategories = item.TheText;
                else
                    selectedCategories += ", " + item.TheText;
            }
            #endregion

            string selectedLanguages = string.Empty;
            #region Language
            List<MyCheckboxClass> selectedLangList = createPage1.languages.Where(item => item.IsSelected == true).ToList();
            foreach (var item in selectedLangList)
            {
                if (selectedLanguages == string.Empty)
                    selectedLanguages = item.TheText;
                else
                    selectedLanguages += ", " + item.TheText;
            }
            #endregion

            newFilm = new Film()
            {
                Title = createPage1.txtTitle.Text.Trim(),
                Description = createPage1.txtDescription.Text.Trim(),
                Actors = createPage1.txtActors.Text.Trim(),
                Category = selectedCategories,
                Language = selectedLanguages
            };

            if (createPage1.txtReleaseYear.Text != string.Empty)
                newFilm.ReleaseYear = int.Parse(createPage1.txtReleaseYear.Text.Trim());
            if (createPage1.txtRating.Text != string.Empty)
                newFilm.Rating = float.Parse(createPage1.txtRating.Text.Trim());
            if (createPage1.txtLength.Text != string.Empty)
                newFilm.Length = short.Parse(createPage1.txtLength.Text.Trim());

            string error = FMS_BLL.Validation.ValidateFilm(newFilm);
            if (error == string.Empty)
            {
                frmCreate.Content = createPage2;
                btnBack.Visibility = Visibility.Visible;
                btnNext.Visibility = Visibility.Hidden;
                btnFinish.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show(error);
        }
        
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            if (createPage2.txtRentalDuration.Text != string.Empty)
                newFilm.RentalDuration = int.Parse(createPage2.txtRentalDuration.Text);
            if (createPage2.txtRentalRate.Text != string.Empty)
                newFilm.RentalRate = double.Parse(createPage2.txtRentalRate.Text);
            if (createPage2.txtReplacementCost.Text != string.Empty)
                newFilm.ReplacementCost = double.Parse(createPage2.txtReplacementCost.Text);

            string error = FMS_BLL.Validation.ValidateFilm(newFilm);
            if (error != string.Empty)
                MessageBox.Show(error);
            
            else
            {
                if (Operation.Create(newFilm))
                    MessageBox.Show("\tFilm Added Successfully!\t");
                else
                    MessageBox.Show("\tOOPS! Something Went Wrong.\t");

                this.Close();
            }
        }
    }
}
