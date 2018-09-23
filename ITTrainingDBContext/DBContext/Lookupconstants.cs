using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Lookupconstants
    {
        public Lookupconstants()
        {
            Traningitems = new HashSet<Traningitems>();
        }

        public long LookupId { get; set; }
        public string CodeType { get; set; }
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUserId { get; set; }

        public Users CreateUser { get; set; }
        public Users EditUser { get; set; }
        public ICollection<Traningitems> Traningitems { get; set; }
    }
}
