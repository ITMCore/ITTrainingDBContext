using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Comments
    {
        public Comments()
        {
            Traningitems = new HashSet<Traningitems>();
        }

        public string CommentId { get; set; }
        public string CommentOwnerId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentLikeCount { get; set; }
        public string ParentCommentId { get; set; }
        public string CommentDescription { get; set; }
        public string CreateUser { get; set; }
        public string EditUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public Users CreateUserNavigation { get; set; }
        public Users EditUserNavigation { get; set; }
        public ICollection<Traningitems> Traningitems { get; set; }
    }
}
