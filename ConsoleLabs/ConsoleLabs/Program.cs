using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs;  

namespace ConsoleLabs
{
    class Program
    {
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

            Console.ReadKey(); 
        }
         
         
        static void Main(string[] args)
        {
            Lab_12_13();  
        }  
    }
}
