using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InsertionSortProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int Min = 100;
            int Max = 400;
            int arrLen = 30000;


            int[] unsorted =  CreateRandomArray(Min, Max, arrLen);
            List<int> unsorted1 = new List<int>(); 
            List<int> unsorted2 = new List<int>();

            unsorted1 = unsorted.OfType<int>().ToList();
            unsorted2 = unsorted.OfType<int>().ToList();

            var watch1 = new Stopwatch();
            var watch2 = new Stopwatch();

            watch1.Start();
            List<int> sorted1 = InsertionLinearSort(unsorted1);
            watch1.Stop();

            
            watch2.Start();
            List<int> sorted2 = InsertionBinarySort(unsorted2);
            watch2.Stop();


            Console.Out.Write("\n" + "Elapsed Time for Insertion Sort With Linear Search: " + watch1.Elapsed.ToString() + "\n" + "Elapsed Time for Insertion Sort With Binary Search: " + watch2.Elapsed.ToString());
            Console.Read();
        }

        public static int[] CreateRandomArray(int min, int max, int arrLen)
        {
            Random ran = new Random();
            int[] ranArr = new int[arrLen];

            for (int i = 0; i < ranArr.Length; i++)
            {
                ranArr[i] = ran.Next(min, max);
            }

            return ranArr;
        }

        public static List<int> InsertionLinearSort(List<int> instance)
        {
            for (int j = 1; j < instance.Count; j++)   // T(n) = n
            {
                var key = instance[j];   // T(n) = n - 1 
                int i = j - 1;   // T(n) = n - 1 
                int location = LinearSearch(instance, key); // T(n) = n(n -1)

                while (i >= location && instance[i] > key) // The while loop based on average case will execute n(n - 1) /2
                {
                    instance[i + 1] = instance[i]; // T(n) = n-1
                    i--;                     // T(n) = n -1
                }
                instance[i + 1] = key;          // T(n) = n- 1
            }
            return instance;
        }

        public static List<int> InsertionBinarySort(List<int> instance)
        {    
            for (int j = 1; j < instance.Count; j++) // T(n) = n
            {
                var key = instance[j]; // T(n) = n-1            
                int i = j - 1; // T(n) = n -1

                int location = BinarySearch(instance, 0, j, key);  // T(n) = n (lg n)

                while (i >= location && instance[i] > key) // The while loop based on average case so will execute n(n - 1) /2
                {
                    instance[i + 1] = instance[i];  // T(n) = n -1
                    i--;
                }
                instance[i + 1] = key;     // T(n) = n - 1
            }

            return instance;
        }

        public static int BinarySearch(List<int> sortedArray, int l, int h, int key)
        {
            if (h <= l) // T(n) = 1
                return (key > sortedArray[l]) ? l + 1 : l;  // T(n) = 1
            int mid = (l + h) / 2; // T(n) = 1
            if (sortedArray[mid] == key) // T(n) = 1
            {
                return mid + 1; // T(n) = 1
            }
            if (sortedArray[mid] > key) // T(n) = 1
            {
                return BinarySearch(sortedArray, l, mid - 1, key); // T(n) = n /2
            }
            else
                return BinarySearch(sortedArray, mid + 1, h, key); // T(n) = n /2
        }

        public static int LinearSearch(List<int> sortedArray, int key)
        {
            for(int i = 0; i < sortedArray.Count; i++) // T(n) = n
            {
                if(key <= sortedArray[i])  // T(n) = n - 1
                {
                    return i;  
                }
            }
            return -1;
        }

    }

}
