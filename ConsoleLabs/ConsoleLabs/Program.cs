using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs;
using Algorithms_Library;
using DekstraAlgoritm;
using System.IO; 
    
namespace ConsoleLabs 
{
    class Program      
    {
        static void Lab_8()  
        {

             
            GraphBF graph = new GraphBF(4,3); 


            // add edge 0-1 (or A-B in above figure) 
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 1; 

            // add edge 0-2 (or A-C in above figure)
            graph.edge[1].src = 1;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 2;

            // add edge 1-2 (or B-C in above figure)
            graph.edge[2].src = 2;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 3;
             
         

            graph.BellmanFord(graph, 0);

            Console.ReadKey(); 
        } 
        static void Lab_2_7()  
        {     
            try 
            { 
            StreamReader sr = new StreamReader("input.txt");
             
            Graph graph = new Graph(sr);
         
                Console.WriteLine();
             
                graph.PrintAdjacencyMatrix(); 
             
                graph.PrintDistanceMatrix_FU(); 
                   
                Console.ReadKey(); 
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Файл содержит неверные данные");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            } 

        }


        static void Lab_16()  
        { 


        }     
         
           
        static void Lab_15()   
        { 
             
            AVLTree<int> Oak = new AVLTree<int>();
            //                                           10                              10                                             
            Oak.Add(10);  //                            /   \                           /   \
            Oak.Add(3);   //                           /     \                         /     \
            Oak.Add(2);   //                          3      12      ====>            3       15
            Oak.Add(4);   //                         / \     / \                     / \      / \
            Oak.Add(12);  //                        2   4  null 15                  2   4    12  25
            Oak.Add(15);  //                                      \              
            Oak.Add(11);  //                                       25
            Oak.Add(25);  //
              
            Oak.Remove(11);
               
            AVLTree<int>.Print(Oak.Head);   //печатаем измененное дерево 
             
            Console.ReadKey();
        }
         
        static void Lab_12_13()
        {
            Console.WriteLine("Лабораторная работа №13");
            Console.WriteLine("---");
            var tree = new BinaryTree(); 

            tree.Insert(8); 
            tree.Insert(3); 
            tree.Insert(10);  
            tree.Insert(14); 
            tree.Insert(13);  
            tree.Insert(1); 
            tree.Insert(6); 
            tree.Insert(4); 
            tree.Insert(7); 

            BinaryTreeExtensions.Print(tree);

            Console.WriteLine("Лабораторная работа №12");
            Console.WriteLine("---");

            BinaryTreeExtensions.CLR(tree); 
            Console.WriteLine();
            BinaryTreeExtensions.LCR(tree); 
            Console.WriteLine();
            BinaryTreeExtensions.LRC(tree);

            Console.WriteLine("Press any key");
            Console.WriteLine("---");

            Console.ReadKey(); 
        }
        static  void lab_5_10()
        {
            Console.WriteLine("Лабораторная работа №10");
            Console.WriteLine("---"); 

            Kruskal k = new Kruskal(@"4 
                                      6
                                      1 2 1
                                      2 3 6
                                      3 4 2
                                      4 1 5
                                      1 3 4 
                                      2 4 3");

            k.BuildSpanningTree();
            Console.WriteLine("Cost: " + k.Cost);
            k.DisplayInfo();
            Console.WriteLine("---"); 
            Console.WriteLine("Second var...");
            Console.WriteLine("---");

            Prim p = new Prim();
            List<Edge_Prim> MST = new List<Edge_Prim>();
            List<Edge_Prim> list = new List<Edge_Prim>();
            list.Add(new Edge_Prim(1, 2, 5));
            list.Add(new Edge_Prim(2, 3, 3));
            list.Add(new Edge_Prim(3, 4, 4));
            list.Add(new Edge_Prim(4, 5, 11));
            list.Add(new Edge_Prim(5, 1, 2));
            list.Add(new Edge_Prim(1, 3, 1));
            p.algorithmByPrim(5, list, MST);
            foreach (var item in MST)
            {
                Console.WriteLine(item.v1.ToString() + "-->" + item.v2.ToString() + "  Вес :" + item.weight.ToString());
            }

            Console.WriteLine("Press any key");
            Console.WriteLine("---"); 
            Console.ReadKey();
        }
        static void lab6()
        {
            Console.WriteLine("Лабораторная работа №6");
            Console.WriteLine("---");

            Point[] v = new Point[6];
            v[0] = new Point(0, false, "F"); //в любой из точек меняешь значение на 0 (в остальных оставляешь 9999) (начало)
            v[1] = new Point(9999, false, "A");
            v[2] = new Point(9999, false, "B");
            v[3] = new Point(9999, false, "C");
            v[4] = new Point(9999, false, "D");
            v[5] = new Point(9999, false, "E");
            Rebro[] rebras = new Rebro[10];
            rebras[0] = new Rebro(v[0], v[2], 8);
            rebras[1] = new Rebro(v[0], v[3], 4);//FC
            rebras[2] = new Rebro(v[0], v[1], 9);//FA
            rebras[3] = new Rebro(v[2], v[3], 7);//bc
            rebras[4] = new Rebro(v[2], v[5], 5);//be
            rebras[5] = new Rebro(v[3], v[5], 5);//ce
            rebras[6] = new Rebro(v[1], v[5], 6);//ae
            rebras[7] = new Rebro(v[1], v[4], 5);//ad
            rebras[8] = new Rebro(v[3], v[4], 4);//cd
            rebras[9] = new Rebro(v[2], v[4], 7);//bd
            DekstraAlgorim da = new DekstraAlgorim(v, rebras);
            da.AlgoritmRun(v[0]);                                               //выбираешь в каком именно ты поставил 0 (начало)
            List<string> b = PrintGrath.PrintAllMinPaths(da);
            for (int i = 0; i < b.Count; i++)                                 // b.Count меняешь на цифру до которого поинта считать (конец)
                Console.WriteLine(b[i]);
            
            Console.WriteLine("Press any key");
            Console.WriteLine("---");
            Console.ReadKey();
        }  

         
        static void Main(string[] args)
        {
            // Осталось: 1,3,4,9,11,14,16(реализация)

            //Lab_8(); 
            Lab_2_7();  
            //Lab_15();    
            //lab6();  
            //lab_5_10();
           // Lab_12_13(); 
              
        }  
    } 
}
