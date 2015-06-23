using System;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Graph;

namespace TryingOut.Tests.Graphs
{
    internal class ConnectedComponentLabellingTests
    {
        private readonly object[] _testCases =
        {
            new object[]
            {
                new[,]
                {
                    {1, 0},
                    {0, 0}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {1, 0},
                    {0, 0}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {0, 1},
                    {0, 0}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {0, 0},
                    {1, 0}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {0, 0},
                    {0, 1}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {1, 1},
                    {0, 0}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {1, 0},
                    {1, 0}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {1, 0},
                    {0, 1}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {1, 0, 1},
                    {0, 1, 0},
                    {1, 0, 1}
                },
                1
            },
            new object[]
            {
                new[,]
                {
                    {1, 0, 1},
                    {0, 0, 0},
                    {1, 0, 1}
                },
                4
            },
            new object[]
            {
                new[,]
                {
                    {1, 0, 1},
                    {1, 0, 0},
                    {1, 0, 1}
                },
                3
            },
            new object[]
            {
                new[,]
                {
                    {1, 0, 1},
                    {1, 0, 1},
                    {1, 0, 1}
                },
                2
            },
            new object[]
            {
                new[,]
                {
                    {1, 0, 1},
                    {1, 1, 1},
                    {1, 0, 1}
                },
                1
            }
        };

        [Test]
        public void ShouldReturnZeroForEmptyArray()
        {
            var image = new bool[,] {};
            new ConnectedComponentLabelling().FindNumberOfShapes(image).Should().Be(0);
        }

        [Test]
        public void ShouldThrowExceptionWhenArrayIsNot2Dimension()
        {
            Action a = () => new ConnectedComponentLabelling().FindNumberOfShapes(new bool[] {});
            a.ShouldThrow<ArgumentException>().WithMessage("Expecting two dimensional array");

            a = () => new ConnectedComponentLabelling().FindNumberOfShapes(new bool[,,] {});
            a.ShouldThrow<ArgumentException>().WithMessage("Expecting two dimensional array");
        }

        [Test]
        public void ShouldReturnZeroWhenThereIsNoConnectedComponents()
        {
            new ConnectedComponentLabelling().FindNumberOfShapes(new[,]
            {
                {0, 0},
                {0, 0}
            }).Should().Be(0);
        }

        [Test]
        [TestCaseSource("_testCases")]
        public void ShouldReturnOneWhenThereIsAConnectedComponents(Array image, int expectedNumberOfShapes)
        {
            PrintImage("Before", image);

            new ConnectedComponentLabelling().FindNumberOfShapes(image).Should().Be(expectedNumberOfShapes);
            
            PrintImage("After", image);
        }

        private static void PrintImage(string message, Array image)
        {
            Console.WriteLine(message);

            for (var i = 0; i < image.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < image.GetUpperBound(1) + 1; j++)
                {
                    Console.Write((int) image.GetValue(i, j));
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
    }
}