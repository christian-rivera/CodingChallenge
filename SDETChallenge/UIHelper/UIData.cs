using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.UIHelper
{
    public class Microsoft
    {
        [JsonProperty("microsoft-product-search")]
        public string MicrosoftProductSearch { get; set; }

        [JsonProperty("no-of-items")]
        public string NoOfItems { get; set; }
    }

    public class Amazon
    {
        [JsonProperty("user-email")]
        public string UserEmail { get; set; }

        [JsonProperty("amazon-search-value")]
        public string AmazonSearchValue { get; set; }
    }

    public class Data
    {
        public Microsoft microsoft { get; set; }
        public Amazon amazon { get; set; }
    }

    public class UIData
    {
        public Data data { get; set; }
    }


}
