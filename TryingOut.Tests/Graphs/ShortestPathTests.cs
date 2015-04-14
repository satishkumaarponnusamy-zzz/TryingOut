using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Graph;

namespace TryingOut.Tests.Graphs
{
    [TestFixture]
    class ShortestPathTests
    {
        private Graph.Graph _graph;
        private Vertex _source;
        private Vertex _target;

        [SetUp]
        public void SetUp()
        {
            _source = new Vertex("Source");
            var one = new Vertex("One");
            var two = new Vertex("Two");
            _target = new Vertex("Target");

            _source.Neighbours.Add(one, 1);
            _source.Neighbours.Add(two, 2);
            one.Neighbours.Add(_target, 1);
            two.Neighbours.Add(_target, 2);

            _graph = new Graph.Graph();
            _graph.Vertices.Add(_source);
            _graph.Vertices.Add(one);
            _graph.Vertices.Add(two);
            _graph.Vertices.Add(_target);
        }

        [Test]
        public void ShouldReturnShortestPath()
        {
            var shortestPath = ShortestPathFinder.Get(_graph, _source, _target);
            
            const string expectedPath = "Source -> One -> Target";
            const string expectedDistance = "0 -> 1 -> 2";
            const int totalDistance = 2;

            ShortestPathFormatter.GetPath(shortestPath).Should().Be(expectedPath);
            ShortestPathFormatter.GetDistance(shortestPath).Should().Be(expectedDistance);
            ShortestPathFormatter.GetTotalDistance(shortestPath).Should().Be(totalDistance);
        }
    }
}
