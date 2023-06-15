using Bieb.Models;
using Bieb.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Bieb.Commands.Icommand;

namespace Bieb.ViewModel
{

    public class BiebItemViewModel : ObservableObject
    {
        private readonly BiebDbContext _db;
        private BiebItem selectedBiebItem;
        private bool enableDeleteButton = false;
        private bool enableEditButton = false;

        public ObservableCollection<BiebItem> BiebItems { get; set; } = new();
        public BiebItem SelectedBiebItem
        {
            get => selectedBiebItem; set
            {
                selectedBiebItem = value;
                SetProperty(ref enableDeleteButton, value is not null, nameof(EnableDeleteButton));
                SetProperty(ref enableEditButton, value is not null, nameof(EnableEditButton));
                OnPropertyChanged(nameof(SelectedBiebItem));
            }
        }
        public bool EnableDeleteButton { get => enableDeleteButton; set => enableDeleteButton = value; }
        public bool EnableEditButton { get => enableEditButton; set => enableEditButton = value; }

        //Icommands
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; }
        public ICommand BackCommand { get; }


        public BiebItemViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            LoadData();

            AddCommand = new RelayCommand(AddBiebItem); //relay command is more up-to-date
            DeleteCommand = new RelayCommand(DeleteBiebItem);
            EditCommand = new RelayCommand(EditBiebItem);
            BackCommand = new DelegateCommand(ExecuteBackCommand); //delegate command because i had to

        }
        private void DeleteBiebItem() //delete selected biebitem
        {
            if (SelectedBiebItem is null)
            {
                return;
            }
            _db.BiebItems.Remove(SelectedBiebItem);
            _db.SaveChanges();
            BiebItems.Remove(SelectedBiebItem);
        }

        private void AddBiebItem() //add or update window opens
        {

            var addBiebItemWindow = new AddOrUpdateBiebItemView(null);
            addBiebItemWindow.ShowDialog();

            LoadData();
        }

        private void EditBiebItem() //add or update window opens with selected biebitem data loaded
        {
            if (SelectedBiebItem is null)
            {
                return;
            }

            var addAuthorWindow = new AddOrUpdateBiebItemView(SelectedBiebItem);

            addAuthorWindow.ShowDialog();

            LoadData();
        }

        private void ExecuteBackCommand(object parameter)
        {
            // Create an instance of the MainWindow
            MainWindow mainWindow = new MainWindow();

            // Get the current window
            Window currentWindow = Application.Current.MainWindow;

            // Set the MainWindow as the new current window
            Application.Current.MainWindow = mainWindow;

            // Close the current window
            currentWindow.Close();

            // Show the MainWindow
            mainWindow.Show();
        }

        private void LoadData()
        {
            

            var newData = _db.BiebItems.Include(x => x.Authors).ToList();

            BiebItems.Clear();
            foreach (var item in newData)
            {
                BiebItems.Add(item);
            }
        }
        protected new virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
