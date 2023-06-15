using Bieb.Views;
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

namespace Bieb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GoToAuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorListView authorListView = new AuthorListView();
            authorListView.Show();
            Close(); // Optional: Close the MainWindow if desired
        } 
        private void GoToBiebItemsButton_Click(object sender, RoutedEventArgs e)
        {
            BiebItemListView biebItemListView = new BiebItemListView();
            biebItemListView.Show();
            Close(); // Optional: Close the MainWindow if desired
        }
    }
}
