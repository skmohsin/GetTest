using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GetTest.Entities.Entity;

namespace GetTest.Entities
{
    [Table("User")]
    public class User : Entity.Entity
    {
        [Key]
        public int UserID { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Degree { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
