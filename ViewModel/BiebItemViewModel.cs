﻿using Bieb.Models;
using Bieb.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Bieb.Commands.Icommand;

namespace Bieb.ViewModel
{

    public class BiebItemViewModel : ObservableObject
    {
        private readonly BiebDbContext _db;
        private BiebItem selectedBiebItem;
        private bool enableDeleteButton = false;
        private bool enableEditButton = false;

        public ObservableCollection<BiebItem> BiebItems { get; set; } = new();
        public BiebItem SelectedBiebItem
        {
            get => selectedBiebItem; set
            {
                selectedBiebItem = value;
                SetProperty(ref enableDeleteButton, value is not null, nameof(EnableDeleteButton));
                SetProperty(ref enableEditButton, value is not null, nameof(EnableEditButton));
                OnPropertyChanged(nameof(SelectedBiebItem));
            }
        }
        public bool EnableDeleteButton { get => enableDeleteButton; set => enableDeleteButton = value; }
        public bool EnableEditButton { get => enableEditButton; set => enableEditButton = value; }


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; }


        public BiebItemViewModel()
        {
            var options = new DbContextOptionsBuilder<BiebDbContext>()
                .UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _db = new BiebDbContext(options);

            LoadData();

            AddCommand = new RelayCommand(AddBiebItem);
            DeleteCommand = new RelayCommand(DeleteBiebItem);
            EditCommand = new RelayCommand(EditBiebItem);

        }
        private void DeleteBiebItem()
        {
            if (SelectedBiebItem is null)
            {
                return;
            }
            _db.BiebItems.Remove(SelectedBiebItem);
            _db.SaveChanges();
            BiebItems.Remove(SelectedBiebItem);
        }

        private void AddBiebItem()
        {

            var addBiebItemWindow = new AddOrUpdateBiebItemView(null);
            addBiebItemWindow.ShowDialog();

            LoadData();
        }

        private void EditBiebItem()
        {
            if (SelectedBiebItem is null)
            {
                return;
            }

            var addAuthorWindow = new AddOrUpdateBiebItemView(SelectedBiebItem);

            addAuthorWindow.ShowDialog();

            LoadData();
        }

        private void LoadData()
        {
            

            var newData = _db.BiebItems.Include(x => x.Authors).ToList();

            BiebItems.Clear();
            foreach (var item in newData)
            {
                BiebItems.Add(item);
            }
        }
        protected new virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
