using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.APIHelper
{
    public class Data
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }

    public class UserInfoData
    {
        public Data data { get; set; }
    }


}
