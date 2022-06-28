using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public enum Colors_Vertex
    {
        White = 1,
        Gray,
        Black
    }

    class Vertex
    {
        //private static int IDV = 0;
        //private int ID;
        public string Name { get; set; }
        public Vertex prevVertex;    //предыдущая вершина, от которой пришли
        public double distance;     //суммарное расстояние
        //public bool visit;        //посещение вершины
        public Colors_Vertex color;
        public List<Edge> adjLEdges;   //набор смежных ребер (т.е. ребра, котрые выходят из данной вершины)
        public List<Vertex> adjLVertexes = new List<Vertex>(); //набор смежных вершин - не нужен

        //*Для DFS*
        public int discovered;  //обнаруженная вершина
        public int finished;    //обработанная вершина
        public int time;        //метака времени

        Vertex()
        {
            Name = "No name";
            adjLEdges = new List<Edge>();
        }

        public Vertex(string name)
        {
            Name = name;
            adjLEdges = new List<Edge>();
        }

        public int CountEdgesVertex { get { return adjLEdges.Count; } }     //Кол-во ребер, идущих от вершины

        public override string ToString()
        {
            return string.Format("Name: ({0})", Name);
        }


    }
}
