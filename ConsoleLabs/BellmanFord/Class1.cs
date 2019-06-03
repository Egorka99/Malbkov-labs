using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    // Класс для представления взвешенного ребра в графе
    public class Edge
    {
        /// <summary> 
        /// Начальная вершина
        /// </summary>
        public int src;

        /// <summary>
        /// Конечная вершина 
        /// </summary>
        public int dest;

        /// <summary>
        /// Вес  
        /// </summary>
        public int weight;

        /// <summary>
        /// Инициализация
        /// </summary> 
        public Edge()
        { 
            src = dest = weight = 0;
        }
    };
      
    public class GraphBF
    {
        /// <summary>
        /// Кол-во вершин
        /// </summary>
        private int V;

        /// <summary>
        /// Кол-во ребер 
        /// </summary>
        private int E; 

        public Edge[] edge;  
 
        public GraphBF(int v, int e)
        {
            V = v;
            E = e; 
            edge = new Edge[e];
            for (int i = 0; i < e; ++i) 
                edge[i] = new Edge();
        }

        /// <summary>
        /// Алгоритм Беллмана-Форда:   
        /// </summary> 
        /// <param name="graph">Граф</param>
        /// <param name="src">Начальная вершина</param>
        public void BellmanFord(GraphBF graph, int src) 
        { 
            int V = graph.V, E = graph.E;
             
            double[] dist = new double[V];   
            int[] parent = new int[V];

              
            // Шаг 1: Для всех вершин дистанция - бесконечность 
            for (int i = 0; i < V; ++i)  
                dist[i] = double.PositiveInfinity; 
            dist[src] = 0; 
                
            //Шаг 2: Релаксировать все ребра |V| - 1 раз 
            for (int i = 1; i < V; ++i)
            {
                for (int j = 0; j < E; ++j)
                {
                    int u = graph.edge[j].src;
                    int v = graph.edge[j].dest; 
                    int weight = graph.edge[j].weight;

                    //1. не проверяйте узлы с бесконечным расстоянием, так как мы еще не обнаружили этот путь для достижения этого узла в графе
                    //2.проверьте, можно ли уменьшить текущее расстояние
                    if (dist[u] != double.PositiveInfinity &&
                        dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;  
                        parent[v] = u;
                    } 
                }
            }
             
            //Шаг 3: Проверка наличие циклов с отрицательным весом. 
            for (int j = 0; j < E; ++j)
            {
                int u = graph.edge[j].src;
                int v = graph.edge[j].dest;
                int weight = graph.edge[j].weight;   
                if (dist[u] != double.PositiveInfinity &&
                    dist[u] + weight < dist[v]) 
                {
                    Console.WriteLine("Граф имеет циклы с отрицательным весом");
                } 
            }

            printArr(dist, V, src);
        } 
              
        void printArr(double[] dist, int V, int src)
        { 
            Console.WriteLine("Кратчайшее расстояние от начальной вершины до остальных:");
            for (int i = 0; i < V; ++i) 
                Console.WriteLine("от " + src + " до " + i + " - " + dist[i]);  
        }   
    }   
} 
  