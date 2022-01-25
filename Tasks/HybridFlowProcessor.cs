using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly IDoublyLinkedList<T> storage;

        public HybridFlowProcessor()
        {
            this.storage = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (this.storage.Length <= 0)
            {
                throw new InvalidOperationException();
            }

            return this.storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            this.storage.Add(item);
        }

        public T Pop()
        {
            if (this.storage.Length <= 0)
            {
                throw new InvalidOperationException();
            }

            return this.storage.ElementAt(this.storage.Length - 1);
        }

        public void Push(T item)
        {
            this.storage.Add(item);
        }
    }
}
