using System;
using System.Collections.Generic;
using System.Text;

namespace WebappCreator.Helpers
{
    public class FileSystemHelper
    {
        /// <summary>
        /// Method allowing to get the path to the folder specified 
        /// as paramameter by OS
        /// </summary>
        /// <param name="folderType">Enumeratori</param>
        /// <returns></returns>
        public static string GetFolderPath(Environment.SpecialFolder folderType)
        {
            return System.Environment.GetFolderPath(folderType);
        }
    }
}
