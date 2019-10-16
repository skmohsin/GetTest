using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetTest.Entities
{
    [Table("Patient")]
    public class Patient : Entity.Entity
    {
        [Key]
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
