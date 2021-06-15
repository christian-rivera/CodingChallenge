using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.UIHelper
{
    public class UiHelper
    {
        public UIData getUIData()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\Resources\\AppData.json";
            var json = JsonConvert.DeserializeObject<UIData>(File.ReadAllText(path));
            return json;
        }
    }
}
