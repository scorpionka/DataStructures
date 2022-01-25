using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly DoublyLinkedList<T> collection;
        private int position = -1;

        public DoublyLinkedListEnumerator(DoublyLinkedList<T> collection)
        {
            this.collection = collection;
        }

        public Node<T> Node { get; private set; }
        public T Current { get { return this.Node.NodeValue; } }
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            position++;

            if (position == 0)
            {
                this.Node = this.collection.HeadNode;
            }
            else
            {
                this.Node = this.Node.NextNode;
            }

            return (position < this.collection.Length);
        }

        public void Reset()
        {
            this.position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}
