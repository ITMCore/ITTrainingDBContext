using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Traningitems
    {
        public Traningitems()
        {
            InverseParentTrainingItem = new HashSet<Traningitems>();
            Subjectfortrainings = new HashSet<Subjectfortrainings>();
        }

        public string TrainingItemId { get; set; }
        public string TrainingItemTitle { get; set; }
        public string TrainingSourceId { get; set; }
        public string TraningItemDescription { get; set; }
        public long TraningItemType { get; set; }
        public string ParentTrainingItemId { get; set; }
        public string TrainingItemContent { get; set; }
        public string TrainingItemDiscussionId { get; set; }
        public string TrainingItemLink { get; set; }
        public string CreateUserId { get; set; }
        public string EditUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public Users CreateUser { get; set; }
        public Users EditUser { get; set; }
        public Traningitems ParentTrainingItem { get; set; }
        public Comments TrainingItemDiscussion { get; set; }
        public Traningsources TrainingSource { get; set; }
        public Lookupconstants TraningItemTypeNavigation { get; set; }
        public ICollection<Traningitems> InverseParentTrainingItem { get; set; }
        public ICollection<Subjectfortrainings> Subjectfortrainings { get; set; }
    }
}
