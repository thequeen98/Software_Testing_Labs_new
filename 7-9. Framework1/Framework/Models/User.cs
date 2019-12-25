using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.Models
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string VelocityNumber { get; set; }
        public string Password { get; set; }

        public User(string email, string password, string ferstName, string lastName)
        {
            this.FirstName = ferstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public User(string lastName ,string velocityNumber, string password)
        {
            this.LastName = lastName;
            this.VelocityNumber = velocityNumber;
            this.Password = password;
        }
    }
}
