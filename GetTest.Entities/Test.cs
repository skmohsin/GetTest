using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetTest.Entities
{
    [Table("Test")]
    public class Test : Entity.Entity
    {
        [Key]
        public int TestID { get; set; }
        public int PatientID { get; set; }
        public string Name { get; set; }
    }
}
