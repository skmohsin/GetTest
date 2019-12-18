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



// private DateTime? createdOn;
//public DateTime? CreatedOn
//{
//    get
//    {
//        if (createdOn == null)
//        {
//            createdOn = DateTime.Now;
//        }
//        return createdOn.Value;
//    }
//}

//public DateTime? _CreatedOn { private get; set; }
//public DateTime? CreatedOn
//{
//    get
//    {
//        if (_CreatedOn == null)
//        {
//            _CreatedOn = DateTime.Now;
//        }
//        return _CreatedOn.Value;
//    }
//    set
//    {
//        _CreatedOn = value;
//    }
//}