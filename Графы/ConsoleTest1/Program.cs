using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs; 

namespace ConsoleTest1
{
    class Program 
    {
        static void Main(string[] args)
        {
            int[,] aMatrix = {
                {0, 0, 0, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 3, 1, 0}  
            };
             
            Graph graph = new Graph(aMatrix, 4);

            graph.MinPathInAcyclicGraph(0);

            foreach (var item in graph.ListInfo)
            {
                Console.WriteLine(item);
            }
             
            Console.ReadKey();  
        }  
         
    }
}  
