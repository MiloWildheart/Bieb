﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bieb.Models
{
    public class Author : NotifyPropertyChanged
    {

        //getting and setting values
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChange(); // Notify the view model that the property has changed
            }
        }


        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChange(); // Notify the view model that the property has changed
            }
        }
        // The collection of BiebItems associated with the author
        public ObservableCollection<BiebItem> BiebItems { get; set; }
        
    }
}


