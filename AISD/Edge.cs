using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class Edge
    {
        public Vertex From { get; set; }   //От куда 
        public Vertex To { get; set; }     //Куда
        public int Weight { get; set; }

        public Edge()
        {
            From = null;
            To = null;
            Weight = 0;
        }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}; {To}; {Weight})";
        }


    }
}
