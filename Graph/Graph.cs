using System.Collections.Generic;

namespace TryingOut.Graph
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }
    }
}