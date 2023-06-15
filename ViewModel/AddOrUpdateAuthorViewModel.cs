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
        
        //indicates whether you're in editting mode
        private bool _isEditing;

        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }

        public ICommand SaveCommand { get; } //command to save changes

        private BiebDbContext _db;

        public AddOrUpdateAuthorViewModel(Author? author)
        {
            //initialize save and database context. CHANGE THE STRING ON DIFFERENT COMPUTERS.
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            //set author and determine if its in editting mode
            Author = author ?? new();
            IsEditing = author != null;
        }


        //save changed to database
        public void Save()
        {
            if (!IsEditing)
            {
                _db.Authors.Add(Author); //adding to database
            }
            _db.SaveChanges(); //save to database
            
            IsEditing = true; //is editting to true after saving
        }
    }
}
