using System;
using System.Collections.Generic;

namespace TryingOut.LinkedList
{
    public class Palindrome
    {
        public bool Check(LinkedListNode<char> head)
        {
            if(head == null)
            {
                throw new ArgumentNullException("Head");
            }
            return CheckHelper(ref head, head);
        }

        private static bool CheckHelper(ref LinkedListNode<char> head, LinkedListNode<char> tail)
        {
            if (tail.Next != null)
            {
                if (!CheckHelper(ref head, tail.Next))
                {
                    return false;
                }
            }

            var temp = head;
            head = head.Next;
            return temp.Value == tail.Value;
        }
    }
}
