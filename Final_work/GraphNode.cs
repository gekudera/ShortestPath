using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_work
{
    [Serializable]
    public class GraphNode<TKey>
        //подключили метод для сравнения (==)
        where TKey: IEquatable<TKey>
    {
        public TKey TopId
        {
            get => top_id; set => top_id = value;
        }
        public List<TKey> Neighbours
        {
            get => neighbors; set => neighbors = value;
        }

        private TKey top_id;
        private List<TKey> neighbors;

        private GraphNode()
        {
        }

        public GraphNode(TKey top)
        {
            this.top_id = top;
            neighbors = new List<TKey>();
        }

        public GraphNode(TKey top, List<TKey> neigh)
        {
            this.top_id = top;
            neighbors = new List<TKey>(neigh);
        }

        //неограниченное количество параметров
        public void AddNeighbors(params TKey[] neig)  
        {
            //foreach (var item in neig)
                //neighbors.Add(item);

            neighbors.AddRange(neig);
        }

        public void DeleteNeighbors(params TKey[] neig)
        {
            for (int i = 0; i < neig.Length; i++)
                neighbors.Remove(neig[i]);
        }
    }
}
