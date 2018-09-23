using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Subjects
    {
        public Subjects()
        {
            Keywords = new HashSet<Keywords>();
            Subjectfortrainings = new HashSet<Subjectfortrainings>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }

        public Users CreateUser { get; set; }
        public ICollection<Keywords> Keywords { get; set; }
        public ICollection<Subjectfortrainings> Subjectfortrainings { get; set; }
    }
}
