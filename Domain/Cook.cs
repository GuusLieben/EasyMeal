using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Cook : IActor
    {
        public Cook()
        {

        }

        public Cook(string firstname, string lastname, string email, string phonenumber, string password)
        {
          
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Phonenumber = phonenumber;
            Password = password;
        }

        [Key]
        public int Id { get; set; }

    }
}
