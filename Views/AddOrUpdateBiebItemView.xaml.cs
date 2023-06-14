using Bieb.Models;
using Bieb.ViewModel;
using System.Windows;
using System.Windows.Controls;

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

        /// <summary>
        /// There was no way to bind the selected items of an author to the "Multiple" selection mode listbox. Therefore we have to use the codebehind to send this to the viewmodel.
        /// This is not business logic because it is view-related data. Actual handling and usage of these selected items is still correctly done in the viewmodel!
        /// </summary>
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = (AddOrUpdateBiebItemViewModel)DataContext;

            foreach (var item in e.RemovedItems)
            {
                var author = (Author)item;
                vm.SelectedAuthors.Remove(author);
            }

            foreach (var item in e.AddedItems)
            {
                var author = (Author)item;
                vm.SelectedAuthors.Add(author);
            }
        }
    }
}
