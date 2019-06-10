using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs;
using System.IO;
using DekstraAlgoritm;
    
namespace ConsoleLabs 
{
    class Program      
    { 
 
        static void Lab_16()  
        {
            BTree<int, int> T = new BTree<int, int>(2);
            T.Insert(5, 16);
            T.Insert(7, 2);
            T.Insert(8, 11); 
            T.Insert(4, 22);
            T.Insert(9, 3);
            T.Insert(11, 8);
            T.Insert(15, 18);  
            Display_BTree(T.Root); 
            Console.WriteLine();
            Console.WriteLine("Press Enter...");
            Console.ReadLine();
            Console.WriteLine("Delete 11, 4:");
            T.Delete(11);
            T.Delete(4);
            Display_BTree(T.Root); 
            Console.WriteLine();
            Console.WriteLine("Press Enter...");
            Console.ReadLine();
            Console.WriteLine("Search 7:");
            Entry<int, int> F = T.Search(7);
            Console.Write("Key = " + F.Key + ", Pointer = " + F.Pointer + "; ");
            for (; ; );
        }

        private static void Display_BTree(Node<int, int> N) 
        {
            foreach (Entry<int, int> E in N.Entries) 
            { 
                Console.Write("Key = " + E.Key + ", Pointer = " + E.Pointer + "; ");
                Console.WriteLine();
            }
            if (N.Children.Count != 0) Console.WriteLine("\r\nChildren:");
            foreach (Node<int, int> A in N.Children)
                Display_BTree(A); 
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


        static void lab6()
        {
            Console.WriteLine("Лабораторная работа №6");
            Console.WriteLine("---");

            Point[] v = new Point[3];
            v[0] = new Point(0, false, "0"); //в любой из точек меняешь значение на 0 (в остальных оставляешь 9999) (начало)	
            v[1] = new Point(9999, false, "1");
            v[2] = new Point(9999, false, "2");
           
            Rebro[] rebras = new Rebro[2];
            rebras[0] = new Rebro(v[0], v[1], 4);
            rebras[1] = new Rebro(v[1], v[2], 2);//FC	
            
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
            lab6();
            //Lab_16(); 
            //Lab_15();     

           // Lab_12_13(); 
              
        }  
    } 
}
