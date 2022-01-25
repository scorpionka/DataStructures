namespace Tasks
{
    public class Node<T>
    {
        private T nodeValue;
        private Node<T> previousNode;
        private Node<T> nextNode;

        public Node(T nodeValue)
        {
            this.nodeValue = nodeValue;
        }

        public T NodeValue { get => nodeValue; set => nodeValue = value; }
        public Node<T> PreviousNode { get => previousNode; set => previousNode = value; }
        public Node<T> NextNode { get => nextNode; set => nextNode = value; }
    }
}
