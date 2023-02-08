using System;
using System.Text.RegularExpressions;


namespace CodeTestLocal
{
    public class InputConverter
    {
        public static string[] ConvertInput(string input)
        {
            return Regex.Split(input, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        }
    }
}
