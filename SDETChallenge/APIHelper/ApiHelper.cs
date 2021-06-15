using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.APIHelper
{
    public class ApiHelper
    {
        string apiUrl = "http://dummy.restapiexample.com/api/v1/employee/1";
        WebClient webClient = new WebClient();

        public string getUsernameFromApi()
        {
            var datos = webClient.DownloadString(apiUrl);
            var json = JsonConvert.DeserializeObject<UserInfoData>(datos);
            return json.data.employee_name;
        }

        
    }
}
