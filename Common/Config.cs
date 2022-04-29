using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestItTests.Common
{
    public class Config
    {
        public Config(){}

        string jsonStr = File.ReadAllText(Path.GetFullPath(@"../../../") + "/config.json");
        public MyConfig Configure => JsonConvert.DeserializeObject<MyConfig>(jsonStr);
    }

    public class MyConfig
    {
        public DriverSettings Driver {get; set;}
        public class DriverSettings
        {
            public string Browser {get; set;}
        }

    }
}
