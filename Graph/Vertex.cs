using System.Collections.Generic;

namespace TryingOut.Graph
{
    public class Vertex
    {
        public string Name { get; set; }
        public Dictionary<Vertex, int> Neighbours { get; set; }

        public Vertex()
        {
            Neighbours = new Dictionary<Vertex, int>();
        }

        public Vertex(string name)
        {
            Name = name;
            Neighbours = new Dictionary<Vertex, int>();
        }
    }
}