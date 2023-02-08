using System;
using System.Text.RegularExpressions;


namespace CodeTestLocal
{
    public class InputConverter
    {
        // Splits input string by comma, unless the comma is enclosed in quotes
        public static string[] ConvertInput(string input)
        {
            return Regex.Split(input, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        }
    }
}
