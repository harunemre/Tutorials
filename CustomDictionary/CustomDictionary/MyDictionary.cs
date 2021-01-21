namespace CustomDictionary
{
    /// <summary>
    /// Bir dictionary temelinde linked list implemantosyunu kullanır.
    /// Örnekteki linked list implemantosyundan esinlendildi. <see href="https://codeinout.blogspot.com/2019/10/implementing-generic-linked-list-with.html">Bknz</see>
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MyDictionary<TKey, TValue>
    {
        public HashNodeMap<TValue> hashNode = null;
        public int Count;

        private HashNodeMap<TValue> CreateNode(TKey key, TValue value)
        {
            int hashCode = key.GetHashCode();
            HashNodeMap<TValue> newNodeMap = new HashNodeMap<TValue>
            {
                data = new Node<TValue>(value),
                key = hashCode
            };
            return newNodeMap;
        }

        public void Add(TKey key, TValue value)
        {
            if (hashNode == null)
            {
                hashNode = CreateNode(key, value);
            }
            else
            {
                HashNodeMap<TValue> current = hashNode;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = CreateNode(key, value);
            }
            Count++;
        }
    }
}