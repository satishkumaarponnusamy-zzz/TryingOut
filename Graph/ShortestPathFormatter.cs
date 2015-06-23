using System.Collections.Generic;
using System.Linq;

namespace TryingOut.Graph
{
    public class ShortestPathFormatter
    {
        public static string GetPath(ShortestPath shortestPath)
        {
            if (shortestPath == null)
            {
                return null;   
            }

            return shortestPath.Vertices.Count == 0 ? null : string.Join(" -> ", shortestPath.Vertices.Select(x => x.Name));
        }

        public static string GetDistance(ShortestPath shortestPath)
        {
            if (shortestPath == null)
            {
                return null;
            }

            return shortestPath.Vertices.Count == 0 ? null : string.Join(" -> ", shortestPath.Distances.Select(x => x));

            //if (shortestPath == null)
            //{
            //    return null;
            //}

            //if (shortestPath.Vertices.Count == 0)
            //{
            //    return null;
            //}

            //var distances = GetDistances(shortestPath);

            //return string.Join(" -> ", distances);
        }

        public static int GetTotalDistance(ShortestPath shortestPath)
        {
            return shortestPath.TotalDistance;

            //if (shortestPath == null)
            //{
            //    return -1;
            //}

            //if (shortestPath.Vertices.Count == 0)
            //{
            //    return -1;
            //}

            //var distances = GetDistances(shortestPath);

            //return distances.Sum(x => x);
        }

        private static IEnumerable<int> GetDistances(ShortestPath shortestPath)
        {
            var distances = new List<int>();

            for (var i = 1; i < shortestPath.Vertices.Count; i++)
            {
                var prevVertex = shortestPath.Vertices[i - 1];
                var currentVertex = shortestPath.Vertices[i];
                distances.Add(prevVertex.Neighbours[currentVertex]);
            }

            return distances;
        }
    }
}
