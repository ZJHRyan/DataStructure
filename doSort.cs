using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_App
{
    public class doSort
    {
        public void insertionSort(int[] array)//, out int[] target)
        {
            int i = 0, j = 0, count = 0;
            int temp;
            for (j = 1; j < array.Length; j++)//
            {
                // array[j] is the number to be inserted to sorted part
                temp = array[j];
                // i starts from the left neighbor of j
                i = j - 1;

                while (i >= 0 && array[i] > temp)
                {
                    count = count + 1;
                    array[i + 1] = array[i];
                    i -= 1;
                    //DisplayArrayToConsole(array);
                }
                array[i + 1] = temp;
            }
            Console.WriteLine("count" + count.ToString());
            Console.ReadLine();
            //foreach (int K in array)
            //{
            //    Console.Write(K.ToString() + ","); 
            //}


        }

    }
    public class MergeSort
    {

        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        public void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        public void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }
        // Driver code
        // This code is contributed by Princi Singh
    }
    public class GFG_for
    {
        public static void fib_for(int n)
        {
            DateTime beforDTFor = System.DateTime.Now;
            int a = 0, b = 1, c;
            if (n >= 0)
                Console.Write(a + " ");
            if (n >= 1)
                Console.Write(b + " ");
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                Console.Write(c + " ");
                a = b;
                b = c;
            }
            DateTime afterDTFor = System.DateTime.Now;
            TimeSpan tsFor = afterDTFor.Subtract(beforDTFor);
            Console.WriteLine("\nFor loop fib spend {0}ms.", tsFor.TotalMilliseconds);
        }//
    }// end of  public class GFG1
    public class GFG_while
    {


        public static void fib_while(int n)
        {
            DateTime beforDTWhile = System.DateTime.Now;
            // initialize the first two numbers in the sequence
            int oldNumber = 1;
            int currentNumber = 1;

            int nextNumber;

            System.Console.Write(currentNumber + " ");

            while (currentNumber < n)
            {
                System.Console.Write(currentNumber + " ");

                // calculate the next number by adding the
                // current number to the old number
                nextNumber = currentNumber + oldNumber;

                oldNumber = currentNumber;
                currentNumber = nextNumber;
            }
            DateTime afterDTWhile = System.DateTime.Now;
            TimeSpan tsWhile = afterDTWhile.Subtract(beforDTWhile);
            Console.WriteLine("\nwhile fib spend {0}ms.", tsWhile.TotalMilliseconds);

        }

    }



}
