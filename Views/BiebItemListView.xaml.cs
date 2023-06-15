using System;
using System.Collections.Generic;
using System.Linq;
using Bieb.Models;
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

namespace Bieb.Views
{
    /// <summary>
    /// i only put filtertextbox options here.
    /// </summary>
    public partial class BiebItemListView : Window
    {
        public BiebItemListView()
        {
            InitializeComponent();
        }
        
        
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BiebItemList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var BiebItem = (BiebItem)obj;

            return BiebItem.Titel.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
        
    }
}
