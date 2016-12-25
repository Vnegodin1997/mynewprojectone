using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PI4_Ind
{
    class Program
    {
        public static Queue<int> q;
        public static bool[] used;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("D:\\graphs.txt");
            q = new Queue<int>();
            used = new bool[25];
            string str; int u;

            int[,] graph = new int[5, 5]; int k = 0; var split = new char[1] { ' ' };
            while ((str = sr.ReadLine()) != null)
            {
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    graph[k, i] = (Array.ConvertAll(str.Split(split, StringSplitOptions.RemoveEmptyEntries), int.Parse)[i]);
                    Console.Write(graph[k, i]);
                }
                k++;
                Console.WriteLine();
            }
            u = Convert.ToInt32(Console.ReadLine());

            BFS(graph, u);
            Console.Read();
        }

        static void BFS(int[,] mass, int u)
        {
            int init = u, s = 0;
            used[u - 1] = true; int k = 0;
            q.Enqueue(u);
            File.AppendAllText("D:\\graphs_output.txt", "Начинаем обход с вершины " + u + "\r\n");
            while (q.Count != 0)
            {
                u = q.Peek();
                q.Dequeue();
                File.AppendAllText("D:\\graphs_output.txt", " ");
                for (int i = 0; i < mass.GetLength(1); i++)
                {
                    if (mass[u - 1, i] == 1 && !used[i])
                    {
                        File.AppendAllText("D:\\graphs_output.txt", "Перешли к узлу " + (i + 1) + "\r\n");
                        used[i] = true;
                        q.Enqueue(i + 1);
                        if (u == init)
                            s++;
                    }
                }
                k++;
                if (k == 2 && s == 1)
                    File.AppendAllText("D:\\graphs_output.txt", "Человек " + init + " является условно знакомым со всей компанией" + "\r\n");
            }
        }
    }
}
