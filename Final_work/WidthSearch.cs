using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_work
{
    internal class WidthSearch
    {
        private Graph<int> graph;
        //добавленная вершина, ее родитель, построеннй путь
        List<Pair<int, int, List<int>>> levels_matr;

        public WidthSearch(Graph<int> gr)
        {
            graph = gr;
            levels_matr = new List<Pair<int, int, List<int>>>();
        }

        private bool IsRealTop(int top)
        {
            var topNode = graph.graphNodes.Find(x => x.TopId.Equals(top));
            if (topNode == null) return false;
            else return true;
        }

        public int Run(int start, int finish)
        {
            List<int> mark_top = new List<int>();

            //проверка, что точки старта и финиша существуют в графе
            if (IsRealTop(start) == false || IsRealTop(finish) == false)
                return 0;

            //Шаг 1. Стартовая вершина помечена как рассматриваемая
            int current = start;
            int lvl = 0;
            List<int> curr_puth = new List<int>();
            curr_puth.Add(start);
            levels_matr.Add(new Pair<int, int, List<int>>(start, lvl, curr_puth));

            while (mark_top.Count != graph.graphNodes.Count-1)
            {
                //увеличиваем уровень 
                lvl++;

                List<int> neigh = graph.graphNodes[current].Neighbours;

                for (int i = 0; i < neigh.Count(); i++)
                {
                    if (!mark_top.Contains(neigh[i]))
                    {
                        var new_puth = new List<int>(curr_puth);
                        new_puth.Add(neigh[i]);
                        levels_matr.Add(new Pair<int, int, List<int>>(neigh[i], lvl, new_puth));
                    }
                }
                mark_top.Add(current);

                //нужно выбрать новую рассматриваемую вершину.
                //Для этого рассмотрим матрицу уровней и выберем первую не помеченную
                for (int j = 0; j < levels_matr.Count; j++)
                {
                    if (!mark_top.Contains(levels_matr[j].Value1))
                    {
                        current = levels_matr[j].Value1;
                        lvl = levels_matr[j].Value2;
                        curr_puth = levels_matr[j].Value3;
                        break;
                    }
                        
                }
            }


            //восстановление пути
            int indx = 0;
            for (int i=0; i< levels_matr.Count; i++)
            {
                if (levels_matr[i].Value1 == finish)
                    indx = i;
            }

            foreach (var item in levels_matr[indx].Value3)
            Console.WriteLine(item);
            return levels_matr[indx].Value2;
        }
    }
}

public class Pair<T, T2, T3>
{
    public T Value1 { get; set; }
    public T2 Value2 { get; set; }
    public T3 Value3 { get; set; }  
    public Pair(T value1, T2 value2, T3 value3)
    {
        Value1 = value1;
        Value2 = value2;
        Value3 = value3;
    }
}