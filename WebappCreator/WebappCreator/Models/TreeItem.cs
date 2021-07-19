using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebappCreator.Models
{
    internal class TreeItem : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                /* it's not necessary */
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
