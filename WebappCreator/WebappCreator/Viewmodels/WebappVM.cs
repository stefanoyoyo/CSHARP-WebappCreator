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
        public DelegateCommand CreateProject { get; set;  }
        public DelegateCommand OpenProject { get; set;  }

        /** Property to memorize the index.html file path in the project*/
        public string ProjectPath { get; set;  }
        #endregion

        #region constructor
        public WebappVM() 
        {
            CreateProject = new DelegateCommand(OpenFolder);
            OpenProject = new DelegateCommand(OpenFile);
        }
        #endregion

        #region methods
        /// <summary>
        /// Metodo che permette di lanciare la dialog per chiedere la selezione di
        /// una cartella per contenente un progetto da aprire
        /// </summary>
        public void OpenFolder() 
        {
            string folder = FolderPicker.OpenFolderDialog(
                FileSystemHelper.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            // TODO: method to create a folder before creating file in it.
            bool success3 = FileHelper.CreateMultipleFiles(
                Models.FileInfo.GetFiles(
                        new string[][]
                        { // <html><header></header><body></body></html>
                            new string[] { "Index.html", folder, "<div style=\"width:100vw;height:100vh;\">\n<iframe style=\"width:100vw; height:100vh;border-width: 0;\" src=\"home/home.html\" ></iframe></div>"},
                            new string[] { "Home.html", folder + "\\Home", "<html><header><!-- #region imports --><script type=\"text/javascript\" src=\"Home.js\"></script><link rel=\"stylesheet\" href=\"Home.css\"><!-- #endregion --></header><body>HELLO WORLD</body></html>"},
                            new string[] { "Home.css", folder + "\\Home", "HELLO WORLD"},
                            new string[] { "Home.js", folder + "\\Home", "HELLO WORLD"},
                        }
                    ));
        }

        public void OpenFile()
        {
            string file = FilePicker.OpenFileDialog(
                FileSystemHelper.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
                "Index.html", 
                ".html", 
                "Main project file (.html)|*.html");
            Console.WriteLine(file);
        }


        #endregion

    }
}
