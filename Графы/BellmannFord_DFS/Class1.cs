using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    // Класс для представления взвешенного ребра в графе
    public class EdgeBF
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
        public EdgeBF()
        {
            src = dest = weight = 0;
        }
    };

    public class GraphBF
    {
        /// <summary>
        /// Кол-во вершин
        /// </summary>
        public int V;

        /// <summary>
        /// Кол-во ребер 
        /// </summary>
        public int E;


        /// <summary>
        /// Лист с ответом алгоритма   
        /// </summary>
        public List<string> ListInfo = new List<string>();

        public EdgeBF[] edge;

        // public int[,] aMatrix;  

        //public GraphBF(int[,] aMatrix)
        //{
        //    this.aMatrix = aMatrix; 

        //    // количество вершин = длина вложенного массива 
        //    V = aMatrix.GetLength(0);

        //    // ищем ненулевые элементы матрицы  
        //    for (int i = 0; i < aMatrix.GetLength(0) ; i++)
        //    {
        //        for (int j = 0; j < aMatrix.GetLength(1) ; j++)
        //        { 
        //            if (aMatrix[i, j] != 0) 
        //                E++;   
        //        }   
        //    }   

        //    edge = new Edge[E];
        //    for (int i = 0; i < E; ++i)
        //        edge[i] = new Edge(); 
        //}  

        public GraphBF(int v, int e) 
        {
            V = v;
            E = e;
            edge = new EdgeBF[e];
            for (int i = 0; i < e; ++i)
                edge[i] = new EdgeBF();
        }

        /// <summary>
        /// Обход в глубину 
        /// </summary>
        public void doDFS()  
        {
            int[,] aMatrix = fillAdjacencyMatrix(); 

            bool[] visited = new bool[V];

            ListInfo.Add("Порядок обхода: "); 

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                    DFS(i); 
            }

            void DFS(int st)
            {
                visited[st] = true;
                ListInfo.Add(st + " - серая");

                for (int i = 0; i < V; i++)
                {
                    if (aMatrix[st, i] != 0 && !visited[i])
                        DFS(i);
                }
                ListInfo.Add(st + " - черная");  

            }
 
             

        } 
         
        private int[,] fillAdjacencyMatrix()
        {
            int[,] matrix = new int[V,V];
             
            for (int i = 0; i < V; i++) 
                for (int j = 0; j < V; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < edge.Count(); i++) 
            {
                matrix[edge[i].src, edge[i].dest] = 1; 
                matrix[edge[i].dest, edge[i].src] = 1; 
            }

            return matrix; 
        } 
         
        /// <summary>
        /// Топологическая сортировка 
        /// </summary>
        /// <returns></returns> 

        //private List<int> topSort()
        //{
        //    bool[] visited = new bool[E];

        //    List<int> ans = new List<int>();  

        //    for (int i = 0; i < visited.Length; i++)
        //    {
        //        visited[i] = false;  
        //    }  


        //    for (int i = 0; i < V; i++)
        //    { 
        //        if (!visited[i])  
        //        {
        //            DFS(i);
        //        }
        //    } 

        //    ans.Reverse(); 

        //    void DFS(int st) 
        //    { 
        //        visited[st] = true;    

        //        for (int i = 0; i < E - 1; i++) 
        //        {
        //            if (!visited[i])
        //            { 
        //                DFS(i);
        //            }   
        //        }
        //        ans.Add(st);  

        //    } 

        //    return ans;  
        //} 

        //public void MinPathInAcyclicGraph(int src) 
        //{     
        //    double[] dist = new double[V]; 

        //    int[] p = topSort().ToArray();     

        //    for (int i = 0; i < V; ++i)  
        //        dist[i] = double.PositiveInfinity;
        //    dist[src] = 0;


        //    for (int i = 0; i < V; ++i) 
        //    {
        //        for (int j = 0; j < V; j++)
        //        {
        //            if (aMatrix[p[i], j] != 0)
        //            {
        //                dist[j] = Math.Min(dist[p[i]], aMatrix[p[i], j]);
        //            }
        //        }        
        //    }                                                                                                                                         

        //    for (int i = 0; i < p.Length; i++) 
        //    {
        //        Console.WriteLine(p[i]);
        //    }

        //    printArr(dist, V, src); 
        //}    




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

            //printArr(dist, V, src); 

            AddArrayToListInfo(dist, V, src); 
        }

        void printArr(double[] dist, int V, int src) 
        {
            Console.WriteLine("Кратчайшее расстояние от начальной вершины до остальных:");
            for (int i = 0; i < V; ++i)
                Console.WriteLine("от " + src + " до " + i + " - " + dist[i]);
        }

        void AddArrayToListInfo(double[] dist, int V, int src)
        {
            ListInfo.Add("Кратчайшее расстояние от начальной вершины до остальных:");
            for (int i = 0; i < V; ++i)
                ListInfo.Add("от " + src + " до " + i + " - " + dist[i]);
        }
    }
}
 