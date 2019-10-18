using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Entities.Entity
{
    public abstract class Entity
    {

        private DateTime? createdOn;

        public int CreatedBy { get; set; }

        public DateTime? CreatedOn
        {
            get
            {
                if (createdOn == null)
                {
                    createdOn = DateTime.Now;
                }
                return createdOn.Value;
            }
        }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}



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