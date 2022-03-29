using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using a107230001_DSLibrary.DS_Queue;


namespace a107230001_App
{
    public class dsQueue<E>
    {
        static int minIndex(ref System.Collections.Generic.Queue<int> q,
                                int sortedIndex)
        {
            int min_index = -1;
            int min_val = int.MaxValue;
            int n = q.Count;
            for (int i = 0; i < n; i++)
            {
                int curr = q.Peek();
                q.Dequeue(); 
                if (curr <= min_val &&
                       i <= sortedIndex)
                {
                    min_index = i;
                    min_val = curr;
                }
                q.Enqueue(curr);
            }
            return min_index;
        }

        // Moves given minimum 
        // element to rear of queue
        static void insertMinToRear(ref System.Collections.Generic.Queue<int> q,
                                    int min_index)
        {
            int min_val = 0;
            int n = q.Count;
            for (int i = 0; i < n; i++)
            {
                int curr = q.Peek();
                q.Dequeue();
                if (i != min_index)
                    q.Enqueue(curr);
                else
                    min_val = curr;
            }
            q.Enqueue(min_val);
        }

        static void sortQueue(ref System.Collections.Generic.Queue<int> q)
        {
            for (int i = 1; i <= q.Count; i++)//每轮找最小值
            {
                int min_index = minIndex(ref q,
                                         q.Count - i);//查找最小值 的data
                insertMinToRear(ref q,
                                min_index); //insert最小值 
            }
        }
        public static void Insertionsort(List<int> source)
        {
            List<int> sortedData = new List<int>();
            System.Collections.Generic.Queue<int> qq = new System.Collections.Generic.Queue<int>();//创建queue
            foreach (int vv in source)
            {
                qq.Enqueue(vv);//将每一个data 推入queue
            }
            sortQueue(ref qq);//查找最小值
            while (qq.Count != 0)
            {
                Console.Write(qq.Peek() + " ");
                qq.Dequeue();
            }

        }

        // ---Insertions Sort---//

        //---Selection sort using priority queue
        public static List<E> selectionSort(List<E> source)
        {
            List<E> sortedData = new List<E>();
            System.Collections.Generic.Queue<E> qq = new System.Collections.Generic.Queue<E>();

            foreach(var vv in source)
            {
                qq.Enqueue(vv);
            }
            return sortedData;
        }//End of selectionSort
        static void FrontToLast(System.Collections.Generic.Queue<int> q,
                        int qsize)
        {
            // Base condition
            if (qsize <= 0)
                return;

            // pop front element and push
            // this last in a queue
            q.Enqueue(q.Peek());
            q.Dequeue();

            // Recursive call for pushing element
            FrontToLast(q, qsize - 1);
        }

        // Function to push an element in the queue
        // while maintaining the sorted order
        static void pushInQueue(System.Collections.Generic.Queue<int> q,
                                int temp, int qsize)
        {

            // Base condition
            if (q.Count == 0 || qsize == 0)
            {
                q.Enqueue(temp);
                return;
            }

            // 如果当前元素小于前面的元素
            else if (temp <= q.Peek())
            {

                // Call stack with front of queue
                q.Enqueue(temp);

                // 递归调用，将队列中的一个前端的元素插入到最后一个队列中。
                FrontToLast(q, qsize);
            }
            else
            {

                // 将前面的元素推到
                // 队列中的最后一个
                q.Enqueue(q.Peek());
                q.Dequeue();

                // 递归调用，用于推送
                // 元素在队列中的位置
                pushInQueue(q, temp, qsize - 1);
            }
        }
        static void SsortQueue(System.Collections.Generic.Queue<int> q)
        {

            // 如果队列是空的，则返回
            if (q.Count == 0)
                return;

            // 获取前面的元素，该元素将
            // 将被存储在这个变量中
            // 在整个递归堆栈中
            int temp = q.Peek();

            // 移除前面的元素
            q.Dequeue();

            // 递归调用
            SsortQueue(q);

            // Push the current element into the queue
            // according to the sorting order
            pushInQueue(q, temp, q.Count);
        }
        public static void Selectsort(List<int> source)
        {
            List<int> sortedData = new List<int>();
            System.Collections.Generic.Queue<int> qq = new System.Collections.Generic.Queue<int>();//创建queue
            foreach (int vv in source)
            {
                qq.Enqueue(vv);//将每个data 推入queue
            }
            SsortQueue( qq);//排序
            while (qq.Count != 0)
            {
                Console.Write(qq.Peek() + " ");
                qq.Dequeue();
            }

        }

    }
}
