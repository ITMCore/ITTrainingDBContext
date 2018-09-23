using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Keywords
    {
        public string KeywordId { get; set; }
        public string KeywordDesc { get; set; }
        public int SubjectId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }

        public Subjects Subject { get; set; }
    }
}
