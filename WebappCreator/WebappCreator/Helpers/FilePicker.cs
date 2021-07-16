using System;
using System.Collections.Generic;
using System.Text;

namespace WebappCreator.Helpers
{
    public class FilePicker
    {
        /// <summary>
        /// Method to opern the file dialog and getting the selected
        /// file path. 
        /// </summary>
        /// <param name="inputPath">Optional parameter to suggest a default source folder the dialog will show as it opens up</param>
        /// <param name="SuggestfileName">Optional parameter to suggest a file name</param>
        /// <param name="SuggestDefaultExtention">Optional parameter to suggest a default extention</param>
        /// <param name="SuggestFilter">Optional parameter to suggest a custom filter</param>
        /// <returns></returns>
        public static string OpenFileDialog(string inputPath = null, string SuggestfileName=null, string SuggestDefaultExtention=null, string SuggestFilter = null)
        {
            string filename = null;
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = inputPath != null ? inputPath : dlg.InitialDirectory; // Set default source folder
            dlg.FileName = SuggestfileName != null ? SuggestfileName : "Document"; // Default file name
            dlg.DefaultExt = SuggestDefaultExtention != null ? SuggestDefaultExtention : ".txt"; // Default file extension
            dlg.Filter = SuggestFilter != null ? SuggestFilter : "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }
            return filename;
            
        }
    }
}
