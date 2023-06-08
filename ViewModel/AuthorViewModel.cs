using Bieb.Models;
using Bieb.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static Bieb.Commands.Icommand;

namespace Bieb.ViewModel
{
    class AuthorViewModel : ObservableObject
    {
        private readonly BiebDbContext _db;
        private Author selectedAuthor;
        private bool enableDeleteButton = false;

        public ObservableCollection<Author> Authors { get; set; }
        public Author SelectedAuthor
        {
            get => selectedAuthor; set
            {
                selectedAuthor = value;
                SetProperty(ref enableDeleteButton, value is not null, nameof(EnableDeleteButton));
            }
        }
        public bool EnableDeleteButton { get => enableDeleteButton; set => enableDeleteButton = value; }


        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; set; }


        public AuthorViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);
            Authors = new ObservableCollection<Author>(_db.Authors.ToList()); //TODO: Use async loading (not in ctor??)

            SaveCommand = new DelegateCommand(SaveAuthor);
            AddCommand = new DelegateCommand(AddAuthor);
            DeleteCommand = new RelayCommand(DeleteAuthor);


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
        private void AddAuthor(object parameter)
        {
            // Create a new person based on the input
            var author = new Author();

            var addAuthorWindow = new AddAuthorView();
            addAuthorWindow.ShowDialog();

            // Add the person to the collection
            Authors.Add(author);

        }

        private void SaveAuthor(object parameter)
        {
            // Get the author details from the input fields in the view
            string authorName = ((AddAuthorView)Application.Current.MainWindow).txtAuthorName.Text;

            // Create a new author object with the entered details
            var newAuthor = new Author
            {
                Name = authorName
                // Set other author properties as needed
            };

            // Add the new author to the collection
            Authors.Add(newAuthor);

            // Save changes to the database
            _db.SaveChanges();

            // Close the AddAuthorView window and return to MainWindow
            Application.Current.MainWindow.Close();
        }

        //Delete command
        private void DeleteAuthor(object parameter)
        {
            if (SelectedAuthor != null)
            {
                // Perform the delete operation on the selected author
                Authors.Remove(SelectedAuthor);
                _db.Authors.Remove(SelectedAuthor);
                _db.SaveChanges();
            }
        }
        private bool CanDeleteAuthor(object parameter)
        {
            return SelectedAuthor != null;
        }




    }
}
