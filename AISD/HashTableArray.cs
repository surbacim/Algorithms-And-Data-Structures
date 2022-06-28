using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class HTArray<T>
    {
        public SingleNode<T>[] htArray;
        public int Size;
        public int count;

        public int getCount()
        {
            return count;
        }

        public HTArray(int size)
        {
            this.Size = size;
            htArray = new SingleNode<T>[size];
            for (int i = 0; i < size; i++)
                htArray[i] = new SingleNode<T>();
            count = 0;
        }

        public int HashCode(int key)    //возвращает хеш-функцию
        {
            return key % Size;
        }

        public void AddKV(int key, T value)
        {
            if (count == Size) { return; }
            int j = HashCode(key);

            do
            {
                if (htArray[j] == null || htArray[j].Key == 0)
                {
                    htArray[j] = new SingleNode<T>(key, value);
                    break;
                }
                else j++;

                if (j == Size)
                {
                    j = 0;
                }
            }
            while (true);

            count++;
        }

        public int SearchByKey(int key)
        {
            int j = 0;

            j = HashCode(key);

            while (htArray[j] != null)
            {
                if (htArray[j].Key.CompareTo(key) == 0)
                {
                    return j;
                }

                j++;

                if (j == Size)
                {
                    j = 0;
                }

            }
            return -1;
        }

        public void RemoveByKey(int key)
        {
            int index = SearchByKey(key);

            if (index != -1)
            {
                htArray[index].Key = key;
                htArray[index].Value = default;
                count--;
            }
        }

        public SingleNode<T>[] ToArray()
        {
            SingleNode<T>[] tmp = null;
            int tmpcount = count;
            if (tmpcount > 0)
            {
                tmp = new SingleNode<T>[tmpcount];
                int k = 0;
                for (int i = 0; i < Size; i++)
                {
                    if (htArray[i] != null && htArray[i].Key.CompareTo(default) != 0)
                    {
                        tmp[k++] = htArray[i];
                    }
                }
            }
            return tmp;
        }

        public void Resizenew(int newSize)
        {
            SingleNode<T>[] tmp = null;
            int tmpcount = count;
            if (tmpcount > 0) tmp = this.ToArray();
            this.Size = newSize;
            htArray = new SingleNode<T>[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                htArray[i] = null;
            }
            count = 0;
            if (tmpcount > 0)
            {
                foreach (SingleNode<T> el in tmp)
                {
                    this.AddKV(el.Key, el.Value);
                }
            }

        }

        public void View()
        {
            for (int i = 0; i < htArray.Length; i++)
            {
                if (htArray[i] != null && htArray[i].Key != 0)
                {
                    Console.WriteLine(htArray[i]);
                }
            }
        }

    }
}

