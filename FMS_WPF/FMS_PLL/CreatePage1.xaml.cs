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
    /// Interaction logic for pgCreate1.xaml
    /// </summary>
    public partial class CreatePage1 : Page
    {
        public List<MyCheckboxClass> categories { get; set; }
        public List<MyCheckboxClass> languages { get; set; }

        public CreatePage1()
        {
            InitializeComponent();

            AddCategories();
            AddLanguages();
        }

        public void AddCategories()
        {
            categories = new List<MyCheckboxClass>();

            foreach (string item in MainWindow.allCategories)
            {
                MyCheckboxClass category = new MyCheckboxClass();
                category.TheText = item;
                categories.Add(category);
            }

            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Action" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Adventure" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Comedy" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Crime" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Drama" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Historical" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Horror" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Musical" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Mystery" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Romance" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Science Fiction" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "Thriller" });
            //categories.Add(new MyCheckboxClass { IsSelected = false, TheText = "War" });

            lboxCategory.DataContext = categories;
        }

        public void AddLanguages()
        {
            languages = new List<MyCheckboxClass>();

            foreach (string item in MainWindow.allLanguages)
            {
                MyCheckboxClass language = new MyCheckboxClass();
                language.TheText = item;
                languages.Add(language);
            }

            lboxLanguage.DataContext = languages;
        }
    }

}
