using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITest.DataStruct
{
    public class ApiConfig
    {
        public string Name { get; set; } = "默认配置" + Guid.NewGuid().ToString();
        public string ApiBaseUrl { get; set; } = "http://127.0.0.1:8080";
        public string ApiKey { get; set; } = "123";
        public List<ModelInfo> Models { get; set; } = new List<ModelInfo>();

        public ApiConfig()
        {
            
        }


        public void RmoveModel(string name)
        {
            ModelInfo? e = this.Models.FirstOrDefault(c => c.Model.Equals(name));
            if (e == null) return;
            this.Models.Remove(e);
        }
    }
}
