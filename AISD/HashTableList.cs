using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class HTList<T> where T : IComparable
    {
        public List<SingleNode<T>>[] htLists;
        public int Size;    //кол-во списков
        public int count;   //кол-во всех эл-ов в таблице

        public int getCount()
        {
            return count;
        }

        public HTList(int size)
        {
            this.Size = size;
            htLists = new List<SingleNode<T>>[size];
            for (int i = 0; i < size; i++)
                htLists[i] = new List<SingleNode<T>>();
            count = 0;
        }

        public int HashCode(int key)    //возвращает хеш-функцию
        {
            return key % Size;
        }

        public void AddKV(int key, T value)
        {
            if (count >= Size)
            {
                Console.WriteLine("Error! HT is full!");
                return;
            }

            int index = HashCode(key);
            if (htLists[index] != null && htLists[index].Count == key)
            {
                Console.WriteLine($" {key} - this key exists!");
                return;
            }
            else
            {
                SingleNode<T> element = new SingleNode<T>(key, value);
                htLists[index].Add(element);

            }

            count++;
        }

        public void RemoveByKey(int key)  //удаление элемента по ключу
        {
            int index = HashCode(key);
            int findind = -1;
            for (int i = 0; i < htLists[index].Count; i++)
            {
                SingleNode<T> curitem = htLists[index][i];
                if (curitem.Key.CompareTo(key) == 0) { findind = i; break; }
            }
            if (findind >= 0) { htLists[index].RemoveAt(findind); count--; }

        }

        public void Resize(int newSize) //Изменить размер хеш-таблицы   
        {
            List<SingleNode<T>> tmp = new List<SingleNode<T>>();

            for (int index = 0; index < Size; index++)
            {
                for (int i = 0; i < htLists[index].Count; i++)
                {
                    SingleNode<T> curitem = htLists[index][i];
                    tmp.Add(curitem);
                }
            }

            htLists = new List<SingleNode<T>>[newSize];
            this.Size = newSize;
            for (int i = 0; i < Size; i++)
            {
                htLists[i] = new List<SingleNode<T>>();
            }
            count = 0;

            foreach (SingleNode<T> el in tmp)
            {
                this.AddKV(el.Key, el.Value);
            }
        }

        public SingleNode<T> SearchByKey(int key)   //Поиск
        {
            int index = HashCode(key);
            for (int i = 0; i < htLists[index].Count; i++)
            {
                var curitem = htLists[index][i];
                if (curitem.Key.CompareTo(key) == 0) { return curitem; }

            }
            return null;
        }

        public void View()
        {
            for (int index = 1; index < Size; index++)
            {
                Console.WriteLine("List {0}", index);
                for (int i = 0; i < htLists[index].Count; i++)
                {
                    SingleNode<T> curitem = htLists[index][i];
                    Console.Write("{0} ", curitem);
                }
                Console.WriteLine();
            }
        }

    }
}

