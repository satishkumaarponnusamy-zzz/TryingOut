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

        [Test]
        public void ShouldReturnShortestPath1()
        {
            var one = new Vertex("1");
            var two = new Vertex("2");
            var three = new Vertex("3");
            var four = new Vertex("4");
            var five = new Vertex("5");
            var six = new Vertex("6");

            one.Neighbours.Add(six, 14);
            one.Neighbours.Add(three, 9);
            one.Neighbours.Add(two, 7);

            two.Neighbours.Add(one, 7);
            two.Neighbours.Add(three, 10);
            two.Neighbours.Add(four, 15);

            three.Neighbours.Add(one, 9);
            three.Neighbours.Add(two, 10);
            three.Neighbours.Add(four, 11);
            three.Neighbours.Add(six, 2);

            four.Neighbours.Add(two, 15);
            four.Neighbours.Add(three, 11);
            four.Neighbours.Add(five, 6);

            five.Neighbours.Add(four, 6);
            five.Neighbours.Add(six, 9);

            six.Neighbours.Add(one, 14);
            six.Neighbours.Add(three, 9);
            six.Neighbours.Add(five, 9);

            var graph = new Graph.Graph();
            graph.Vertices.Add(one);
            graph.Vertices.Add(two);
            graph.Vertices.Add(three);
            graph.Vertices.Add(four);
            graph.Vertices.Add(five);
            graph.Vertices.Add(six);

            var shortestPath = ShortestPathFinder.Get(graph, one, five);

            const string expectedPath = "1 -> 3 -> 6 -> 5";
            const string expectedDistance = "0 -> 9 -> 11 -> 20";
            const int totalDistance = 20;

            ShortestPathFormatter.GetPath(shortestPath).Should().Be(expectedPath);
            ShortestPathFormatter.GetDistance(shortestPath).Should().Be(expectedDistance);
            ShortestPathFormatter.GetTotalDistance(shortestPath).Should().Be(totalDistance);
        }
    }
}
