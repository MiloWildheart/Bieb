using Bieb.Models;
using Bieb.ViewModel;
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
    /// Interaction logic for AddOrUpdateBiebItemView.xaml
    /// </summary>
    public partial class AddOrUpdateBiebItemView : Window
    {
        public AddOrUpdateBiebItemView(BiebItem? biebItem)
        {
            this.DataContext = new AddOrUpdateBiebItemViewModel(biebItem);
            InitializeComponent();

        }
    }
}
