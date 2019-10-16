using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Repository
{
    public abstract class Entity
    {
        public abstract int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
