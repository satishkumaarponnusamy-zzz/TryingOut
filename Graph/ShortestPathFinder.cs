using System;
using System.Collections.Generic;
using TryingOut.Trees;

namespace TryingOut.Graph
{
    public class ShortestPathFinder
    {
        public static ShortestPath Get(Graph graph, Vertex source, Vertex target)
        {
            if (graph == null)
            {
                throw new ArgumentNullException();
            }

            if (graph.Vertices.Count < 1)
            {
                throw new ArgumentException("Empty Graph");
            }

            var distance = new Dictionary<Vertex, int>();
            var previousVertex = new Dictionary<Vertex, Vertex>();
            Func<Vertex, Vertex, bool> comparer = (vertex, vertex1) => distance[vertex] < distance[vertex1];
            var priorityQueue = new Heap<Vertex>(comparer);

            distance.Add(source, 0);
            previousVertex.Add(source, null);
            priorityQueue.Insert(source);

            while (priorityQueue.GetCount() > 0)
            {
                var currentVertexWithMinimumDistanceToSource = priorityQueue.GetRootItem();
                if (String.Compare(currentVertexWithMinimumDistanceToSource.Name, target.Name, StringComparison.Ordinal) == 0)
                {
                    return GenerateShortestPathFrom(previousVertex, distance, target);
                }

                foreach (var neighbour in currentVertexWithMinimumDistanceToSource.Neighbours)
                {
                    var neighbourVertex = neighbour.Key;
                    var distanceToNeighbour = neighbour.Value;
                    var dist = distance[currentVertexWithMinimumDistanceToSource] + distanceToNeighbour;
                    if (distance.ContainsKey(neighbourVertex))
                    {
                        if (dist >= distance[neighbourVertex])
                        {
                            continue;
                        }

                        distance[neighbourVertex] = dist;
                        previousVertex[neighbourVertex] = currentVertexWithMinimumDistanceToSource;
                    }
                    else
                    {
                        distance.Add(neighbourVertex, dist);
                        previousVertex.Add(neighbourVertex, currentVertexWithMinimumDistanceToSource);
                        
                        priorityQueue.Insert(neighbourVertex);
                    }
                }
            }

            return null;
        }

        private static ShortestPath GenerateShortestPathFrom(IReadOnlyDictionary<Vertex, Vertex> previousVertex, 
            IReadOnlyDictionary<Vertex, int> distance, Vertex target)
        {
            var shortestPath = new ShortestPath
            {
                TotalDistance = distance[target]
            };

            var vertices = new Stack<Vertex>();
            var current = target;

            while(previousVertex[current] != null)
            {
                vertices.Push(current);
                current = previousVertex[current];
            }
            vertices.Push(current);

            while (vertices.Count > 0)
            {
                var vertex = vertices.Pop();
                shortestPath.Vertices.Add(vertex);
                shortestPath.Distances.Add(distance[vertex]);
            }
            return shortestPath;
        }
    }
}
