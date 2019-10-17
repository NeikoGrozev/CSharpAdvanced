namespace CustomDoublyLinkedList
{
    using System;

    public class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }
        }

        private ListNode head;

        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            ListNode newHead = new ListNode(element);

            if (this.Count == 0)
            {
                this.head = newHead;
                this.tail = newHead;
            }
            else
            {// 2 1
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            ListNode newTail = new ListNode(element);

            if (this.Count == 0)
            {
                this.head = newTail;
                this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public int RemoveFirs()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }

            int removeElement = this.head.Value;

            ListNode newHead = this.head.NextNode;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;

            return removeElement;
        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }

            int removeElement = this.tail.Value;

            ListNode newTail = this.tail.PreviousNode;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;

            return removeElement;
        }

        public void ForEach(Action<int> action)
        {
            ListNode currentNode = this.head;

            while (true)
            {
                if (currentNode == null)
                {
                    break;
                }

                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }
    }
}
