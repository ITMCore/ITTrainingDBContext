using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Subjectfortrainings
    {
        public int SubjectId { get; set; }
        public string TrainingItemId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public int SubjectsSubjectId { get; set; }
        public string TraningItemTrainingItemId { get; set; }

        public Users CreateUser { get; set; }
        public Subjects SubjectsSubject { get; set; }
        public Traningitems TraningItemTrainingItem { get; set; }
    }
}
