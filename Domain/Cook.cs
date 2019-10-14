using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Cook : IActor
    {
        public Cook()
        {

        }

        public Cook(string firstname, string lastname, string email, string phonenumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Phonenumber = phonenumber;
            UserName = email;
        }

        // For quick seed data
        public Cook(string email)
        {
            Email = email;
        }

        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
