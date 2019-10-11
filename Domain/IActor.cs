using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public abstract class IActor
    {
        
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        
        [Column("LastName")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        
        [Column("Email")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        
        [Column("PhoneNumber")]
        [Display(Name = "Phone number")]
        public string Phonenumber { get; set; }

        
        [Column("Hash")]
        [Display(Name = "Password Hash")]
        public string Password { get; set; }
    }
}
