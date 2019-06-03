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

        private int[,] AdjacencyMatrix;

        private int MatrixSize;

        private bool[] visited;
        private int[] num; 
        private int count;   
          
        public Graph(int[,] AdjacencyMatrix, int MatrixSize) 
        {
            this.AdjacencyMatrix = AdjacencyMatrix;

            this.MatrixSize = MatrixSize; 
             
            visited = new bool[MatrixSize];
            num = new int[MatrixSize];
            count = 0; 
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

            visited = new bool[MatrixSize];
            num = new int[MatrixSize];
            count = 0; 
        }

        /// <summary>
        /// Процедура поиска в глубину  
        /// </summary>
        /// <param name="st">Стартовая вершина</param>
        /// <param name="numb">Компонента связности</param>
        private void DFS(int st, int numb) 
        {
            visited[st] = true; 

            for (int r = 0; r < MatrixSize; r++)
            {
                if ((AdjacencyMatrix[st, r] != 0) && (!visited[r]))
                {
                    DFS(r, numb);
                }
            }  
        } 

        public void PrintDFS()
        {

            for (int i = 0; i < MatrixSize; ++i) //проход DFS по всем вершинам и определение их компонент связности 
            {
                int numb = 0;
                for (i = 0; i < MatrixSize; ++i)
                {
                    if (!visited[i])
                    {
                        DFS(i, numb + 1);
                        numb++;
                        count++;

                    }
                    num[i] = numb;
                } 
            }
            if (count == 0)
                Console.WriteLine("Граф связный");
            else
                Console.WriteLine("Граф несвязный.Количество компонент: " + count);

            Console.WriteLine();
            Console.WriteLine("Принадлежность к компонентам связности: ");
             
            for (int i = 0; i < MatrixSize; ++i) //вывод компонент связности вершин
            {
                Console.WriteLine((i + 1) + " вершина - " + Convert.ToString(num[i]));
            }

        } 
          
        public void PrintAdjacencyMatrix()
        { 
            Console.WriteLine("Матрица смежности: ");
            for (int i = 0; i < MatrixSize; ++i) 
                Console.Write("  " + (i + 1) + "");
            Console.WriteLine();

            for (int i = 0; i < MatrixSize; ++i)
            {  
                for (int j = 0; j < MatrixSize; ++j)
                { 
                    if (j == 0) 
                    {
                        Console.Write(i + 1);

                    }

                    if (AdjacencyMatrix[i, j] == 0) // если элемент матрицы находится на последнем столбце
                    {

                        Console.Write(" - ", AdjacencyMatrix[i, j]);

                    }
                    else
                    { 
                        Console.Write(" {0} ", AdjacencyMatrix[i, j]);
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine(); 
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
             

            Console.WriteLine();
            Console.WriteLine("Матрица растояний: ");

            for (int i = 0; i < MatrixSize; ++i)
                Console.Write("  " + (i + 1) + "");

            Console.WriteLine();
            for (int i = 0; i < MatrixSize; ++i)
            {
                for (int j = 0; j < MatrixSize; ++j)
                {
                    if (j == 0)
                    {
                        Console.Write(i + 1);

                    }

                    if (AdjacencyMatrix[i, j] == 0) // если элемент матрицы находится на  последнем столбце
                    {

                        Console.Write(" - ", AdjacencyMatrix[i, j]);

                    }
                    else 
                    {
                        Console.Write(" {0} ", AdjacencyMatrix[i, j]);
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine(); 
        }
 
    }

     
}
 