using System.Collections.Generic;

namespace TryingOut.Graph
{
    public class ShortestPath
    {
        public List<Vertex> Vertices { get; set; }
        public List<int> Distances { get; set; }
        public int TotalDistance { get; set; }

        public ShortestPath()
        {
            Vertices = new List<Vertex>();
            Distances = new List<int>();
            TotalDistance = int.MinValue;
        }
    }
}
