using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class DoubleList<T> where T : IComparable
    {
        DoubleNode<T> head;            //Головной/первый элемент
        DoubleNode<T> tail;            //Последний/хвостовой элемент
        public int Count { get; set; }     //количество элементов(узлов) в списке

        public DoubleList()
        {
            head = null;
            tail = null;
        }

        //Добавление в начало
        public void AddTop(int k, T v)
        {

            DoubleNode<T> new_node = new DoubleNode<T>(k, v);
            DoubleNode<T> tmp = head;
            new_node.Next = tmp;
            head = new_node;
            if (Count == 0)
                tail = head;
            else
                tmp.Prev = new_node;
            Count++;
        }

        //Добавление узла в конец
        public void AddEnd(int k, T v)
        {
            DoubleNode<T> new_node = new DoubleNode<T>(k, v);

            if (head == null)
            {
                //head = new_node;
                AddTop(k, v);
            }
            else
            {
                new_node.Prev = tail;
                tail.Next = new_node;
                tail = new_node;
            }
            Count++;
        }

        //Проверка на наличие элемента в двусвязном списке
        public bool IsContainsByValue(T value)
        {
            DoubleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }

        //Удаление первого узла из двусвязного списка
        public void RemoveTop()
        {
            if (Count > 0)
            {
                head = head.Next;
                head.Prev = null;
                Count--;
                return;
            }
        }


        //Удаление последнего узла из двусвязного списка
        public void RemoveEnd()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    head = null; tail = null; Count = 0; return;
                }

                DoubleNode<T> tmp = head;

                //Найдем предпоследний узел
                while (tmp.Next.Next != null)        //tmp.Next.Next - предпоследний узел
                {
                    tmp = tmp.Next;
                }
                tmp.Next.Prev = null;
                tmp.Next = null;
                tail = tmp;

                Count--;
            }
        }

        //Удаление по значению
        public bool RemoveByValue(T value)
        {
            DoubleNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Prev;
                }

                // если узел не первый
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                Count--;
                return true;
            }
            return false;
        }

        //Удаление по ключу
        public bool RemoveByKey(int value)
        {
            DoubleNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Key.Equals(value))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Prev;
                }

                // если узел не первый
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                Count--;
                return true;
            }
            return false;
        }

        //Удаление по индексу
        public bool RemoveByIndex(int index)
        {
            int i = 0;
            DoubleNode<T> current = head;

            if (index < 0 || index >= Count) return false;

            // поиск удаляемого узла
            while (current != null)
            {
                if (i == index)
                {
                    break;
                }
                i++;
                current = current.Next;
            }

            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Prev;
                }

                // если узел не первый
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                Count--;
                return true;
            }
            return false;
        }

        //Поиск по значению
        public DoubleNode<T> FindByValue(T value)
        {
            DoubleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }

        //Поиск по ключу
        public DoubleNode<T> FindByKey(int key)
        {
            DoubleNode<T> tmp = head;
            while (tmp != null)
            {
                if (tmp.Key.Equals(key))
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }

        //Поиск по индесу
        public DoubleNode<T> FindByIndex(int index)
        {
            int i = 0;
            DoubleNode<T> tmp = head;
            if (index < 0 || index >= Count) return null;
            while (tmp != null)
            {
                if (i == index) { return tmp; }
                tmp = tmp.Next;
                i++;
            }
            return null;
        }

        //Вставка нового узла после выбранного узла
        public void InsertByAfterValue(T select, int key, T value)
        {
            DoubleNode<T> after_me = head;
            if (Count == 0) { head = after_me; }
            while (after_me != null)
            {
                if (after_me.Value.Equals(select))
                {
                    //FindByValue(value);
                    DoubleNode<T> nn = new DoubleNode<T>(key, value);
                    if (after_me.Next == null) { AddEnd(key, value); return; }
                    after_me.Next.Prev = nn;
                    nn.Next = after_me.Next;
                    after_me.Next = nn;
                    nn.Prev = after_me;
                }
                after_me = after_me.Next;
                Count++;
            }
        }

        //Вставка нового узла перед выбранным узлом
        public void InsertByBeforeValue(T select, int key, T value)
        {
            DoubleNode<T> before_me = head;
            if (Count == 0) { head = before_me; tail = before_me; }
            while (before_me != null)
            {
                if (before_me.Value.Equals(select))
                {
                    DoubleNode<T> nn = new DoubleNode<T>(key, value);
                    if (before_me.Prev == null) { AddTop(key, value); return; }
                    before_me.Prev.Next = nn;
                    nn.Prev = before_me.Prev;
                    before_me.Prev = nn;
                    nn.Next = before_me;
                }
                before_me = before_me.Next;
                Count++;
            }
        }

        public void ViewForward()
        {
            Console.WriteLine("Double List Forward");
            DoubleNode<T> current = head;

            while (current != null)
            {
                Console.Write("{0} => ", current);
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void ViewBack()
        {
            Console.WriteLine("Double List Back");
            DoubleNode<T> current = tail;

            while (current != null)
            {
                Console.Write("{0} => ", current);
                current = current.Prev;
            }
            Console.WriteLine();
        }

        //Очистка
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

    }
}

