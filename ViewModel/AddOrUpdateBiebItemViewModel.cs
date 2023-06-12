using Bieb.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    class AddOrUpdateBiebItemViewModel : ObservableObject
    {
        public BiebItem BiebItem { get; }
        public bool IsEditing { get; }

        public ICommand SaveCommand { get; }
        private BiebDbContext _db;

        public AddOrUpdateBiebItemViewModel (BiebItem? biebItem)
        {
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            BiebItem = biebItem ?? new();
            IsEditing = biebItem != null;
        }

        public void Save()
        {
            if (!IsEditing)
            {
                _db.BiebItems.Add(BiebItem);
            }
            _db.SaveChanges();
        }
    }
}
