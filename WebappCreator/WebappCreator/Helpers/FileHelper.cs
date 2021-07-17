using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebappCreator.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Method to create the files specified.
        /// When no extention is specified, a file 
        /// having no extention will be created.
        /// </summary>
        /// <param name="files">Files to create</param>
        /// <returns></returns>
        public static bool CreateMultipleFiles(Models.FileInfo[] files) 
        {
            foreach (var file in files)
            {
                if (!CheckPathValidity(file.Path))
                {
                    ValidatePath(file.Path);
                }
                FileHelper.CreateTextFile(
                    file.Path, 
                    file.Name,
                    file.Content);
            }

            return false;
        }

        /// <summary>
        /// Method to validate the path specified by creating 
        /// the non existing folders
        /// </summary>
        /// <param name="path">Path which validity is to check</param>
        private static void ValidatePath(string path)
        {
            string composedPath = "";
            var tokens = path.Split("\\");
            foreach (var folder in tokens)
            {
                composedPath += folder;
                if (FileHelper.FolderExists(composedPath))
                {
                    composedPath += "\\";
                }
                else
                {
                    // Removing last folder from path to create it
                    FileHelper.CreateFolder( 
                        ConcatStrings(
                            tokens.Where((item, index) => index != tokens.Length - 1).ToArray()),
                            tokens.Where((item, index) => index == tokens.Length - 1).ToArray()[0]
                        );
                }
            }
        }

        /// <summary>
        /// Method to concatenate a stirng array into a single merged string.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private static string ConcatStrings(string[] tokens)
        {
            string concat = "";
            foreach (var token in tokens)
            {
                concat += token + "\\";
            }
            return concat;
        }

        /// <summary>
        /// Method cheching if the folders composing the specified 
        /// path exist.
        /// <process>
        /// The following path 
        /// C:\Users\user\folder\Document\_4__WebappCreator\AppTesting\Project_1
        /// is cheched token by token to test if a subpath does not exist. 
        ///  •  C:
        ///  •  C:\Users
        ///  •  C:\Users\user\folder
        ///  •  C:\Users\user\folder\Document
        ///  •  C:\Users\user\folder\Document\_4__WebappCreator
        ///  •  C:\Users\user\folder\Document\_4__WebappCreator\AppTesting
        ///  •  C:\Users\user\folder\Document\_4__WebappCreator\AppTesting\Project_1
        /// </process>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool CheckPathValidity(string path)
        {
            string composedPath = "";
            foreach (var folder in path.Split("\\"))
            {
                composedPath += folder;
                if (FileHelper.FolderExists(composedPath))
                {
                    composedPath += "\\";
                }
                else 
                {
                    return false;
                }
            }
            return true;
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
                path = StringHelper.ManagePathFilenameDivisor(path);
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
                path = StringHelper.ManagePathFilenameDivisor(path);
                if (!File.Exists(path + filename))
                {
                    bool success = CreateFile(path, filename);
                    File.WriteAllText(
                        path + filename,
                        text != null ? text : String.Empty
                        );
                    return true;
                }
                return false;
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
                path = StringHelper.ManagePathFilenameDivisor(path);
                if (!Directory.Exists(path + folderName))
                {
                    Directory.CreateDirectory(path + folderName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method to check if the specified file exists.
        /// </summary>
        /// <param name="path">Path of the file to check</param>
        /// <returns></returns>
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Method to check if the specified folder exists.
        /// </summary>
        /// <param name="path">Path of the folder to check</param>
        /// <returns></returns>
        public static bool FolderExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
