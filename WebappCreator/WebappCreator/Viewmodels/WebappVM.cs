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
        public DelegateCommand DefineFile { get; set;  }
        #endregion

        #region constructor
        public WebappVM() 
        {
            DefineFolder = new DelegateCommand(SetFolder);
            DefineFile = new DelegateCommand(SetFile);
        }
        #endregion

        #region methods
        /// <summary>
        /// Metodo che permette di lanciare la dialog per chiedere la selezione di
        /// una cartella per contenente un progetto da aprire
        /// </summary>
        public void SetFolder() 
        {
            string folder = FolderPicker.OpenFolderDialog();
            Console.WriteLine(folder);
        }

        public void SetFile()
        {
            string file = FilePicker.OpenFileDialog();
            Console.WriteLine(file);
        }


        #endregion

    }
}
