using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    class FieldsValidation
    {
        public static string PasswordCheck(string password)
        {
            bool check = Regex.IsMatch(password, @"^(?=.{8,})(?=.*[a-z])(?=.*[0-9])(?=.*[A-Z])(?!.*\s).*$");
            if (check)
                return password;
            else            
                return null;            
        }
        public static string NumberCheck(string number)
        {
            bool check = Regex.IsMatch(number, @"^[0-9]+$") && Regex.IsMatch(number[0].ToString(), "[1-9]");
            if (check)
                return number;
            else
                return null;
        }
    }
}
