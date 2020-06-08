using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserAccount { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public string Sex { get; set; }
    }
}
