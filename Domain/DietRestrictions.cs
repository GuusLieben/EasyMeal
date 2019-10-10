using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class DietRestrictions
    {
        public DietRestrictions(int id, Setting setting)
        {
            _id = id;
            _setting = setting;
        }

        public DietRestrictions()
        {
        }

        [Key]
        [Column("RestrictionId")]
        [Required]
        public int _id { get; set; }

        [Column("Setting")]
        [Required]
        public Setting _setting { get; set; }

        public enum Setting
        {
            NoSalt, DiabeticSafe, NoGluten
        }
    }
}
