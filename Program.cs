using System;
using System.Collections.Generic;
using Lab3.SortingAlgorithms;
using System.Diagnostics;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = GenerateRandomIntList(1000, 5000);
            
            //List<double> doubleList = GenerateRandomDoubleList(100, 500);

            //Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));
            //Console.WriteLine("[{0}]", string.Join(", ", doubleList.ToArray()));


            BubbleSort<int> bubbleSort = new BubbleSort<int>();
            Console.WriteLine("BUBBLE SORT");

            double totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort<int>(bubbleSort, intListCopy);
            }

            double averageTime = totalTime / 11;
            Console.WriteLine( $"{averageTime}" );



            InsertionSort<int> insertionSort = new InsertionSort<int>();
            Console.WriteLine("INSERTION SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort<int>(insertionSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"{averageTime}");

            //Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));


            //bubbleSort.Sort(ref intListCopy);

            //BucketSort<int> bucketSort = new BucketSort<int>();
            //bucketSort.Sort(ref intListCopy);

            //HeapSort<int> heapSort = new HeapSort<int>();
            //heapSort.Sort(ref intList);

            //MergeSort<int> mergeSort = new MergeSort<int>();
            //mergeSort.Sort(ref intList);

            //InsertionSort<int> insertionSort = new InsertionSort<int>();
            //insertionSort.Sort(ref intList);

            //SelectionSort<int> selectionSort = new SelectionSort<int>();
            //selectionSort.Sort(ref intList);

            //quickSort.Sort(ref intList);
            //QuickSort<double> quickSortDouble = new QuickSort<double>();
            //quickSortDouble.Sort(ref doubleList);

            //TreeSort<int> treeSort = new TreeSort<int>();
            //treeSort.Sort(ref intList);

            //Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));
            //Console.WriteLine("[{0}]", string.Join(", ", doubleList.ToArray()));

            //Console.WriteLine("QUICKSORT");
            //QuickSort<int> quickSort = new QuickSort<int>();
            //for( int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array
            //    TimeSort(quickSort, intListCopy);
            //}

            //MergeSort<int> mergeSort = new MergeSort<int>();
            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array
            //    TimeSort(mergeSort, intListCopy);
            //}

            //MergeSort<int> mergeSort = new MergeSort<int>();
            //intListCopy = new List<int>(intList);   // make a copy of the original unsorted array
            //TimeSort(mergeSort, intListCopy);

            //InsertionSort<int> insertionSort = new InsertionSort<int>();
            //intListCopy = new List<int>(intList);   // make a copy of the original unsorted array
            //TimeSort(insertionSort, intListCopy);

            //BubbleSort<int> bubbleSort = new BubbleSort<int>();
            //intListCopy = new List<int>(intList);   // make a copy of the original unsorted array
            //TimeSort(bubbleSort, intListCopy);





        }

        public static double TimeSort<T>(ISortable<T> sortable, List<T> items) where T : IComparable<T>
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(ref items);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);

            return ts.TotalSeconds;

        }

        public static double TimeSort(ISortableInt sortable, List<int> items)
        {
            int[] array = items.ToArray();

            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var sorted = sortable.Sort(array);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);

            return ts.TotalSeconds;
        }


        public static List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for(int i=0; i < length; i++)
            {
                list.Add(random.Next(maxValue));               
            }

            return list;
        }

        public static List<double> GenerateRandomDoubleList(int length, double maxValue)
        {
            List<double> list = new List<double>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.NextDouble()* maxValue);
            }

            return list;
        }
    }
}
