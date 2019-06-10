using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public static class Cycles
    {

        /// <summary> 
        /// Алгоритм поиска в ширину  
        /// </summary>
        /// <param name="unit">Начальная вершина</param>
        /// <param name="matrix">Матрица</param>
        /// <param name="mass">Выходной массив вершин</param>
         private static void BFS(int unit, int[,] matrix, ref int[] mass)
         {
            int n = matrix.GetLength(1);
            bool[] visited = new bool[n];
            int[] queue = new int[n];
            int count = 0, head; 
            int number = 0; head = 0;
            queue[number++] = unit; 
            visited[unit] = true;
            while (head < number)
            {
                unit = queue[head++];
                mass[count] = unit + 1;
                for (int i = 0; i < n; i++)
                    if (!visited[i] && (matrix[unit, i] != 0 || matrix[unit, i] != 0))
                    {
                        queue[number++] = i;
                        visited[i] = true;
                    }
                count++;
            }
        } 

        /// <summary>
        /// Алгоритм поиска Эйлерова цикла
        /// </summary>
        /// <param name="matrix">Матрица смежности</param>
        /// <returns>true - есть цикл</returns>
        public static bool Euler_cycle(int[,] matrix)
        {
            int n = matrix.GetLength(1);  
            for (int i = 1; i < n + 1; i++) 
            {
                int[] mass = new int[n];
                BFS(i - 1, matrix, ref mass);
                int count = 0;

                for (int j = 0; j < n; j++)
                    if (mass[j] != 0) count++;
                if (count != n) return false; 
                 
            } 
            return true; 
        }


        /// <summary>
        /// Проверка, можно ли добавить вершину в Гамильтонов цикл
        /// </summary>
        /// <param name="v">Вершины</param>
        /// <param name="graph">Граф</param>
        /// <param name="path">Текущий путь</param>
        /// <param name="pos">Текущая позиция</param>
        /// <returns></returns>
        static bool IsSafe(int v, int[,] graph, int[] path, int pos)
        {
            // Проверка, является ли вершина смежной с ранее добавленной
            if (graph[path[pos - 1], v] == 0)
                return false;
            // Проверка включённости вершины
            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }

        /// <summary>
        /// Рекурсивная функция полезности для решения задачи гамильтонова цикла
        /// </summary>
        /// <param name="graph">Граф</param>
        /// <param name="V">Вершины</param>
        /// <param name="path">Текущий путь</param>
        /// <param name="pos">Текущая позиция</param>
        /// <returns></returns>
        static bool HamCycleUtil(int[,] graph, int V, int[] path, int pos)
        {
            /*базовый случай: если все вершины включены в Гамильтонов цикл */
            if (pos == V)
            {
                // И если есть ребро от последней включенной вершины до 
                // первая вершина
                if (graph[path[pos - 1], path[0]] != 0)
                    return true;
                else
                    return false;
            }
            // Перебираем оставшиеся вершины в поисках подходящей для добавления в Гамильтонов цикл
            for (int v = 1; v < V; v++)
            {
                // Проверка, можно ли добавить эту вершину в Гамильтонов цикл
                if (IsSafe(v, graph, path, pos))
                {
                    path[pos] = v;
                    if (HamCycleUtil(graph, V, path, pos + 1))
                        return true;
                    // Если добавление вершины v не приводит к решению - удаляем
                    path[pos] = -1;
                }
            }
            // Если подходящая вершина не найдена
            return false; 
        }

        /// <summary>
        /// Вывод Гамильтонова цикла с помощью метода обратного поиска
        /// </summary>
        /// <param name="graph">Матрица</param>
        /// <param name="V">Кол-во вершин</param>
        /// <param name="path">Выходной вектор путей</param>
        /// <returns></returns>
        public static bool HamCycle(int[,] graph, int V, out int[] path)
        {
            path = new int[V];
            for (int i = 0; i < V; i++)
                path[i] = -1;
            // Поставим вершину № 0 первой вершиной пути. Если
            // Гамильтонов цикл существует, то путь может быть
            // запущен из любой точки цикла, поскольку граф неориентирован
            path[0] = 0;
            return HamCycleUtil(graph, V, path, 1);
        } 
    }
}
 