using System;
using System.Collections.Generic;

namespace ITTrainingDBContext.DBContext
{
    public partial class Adminuseraccounts
    {
        public string AdminId { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminEmailId { get; set; }
        public string AdminMobileNumber { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string UserId { get; set; }

        public Users User { get; set; }
    }
}
