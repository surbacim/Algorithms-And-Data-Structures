using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class SingleNode<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }
        public SingleNode<T> Next { get; set; }

        public SingleNode()
        {
            Key = 0;
            Value = default(T);
            Next = null;
        }

        public SingleNode(int key, T value, SingleNode<T> next)
        {
            Key = key;
            Value = value;
            Next = next;
        }

        public SingleNode(int key, T value)
        {
            Key = key;
            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            return string.Format("key = {0} value = {1}", Key, Value);
        }



    }
}
