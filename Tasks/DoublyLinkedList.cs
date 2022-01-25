using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;

        public int Length
        {
            get
            {
                int count = 0;
                Node<T> node = this.head;

                while (node != null)
                {
                    node = node.next;
                    count++;
                }

                return count;
            }
        }

        public Node<T> Head => this.head;

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            Node<T> last = this.head;
            newNode.next = null;

            if (this.head == null)
            {
                newNode.prev = null;
                this.head = newNode;
                return;
            }

            while (last.next != null)
                last = last.next;

            last.next = newNode;
            newNode.prev = last;
        }

        public void AddAt(int index, T e)
        {
            if (this.Length == 0 || index == this.Length)
            {
                this.Add(e);
                return;
            }

            int count = 0;
            Node<T> last = this.head;

            if (index == 0)
            {
                this.head.Data = e;
                return;
            }

            while (last.next != null)
            {
                last = last.next;
                count++;

                if (index == count)
                {
                    last.Data = e;
                    return;
                }
            }
        }

        public T ElementAt(int index)
        {
            if (this.Length <= index || index < 0)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            int count = 0;
            Node<T> last = this.head;

            if (index == 0)
            {
                return last.Data;
            }

            while (last.next != null)
            {
                last = last.next;
                count++;

                if (index == count)
                {
                    return last.Data;
                }
            }

            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this);
        }

        public void Remove(T item)
        {
            if (this.head == null)
            {
                return;
            }

            Node<T> last = this.head;

            while (last != null)
            {
                if (last.Data.Equals(item))
                {
                    this.head = RemoveNode(last);
                    return;
                }
                else
                    last = last.next;

            }
        }

        public T RemoveAt(int index)
        {
            if (this.head == null || index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            Node<T> last = this.head;
            int count;

            for (count = 0; last != null && count < index; count++)
            {
                last = last.next;
            }

            this.RemoveNode(last);

            return last.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private Node<T> RemoveNode(Node<T> node)
        {
            if (this.head == null || node == null)
                return null;

            if (this.head == node)
                this.head = node.next;

            if (node.next != null)
                node.next.prev = node.prev;

            if (node.prev != null)
                node.prev.next = node.next;

            return this.head;
        }
    }
}
