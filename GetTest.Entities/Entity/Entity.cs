using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Entities.Entity
{
    public abstract class Entity
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
