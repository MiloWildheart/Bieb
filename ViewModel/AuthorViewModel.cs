using Bieb.Models;
using Bieb.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using static Bieb.Commands.Icommand;
using System.ComponentModel;
using System.Windows;

namespace Bieb.ViewModel
{
    class AuthorViewModel : ObservableObject
    {
        private readonly BiebDbContext _db;
        private Author selectedAuthor;
        private bool enableDeleteButton = false;
        private bool enableEditButton = false;

        public ObservableCollection<Author> Authors { get; set; } = new();
        public Author SelectedAuthor
        {
            get => selectedAuthor; set
            {
                selectedAuthor = value;
                SetProperty(ref enableDeleteButton, value is not null, nameof(EnableDeleteButton));
                SetProperty(ref enableEditButton, value is not null, nameof(EnableEditButton));
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }
        public bool EnableDeleteButton { get => enableDeleteButton; set => enableDeleteButton = value; }
        public bool EnableEditButton { get => enableEditButton; set => enableEditButton = value; }


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; }

        public ICommand BackCommand { get; }


        public AuthorViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            LoadData();

            AddCommand = new RelayCommand(AddAuthor);
            DeleteCommand = new RelayCommand(DeleteAuthor);
            EditCommand = new RelayCommand(EditAuthor);
            BackCommand = new DelegateCommand(ExecuteBackCommand);
        }

        private void DeleteAuthor()
        {
            if (SelectedAuthor is null)
            {
                return;
            }

            _db.Authors.Remove(SelectedAuthor);
            _db.SaveChanges();
            Authors.Remove(SelectedAuthor);
        }

        //add command
        private void AddAuthor()
        {
            var addAuthorWindow = new AddOrUpdateAuthorView(null);
            addAuthorWindow.ShowDialog();

            LoadData();
        }
        private void EditAuthor()
        {
            if(SelectedAuthor is null)
            { 
                return; 
            }

            var addAuthorWindow = new AddOrUpdateAuthorView(SelectedAuthor);
            
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

            var newData = _db.Authors.Include(x => x.BiebItems).ToList();

            Authors.Clear();
            foreach (var item in newData)
            {
                Authors.Add(item);
            }
        }
        protected new virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
