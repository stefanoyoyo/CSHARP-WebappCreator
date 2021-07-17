using System;
using System.Collections.Generic;
using System.Text;

namespace WebappCreator.Models
{
    public class FileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        private string FullPath { get; set; }

        #region constructors
        public FileInfo() { }

        public FileInfo(string name, string path, string Content)
        {
            this.Name = name;
            this.Path = path;
            this.FullPath = path + "\\" + name;
            this.Content = Content;
        }

        #endregion
        /// <summary>
        /// Method to map the given matrix rapresenting a series of file 
        /// to an array of fileInfo
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static FileInfo[] GetFiles(string[][] informations)
        {
            List<FileInfo> files = new List<FileInfo>();
            foreach (var item in informations)
            {
                files.Add(MapToFile(item));
            }
            return files.ToArray();
        }

        /// <summary>
        /// Method to map the given array as an instance of FileInfo
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public static FileInfo MapToFile(string[] information)
        {
            return new FileInfo(
                information[0], 
                information[1], 
                information[2]
                );
        }
    }
}
