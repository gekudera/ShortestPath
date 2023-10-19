using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Final_work
{
    internal class FileReader
    {
        public static void ReadFile(string filePath)
        {
            string data = File.ReadAllText(filePath);
            var o = JsonConvert.DeserializeObject<GraphNode<int>>(data);
        }
    }
}
