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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FMS_PLL
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public List<MyCheckboxClass> allCategoriesList { get; set; }
        public List<MyCheckboxClass> allLanguagesList { get; set; }
        public EditPage()
        {
            InitializeComponent();
        }

        public List<MyCheckboxClass> GetCategories(string myCategories)
        {
            allCategoriesList = new List<MyCheckboxClass>();

            foreach (string item in MainWindow.allCategories)
            {
                MyCheckboxClass category = new MyCheckboxClass();
                category.TheText = item;

                if (myCategories.Contains(item))
                    category.IsSelected = true;

                allCategoriesList.Add(category);
            }

            return allCategoriesList;
        }

        public List<MyCheckboxClass> GetLanguages(string myLanguages)
        {
            allLanguagesList = new List<MyCheckboxClass>();

            foreach (string item in MainWindow.allLanguages)
            {
                MyCheckboxClass language = new MyCheckboxClass();
                language.TheText = item;

                if (myLanguages.Contains(item))
                    language.IsSelected = true;

                allLanguagesList.Add(language);
            }

            return allLanguagesList;
        }
        
    }
}
