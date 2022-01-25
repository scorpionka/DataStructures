namespace Tasks
{
    public class Node<T>
    {
        private T data;
        public Node<T> prev;
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;
        }

        public T Data { get => data; set => data = value; }
    }
}
