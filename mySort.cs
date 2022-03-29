//
//Protect insertionSort
//Data:20210303
//Author:a107230001
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_Application
{
    public class mySort
    {

        public void insertionSort(int[] array)//, out int[] target)
        {
            int i = 0, j = 0,count=0;
            int temp;
            for (j = 1; j < array.Length; j++)
            {
                // array[j] is the number to be inserted to sorted part
                temp = array[j];
                // i starts from the left neighbor of j
                i = j - 1;

                while (i >= 0 && array[i] > temp)
                {
                    count=count+1;
                    array[i + 1] = array[i];
                    i -= 1;
                    //DisplayArrayToConsole(array);
                }
                array[i + 1] = temp;
            }
            Console.WriteLine("count"+count.ToString());
            Console.ReadLine();
            //foreach (int K in array)
            //{
            //    Console.Write(K.ToString() + ","); 
            //}

        }
        //public void insertionSort(E[] source, out E[] tt)
        //{
        //    tt = new E[source.Length];
        //    source.CopyTo(tt, 0);
        //}

        public class SinglyLinkedList<E> 
        {
            private static class Node<E>
            {
                private E element;
                private Node<E> next;
                public Node()
                {
                    this(null, null);
                }
                public Node(E e, Node<E> n)
                    {
                        
                    }


            }
        }
    }// end of class mySort
}// end of namespace
