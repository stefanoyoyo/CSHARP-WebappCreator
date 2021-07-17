using System;
using System.Collections.Generic;
using System.Text;

namespace WebappCreator.Helpers
{
    public class StringHelper
    {
        /// <summary>
        /// Method to test if last path string character is '/'.
        /// If it is not, it will be added.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ManagePathFilenameDivisor(string path)
        {
            return path.ToCharArray()[path.Length - 1] == '/' ? path : path + '/';
        }

        public static string GetLastToken(string tokens, char[] splitter)
        {
            return tokens.Split(splitter)[tokens.Split(splitter).Length - 1];
        }
    }
}
