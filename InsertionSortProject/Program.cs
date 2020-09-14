using System;
using System.Diagnostics;


namespace InsertionSortProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int Min = 100;
            int Max = 400;
            int arrLen = 30000;


            int[] unsorted = CreateRandomArray(Min, Max, arrLen);

            var watch1 = new Stopwatch();
            var watch2 = new Stopwatch();

            watch1.Start();
            int[] sorted1 = InsertionLinearSort(unsorted);
            watch1.Stop();

            watch2.Start();
            int[] sorted2 = InsertionBinarySort(unsorted);
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

        public static int[] InsertionLinearSort(int[] instance)
        {
            for (int j = 1; j < instance.Length; j++)  
            {
                var key = instance[j];  
                int i = j - 1;  
                int location = LinearSearch(instance, key);

                while (i >= location && instance[i] > key) 
                {
                    instance[i + 1] = instance[i]; 
                    i = i - 1;                     
                }
                instance[i + 1] = key;            
            }
            return instance;
        }

        public static int[] InsertionBinarySort(int[] instance)
        {
            int pos = 0;

            for (int j = 1; j < instance.Length; j++)
            {
                var key = instance[j];

                int u = key;
                int i = j - 1;
                instance[pos] = instance[i];
                int location = BinarySearch(instance, 0, j, key);

                while (i >= location)
                {
                    instance[i + 1] = instance[i];
                    i--;
                }

                instance[i + 1] = key;
                pos++;
            }

            return instance;
        }

        public static int BinarySearch(int[] sortedArray, int l, int h, int key)
        {
            if (h <= l)
                return (key > sortedArray[l]) ? l + 1 : l;
            int mid = (l + h) / 2;
            if (sortedArray[mid] == key)
            {
                return mid + 1;
            }
            if (sortedArray[mid] > key)
            {
                return BinarySearch(sortedArray, l, mid - 1, key);
            }
            else
                return BinarySearch(sortedArray, mid + 1, h, key);

        }

        public static int LinearSearch(int[] sortedArray, int key)
        {
            for(int i = 0; i < sortedArray.Length; i++) 
            {
                if(key <= sortedArray[i])  
                {
                    return i;  
                }
            }
            return -1;
        }

    }
}
