using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_DSLibrary.DS_Stack
{
    public class DS_Stack<E>
    {//----Clobal Data----//
        private ArrayList data;
        private uint top = 0;
        private uint pSize = 0;

        //----Construction---//
        public DS_Stack()//the empth construction
        {
            data = new ArrayList();
            top = 0;//top on first location to add data
            pSize = 0;
        }//End of constructor

        //---Method---///
        public bool isEmpty()
        {
            if (top == 0) return true;
            else return false;
        }//End of isEmpty

        public bool push(object oo)
        {
            bool flag = true;
            try
            {
                data.Add(oo);//add data
                top++;// top = 0 data put than top++
                pSize += 1;
            }
            catch(Exception ee) { flag = false; }//if else full
            return flag;//judge whether push
        }//End of push
        public object update()
        {
            object popData = null;
            if (!isEmpty())
            {
                data.Remove((int)top);
                popData = data[(int)top];
            }
            return popData;
        }//End of update

        public object pop()
        {
            object popData = null;
            if(!isEmpty())
            {
                top--;//top is initialized to 0 
                popData = data[(int)top];
                data.Remove((int)top);
                pSize -= 1;
            }
            return popData;
        }//End of pop
        public object peek()
        {
            object topData = null;
            if(!isEmpty())
            {
                topData = data[(int)(top - 1)];
            }
            return topData;
        }//End of peek

        public uint size()
        {
            return (pSize);//out put size
        }
        public string printStack()
        {
            string ss = "The content of stack (top is on right ) is :\n";
            if(!isEmpty())
            {
                foreach(object oo in data)
                {
                    ss += (" " + oo.ToString());//out result
                }

            }
            return ss;
        }//End of printStack
        public override string ToString()
        {
            string ss = "";
            if(!isEmpty())
            {
                foreach(object oo in data)
                {
                    ss += (" " + oo.ToString());//out result
                }
            }
            return ss;
        }//End of ToString


    }//End of class DS_Stack<E>
}//End of namespace a107230001_DSLibrary.DS_Stack
