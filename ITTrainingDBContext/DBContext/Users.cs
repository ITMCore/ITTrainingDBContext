using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Users
    {
        public Users()
        {
            Adminuseraccounts = new HashSet<Adminuseraccounts>();
            AffiliatelinksCreateUser = new HashSet<Affiliatelinks>();
            AffiliatelinksEditUser = new HashSet<Affiliatelinks>();
            CommentsCreateUserNavigation = new HashSet<Comments>();
            CommentsEditUserNavigation = new HashSet<Comments>();
            LookupconstantsCreateUser = new HashSet<Lookupconstants>();
            LookupconstantsEditUser = new HashSet<Lookupconstants>();
            Subjectfortrainings = new HashSet<Subjectfortrainings>();
            Subjects = new HashSet<Subjects>();
            TraningitemsCreateUser = new HashSet<Traningitems>();
            TraningitemsEditUser = new HashSet<Traningitems>();
            TraningsourcesCreateUser = new HashSet<Traningsources>();
            TraningsourcesEditUser = new HashSet<Traningsources>();
        }

        public string UserId { get; set; }
        public string UserType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public string CreateUserId { get; set; }
        public string EditUserId { get; set; }

        public ICollection<Adminuseraccounts> Adminuseraccounts { get; set; }
        public ICollection<Affiliatelinks> AffiliatelinksCreateUser { get; set; }
        public ICollection<Affiliatelinks> AffiliatelinksEditUser { get; set; }
        public ICollection<Comments> CommentsCreateUserNavigation { get; set; }
        public ICollection<Comments> CommentsEditUserNavigation { get; set; }
        public ICollection<Lookupconstants> LookupconstantsCreateUser { get; set; }
        public ICollection<Lookupconstants> LookupconstantsEditUser { get; set; }
        public ICollection<Subjectfortrainings> Subjectfortrainings { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
        public ICollection<Traningitems> TraningitemsCreateUser { get; set; }
        public ICollection<Traningitems> TraningitemsEditUser { get; set; }
        public ICollection<Traningsources> TraningsourcesCreateUser { get; set; }
        public ICollection<Traningsources> TraningsourcesEditUser { get; set; }
    }
}
