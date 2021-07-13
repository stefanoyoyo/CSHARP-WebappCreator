using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows;
using WebappCreator.Helpers;
using System.Windows;

namespace WebappCreator.Viewmodels
{
    public class WebappVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region properties
        public DelegateCommand DefineFolder { get; set;  }
        #endregion

        #region constructor
        public WebappVM() 
        {
            DefineFolder = new DelegateCommand(SetFolder);
        }
        #endregion

        #region methods
        public void SetFolder() 
        {
            Console.WriteLine("clicked");
            string folder = FolderPicker.OpenFolderDialog();
            string file = FilePicker.OpenFileDialog();
            Console.WriteLine(folder);
            Console.WriteLine(file);
        }


        #endregion

    }
}
