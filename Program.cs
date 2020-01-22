
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sotrudniki
{
    class Program
    {
        static string inputPath = "../../input.txt";
        static  string outputPath = "../../output.txt";
        static bool[] visited;
        static Person[] persons;
        static int[,] g;
        public static void Main(string[] args)
        {
            int n = 0;
            Person boss = new Person { Id = 0, BossId = 0, Name = "" };
            List<Person> people = new List<Person>();
            using (StreamReader sr = new StreamReader(inputPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var t = line.Split('|');
                    Person p = new Person { Id = int.Parse(t[0]), BossId = int.Parse(t[1]), Name = t[2] };
                    people.Add(p);
                    n = Math.Max(n, p.Id);
                    if (p.BossId == 0) boss = p;
                }
            }
            n++;
            g = new int[n, n];
            visited = new bool[n];
            persons = new Person[n];
            foreach (var p in people)
            {
                persons[p.Id] = p;
                g[p.BossId, p.Id] = 1;

            }
            using (StreamWriter sw = new StreamWriter(outputPath, false, System.Text.Encoding.Default))
            {
                sw.Write("");
            }
            dfs(boss.Id, 0, n);

        }
       public static void dfs(int v, int l, int n)
            {

                using (StreamWriter sw = new StreamWriter(outputPath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(String.Concat(Enumerable.Repeat("---", l)) + persons[v].Name);
                }
                visited[v] = true;
                for (int i = 0; i < n; i++)
                {
                    if (g[v, i] == 1 && !visited[i])
                    {
                        dfs(i, l + 1, n);
                    }
                }
            }
    }
}
