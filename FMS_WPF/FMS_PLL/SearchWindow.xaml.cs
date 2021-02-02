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
using System.Data;

namespace FMS_PLL
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        static SearchPage searchPage;
        static EditPage editPage;
        Film myFilm;

        public SearchWindow()
        {
            InitializeComponent();

            searchPage = new SearchPage();
            editPage = new EditPage();

            btnSearch.Visibility = Visibility.Visible;
            dgMyFilms.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            btnRemove.Visibility = Visibility.Hidden;

            frmSearch.NavigationService.Navigate(searchPage);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            myFilm = new Film();

            if (searchPage.txtTitle.Text == string.Empty && searchPage.txtReleaseYear.Text == string.Empty && searchPage.txtRating.Text == string.Empty)
                MessageBox.Show("\t All Fields Are Empty! \t");
            else
            {
                if (searchPage.txtTitle.Text != string.Empty)
                    myFilm.Title = searchPage.txtTitle.Text.Trim();

                if (searchPage.txtReleaseYear.Text != string.Empty)
                    myFilm.ReleaseYear = int.Parse(searchPage.txtReleaseYear.Text.Trim());

                if (searchPage.txtRating.Text != string.Empty)
                    myFilm.Rating = float.Parse(searchPage.txtRating.Text.Trim());

                List<Film> myFilms = Operation.Search(myFilm);

                if (myFilms == null)
                {
                    dgMyFilms.ItemsSource = null;
                    MessageBox.Show("\tFilm Not Found!\t");
                }
                else
                    dgMyFilms.ItemsSource = myFilms;
            }
        }

        private void dgMyFilms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch.Content = editPage;

            myFilm = (Film)dgMyFilms.SelectedItems[0];

            btnUpdate.Visibility = Visibility.Visible;
            btnRemove.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            btnSearch.Visibility = Visibility.Hidden;
            dgMyFilms.Visibility = Visibility.Hidden;

            editPage.txtTitle.Text = myFilm.Title;
            editPage.txtDescription.Text = myFilm.Description;
            editPage.txtActors.Text = myFilm.Actors;
            editPage.txtLength.Text = myFilm.Length.ToString();
            editPage.txtRating.Text = myFilm.Rating.ToString();
            editPage.txtReleaseYear.Text = myFilm.ReleaseYear.ToString();
            editPage.txtRentalDuration.Text = myFilm.RentalDuration.ToString();
            editPage.txtRentalRate.Text = myFilm.RentalRate.ToString();
            editPage.txtReplacementCost.Text = myFilm.ReplacementCost.ToString();
            editPage.lboxCategory.DataContext = editPage.GetCategories(myFilm.Category);
            editPage.lboxLanguage.DataContext = editPage.GetLanguages(myFilm.Language);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            btnSearch.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            btnRemove.Visibility = Visibility.Hidden;
            dgMyFilms.Visibility = Visibility.Visible;
            frmSearch.Content = searchPage;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategories = string.Empty;
            #region Category
            List<MyCheckboxClass> selectedCatList = editPage.allCategoriesList.Where(item => item.IsSelected == true).ToList();
            foreach (var item in selectedCatList)
            {
                if (selectedCategories == string.Empty)
                    selectedCategories = item.TheText;
                else
                    selectedCategories += ", " + item.TheText;
            }
            #endregion

            string selectedLanguages = string.Empty;
            #region Language
            List<MyCheckboxClass> selectedLangList = editPage.allLanguagesList.Where(item => item.IsSelected == true).ToList();
            foreach (var item in selectedLangList)
            {
                if (selectedLanguages == string.Empty)
                    selectedLanguages = item.TheText;
                else
                    selectedLanguages += ", " + item.TheText;
            }
            #endregion

            myFilm = new Film()
            {
                Title = editPage.txtTitle.Text.Trim(),
                Description = editPage.txtDescription.Text.Trim(),
                Actors = editPage.txtActors.Text.Trim(),
                Category = selectedCategories,
                Language = selectedLanguages
            };

            if (editPage.txtReleaseYear.Text != string.Empty)
                myFilm.ReleaseYear = int.Parse(editPage.txtReleaseYear.Text.Trim());
            if (editPage.txtRating.Text != string.Empty)
                myFilm.Rating = float.Parse(editPage.txtRating.Text.Trim());
            if (editPage.txtLength.Text != string.Empty)
                myFilm.Length = short.Parse(editPage.txtLength.Text.Trim());

            if (editPage.txtRentalDuration.Text != string.Empty)
                myFilm.RentalDuration = int.Parse(editPage.txtRentalDuration.Text);
            if (editPage.txtRentalRate.Text != string.Empty)
                myFilm.RentalRate = double.Parse(editPage.txtRentalRate.Text);
            if (editPage.txtReplacementCost.Text != string.Empty)
                myFilm.ReplacementCost = double.Parse(editPage.txtReplacementCost.Text);

            string error = FMS_BLL.Validation.ValidateFilm(myFilm);
            if (error != string.Empty)
                MessageBox.Show(error);

            else
            {
                if (Operation.Update(myFilm))
                    MessageBox.Show("\tFilm Updated Successfully!\t");
                else
                    MessageBox.Show("\tOOPS! Something Went Wrong.\t");

                this.Close();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.Remove(myFilm.Title))
                MessageBox.Show("\tFilm Removed Successfully!\t");
            else
                MessageBox.Show("\tOOPS! Something Went Wrong.\t");

            this.Close();
        }

    }
}
