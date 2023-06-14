using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bieb.Models
{
    public class BiebItem : NotifyPropertyChanged
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
                RaisePropertyChange(); //viewmodel
            }
        }

        //getting and setting values
        private string _titel;
        public string Titel
        {
            get
            {
                return _titel;
            }
            set
            {
                _titel = value;
                RaisePropertyChange(); //viewmodel
            }
        }
        private string _mediaType;
        public string MediaType
        {
            get
            {
                return _mediaType;
            }
            set
            {
                _mediaType = value;
                RaisePropertyChange(); //viewmodel
            }
        }
       

        public ObservableCollection<Author> Authors { get; set; }
        
    }
}
