using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebappCreator.Helpers
{
    public class FileHelper
    {
        public static bool CreateMultipleFiles() 
        {
            return false;
        }

        /// <summary>
        /// Method to create a new file in the PC filesystem
        /// </summary>
        /// <param name="path">Path of th efile in the file system</param>
        /// <param name="filename">Name the file will have</param>
        /// <returns></returns>
        public static bool CreateFile(string path, string filename)
        {
            try
            {
                path = ManagePathFilenameDivisor(path);
                File.Create(path + filename).Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method to test if last path string character is '/'.
        /// If it is not, it will be added.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ManagePathFilenameDivisor(string path)
        {
            return path.ToCharArray()[path.Length - 1] == '/' ? path : path + '/';
        }

        /// <summary>
        /// Method to create a new file in the PC filesystem
        /// </summary>
        /// <process>
        /// It is NOT possibile to create a file in a 
        /// non existing folder. Please use CreateFolder
        /// first when source folser does not exist.
        /// {"Could not find a part of the path 'C:\\Users\\user\\Desktop\\New folder\\Test\\HELLO\\Index.html'."}
        /// </process>
        /// <param name="path">Path of the file in the file system</param>
        /// <param name="filename">Name the file will have</param>
        /// <param text="text">Optional Text to write into the file</param>
        /// <returns>Boolean to notify the state of the operation. </returns>
        public static bool CreateTextFile(string path, string filename, string text = null)
        {
            try
            {
                bool success = CreateFile(path, filename);
                path = ManagePathFilenameDivisor(path);
                File.WriteAllText(
                    path + filename,
                    text != null ? text : String.Empty
                    );
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method to use for creating a folder into the specified path and
        /// using the specified name
        /// </summary>
        /// <param name="path">Path of the folder in file system</param>
        /// <param name="folderName">Name of the folder</param>
        /// <returns></returns>
        public static bool CreateFolder(string path, string folderName)
        {
            try
            {
                path = ManagePathFilenameDivisor(path);
                System.IO.Directory.CreateDirectory(path + folderName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
