using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.LinkedList;

namespace TryingOut.Tests.LinkedList
{
    class PalindromeTests
    {
        private readonly Palindrome _palindrome = new Palindrome();

        [Test]
        public void ShouldThrowArgumentNullException()
        {
            Action a = () => _palindrome.Check(null);
            a.ShouldThrow<ArgumentNullException>();
        }

        private object[] _testCases = new[]
        {
            new object[]
            {
                new LinkedList<char>(new [] {'a'}),
                true
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'a'}),
                true
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b'}),
                false
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'a'}),
                true
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'b'}),
                false
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'b', 'a'}),
                true
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'd', 'a'}),
                false
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'c', 'b', 'a'}),
                true
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'c', 'd', 'a'}),
                false
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'c', 'd', 'e', 'd', 'c', 'b', 'a'}),
                true
            },
            new object[]
            {
                new LinkedList<char>(new [] {'a', 'b', 'c', 'd', 'e', 'e', 'c', 'b', 'a'}),
                false
            }
        };

        [TestCaseSource("_testCases")]
        public void ShouldCheck(LinkedList<char> list, bool isPalindrome)
        {
            Print(list);

            _palindrome.Check(list.First).Should().Be(isPalindrome);
        }

        private void Print(LinkedList<char> list)
        {
            var node = list.First;
            while (node != null)
            {
                Console.Write(node.Value);
                node = node.Next;
            }
        }
    }
}
