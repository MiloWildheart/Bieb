﻿using Bieb.Models;
using Bieb.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Bieb.Commands.Icommand;

namespace Bieb.ViewModel
{
    class BiebItemViewModel : ObservableObject
    {
        private readonly BiebDbContext _db;
        private BiebItem selectedBiebItem;
        private bool enableDeleteButton = false;

        public ObservableCollection<BiebItem> Items { get; set; } = new();
        public BiebItem SelectedBiebItem
        {
            get => selectedBiebItem;
            set
            {
                selectedBiebItem = value;
                SetProperty(ref enableDeleteButton, value is not null, nameof(EnableDeleteButton));
            }
        }
        public bool EnableDeleteButton { get => enableDeleteButton; set => enableDeleteButton = value; }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; set; }

        public BiebItemViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            LoadData();

            AddCommand = new DelegateCommand(AddBiebitem);
            DeleteCommand = new RelayCommand(DeleteBiebItem);
        }
        private void DeleteBiebItem()
        {
            if (SelectedBiebItem is null)
            {
                return;
            }
            _db.BiebItems.Remove(SelectedBiebItem);
            _db.SaveChanges();
            Items.Remove(SelectedBiebItem);
        }

        private void AddBiebitem(object parameter)
        {
            var addItemWindow = new AddOrUpdateBiebItemView(null);
            addItemWindow.ShowDialog();

            LoadData();
        }
        private void LoadData()
        {
            var newData = _db.BiebItems.ToList();

            Items.Clear();
            foreach (var item in newData)
            {
                Items.Add(item);
            }
        }
    }
}
