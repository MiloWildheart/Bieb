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

namespace Bieb.ViewModel
{
    class AuthorViewModel : ObservableObject
    {
        private readonly BiebDbContext _db;
        private Author selectedAuthor;
        private bool enableDeleteButton = false;

        public ObservableCollection<Author> Authors { get; set; } = new();
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
        public ICommand DeleteCommand { get; set; }


        public AuthorViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            LoadData();

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
            var addAuthorWindow = new AddOrUpdateAuthorView(null);
            addAuthorWindow.ShowDialog();

            LoadData();
        }

        private void LoadData()
        {
            var newData = _db.Authors.ToList();

            Authors.Clear();
            foreach (var item in newData)
            {
                Authors.Add(item);
            }
        }

    }
}
