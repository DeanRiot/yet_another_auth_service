﻿using System.Text.RegularExpressions;

namespace Email.Data
{
    internal struct Credentials
    {
        Regex email_validation = new ("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        internal Credentials (string email, string password)
        {
            Email = email;
            Password = password;
        }

        private string _email = string.Empty;
        private string _password = string.Empty;
        internal string Email {
            get => _email;
            set => _email = email_validation.IsMatch(value) ? value :
                           throw new InvalidDataException("Email adress has incorrect format (must be like test@mail.com)");       
        }
        internal string Password
        {
            get => _password;
            set => _password = value;
        }
    }
}
