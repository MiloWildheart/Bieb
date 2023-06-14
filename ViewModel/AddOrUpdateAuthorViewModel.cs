using Bieb.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    public class AddOrUpdateAuthorViewModel : ObservableObject
    {
        public Author Author { get; }
        public bool IsEditing { get; }

        public ICommand SaveCommand { get; }

        private BiebDbContext _db;

        public AddOrUpdateAuthorViewModel(Author? author)
        {
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            Author = author ?? new();
            IsEditing = author != null;
        }

        public void Save()
        {
            if (!IsEditing)
            {
                _db.Authors.Add(Author);
            }
            _db.SaveChanges();
        }
    }
}
