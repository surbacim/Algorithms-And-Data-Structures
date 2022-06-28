using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class DoubleNode<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }
        public DoubleNode<T> Next { get; set; }     //Ссылка на следующий узел
        public DoubleNode<T> Prev { get; set; }     //Ссылка на предыдущий узел

        public DoubleNode()
        {
            Key = 0;
            Value = default(T);
            Next = null;
            Prev = null;
        }

        public DoubleNode(int key, T value, DoubleNode<T> next, DoubleNode<T> prev)
        {
            Key = key;
            Value = value;
            Next = next;
            Prev = prev;
        }

        public DoubleNode(int key, T value)
        {
            Key = key;
            Value = value;
            Next = null;
            Prev = null;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Key, Value);
        }




    }
}
