using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PasswordValidation.Helpers
{
    public class Validation
    {
        public static PasswordValidation ValidatePassword(string NewPassword, string ConfirmPassword, int? MinCharacters, bool RequiresUppercase = false, bool RequiresLowercase = false, bool RequireSpecialCharacter = false, bool RequiresNumber = false, bool RequiresLetter = false, bool MustNotStartOrEndWithANumber = false)
        {
            var validationResults = new PasswordValidation();


            // Check if passwords match
            validationResults.PasswordsMatch = false;
            if (NewPassword == ConfirmPassword) validationResults.PasswordsMatch = true;

            // Check if minimun characters has been met
            if (MinCharacters != null)
            {
                validationResults.HasMinCharacters = false;
                if (NewPassword.Length >= MinCharacters) validationResults.HasMinCharacters = true;
            }

            // If set, check if password has an uppercase character
            if (RequiresUppercase == true)
            {
                validationResults.HasUpperCase = NewPassword.Any(char.IsUpper);
            }

            // If set, check if password has a lowercase character
            if (RequiresLowercase == true)
            {
                validationResults.HasLowerCase = NewPassword.Any(char.IsLower);
            }

            // If set, check if password has a special character
            if (RequireSpecialCharacter == true)
            {
                Regex specialCharacters = new Regex("[^A-Za-z0-9]");
                validationResults.HasSpecialCharacter = specialCharacters.IsMatch(NewPassword);
            }

            // If set, check password for a number
            if (RequiresNumber == true)
            {
                validationResults.HasNumber = NewPassword.Any(char.IsNumber);
            }

            // If set, check password for a letter
            if (RequiresLetter == true)
            {
                validationResults.HasLetter = NewPassword.Any(char.IsLetter);
            }

            // If set, check passwords first/last character for numbers
            if (MustNotStartOrEndWithANumber == true)
            {
                // check first char
                var firstCharChecker = false;
                if (!string.IsNullOrEmpty(NewPassword))
                {
                    firstCharChecker = !NewPassword.Substring(0, 1).Any(char.IsNumber);
                }


                // check last char
                var lastCharChecker = false;
                if (!string.IsNullOrEmpty(NewPassword))
                {
                    lastCharChecker = !NewPassword.Substring(NewPassword.Length - 1).Any(char.IsNumber);
                }

                if(firstCharChecker && lastCharChecker)
                {
                    validationResults.StartsEndsWithLetter = true;
                }


            }

            return validationResults;
        }

        public class PasswordValidation
        {
            public bool PasswordsMatch { get; set; }

            public bool HasMinCharacters { get; set; }

            public bool HasUpperCase { get; set; }

            public bool HasLowerCase { get; set; }

            public bool HasSpecialCharacter { get; set; }

            public bool HasNumber { get; set; }

            public bool HasLetter { get; set; }

            public bool StartsEndsWithLetter { get; set; }
        }
    }
}