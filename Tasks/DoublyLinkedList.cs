using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> headNode;

        public int Length
        {
            get
            {
                int count = 0;
                Node<T> node = this.HeadNode;

                while (node != null)
                {
                    node = node.NextNode;
                    count++;
                }

                return count;
            }
        }

        public Node<T> HeadNode { get => this.headNode; set => this.headNode = value; }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            Node<T> currentNode = this.HeadNode;
            newNode.NextNode = null;

            if (this.HeadNode == null)
            {
                newNode.PreviousNode = null;
                this.HeadNode = newNode;
                return;
            }

            while (currentNode.NextNode != null)
                currentNode = currentNode.NextNode;

            currentNode.NextNode = newNode;
            newNode.PreviousNode = currentNode;
        }

        public void AddAt(int index, T e)
        {
            if (this.Length == 0 || index == this.Length)
            {
                this.Add(e);
                return;
            }

            int count = 0;
            Node<T> currentNode = this.HeadNode;

            if (index == 0)
            {
                this.HeadNode.NodeValue = e;
                return;
            }

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
                count++;

                if (index == count)
                {
                    currentNode.NodeValue = e;
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
            Node<T> currentNode = this.HeadNode;

            if (index == 0)
            {
                return currentNode.NodeValue;
            }

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
                count++;

                if (index == count)
                {
                    return currentNode.NodeValue;
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
            if (this.HeadNode == null)
            {
                return;
            }

            Node<T> currentNode = this.HeadNode;

            while (currentNode != null)
            {
                if (currentNode.NodeValue.Equals(item))
                {
                    this.HeadNode = RemoveNode(currentNode);
                    return;
                }
                else
                    currentNode = currentNode.NextNode;

            }
        }

        public T RemoveAt(int index)
        {
            if (this.HeadNode == null || index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            Node<T> currentNode = this.HeadNode;
            int count;

            for (count = 0; currentNode != null && count < index; count++)
            {
                currentNode = currentNode.NextNode;
            }

            this.RemoveNode(currentNode);

            return currentNode.NodeValue;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private Node<T> RemoveNode(Node<T> nodeToRemove)
        {
            if (this.HeadNode == null || nodeToRemove == null)
                return null;

            if (this.HeadNode == nodeToRemove)
                this.HeadNode = nodeToRemove.NextNode;

            if (nodeToRemove.NextNode != null)
                nodeToRemove.NextNode.PreviousNode = nodeToRemove.PreviousNode;

            if (nodeToRemove.PreviousNode != null)
                nodeToRemove.PreviousNode.NextNode = nodeToRemove.NextNode;

            return this.HeadNode;
        }
    }
}
