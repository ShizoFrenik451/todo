using SQLite;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SQLiteNetExtensions.Attributes;

namespace SimpleTodo.Models
{
    public class TodoItem : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }        
        public int TodoCategoryId { get; set; }
        [ManyToOne]
        public TodoCategory TodoCategory { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));


                }
            }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set
            {
                if (notes != value)
                {
                    notes = value;
                    OnPropertyChanged(nameof(Notes));


                }
            }
        }

        private bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                if (done != value)
                {
                    done = value;
                    OnPropertyChanged(nameof(Done));
                }
            }
        }
        public byte[] ImageData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
