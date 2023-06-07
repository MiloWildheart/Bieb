using Bieb.Models;
using Bieb.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bieb.Commands.Icommand;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    class AuthorViewModel : NotifyPropertyChanged
    {
     
      
        public AuthorViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);
            _db.Authors.Load();

          
            DeleteCommand = new Icommand.DelegateCommand(CanDeleteAuthor, DeleteAuthor);

        }

        private readonly BiebDbContext _db = new();
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<(string, string)> AuthorNames { get; set; }
        
        //add command
        private void AddAuthor(object parameter)
        {
            // Create a new person based on the input
            var author = new Author();

            // Add the person to the collection
            Authors.Add(author);
            _db.SaveChanges();
        }

        //Delete command
        public ICommand DeleteCommand { get; set; }
        private void DeleteAuthor(object parameter)
        {
            if (parameter is Author author)
            {
                // Perform the delete operation on the selected author
                Authors.Remove(author);
            }
        }
        private bool CanDeleteAuthor(object parameter)
        {
            return parameter is Author;
        }

      
       

    }
}
