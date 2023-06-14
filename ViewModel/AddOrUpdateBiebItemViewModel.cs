﻿using Bieb.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Bieb.ViewModel
{
    class AddOrUpdateBiebItemViewModel : ObservableObject
    {
        public BiebItem BiebItem { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public bool IsEditing { get; }

        public ICommand SaveCommand { get; set; }

        private BiebDbContext _db;

        public AddOrUpdateBiebItemViewModel (BiebItem? biebItem)
        {
            SaveCommand = new RelayCommand(Save);
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            _db = new BiebDbContext(options);
            Authors = new ObservableCollection<Author>(_db.Authors.ToList());

            BiebItem = biebItem ?? new();
            IsEditing = biebItem != null;
            //LoadData();
        }

        //private void LoadData()
        //{

        //    var newData = _db.Authors.ToList();

        //    Authors.Clear();
        //    foreach (var item in newData)
        //    {
        //        Authors.Add(item);
        //    }
        //}

        public void Save()
        {
            if (!IsEditing)
            {
                //_db.BiebItems.Add(BiebItem);
            }
            _db.SaveChanges();
        }
    }
}
