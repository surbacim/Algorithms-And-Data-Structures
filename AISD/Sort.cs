using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class Sort
    {
        public static void BubbleSort<T>(T[] list) where T : IComparable
        {
            int N = list.Length;
            int numberOfPairs = N - 1;
            int swappedElements = N;
            while (swappedElements > 0)
            {
                swappedElements = 0;
                for (int i = 0; i < numberOfPairs; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)   // if(list[i]>list[i+1])
                    {
                        T tmp; tmp = list[i]; list[i] = list[i + 1]; list[i + 1] = tmp; //Swap(list[i],list[i+1])
                        swappedElements++;
                    }
                }
                numberOfPairs--;  // numberOfPairs = numberOfPairs - l;
            }
        }

        public static void BubbleSortSwap<T>(T[] list) where T : IComparable
        {
            int N = list.Length;
            int numberOfPairs = N - 1;  //кол-во пар
            int swappedElements = N;    //замененные элементы
            while (swappedElements > 0)
            {
                swappedElements = 0;
                for (int i = 0; i < numberOfPairs; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)   // if(list[i]>list[i+1])
                    {
                        Swap(ref list[i], ref list[i + 1]); //Swap(list[i],list[i+1])
                        swappedElements++;
                    }
                }
                numberOfPairs--;  // numberOfPairs = numberOfPairs - l;
            }
        }

        //В данном методе показывается пошаговая работа сортировки "пузырьком" (для себя) 
        public static void MyBubbleSortStep<T>(T[] list) where T : IComparable
        {
            bool needSort = true;
            for (int i = 0; (i < list.Length) && needSort; i++)
            {
                needSort = false;
                for (int j = 0; j < list.Length - 1; j++)
                {
                    if (list[j + 1].CompareTo(list[j]) < 0)
                    {
                        Swap(ref list[j + 1], ref list[j]);
                        needSort = true;
                    }
                }

                //Распечатка промежуточного состояния массива
                Console.WriteLine("\nstep {0}:", i);
                for (int k = 0; k < list.Length; k++)
                {
                    Console.WriteLine(" {0}", list[k]);
                }
            }
        }

        //Метод обмена элементов                                                    spaw - замена
        public static void Swap<T>(ref T a, ref T b)
        {
            T c = a; a = b; b = c;
        }

        //Сортировка вставками
        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1].CompareTo(key) > 0))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
        }

        //Находим минимальный индекс - данный метод нужен для сортировки выбором
        public static int IndexOfMin<T>(T[] list, int n) where T : IComparable
        {
            int result = n;
            for (var i = n; i < list.Length; ++i)
            {
                if (list[i].CompareTo(list[result]) < 0)
                {
                    result = i;
                }
            }
            return result;
        }

        //Сортировка выбором
        public static T SelectionSort<T>(T[] list, int currentIndex = 0) where T : IComparable
        {
            if (currentIndex == list.Length - 1)
                return list[currentIndex];

            int index = IndexOfMin(list, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref list[index], ref list[currentIndex]);
            }

            return SelectionSort(list, currentIndex + 1);
        }

        //Сортиовка Шелла
        public static void ShellSort<T>(T[] list) where T : IComparable
        {
            //расстояние между элементами, которые сравниваются
            var d = list.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < list.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (list[j - d].CompareTo(list[j]) > 0))
                    {
                        Swap(ref list[j], ref list[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }
        }

        //Сортировка "Шейкер"
        public static T[] ShakerSort<T>(T[] list) where T : IComparable
        {
            for (var i = 0; i < list.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо || сверху вниз
                for (var j = i; j < list.Length - i - 1; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        Swap(ref list[j], ref list[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево || снизу вверх
                for (var j = list.Length - 2 - i; j > i; j--)
                {
                    if (list[j - 1].CompareTo(list[j]) > 0)
                    {
                        Swap(ref list[j - 1], ref list[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return list;
        }

        public static int partition<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            int razdel = minIndex;
            for (int j = minIndex; j <= maxIndex; j++)         // просматриваем с a по b
            {
                if (list[j].CompareTo(list[maxIndex]) <= 0)  // если элемент m[j] не превосходит m[b],
                {
                    //T t = m[i];                  // меняем местами m[j] и m[a], m[a+1], m[a+2] и так далее...
                    //m[i] = m[j];                 // то есть переносим элементы меньшие m[b] в начало,
                    //m[j] = t;                    // а затем и сам m[b] «сверху»
                    Swap(ref list[razdel], ref list[j]);
                    razdel++;                      // таким образом, последний обмен: m[b] и m[i], после чего i++
                }
            }
            return razdel - 1;                        // в индексе i хранится <новая позиция элемента list[b]> + 1
        }


        //Быстрая сортировка
        public static T[] QuickSort<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            if (minIndex >= maxIndex)
            {
                return list;
            }

            var razdelIndex = partition(list, minIndex, maxIndex);
            QuickSort(list, minIndex, razdelIndex - 1);
            QuickSort(list, razdelIndex + 1, maxIndex);

            return list;
        }

        //Метод для слияния массивов
        public static void Merge<T>(T[] list, int minIndex, int middleIndex, int maxIndex) where T : IComparable
        {
            var left = minIndex;
            var right = middleIndex + 1;
            var tempArray = new T[maxIndex - minIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= maxIndex))
            {
                if (list[left].CompareTo(list[right]) < 0)
                {
                    tempArray[index] = list[left];
                    left++;
                }
                else
                {
                    tempArray[index] = list[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = list[i];
                index++;
            }

            for (var i = right; i <= maxIndex; i++)
            {
                tempArray[index] = list[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                list[minIndex + i] = tempArray[i];
            }
        }

        //Сортировка слиянием
        public static T[] MergeSort<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            if (minIndex < maxIndex)
            {
                var middleIndex = (minIndex + maxIndex) / 2;
                MergeSort(list, minIndex, middleIndex);
                MergeSort(list, middleIndex + 1, maxIndex);
                Merge(list, minIndex, middleIndex, maxIndex);
            }

            return list;
        }

    }
}
