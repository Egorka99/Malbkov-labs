using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    public class BFS
    {
        private List<int> distance;
        private List<int> parent;
        private List<string> colour;
        private List<int>[] g;
        private int vertexCount;
        private HashSet<int> vertices;

        BFS(int vertexCount)
        {
            this.vertexCount = vertexCount;
            distance = new List<int>();
            parent = new List<int>();
            colour = new List<string>();
            g = new List<int>[vertexCount];
            vertices = new HashSet<int>();
            for (int i = 0; i < vertexCount; i++)
                g[i] = new List<int>();
        }

        private void addEdge(int source, int destination)
        {
            g[source].Add(destination);
            vertices.Add(source);
            vertices.Add(destination);
        }

        private string s;
        private void bfs(int source)
        {
            Queue<int> queue = new Queue<int>();
            distance[source] = 0;
            colour[source] = "grey";
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                s += (u + " ");
                for (var j = 0; j < g[u].Count; j++)
                {
                    if (colour[j] == ("white"))
                    {
                        distance[j] = distance[u] + 1;
                        parent[j] = u;
                        colour[j] = "grey";
                        queue.Enqueue(j);
                    }
                }
                colour[u] = "black";
            }
        }

        private void doBFS()
        {
            for (int i = 0; i < vertexCount; i++)
            {
                distance[i] = 9999;
                colour[i] = "white";



            }
            for (int i = 0; i < vertexCount; i++)
                if (colour[i] == "white")
                    bfs(i);
        }

    }
}
