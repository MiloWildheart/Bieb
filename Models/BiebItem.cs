using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
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
                RaisePropertyChange(); // Notify the view model that the property has changed
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
                RaisePropertyChange(); // Notify the view model that the property has changed
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
                RaisePropertyChange(); // Notify the view model that the property has changed
            }
        }

        // returns the names of the authors as a string
        

        public ObservableCollection<Author> Authors { get; set; } = new();


        //[NotMapped]
        public string AuthorsAsString => string.Join(", ", Authors.Select(x => x.Name));

    }
}
