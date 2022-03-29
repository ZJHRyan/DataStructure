using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_App
{
    public class dsRecursive
    {
    }
    public class DCG
    {
        public static ulong GCDLoop(ulong a, ulong b)
        {
            while (a != 0 && b != 0)//End Conditions a != 0 && b != 0
            {
                if (a > b)
                    a %= b;//divided
                else
                    b %= a;//divided 
            }

            return a | b;
        }//End of GCDLoop
        public static ulong GCDRecursive(ulong n1, ulong n2)
        {
            if (n2 == 0)
            {
                return n1;
            }
            else
            {
                return GCDRecursive(n2, n1 % n2);//recursive
            }
        }//End of GCDRecursive
    }//End of class DCG
    public class BinarySearch
    {
        // Returns index of x if it is present in
        // arr[l..r], else return -1
        public static int binarySearchRecursive(int[] arr, int l,int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;
                // If the element is present at the
                // middle itself
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then
                // it can only be present in left subarray
                if (arr[mid] > x)
                    return binarySearchRecursive(arr, l, mid - 1, x);

                // Else the element can only be present
                // in right subarray
                return binarySearchRecursive(arr, mid + 1, r, x);
            }

            // We reach here when element is not present
            // in array
            return -1;
        }//End of binarySearchRecursive
        public static int binarySearchLoop(int[] arr, int x)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                // Check if x is present at mid
                if (arr[m] == x)
                    return m;

                // If x greater, ignore left half
                if (arr[m] < x)
                    l = m + 1;

                // If x is smaller, ignore right half
                else
                    r = m - 1;
            }

            // if we reach here, then element was
            // not present
            return -1;
        }//End of binarySearchLoop
    }//End of class BinarySearch
    public class Sequence
    {
        // Recursive program to find the 
        // value of the given series
        public static float sequenceRecursive(int i, int n, float s)
        {
            // Base case
            if (i > n)
                return s;
            // Recursive case
            else
            {
                // If we are currently looking
                // at the even number
                if (i % 2 == 0)
                    s -=(float)(i*2-1) / (2*i+1);

                // If we are currently looking 
                // at the odd number
                else
                    s +=(float)((2 * i - 1) / (2 * i + 1));
                return sequenceRecursive(i + 1, n, s);
            }
        }// End of sequenceRecursive
        public static float sequenceLoop(int n)
        {
            float sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                    sum -= (float)(i * 2 - 1) / (2 * i + 1);
                // If we are currently looking 
                // at the odd number
                else
                    sum += (float)((2 * i - 1) / (2 * i + 1));
            }        
            return sum;
        }//End of sequenceLoop
    }// End of class sequence
    public class HanoiTowerRecursive
    {
        public  static void towerOfHanoiRecuisive(int n, char from_rod, char to_rod, char aux_rod)//from where|to where|destination|
        {
            if (n == 1)
            {
                Console.WriteLine("Move disk 1 from rod " + from_rod + " to rod " + to_rod);
                return;
            }
            towerOfHanoiRecuisive(n - 1, from_rod, aux_rod, to_rod);//recursive
            Console.WriteLine("Move disk " + n + " from rod " + from_rod + " to rod " + to_rod);//output
            towerOfHanoiRecuisive(n - 1, aux_rod, to_rod, from_rod);//recursive
        }//End of towerOfHanoiRecuisive
    }//End of class HanoiTower
    public class TowerOfHanoiLoop
    {
        int count = 1;
        int m_numdiscs;
        public TowerOfHanoiLoop()
        {
            numdiscs = 0;
        }
        public TowerOfHanoiLoop(int newval)
        {
            numdiscs = newval;
        }
        public int numdiscs
        {
            get { return m_numdiscs; }
            set
            {
                if (value > 0)
                    m_numdiscs = value;
            }
        }
        public void movetower(int n, int from, int to, int other)// move
        {
            if (n > 0)
            {
                movetower(n - 1, from, other, to);
                Console.WriteLine("step " + count + ": Move disk {0} from tower {1} to tower {2}", n, from, to);//output
                count += 1;
                movetower(n - 1, other, to, from);
                
            }
        } //End of movetower
    }//End of class TowerOfHanoiLoop
}//End of namespace a107230001_App
#region Postpone processing:expression
////-----Postpone processing:expression-----//

//public static String in2postfix(String ss)
//{
//    String result = "";
//    return result;
//}
//public static bool in2postfix(String ss, out String result)
//{
//    Stack<char> expStack = new Stack<char>();
//    DS_Stack<char> expMyStack = new DS_Stack<char>();
//    String operators = "+=*/%^";
//    bool flag = true;
//    result = "";
//    //checkExpressionn(ss){ }
//    char[] source = ss.ToCharArray();
//    if (checkExpressionn(ss))
//    {
//        foreach (char cc in source)
//        {

//            //Step1:"("
//            if (cc == 'C') { expStack.Push(cc); expMyStack.push(cc); }
//            //else if ((cc=="*")||()||()||()||())
//            else if (operators.Contains(cc))
//            {
//                while (checkPrioriyt(cc, expStack.Peek()))//cc>=top return true
//                {
//                    result += (expStack.Pop().ToString());//pop
//                }
//                expStack.Push(cc);
//            }
//            else if (cc == ')')
//            {
//                while ((expStack.Count != 0) && (expStack.Peek() != '('))//not equty 0 or '('
//                {
//                    result += (expStack.Pop().ToString());
//                }
//                if (expStack.Count > 0)
//                { expStack.Pop(); }
//                else { flag = flag = false; break; }
//            }

//            else//strp2:operands
//            {
//                result += cc.ToString();
//            }


//        }
//    }
//    else flag = false;
//    return flag;
//}//End of in2postfix
//static bool checkPrioriyt(char c1, char c2)//c1>=c2 return true
//{
//    bool flag = true;
//    return flag;
//}
//static bool checkExpressionn(String ss)
//{
//    // only be supported inout abcd +-*/
//    bool flag = true;
//    return flag;
//}
#endregion