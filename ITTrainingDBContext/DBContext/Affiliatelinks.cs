using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Affiliatelinks
    {
        public int AffiliateId { get; set; }
        public string TrainingSourceId { get; set; }
        public string AffiliateLinkUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public string CreateUserId { get; set; }
        public string EditUserId { get; set; }

        public Users CreateUser { get; set; }
        public Users EditUser { get; set; }
        public Traningsources TrainingSource { get; set; }
    }
}
