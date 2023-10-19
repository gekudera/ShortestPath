using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_work
{
    internal class Graph<TKey>
        where TKey : IEquatable<TKey>
    {
        public List<GraphNode<TKey>> graphNodes;
        public GraphNode<TKey> this[TKey id]
        {
            get
            {
                if (_nodes == null || graphNodes.Count != _nodes.Count)
                    Init();

                return _nodes[id];
            }
        }

        private Dictionary<TKey, GraphNode<TKey>> _nodes;

        public Graph()
        {
            graphNodes = new List<GraphNode<TKey>>();
            _nodes = new Dictionary<TKey, GraphNode<TKey>>();
        }

        public Graph(int kol)
        {
            graphNodes = new List<GraphNode<TKey>>(kol);
            _nodes = new Dictionary<TKey, GraphNode<TKey>>(kol);
        }

        public Graph(List<GraphNode<TKey>> gr)
        {
            graphNodes = new List<GraphNode<TKey>>(gr);
            _nodes = new Dictionary<TKey, GraphNode<TKey>>(gr.Count);
            Init();
        }

        public void AddNodes(params GraphNode<TKey>[] nodes)
        {
            graphNodes.AddRange(nodes);
            foreach (var n in nodes)
                _nodes.Add(n.TopId, n);
        }

        public void DeleteNodes(params GraphNode<TKey>[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                graphNodes.Remove(nodes[i]);
                _nodes.Remove(nodes[i].TopId);
            }
        }

        public void AddEdge(TKey first_top, TKey second_top)
        {
            var firstNode = graphNodes.Find(x => x.TopId.Equals(first_top));
            var secondNode = graphNodes.Find(x => x.TopId.Equals(second_top));
            if (firstNode == null || secondNode == null)
            {
                Console.WriteLine("Nullptr exseption");
                return;
            }

            if (!firstNode.Neighbours.Contains(second_top))
                firstNode.AddNeighbors(second_top);

            if (!secondNode.Neighbours.Contains(first_top))
                secondNode.AddNeighbors(first_top);
        }

        public void FillRandom(int kol_top)
        {
            var self = this as Graph<int>;
            if (typeof(TKey) == typeof(int) && self != null)
            {
                Random rnd = new Random();
                for (int i = 0; i < kol_top; i++)
                {
                    self.AddNodes(new GraphNode<int>(i, new List<int>()));
                }

                //Полный граф с n вершинами имеет n(n - 1)/2 рёбер
                int kol_edge = rnd.Next(1, kol_top*(kol_top-1)/2);
                for (int i = 0; i < kol_edge; i++)
                {
                    int first = rnd.Next(0, kol_top);
                    int second = first;
                    //гарантия, что first и second не равны
                    while (first == second)
                    second = rnd.Next(0, kol_top);

                    self.AddEdge(first, second);
                }
            }
            else
            {
                Console.WriteLine("Graph type is not int");
            }
        }

        private void Init()
        {
            _nodes ??= new Dictionary<TKey, GraphNode<TKey>>();
            foreach (var node in graphNodes)
            {
                _nodes.Add(node.TopId, node);
            }
        }
    }

}
