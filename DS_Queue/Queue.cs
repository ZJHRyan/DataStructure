using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//for class Queue

namespace a107230001_DSLibrary.DS_Queue
{
    public class PriorityQueue<E>:Queue<E>,IComparer//继承 比较的方法改写 callback python
    {
        //---Global data---//
        private Dictionary<string, E> p_data;//key value//object private

        //---Action---//
        //---constructor---//
        public PriorityQueue()
        {
            p_data = new Dictionary<string, E>();
        }

        //---Method---//
        //---Enqueue---//
        public bool enqueue(KeyValuePair<string,E>dd)
        {
            bool flag = true;
            if (isFull()) { flag = false; }//检查是否是空的 不是false
            else
            {
                p_data.Add(dd.Key, dd.Value);//将 key和value 增加到queue中
                p_size = (uint)p_data.Count;//p_SIZE++
            }
            return flag;
        }//End of enqueue

        //---Dequeue
        public KeyValuePair<string,E>removeMin()
        {
            int ind = 0;
            string key = "";
            E minlnQueue = default(E);

            if(!isEmpty())//如果是empty
            {
                ind = findMin(p_data);//寻找最小的key
                key = p_data.ElementAt(ind).Key;//key赋值
                minlnQueue = p_data.ElementAt(ind).Value;//min value 进行赋值
                p_data.Remove(key);//删除最少的值
                p_size = (uint)p_data.Count;//p_SIZE++

            }
            return new KeyValuePair<string, E>(key, minlnQueue);
        }//End of KeyValuePair
        public int findMin(Dictionary<string,E>qq)
        {
            int ind = -1;
            int key, temp;
            if(qq.Count>0)//如果queue不为空
            {
                try
                {
                    ind = 0;
                    int.TryParse(qq.ElementAt(ind).Key, out key);//将所有值value输入
                    for(int i=1;i<qq.Count;i++)
                    {
                        int.TryParse(qq.ElementAt(i).Key, out temp);//输入all key
                        if(temp<key)//进行比较key
                        {
                            ind = i;//互换key
                            key = temp;
                        }
                    }
                }
                catch (Exception ee) { ind = -1; }
            }
            return ind;
        }//End of findMin

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }//End of PriorityQueue
    public class Queue<E>
    {
        //---Global data---//
        const int MAX_QUEUE_SIZE = 100;
        private List<E> p_data;
        protected uint p_size = 0;
        private int p_front = -1;
        private int p_rear = -1;
        //---Action---//
        //---Constructor---//
        public Queue(int arraySize=MAX_QUEUE_SIZE)//initializer
        {
            p_data = new List<E>();
            p_front = p_rear = -1;
            p_size = 0;
        }
        //---Property---//
        public uint size
        {
            get { return p_size; }
            set { }
        }

        //---Methods---//
        //---is Empty---//
        public bool isEmpty()
        {
            if (p_size == 0) return true;
            else return false;
        }
        //---if full
        public bool isFull()
        {
            return false;
        }
        public bool enqueue(E dd)
        {
            bool flag = true;
            if (isFull()) { flag = true; }
            else
            {
                p_data.Add(dd);
                p_size++;
            }
            return flag;
        }
        //---deQueue
        public E dequeue()
        {
            E temp;
            if (isEmpty()) { temp = default(E); }
            else
            {
                temp = p_data.ElementAt<E>(0);
                p_data.RemoveAt(0);
                p_size--;
                if (isEmpty()) { p_front = p_rear = -1; }//using srray as data storage

            }
            return temp;
        }//End of dequeue
        //---Front
        public E peek()
        {
            E temp;
            if (isEmpty()) { temp = default(E); }//check if isEmpty
            else
            {
                temp = p_data.ElementAt<E>(0);
            }
            return temp;
        }//end of peek

    }//End of class Queue<E>
}//End of nameplace