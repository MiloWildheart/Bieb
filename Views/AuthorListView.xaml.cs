using Bieb.Models;
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

namespace Bieb.Views
{
    /// <summary>
    /// Interaction logic for AuthorListView.xaml
    /// </summary>
    public partial class AuthorListView : Window
    {
        public AuthorListView()
        {
            InitializeComponent();
        }

        private void AuthorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Your event handling logic here
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AuthorList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var Author = (Author)obj;

            return Author.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
