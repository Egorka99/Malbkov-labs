using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    public class BFSS
    {
        private List<int> distance;
        private List<int> parent;
        private List<string> colour;
        private List<int>[] g;
        private int vertexCount;
        private HashSet<int> vertices;
        //
       public BFSS(int vertexCount)
        {
            this.vertexCount = vertexCount;
            distance = new List<int>();
            parent = new List<int>();
            colour = new List<string>();
            g = new List<int>[vertexCount];
            vertices = new HashSet<int>();
            Answer = new List<string>();
            for (int i = 0; i < vertexCount; i++)
                g[i] = new List<int>();
        }

        public void addEdge(int source, int destination)
        {
            g[source].Add(destination);
            vertices.Add(source);
            vertices.Add(destination);
        }
         
        public List<string> Answer;
        private void bfs(int source)
        {
            Queue<int> queue = new Queue<int>();
            distance[source] = 0;
            colour[source] = "grey";
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                Answer.Add("Вершина "+ u + " посещена");
                for (var j = 0; j < g[u].Count; j++)
                {
                    if (colour[j] == ("white"))
                    {
                        distance[j] = distance[u] + 1;
                        parent.Insert(j , u);
                        colour[j] = "grey";
                        queue.Enqueue(j);
                    }
                }
                colour[u] = "black";
            }
        }

        public void doBFS()
        {
            for (int i = 0; i < vertexCount; i++)
            {
                distance.Add(9999);
                colour.Add("white");
                parent.Add(000000);
               
            }
            for (int i = 0; i < vertexCount; i++)
                if (colour[i] == "white")
                    bfs(i);

        }

    }
}
