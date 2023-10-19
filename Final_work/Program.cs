using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Final_work
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var json = File.ReadAllText("test_input_1.json");
            Graph <int> g = json.FromJson<Graph<int>>();
            WidthSearch alg = new WidthSearch(g);
            var tt = alg.Run(2, 7);
            Console.WriteLine(tt);

            //Graph<int> graph = new Graph<int>();
            //graph.FillRandom(10);
            //FileWriter.Write("text1.json", graph.ToJson());

        }
    }
}