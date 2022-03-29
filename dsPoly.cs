using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a107230001_DSLibrary.DS_linkesList;

namespace a107230001_App
{
    public class dsPoly
    {
        public int expo;
        public double coef;

        public dsPoly() { }

        public dsPoly(double coef, int expo)
        {
            this.coef = coef;
            this.expo = expo;
        }//end of dsPolyData(double coef, int expo) 

        public override string ToString()
        {
            string ss = "";
            if (expo == 0) ss = coef.ToString("n2");
            else if (expo == 1) ss = coef.ToString("n2") + "X";
            else ss = coef.ToString("n2") + "X" + expo;
            return ss;
        }//end of override string ToString()

    }//end of class dsPolyData

    public class dsPloyOperation
    {
        public void ployAdd(DataNode<dsPoly> plHead, DataNode<dsPoly> p2Head, ref LinkedListed<dsPoly> resultPloy)
        {
            DataNode<dsPoly> p1Cur = plHead;
            DataNode<dsPoly> p2Cur = p2Head;
            dsPoly pp;

            while ((p1Cur != null) && (p2Cur != null))
            {
                if (p1Cur.data.expo == p2Cur.data.expo) //approach p1+p2
                {
                    pp = new dsPoly(p1Cur.data.coef + p2Cur.data.coef, p2Cur.data.expo);
                    resultPloy.addLast(pp);
                    p1Cur = p1Cur.next;
                    p2Cur = p2Cur.next;
                }
                else if (p1Cur.data.expo > p2Cur.data.expo) //approach p1
                {
                    pp = new dsPoly(p1Cur.data.coef, p1Cur.data.expo);
                    resultPloy.addLast(pp);
                    //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                    p1Cur = p1Cur.next;
                }
                else //approach p2
                {
                    pp = new dsPoly(p2Cur.data.coef, p2Cur.data.expo);
                    resultPloy.addLast(pp);
                    //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                    p2Cur = p2Cur.next;
                }
            }
            while (p1Cur != null)
            {
                pp = new dsPoly(p1Cur.data.coef, p1Cur.data.expo);
                resultPloy.addLast(pp);
                //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                p1Cur = p1Cur.next;

            }
            while (p2Cur != null)
            {
                pp = new dsPoly(p2Cur.data.coef, p2Cur.data.expo);
                resultPloy.addLast(pp);
                //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                p2Cur = p2Cur.next;
            }
        }//end of ployAdd

        public void ploySubtract(DataNode<dsPoly> plHead, DataNode<dsPoly> p2Head, ref LinkedListed<dsPoly> resultPloy)
        {
            DataNode<dsPoly> p1Cur = plHead;
            DataNode<dsPoly> p2Cur = p2Head;
            dsPoly pp;

            while ((p1Cur != null) && (p2Cur != null))
            {
                if (p1Cur.data.expo == p2Cur.data.expo) //approach p1-p2
                {
                    pp = new dsPoly(p1Cur.data.coef - p2Cur.data.coef, p2Cur.data.expo);
                    resultPloy.addLast(pp);
                    p1Cur = p1Cur.next;
                    p2Cur = p2Cur.next;
                }
                else if (p1Cur.data.expo > p2Cur.data.expo) //approach p1
                {
                    pp = new dsPoly(p1Cur.data.coef, p1Cur.data.expo);
                    resultPloy.addLast(pp);
                    //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                    p1Cur = p1Cur.next;
                }
                else //approach p2
                {
                    pp = new dsPoly(p2Cur.data.coef, p2Cur.data.expo);
                    resultPloy.addLast(pp);
                    //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                    p2Cur = p2Cur.next;
                }
            }
            while (p1Cur != null)
            {
                pp = new dsPoly(p1Cur.data.coef, p1Cur.data.expo);
                resultPloy.addLast(pp);
                //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                p1Cur = p1Cur.next;

            }
            while (p2Cur != null)
            {
                pp = new dsPoly(p2Cur.data.coef, p2Cur.data.expo);
                resultPloy.addLast(pp);
                //a107230001_DSLibrary.DS_LinkedList.LinkedListed<dsPolyData>.addLast(ref resultPloy, pp);
                p2Cur = p2Cur.next;
            }
        }//end of ployAdd_Less
    }//end of class dsPloyOperation
}// end of nameplace
