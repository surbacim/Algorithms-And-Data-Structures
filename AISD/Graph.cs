using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class Graph
    {
        public List<Vertex> LVertexes = new List<Vertex>();
        public List<Edge> LEdges = new List<Edge>();

        public int VertexCount { get { return LVertexes.Count; } }
        public int EdgeCount { get { return LEdges.Count; } }

        public void AddVertex(Vertex vertex)
        {
            LVertexes.Add(vertex);
        }

        public bool AddEdge(Vertex from, Vertex to)
        {
            Edge edge = new Edge(from, to);
            if (LEdges.Contains(edge)) return false;
            LEdges.Add(edge);
            from.adjLEdges.Add(edge);
            return true;
        }

        public Vertex FindVertex(Vertex vertexName) //Поиск вершины
        {
            foreach (var v in LVertexes)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }
            return null;
        }

        public void BFS(Vertex startVertex)     //Поиск в ширину (обход графа)
        {
            //v - вершина; u - вершина смежная с v;
            //инициализация
            foreach (Vertex vertex in LVertexes)
            {
                vertex.distance = double.MaxValue; //(бесконечность)
                vertex.prevVertex = null;          //предшественник
                vertex.color = Colors_Vertex.White;
            }

            startVertex.color = Colors_Vertex.Gray;
            startVertex.distance = 0;
            startVertex.prevVertex = null;
            Queue<Vertex> Q = new Queue<Vertex>();
            Q.Enqueue(startVertex);             //Добавить в конец очереди

            while (Q.Count > 0)
            {
                Vertex u = Q.Dequeue();     //Удаляет элемент из начала очереди и возвращает его

                foreach (Edge ee in u.adjLEdges)
                {
                    Vertex v = ee.To;
                    if (v.color == Colors_Vertex.White)
                    {
                        v.color = Colors_Vertex.Gray;
                        v.distance = u.distance + 1;
                        v.prevVertex = u;
                        Q.Enqueue(v);
                    }

                }
                u.color = Colors_Vertex.Black;

            }

        }

        public void DFS(Vertex startVertex) //Поиск в глубину (обход графа)
        {
            foreach (Vertex vv in LVertexes)
            {
                vv.color = Colors_Vertex.White;
                vv.prevVertex = null;
            }

            startVertex.time = 0;

            foreach (Vertex vv in LVertexes)
            {
                if (vv.color == Colors_Vertex.White)   //До вызова DFS_Visit она белая
                {
                    DFS_Visit(startVertex);
                }
            }
        }

        public void DFS_Visit(Vertex u)     //Для DFS
        {
            u.color = Colors_Vertex.Gray;    //Красим в серую
            u.discovered = u.time;
            u.time += 1;    //Счетчик времени увеличиваем на 1

            foreach (Edge ee in u.adjLEdges)
            {
                Vertex v = ee.To;
                if (v.color == Colors_Vertex.White)
                {
                    v.prevVertex = u;
                    DFS_Visit(v);
                }

            }
            u.color = Colors_Vertex.Black;
            u.finished = u.time;
            u.time += 1;
        }

        public void BFSForGraphConnectivity(Vertex startVertex)     //BFS для связности
        {
            //v - вершина; u - вершина смежная с v;

            startVertex.color = Colors_Vertex.Gray;
            startVertex.distance = 0;
            startVertex.prevVertex = null;
            Queue<Vertex> Q = new Queue<Vertex>();
            Q.Enqueue(startVertex);             //Добавить в конец очереди

            while (Q.Count > 0)
            {
                Vertex u = Q.Dequeue();     //Удаляет элемент из начала очереди и возвращает его

                foreach (Edge ee in u.adjLEdges)
                {
                    Vertex v = ee.To;
                    if (v.color == Colors_Vertex.White)
                    {
                        v.color = Colors_Vertex.Gray;
                        v.distance = u.distance + 1;
                        v.prevVertex = u;
                        Q.Enqueue(v);
                    }

                }
                //Q.Dequeue();
                u.color = Colors_Vertex.Black;

            }

        }

        public int GraphConnectivity()      //Связность графа
        {
            foreach (Vertex vertex in LVertexes)
            {
                vertex.distance = double.MaxValue; //(бесконечность)
                vertex.prevVertex = null;          //предшественник
                vertex.color = Colors_Vertex.White;
            }

            int ks = 0;         //кол-во связей
            while (true)
            {
                foreach (Vertex vv in LVertexes)
                {
                    if (vv.distance == double.MaxValue)
                    {
                        ks++;
                        BFSForGraphConnectivity(vv);
                    }

                }
                return ks;
            }

        }

        //Печатает кратчайшие пути из стартовой вершины до нужной вершины
        public void PrintPath(Vertex startVertex, Vertex vertex)
        {
            if (startVertex == vertex) Console.WriteLine("{0}", startVertex);
            else if (vertex.prevVertex == null) Console.WriteLine("Пути из {0} в {1} нет", startVertex, vertex);
            else PrintPath(startVertex, vertex.prevVertex); Console.WriteLine("Итого: {0}", vertex);
        }

        public void View()
        {
            foreach (Vertex v in LVertexes)
            {
                Console.WriteLine("Vertex {0}", v);
                foreach (Edge e in v.adjLEdges)
                {
                    Console.WriteLine("Edge {0}", e);
                }
            }
        }

    }
}
