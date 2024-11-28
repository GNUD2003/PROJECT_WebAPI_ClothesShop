using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_Bussiness.Validations
{
    public class Validate
    {
        public static bool IsValidEmail(string email)
        {
            var EmailAttribute = new EmailAddressAttribute();
            return EmailAttribute.IsValid(email);
        }
        public static bool IsValidPhone(string phone)
        {
            string pattern = @"^(0|\+84)(3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-9])\d{7}$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}

