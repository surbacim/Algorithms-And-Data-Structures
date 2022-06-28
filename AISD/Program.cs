using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Set

            Console.WriteLine("Test Set_Alg\n");
            int[] mas1 = { 2, 6, 3 };
            int[] mas2 = { 3, 6, 9, 11 };
            string[] ms = { "Афанасьев", "Николаев", "Романов" };

            Set<int> s1 = new Set<int>(mas1);
            Set<int> s2 = new Set<int>(mas2);
            Set<string> ss = new Set<string>(ms);
            Console.WriteLine("Множество 1 = {0}", s1);
            Console.WriteLine("Множество 2 = {0}", s2);
            Console.WriteLine("Множество с символами = {0}\n", ss);

            Set<int> s3 = s1.Union(s2);
            Console.WriteLine("Объединение множества {0} с множеством {1} и получим множество = {2}", s1, s2, s3);

            Set<int> s3_1 = s1.Intersection(s2);
            Console.WriteLine("Пересечение множества {0} с множеством {1} и получим множество = {2}", s1, s2, s3_1);

            Console.WriteLine("Добавили в множество {0} новый элемент", s2);
            s2.Add(7);
            Console.WriteLine("и получили: Size = {0} Count = {1} Set_Alg = {2}\n", s2.Size, s2.Count, s2);

            Set<int> s4 = s1 + s2 + s3;
            Console.WriteLine("{0} + {1} + {2} = {3}\n", s1, s2, s3, s4);

            s2.RemoveByIndex(1);
            Console.WriteLine("RemoveByIndex: {0}", s2);

            s2.RemoveByElement(3);
            Console.WriteLine("RemoveByElement: {0}", s2);

            Set<int> set = s1.Difference(s2);
            Console.WriteLine("Дополнение множеств (разность): {0}\n", set);

            s1.Resize(10);
            Console.WriteLine("Увеличим размер иножества {0} и получим newSize: {1} Count: {2}", s1, s1.size, s1.Count);

            List<Set<int>> ls = s1.GetList();
            foreach (var curs in ls) Console.WriteLine("GETLIST: {0}", curs);

            Console.WriteLine("Поиск всех подмножеств множества: 1 вариант");
            s1.Numbcomb(mas1);

            Console.WriteLine("\nПоиск всех подмножеств множества: 2 вариант");
            List<Set<int>> ssss = s1.SetsOfSubSets();
            foreach (var s in ssss)
            {
                Console.WriteLine(s);
            }

            s1.Perevod(15, 2);

            Console.WriteLine("GetElementByIndex: {0}", s1.GetElementByIndex(0));
            Console.WriteLine("SetElementByIndex: {0} Rezult: {1}\n", s1.SetElementByIndex(0, 22), s1);

            #endregion

            #region Sorting

            Console.WriteLine("*Test Sorting*");

            Console.WriteLine("--BubbleSort--");
            double[] mas1s = { -2.5, 0.4, 6, -3.0, 8.1, -6.66, 2.11 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas1s.Length; i++)
                Console.Write("{0}\t", mas1s[i]);
            Console.WriteLine();
            Sort.BubbleSort<double>(mas1s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas1s.Length; i++)
                Console.Write("{0}\t", mas1s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--BubbleSortSwap--");
            double[] mas2s = { 10.5, -2.5, 0.4, 6, -3.0, 8.1, -6.66, 2.11 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas2s.Length; i++)
                Console.Write("{0}\t", mas2s[i]);
            Console.WriteLine();
            Sort.BubbleSortSwap<double>(mas2s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas2s.Length; i++)
                Console.Write("{0}\t", mas2s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--MyBubbleSortStep--");
            double[] mas2_1s = { 0, 1, 2, 4, 5, 6, 3, 7, 8, 9 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas2_1s.Length; i++)
                Console.Write("{0}\t", mas2_1s[i]);
            Console.WriteLine();
            Sort.MyBubbleSortStep<double>(mas2_1s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas2_1s.Length; i++)
                Console.Write("{0}\t", mas2_1s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--InsertionSort--");
            double[] mas3s = { 11.5, -8.5, 0.9, 8, -6.0, 5.1, -7.7, 3.11 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas3s.Length; i++)
                Console.Write("{0}\t", mas3s[i]);
            Console.WriteLine();
            Sort.InsertionSort<double>(mas3s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas3s.Length; i++)
                Console.Write("{0}\t", mas3s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--SelectionSort--");
            double[] mas4s = { 100.0, -25.5, 0.99, 8.22, -65.0, 85.1, -75.7, 13.1 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas4s.Length; i++)
                Console.Write("{0}\t", mas4s[i]);
            Console.WriteLine();
            Sort.SelectionSort<double>(mas4s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas4s.Length; i++)
                Console.Write("{0}\t", mas4s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--Shell sort--");
            double[] mas5s = { 25.0, 15.0, 10.0, -1.0, -15.0, -19.0, -25.0, 5.55 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas5s.Length; i++)
                Console.Write("{0}\t", mas5s[i]);
            Console.WriteLine();
            Sort.ShellSort(mas5s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas5s.Length; i++)
                Console.Write("{0}\t", mas5s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--Shaker sort--");
            double[] mas6s = { 25.5, -99.0, 5.0, -1.0, 2.8, 6.0, -365.0, 4.4 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas6s.Length; i++)
                Console.Write("{0}\t", mas6s[i]);
            Console.WriteLine();
            Sort.ShakerSort(mas6s);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas6s.Length; i++)
                Console.Write("{0}\t", mas6s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("Алгоритмы O(N*logN)");

            Console.WriteLine("--Quick sort--");
            double[] mas7s = { 100, 75, 50.5, 25.5, -25.5, -50.5, -75, -100 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas7s.Length; i++)
                Console.Write("{0}\t", mas7s[i]);
            Console.WriteLine();
            Sort.QuickSort(mas7s, 0, mas7s.Length - 1);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas7s.Length; i++)
                Console.Write("{0}\t", mas7s[i]);
            Console.WriteLine("\n");

            Console.WriteLine("--Marge sort--");
            double[] mas8s = { 1000, 750, 500.5, 250.5, -250.5, -500.5, -750, -1000 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas8s.Length; i++)
                Console.Write("{0}\t", mas8s[i]);
            Console.WriteLine();
            Sort.MergeSort(mas8s, 0, mas8s.Length - 1);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas8s.Length; i++)
                Console.Write("{0}\t", mas8s[i]);
            Console.WriteLine("\n");

            #endregion

            #region Single Node
            Console.WriteLine("Test SingleList and SingleNode!");
            SingleList<int> singleList = new SingleList<int>();

            singleList.AddTop(1, 11);
            singleList.AddTop(2, 22);
            singleList.AddTop(3, 33);
            singleList.AddTop(4, 44);
            singleList.AddTop(5, 55);
            singleList.AddTop(6, 66);
            singleList.AddTop(7, 77);
            singleList.AddEnd(8, 88);
            singleList.AddEnd(9, 99);

            singleList.InsertByAfterValue(11, 20, 20);
            singleList.InsertByBeforeValue(33, 21, 21);
            //singleList.RemoveEnd();
            //singleList.RemoveTop();
            singleList.RemoveByValue(66);
            singleList.RemoveByKey(4);
            singleList.RemoveByIndex(8);

            singleList.View();

            Console.WriteLine("Find by Value: {0}", singleList.FindByValue(22));
            Console.WriteLine("Find by Index: {0}", singleList.FindByIndex(4));
            Console.WriteLine("Find by Key: {0}\n", singleList.FindByKey(1));

            #endregion

            #region Double Node
            Console.WriteLine("Test DoubleList and DoubleNode!");
            DoubleList<int> doubleList = new DoubleList<int>();

            doubleList.AddEnd(2, 22);
            doubleList.AddEnd(3, 33);
            doubleList.AddEnd(4, 44);
            doubleList.AddEnd(5, 55);
            doubleList.AddEnd(6, 66);
            doubleList.AddEnd(7, 77);
            doubleList.AddEnd(8, 88);
            doubleList.AddTop(1, 11);
            doubleList.RemoveTop();
            doubleList.RemoveEnd();

            doubleList.InsertByAfterValue(44, 45, 45);
            doubleList.InsertByBeforeValue(33, 25, 25);

            doubleList.ViewForward();
            doubleList.ViewBack();

            Console.WriteLine("Find by Value: {0}", doubleList.FindByValue(33));
            Console.WriteLine("Find by Key: {0}", doubleList.FindByKey(4));
            Console.WriteLine("Find by Index: {0}\n", doubleList.FindByIndex(2));

            #endregion

            #region Hash Table List

            Console.WriteLine("Hash Table List Test! --- Start");
            HTList<int> hashTableList = new HTList<int>(7);

            hashTableList.AddKV(1, 11);
            hashTableList.AddKV(2, 22);
            hashTableList.AddKV(3, 33);
            hashTableList.AddKV(4, 44);
            hashTableList.AddKV(5, 55);
            hashTableList.AddKV(6, 66);

            hashTableList.View();

            hashTableList.RemoveByKey(5);
            Console.WriteLine("\nAfter Remove:");
            hashTableList.View();

            Console.WriteLine("\nSearch: {0}", hashTableList.SearchByKey(2));

            hashTableList.Resize(10);
            Console.WriteLine("\nAfter Resize");
            hashTableList.View();


            Console.WriteLine("\nHash Table List Test! --- End");

            #endregion

            #region Hash Table Array

            Console.WriteLine("\nHash Table Array Test! --- Start");
            HTArray<string> htArray = new HTArray<string>(7);

            htArray.AddKV(1, "A1");
            htArray.AddKV(2, "B2");
            htArray.AddKV(3, "C3");
            htArray.AddKV(4, "D4");
            htArray.AddKV(5, "E5");
            htArray.AddKV(6, "F6");

            htArray.View();

            Console.WriteLine("\nSearch {0}", htArray.SearchByKey(4));

            htArray.RemoveByKey(5);
            Console.WriteLine("\nAfter remove:");
            htArray.View();

            Console.WriteLine("\nHash Table Array Test! --- End");

            #endregion

            #region Binary Tree

            Console.WriteLine("\nBinary Tree Test! --- Start");
            BinaryTree<string> binaryThree = new BinaryTree<string>();
            binaryThree.AddNodeInThree(10, "A");
            binaryThree.AddNodeInThree(15, "B");
            binaryThree.AddNodeInThree(5, "C");
            binaryThree.AddNodeInThree(25, "D");
            binaryThree.AddNodeInThree(8, "E");
            binaryThree.AddNodeInThree(7, "F");
            binaryThree.AddNodeInThree(12, "G");
            binaryThree.AddNodeInThree(14, "K");
            binaryThree.AddNodeInThree(21, "L");
            binaryThree.AddNodeInThree(1, "M");

            Console.WriteLine("По возрастанию");
            binaryThree.ViewAscending(binaryThree.root);

            Console.WriteLine("\nПо убыванию");
            binaryThree.ViewDescending(binaryThree.root);

            Console.WriteLine("\nОбход в прямом порядке");
            binaryThree.ViewG(binaryThree.root);

            Console.WriteLine("\nОбход в ширину");
            binaryThree.ViewDepthFirst(binaryThree.root);

            binaryThree.DelNode(15);    //Удаляем, когда два потомка
            Console.WriteLine("\nAfter delete - ascending --- Для проверки");
            binaryThree.ViewAscending(binaryThree.root);
            Console.WriteLine("\nAfter delete - descending --- Для проверки");
            binaryThree.ViewDescending(binaryThree.root);

            BinaryNode<string> searchNode = binaryThree.Search(21);
            Console.WriteLine("\nSearch node by key: {0}", searchNode);

            BinaryNode<string> minNode = binaryThree.MinNode(binaryThree.root);
            Console.WriteLine("\nMin  node: {0}", minNode);

            BinaryNode<string> maxNode = binaryThree.MaxNode(binaryThree.root);
            Console.WriteLine("\nMax  node: {0}", maxNode);

            BinaryNode<string> nextNode = binaryThree.NextNodeNew(binaryThree.root);
            Console.WriteLine("\nNext  node: {0}", nextNode);

            BinaryNode<string> prevNode = binaryThree.PrevNodeNew(binaryThree.root);
            Console.WriteLine("\nPrev  node: {0}", prevNode);

            Console.WriteLine("\nView Min => Max");
            BinaryNode<string> curnode = binaryThree.MinNode(binaryThree.root);
            while (curnode != null)
            {
                Console.WriteLine(curnode);
                curnode = binaryThree.NextNodeNew(curnode);
            }

            Console.WriteLine("\nView Max => Min");
            curnode = binaryThree.MaxNode(binaryThree.root);
            while (curnode != null)
            {
                Console.WriteLine(curnode);
                curnode = binaryThree.PrevNodeNew(curnode);
            }

            Console.WriteLine("\nТест левые и праве повороты!");
            BinaryTree<string> rotate = new BinaryTree<string>();

            rotate.AddNodeInThree(1, "N1");
            rotate.AddNodeInThree(2, "N2");
            rotate.AddNodeInThree(3, "N3");
            rotate.AddNodeInThree(4, "N4");

            rotate.ViewAscending(rotate.root);

            rotate.LeftRotate(rotate.root);
            Console.WriteLine("\nAfer Left rotate");
            rotate.ViewAscending(rotate.root);

            rotate.RightRotate(rotate.root);
            Console.WriteLine("\nAfer Right rotate");
            rotate.ViewAscending(rotate.root);

            Console.WriteLine("\nBinary Tree Test! --- End");

            #endregion

            #region Graph

            Console.WriteLine("\nTest Graph!");

            Graph graph = new Graph();
            Vertex v1 = new Vertex("A");
            Vertex v2 = new Vertex("B");
            Vertex v3 = new Vertex("C");
            Vertex v4 = new Vertex("D");
            Vertex v5 = new Vertex("E");
            Vertex v6 = new Vertex("F");
            Vertex v7 = new Vertex("G");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            //Ориентированный граф
            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v6, v5);
            graph.AddEdge(v5, v6);
            graph.AddEdge(v4, v7);
            graph.AddEdge(v6, v7);

            graph.View();

            graph.BFS(v1);
            Console.WriteLine("\nTest BFS --- Start");
            foreach (Vertex v in graph.LVertexes)
            {
                graph.PrintPath(v1, v);
            }
            Console.WriteLine("Test BFS --- End\n");


            graph.DFS(v1);
            Console.WriteLine("\nTest DFS --- Start");
            foreach (Vertex v in graph.LVertexes)
            {
                graph.PrintPath(v1, v);
            }
            Console.WriteLine("Test DFS --- End\n");


            //Граф для примера - неориентированный граф
            Graph gr = new Graph();
            Vertex v11 = new Vertex("A");
            Vertex v22 = new Vertex("B");
            Vertex v33 = new Vertex("C");
            Vertex v44 = new Vertex("D");
            Vertex v55 = new Vertex("E");
            Vertex v66 = new Vertex("F");

            gr.AddVertex(v11);
            gr.AddVertex(v22);
            gr.AddVertex(v33);
            gr.AddVertex(v44);
            gr.AddVertex(v55);
            gr.AddVertex(v66);

            gr.AddEdge(v11, v22);
            gr.AddEdge(v22, v11);
            gr.AddEdge(v22, v33);
            gr.AddEdge(v33, v22);
            gr.AddEdge(v11, v33);
            gr.AddEdge(v33, v11);
            gr.AddEdge(v44, v55);
            gr.AddEdge(v55, v44);

            gr.View();
            Console.WriteLine("Связность графа: {0}\n", gr.GraphConnectivity());

            #endregion
            Console.ReadKey();
        }
    }
}
