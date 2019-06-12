using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labs 
{  
    public class Graph 
    {
        /// <summary>
        /// Матрица смежности   
        /// </summary>
        public int[,] AdjacencyMatrix;

        /// <summary>
        /// Размер матрицы 
        /// </summary> 
        public int MatrixSize;

         
        /// <summary> 
        /// Лист с ответом алгоритма  
        /// </summary>
        public List<string> ListInfo = new List<string>();

        private static int count = 0; 


        public Graph(int[,] AdjacencyMatrix, int MatrixSize) 
        {
            this.AdjacencyMatrix = AdjacencyMatrix;

            this.MatrixSize = MatrixSize; 
              
        } 

        public Graph(StreamReader F)  
        {
            string S; 
            int N;
            string[] Buf;

            S = F.ReadLine(); //вывод первой строки 
            N = int.Parse(S);
              
            int[,] A = new int[N, N]; 

            if (N < 1 || N > 21) //проверка числа N
            {
                throw new Exception("Ошибка.Число N должно быть от 1 до 20");
                 
            }

            for (int i = 0; i < N; i++) //вывод коэффициентов матрицы 
            { 
                S = F.ReadLine();  
                Buf = S.Split(' ');  
                for (int j = 0; j < N; j++)
                {
                    A[i, j] = int.Parse(Buf[j]); 

                    if (A[i, j] > 100 || A[i, j] < 0) //проверка коэф
                    {
                        throw new Exception("Ошибка. Все коэф целые, неотрицательные не превышающие 100");
                    }
                     
                }  
            } 
             
            AdjacencyMatrix = A;
            MatrixSize = N;  
        }

         
        /// <summary>
        /// Топологическая сортировка 
        /// </summary> 
        /// <returns></returns>
        private List<int> TopSort()
        {
            List<int> ans = new List<int>(); 
            bool[] visited = new bool[MatrixSize];

            for (int i = 0; i < visited.Length; i++)
            { 
                visited[i] = false; 
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                if (!visited[i])
                    DFS(i); 
            } 

            void DFS(int st) 
            {
                visited[st] = true;

                for (int i = 0; i < MatrixSize; i++)
                {
                    if (AdjacencyMatrix[st, i] != 0 && !visited[i])
                        DFS(i);
                }
                ans.Add(st);

            }

            ans.Reverse();

            return ans; 
  
        }

        /// <summary>
        /// Минимальный путь в бесконтурном графе 
        /// </summary>
        /// <param name="src"></param>
        public void MinPathInAcyclicGraph(int src)
        {
            double[] dist = new double[MatrixSize];
             
            int[] p = TopSort().ToArray(); 
              
            for (int i = 0; i < MatrixSize; ++i) 
                dist[i] = double.PositiveInfinity; 
            dist[src] = 0; 
              

            for (int i = 0; i < MatrixSize; ++i)
            {
                for (int j = 0; j < MatrixSize; j++) 
                {
                    if (AdjacencyMatrix[p[i], j] != 0) 
                    {
                        dist[j] = Math.Min(dist[j], dist[p[i]] + AdjacencyMatrix[p[i], j]);
                    }
                } 
            } 

            printMinPath(dist, MatrixSize, src);

        }  

        private void printMinPath(double[] dist, int V, int src)
        {
            ListInfo.Add("Кратчайшее расстояние от начальной вершины до остальных:");
            for (int i = 0; i < V; ++i)
                ListInfo.Add("от " + src + " до " + i + " - " + dist[i]);
        } 

        /// <summary>
        /// Алгоритм поиска сильно связанных компонент
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="components">Массив компонент</param>
        public void Component(ref int[] components)
            {
             
                for (int i = 0; i < MatrixSize; ++i)
                {
                    if (components[i] == 0) 
                    { 
                        count++;
                        Com(i, ref components, count);
                    }
                }
                count = 0; 
            } 

        /// <summary> 
        /// Поиск компонент, сильно связаных с данной
        /// </summary>
        /// <param name="st"></param> 
        /// <param name="matrix"></param>
        /// <param name="components"></param> 
        /// <param name="x"></param>
        private void Com(int st, ref int[] components, int x)
        {
            bool[] visited = new bool[MatrixSize]; 
             
            int n = MatrixSize;  
            if (components[0] == 0)
                visited = new bool[n];         
            components[st] = x; 
            visited[st] = true;
            for (int r = 0; r < n; r++)
                if ((AdjacencyMatrix[st, r] != 0) && (!visited[r]))
                    Com(r, ref components, x);
        } 


        public string SCCToStr()
        {
            int[] mass = new int[MatrixSize];
             
            string output = String.Empty; 
            Component(ref mass);   
            for (int i = 0; i < MatrixSize * 3; i++) 
            {
                if (i < MatrixSize)
                    output += i + 1 +  " ";
                if (i == MatrixSize) output += "\r\n";
                if (i >= MatrixSize && i < MatrixSize * 2) 
                    output += " | ";
                if (i == MatrixSize * 2) output += "\r\n";
                if (i >= MatrixSize * 2) 
                    output += mass[i - (MatrixSize * 2)]  + " ";
            }
            return output;

        }    
          
        public void PrintAdjacencyMatrix()    
        { 
            ListInfo.Add("Матрица смежности: ");

            string output = String.Empty;
            output += " ";  
            for (int i = 0; i < MatrixSize; ++i)
                output += "  " + (i + 1) + "";
            ListInfo.Add(output); 



            for (int i = 0; i < MatrixSize; ++i) 
            {
                output = String.Empty; 

                for (int j = 0; j < MatrixSize; ++j)
                {  
                    if (j == 0)   
                    {
                        output += String.Format((i + 1).ToString());
                          
                    } 

                    if (AdjacencyMatrix[i, j] == 0) // если элемент матрицы находится на последнем столбце
                    {

                        output += String.Format(" 0 ", AdjacencyMatrix[i, j]);

                    }
                    else
                    { 
                        output += String.Format(" {0} ", AdjacencyMatrix[i, j]);
                    }
                     
                }
                ListInfo.Add(output);  
            }

        }  
         
        /// <summary>  
        /// Алгоритм Флойда-Уоршелла 
        /// </summary>
        public void PrintDistanceMatrix_FU() 
        {   

            int k;
            for (int i = 0; i < MatrixSize; i++)
                AdjacencyMatrix[i, i] = 0; 
            for (k = 0; k < MatrixSize; k++)
                for (int i = 0; i < MatrixSize; i++) 
                    for (int j = 0; j < MatrixSize; j++)
                        if (AdjacencyMatrix[i, k] != 0 && AdjacencyMatrix[k, j] != 0 && i != j)
                            if (AdjacencyMatrix[i, k] + AdjacencyMatrix[k, j] < AdjacencyMatrix[i, j] || AdjacencyMatrix[i, j] == 0)
                                AdjacencyMatrix[i, j] = AdjacencyMatrix[i, k] + AdjacencyMatrix[k, j];


            ListInfo.Add(" ");
            ListInfo.Add("Матрица расстояний: ");

            string output = String.Empty;
            output += " ";
            for (int i = 0; i < MatrixSize; ++i) 
                output += "  " + (i + 1) + "";
            ListInfo.Add(output);



            for (int i = 0; i < MatrixSize; ++i)
            {
                output = String.Empty;

                for (int j = 0; j < MatrixSize; ++j)
                {
                    if (j == 0)
                    {
                        output += String.Format((i + 1).ToString());

                    }

                    if (AdjacencyMatrix[i, j] == 0) // если элемент матрицы находится на последнем столбце
                    {

                        output += String.Format(" 0 ", AdjacencyMatrix[i, j]);

                    }
                    else
                    {
                        output += String.Format(" {0} ", AdjacencyMatrix[i, j]);
                    }

                }
                ListInfo.Add(output);
            }
         }
 
    }

     
}
 