using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_DSLibrary.DS_linkesList
{
    public class LinkedListed<E> : DataNode<E>// :inherit
    {
        #region //---------- Data ----------//
        //----- Global Variables -----//
        public DataNode<E> head = null;
        public DataNode<E> tail = null;
        private int pSize = 0; //optional, readOnly

        //----- Data Property -----//
        public int size { get { return gerSize(this.head); } set { } }
        //public int size { get { return getSize(this.head); } set { } }
        #endregion
        public LinkedListed() { }
        public LinkedListed(DataNode<E> _head, DataNode<E> _tail)
        {
            head = _head;
            tail = _tail;
        }

        #region //---------- Action ----------//
        #region // ----- Methods for this object : non - static -----//
        //----- Use head in this object head : non - static
        //-- Print linked list
        public string printLinkedList() { return printLinkedList(this.head); }
        public string printReverseDLL() { return printReverseDLL(this.tail); }
        // ----- Print linked list : not use the head of this object, need specify a head of linked list
        string printLinkedList(DataNode<E> head)
        {
            string ss = "";
            DataNode<E> cursor = head;
            if (cursor != null)
            {
                while (cursor.getNext() != null)
                {
                    ss += (cursor.getData() + " + ");
                    cursor = cursor.getNext();
                    //Console.WriteLine("next DataNode");
                }
                ss += (cursor.getData());
            }
            return ss;
        }//end of printLinkedList

        string printReverseDLL(DataNode<E> head)
        {
            string ss = "";
            DataNode<E> cursor = head;

            return ss;
        }//end of printReverseDLL


        //-- Singular LinkedList : add node
        public bool addSLLFirst(E data) { return addFirst(ref this.head, ref this.tail, data); }
        public bool addDLLFirst(E data) { return addFirst(ref this.head, ref this.tail, data); }
        bool addFirst(ref DataNode<E> hh, ref DataNode<E> tt, E data) //add first with head, tail, and data
        {
            bool flag = true;
            DataNode<E> nn = new DataNode<E>(data, null, null); //create a new DataNode
            try
            {
                if (hh == null)
                {
                    hh = tt = nn;
                    //Console.WriteLine("first node : " + nn.getData());
                }
                else
                {
                    nn.next = hh;
                    nn.prev = null; // for DLL
                    hh.prev = nn; // for DLL
                    hh = nn;
                    //Console.WriteLine("more than one DataNode: " + nn.getData());
                }
            }
            catch (Exception ee) { flag = false; }
            return flag;
        }//end of addFirst 

        public bool addSLLLast(E data) { return addLast(ref this.head, ref this.tail, data); }
        public bool addDLLLast(E data) { return addLast(ref this.head, ref this.tail, data); }
        public bool addLast(ref DataNode<E> hh, ref DataNode<E> tt, E data) //add Last with head, tail, and data node
        {
            bool flag = true;
            DataNode<E> nn = new DataNode<E>(data, null, null); //create a new DataNode
            try
            {
                if (hh == null) { hh = tt = nn; }
                else
                {
                    if (tt == null)
                    {
                        DataNode<E> cur = hh;
                        while (cur.next != null) { cur = cur.next; } //find tail
                        nn.prev = cur; //for DLL
                        cur.next = nn;
                        tt = nn;
                    }
                    else
                    {
                        nn.prev = tt; //for DLL
                        //nn.next = tt.next;
                        tt.next = nn; // = null;
                        tt = nn;
                    }
                }
            }
            catch (Exception ee) { flag = false; }
            return flag;
        }//end of addLast 

        public void addLast(ref DataNode<E> hh, E data) //add Last with head, tail, and data node
        {
            bool flag = true;
            DataNode<E> nn = new DataNode<E>(data, null); //create a new DataNode
            DataNode<E> cur = hh;
            try
            {
                if (hh == null) { hh = nn; }
                else
                {
                    while (cur.next != null) { cur = cur.next; }
                    cur.next = nn;
                    nn.next = null;
                }
            }
            catch (Exception ee) { flag = false; }

        }//end of addLast 

        public void addLast(E data) //add Last with head, tail, and data node
        {
            DataNode<E> nn = new DataNode<E>(data, null); //create a new DataNode
            DataNode<E> cur = head;
            try
            {
                if (head == null) { head = nn; }
                else
                {
                    while (cur.next != null) { cur = cur.next; }
                    cur.next = nn;
                    nn.next = null;
                }
            }
            catch (Exception ee) { }

        }//end of addLast

        public bool addSLLNode(DataNode<E> cur, E data) { return addNode(ref this.head, ref this.tail, cur, data); }
        public bool addDLLNode(DataNode<E> cur, E data) { return addNode(ref this.head, ref this.tail, cur, data); }
        bool addNode(ref DataNode<E> hh, ref DataNode<E> tt, DataNode<E> cur, E data) //add with head, tail, and data node
        {
            bool flag = true;
            DataNode<E> nn = new DataNode<E>(data, null, null); //create a new DataNode
            try
            {
                if (cur == null) { hh = tt = nn; }
                else
                {
                    nn.next = cur.next;
                    nn.prev = cur; //for DLL
                    if (cur.next != null)
                        cur.next.prev = nn; //for DLL
                    cur.next = nn;
                    if (nn.next == null)
                        tt = nn;

                }
            }
            catch (Exception ee) { flag = false; }
            return flag;
        }//end of addNode
        //--- Singular LL: del Node---//
        public E delSLLFirst() { return delFirst(ref this.head, ref this.tail); }
        E delFirst(ref DataNode<E> hh, ref DataNode<E> tt)
        {
            E data = default(E);
            if (tt != null)
            {
                if (tt.prev == null) { data = tt.data; hh = tt = null; }
                else
                {
                    DataNode<E> cur = tt;
                    while (cur.prev.prev != null) { cur = cur.prev; }
                    data = cur.prev.data;
                }
                tail.prev = null;
                tail = head;
            }

            return data;
        }//end of delFirst
        public E delSLLLast() { return delLast(ref this.head, ref this.tail); }
        E delLast(ref DataNode<E> hh, ref DataNode<E> tt)
        {
            E data = default(E);
            if (hh != null)
            {
                //data = hh.data;
                if (hh.next == null) { data = hh.data; hh = tt = null; }
                else
                {
                    DataNode<E> cur = hh;
                    while (cur.next.next != null) { cur = cur.next; }
                    data = cur.next.data;
                }
                head.next = null;
                tail = head;
            }
            return data;
        }//end of delFirst
        public E delSLLNode(DataNode<E> cur) { return delNode(ref this.head, ref this.tail, cur); }
        E delNode(ref DataNode<E> hh, ref DataNode<E> tt, DataNode<E> cur)
        {
            E data = default(E);
            if (cur != null)
            {
                data = cur.data;
                if (cur == hh) delFirst(ref head, ref tail);
                else if (cur == tt) delLast(ref head, ref tail);
                else
                {
                    cur.next = cur.next.next;
                }
            }
            return data;
        }
        public int gerSize(DataNode<E> cur)
        {
            int i = 0;
            while (cur != null)
            {
                i++;
                cur = cur.next;

            }
            return i;
        }//end of gerSize(DataNode<E> cur)

        //-- Singular LinkedList : del node

        #endregion

    }//class LinkedListed<E> : DataNode<E>

    public class SLL<E> : LinkedList<E>
    {

    }//end of class  SLL<E> : LinkedList<E>

    public class DLL<E> : LinkedList<E>
    {
    }//end of class DLL<E> : LinkedList<E>
    #endregion
}// end of namespace a107230001_DSLibrary.DS_linkesList
