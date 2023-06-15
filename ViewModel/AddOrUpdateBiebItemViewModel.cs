using Bieb.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    class AddOrUpdateBiebItemViewModel : ObservableObject
    {

        public BiebItem BiebItem { get; set; }

        //observable collection of authors
        public ObservableCollection<Author> Authors { get; set; }

        //selected authors for biebitems
        public List<Author> SelectedAuthors { get; set; } = new();

        //indicate whether in editing mode
        public bool IsEditing { get; private set; }


        public ICommand SaveCommand { get; set; } //save command

        private BiebDbContext _db;

        public AddOrUpdateBiebItemViewModel(BiebItem? biebItem)
        {
            //initialize save command and database context
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);
            //load the authors from database into the authors collecttion and put in into a list
            Authors = new ObservableCollection<Author>(_db.Authors.ToList());

            //setting properties and determine whether in editting mode
            BiebItem = biebItem ?? new();
            IsEditing = biebItem != null;
        }

        //save changes
        public void Save()
        {
            
            BiebItem.Authors.Clear();
            foreach (var author in SelectedAuthors)
            {
                BiebItem.Authors.Add(author);
            }

            if (!IsEditing)
            {
                //add a new Biebitem to database if not editting
                _db.BiebItems.Add(BiebItem);
            }

            _db.SaveChanges(); //save changes to database.

            IsEditing = true; //set to editting mode
        }
    }
}
