using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class BinaryNode<T>
    {
        public int Key;
        public T Value;
        public BinaryNode<T> Parent;
        public BinaryNode<T> Left;
        public BinaryNode<T> Right;

        public BinaryNode(int k, T v)   //Конструктор
        {
            Key = k;
            Value = v;
            Parent = null;
            Left = null;
            Right = null;
        }

        public BinaryNode() //Пустой конструктор
        {
            Key = int.MaxValue;
            Value = default(T);
            Parent = null;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            string ret = string.Format("(Key = {0} Value = {1})", Key, Value);
            if (Parent != null) ret = ret + string.Format(" Parent key = {0};", Parent.Key);
            if (Left != null) ret = ret + string.Format(" Left key = {0};", Left.Key);
            if (Right != null) ret = ret + string.Format(" Right key = {0}", Right.Key);
            return ret;
        }

    }

    class BinaryTree<T>     //Класс бинраного дерева (упорядоченного дерева)
    {
        public BinaryNode<T> root;  //Корень дерева

        public BinaryTree()
        {
            root = null;
        }

        public void AddNodeInThree(int k, T v)  //Добавление узла
        {
            if (root == null)
            {
                root = new BinaryNode<T>(k, v);
                return;
            }
            BinaryNode<T> tmp = root;
            while (tmp != null)
            {
                if (tmp.Key == k) return;
                if (tmp.Key > k) //значит идем влево
                {
                    if (tmp.Left != null) tmp = tmp.Left;
                    else
                    {
                        BinaryNode<T> newNode = new BinaryNode<T>(k, v);
                        newNode.Parent = tmp;
                        tmp.Left = newNode;
                        return;
                    }
                }

                if (tmp.Key < k) //значит идем вправо
                {
                    if (tmp.Right != null) tmp = tmp.Right;
                    else
                    {
                        BinaryNode<T> newNode = new BinaryNode<T>(k, v);
                        newNode.Parent = tmp;
                        tmp.Right = newNode;
                        return;
                    }
                }
            }

        }

        public BinaryNode<T> Search(int k)  //Поиск узла
        {
            if (root == null)
            {
                return null;
            }
            BinaryNode<T> tmp = root;
            while (tmp != null)
            {
                if (tmp.Key == k) return tmp;
                if (tmp.Key > k) //значит идем влево
                {
                    if (tmp.Left != null) tmp = tmp.Left;

                }

                if (tmp.Key < k) //значит идем вправо
                {
                    if (tmp.Right != null) tmp = tmp.Right;

                }
            }
            return null;
        }

        public bool DelNode(int key)    //Удаление узла
        {
            BinaryNode<T> findNode = Search(key);
            if (findNode == null) { return false; }

            //если у узла нет подузлов, можно его удалить
            if (findNode.Left == null && findNode.Right == null)
            {
                if (findNode == root) { root = null; return true; }
                if (findNode.Parent.Right == findNode) { findNode.Parent.Right = null; return true; }
                if (findNode.Parent.Left == findNode) { findNode.Parent.Left = null; return true; }

            }

            //если у удаляемого узла один потомок - либо справа, либо слева
            if (findNode.Left == null || findNode.Right == null)
            {
                BinaryNode<T> p = findNode.Parent;
                if (findNode.Left == null)
                {
                    if (p.Left == findNode) { p.Left = findNode.Right; }
                    else { p.Right = findNode.Right; }

                    findNode.Right.Parent = p;
                }
                else
                {
                    if (p.Left == findNode) { p.Left = findNode.Left; }
                    else { p.Right = findNode.Left; }

                    findNode.Left.Parent = p;
                }
            }

            //если у удаляемого узла два потомка
            if (findNode.Left != null && findNode.Right != null)
            {
                BinaryNode<T> children = NextNodeNew(findNode);    //Потомок
                findNode.Key = children.Key;
                if (children.Parent.Left == children)
                {
                    children.Parent.Left = children.Right;
                    if (children.Right != null) { children.Right.Parent = children.Parent; return true; }
                    return true;
                }
                else children.Parent.Right = children.Right;

                if (children.Right != null) { children.Right.Parent = children.Parent; return true; }
            }

            return false;

        }

        public BinaryNode<T> MinNode(BinaryNode<T> tmp) //min узел от указанной выршины
        {
            while (tmp.Left != null)
            {
                tmp = tmp.Left;
            }
            return tmp;
        }

        public BinaryNode<T> MaxNode(BinaryNode<T> tmp) //max узел от указанной выршины
        {
            while (tmp.Right != null)
            {
                tmp = tmp.Right;
            }
            return tmp;
        }

        public BinaryNode<T> NextNodeNew(BinaryNode<T> x)   //Найти следующий узел по значению ключа
        {
            if (x.Right != null)
            {
                return MinNode(x.Right);
            }
            BinaryNode<T> y = x.Parent;
            while (y != null && x == y.Right)
            {
                x = y;
                y = y.Parent;
            }
            return y;
        }

        public BinaryNode<T> PrevNodeNew(BinaryNode<T> x)   //Найти предыдущий узел по значению ключа
        {
            if (x.Left != null)
            {
                return MaxNode(x.Left);
            }
            BinaryNode<T> y = x.Parent;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }
            return y;
        }

        public void LeftRotate(BinaryNode<T> x)
        {
            if (x.Right != null)
            {
                BinaryNode<T> y = x.Right;    //Находим у
                x.Right = y.Left;   //Левое поддерево "у" становится правым поддревом "x"

                if (y.Left != null)
                {
                    y.Parent.Left = x;
                }

                y.Parent = x.Parent; //Делаем родителя "x" родителем "у"

                if (x.Parent == null)
                {
                    root = y;
                }
                else if (x == x.Parent.Left) { x.Parent.Left = y; }
                else x.Parent.Right = y;

                y.Left = x;     //Делаем "x" левым ребенком "у"
                x.Parent = y;
            }

        }

        public void RightRotate(BinaryNode<T> x)
        {
            if (x.Left != null)
            {
                BinaryNode<T> y = x.Left;    //Находим у
                x.Left = y.Right;   //Правое поддерево "у" становится левым поддревом "x"

                if (y.Right != null)
                {
                    y.Parent.Right = x;
                }

                y.Parent = x.Parent; //Делаем родителя "x" родителем "у"

                if (x.Parent == null)
                {
                    root = y;
                }
                else if (x == x.Parent.Right) { x.Parent.Right = y; }
                else x.Parent.Left = y;

                y.Right = x;     //Делаем "x" правым ребенком "у"
                x.Parent = y;
            }

        }

        public void ViewAscending(BinaryNode<T> tmp)    //Вывести на экран бинарное дерево по возрастанию (Симметричный обход) 
        {
            if (tmp != null)
            {
                if (tmp.Left != null) ViewAscending(tmp.Left);
                Console.WriteLine(tmp);
                if (tmp.Right != null) ViewAscending(tmp.Right);
            }
        }

        public void ViewDescending(BinaryNode<T> tmp)   //Вывести на экран бинарное дерево по убыванию (Обход в обратном порядке)
        {
            if (tmp != null)
            {
                if (tmp.Right != null) ViewDescending(tmp.Right);
                Console.WriteLine(tmp);
                if (tmp.Left != null) ViewDescending(tmp.Left);
            }
        }

        public void ViewG(BinaryNode<T> tmp)    //Вывести на экран бинарное дерево (Обход в прямом порядке)
        {
            if (tmp != null)
            {
                Console.WriteLine(tmp);
                if (tmp.Left != null) ViewG(tmp.Left);
                if (tmp.Right != null) ViewG(tmp.Right);
            }
        }

        public void ViewDepthFirst(BinaryNode<T> tmp)   //Обход в ширину
        {
            Queue<BinaryNode<T>> Qchildren = new Queue<BinaryNode<T>>(); // Создаем очередь для хранения дочерних вершин при дальнейшей обработке

            Qchildren.Enqueue(tmp); // Помещаем корень в очередь

            while (Qchildren.Count > 0) // Обрабатываем очередь, пока она не станет пустой
            {
                BinaryNode<T> node = Qchildren.Dequeue(); // Получаем следующую вершину в очереди
                Console.WriteLine(node); // Обрабатываем вершину

                // Добавляем дочернюю вершину в очередь
                if (node.Left != null) Qchildren.Enqueue(node.Left);
                if (node.Right != null) Qchildren.Enqueue(node.Right);

            }

        }

    }
}
