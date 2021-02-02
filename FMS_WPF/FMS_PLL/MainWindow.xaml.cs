using FMS_BLL;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] allCategories = { "Action", "Adventure", "Comedy", "Crime", "Drama", "Historical", "Horror", "Musical", "Mystery", "Romance", "Science Fiction", "Thriller", "War" };
        public static string[] allLanguages = { "English", "French", "German", "Hindi", "Italian", "Japanese", "Korean", "Malayali", "Tamil", "Telugu" };

        public MainWindow()
        {
            InitializeComponent();
            dgFilmList.ItemsSource = Operation.ViewAll();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow();
            createWindow.ShowDialog();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
        }
    }
    public class MyCheckboxClass
    {
        public string TheText { get; set; }
        public bool IsSelected { get; set; }
    }

}
