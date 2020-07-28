using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.EntityDev
{
    public class User
    {
        public int UserId { get; set; }

        public string StaffNo { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public string UserAccount { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string EMail { get; set; }

        public string Sex { get; set; }

        public int Enable { get; set; }

        public string Remark { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
