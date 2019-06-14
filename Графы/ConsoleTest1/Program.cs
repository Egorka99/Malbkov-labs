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

            int[,] aMatrix1 = {
                { 0, 1, 1, 0, 0, 0 }, 
                { 0, 0, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 1, 1, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0 } 
            };


             
            GraphBF graph = new GraphBF(6,9);

            graph.edge[0].src = 0;
            graph.edge[0].dest = 1; 
            graph.edge[0].weight = 1;
             
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 1;

            graph.edge[2].src = 1; 
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 1;

            graph.edge[3].src = 3;
            graph.edge[3].dest = 4;
            graph.edge[3].weight = 1;

            graph.edge[4].src = 1;
            graph.edge[4].dest = 2;
            graph.edge[4].weight = 1;

            graph.edge[5].src = 2;
            graph.edge[5].dest = 3;
            graph.edge[5].weight = 1;

            graph.edge[6].src = 4;
            graph.edge[6].dest = 5; 
            graph.edge[6].weight = 1; 

            graph.edge[7].src = 4;
            graph.edge[7].dest = 0;
            graph.edge[7].weight = 1;

            graph.edge[8].src = 4;   
            graph.edge[8].dest = 1; 
            graph.edge[8].weight = 1;

            graph.doBFS(0);

            foreach (var item in graph.ListInfo)
            {
                Console.WriteLine(item); 
            }
             
            Console.ReadKey();   
        }  
         
    }
}  
