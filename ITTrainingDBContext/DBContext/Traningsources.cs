using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Traningsources
    {
        public Traningsources()
        {
            Affiliatelinks = new HashSet<Affiliatelinks>();
            Traningitems = new HashSet<Traningitems>();
        }

        public string TrainingSourceId { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteDescription { get; set; }
        public string WebsiteLink { get; set; }
        public string CreateUserId { get; set; }
        public string EditUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public Users CreateUser { get; set; }
        public Users EditUser { get; set; }
        public ICollection<Affiliatelinks> Affiliatelinks { get; set; }
        public ICollection<Traningitems> Traningitems { get; set; }
    }
}
