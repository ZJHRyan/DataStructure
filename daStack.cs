using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using a107230001_DSLibrary.DS_Stack;

namespace a107230001_App
{
    public class daStack
    {
        //---Method---//
        #region parenthesisMatching
        //-----parenthesisMatching-----//
        public static bool parenthesisMatching(string oo)//,out int errorlnd )//(Object oo)
        {
            int errorlnd;
            return (parenthesisMatching(oo, out errorlnd));
        }

        public static bool parenthesisMatching(string oo, out int errorlnd)//(Object oo)
        {
            DS_Stack<char> data = new DS_Stack<char>();
            //Stack<char> data = new Stack<char>();
            errorlnd = 0;
            bool flag = false;
            char[] ooChar = oo.ToCharArray();
            char temp, cc;
            int i = 0;

            for (i = 0; i < ooChar.Length; i++)
            {
                cc = ooChar[i];
                if ((cc == '(') || (cc == '[') || (cc == '{'))
                {
                    data.push(cc);
                }
                else if ((cc == ')') || (cc == ']') || (cc == '}'))// the left is too murch
                {
                    if (data.size() <= 0) { errorlnd = i; flag = false; break; }
                    temp = (char)data.pop();
                    if (!typeMatch(temp, cc)) { errorlnd = i; flag = false; break; }
                }
            }
            if ((data.size() <= 0) && (i == ooChar.Length)) { flag = true; }
            else { errorlnd = i; flag = false; }
            return flag;
        }//End of parenthesisMatching

        private static bool typeMatch(char left, char right)
        {
            bool flag = false;
            switch (left)
            {
                case '(': if (right == ')') flag = true; break;
                case '[': if (right == ']') flag = true; break;
                case '{': if (right == '}') flag = true; break;

            }
            return flag;
        }//End of typeMatch
        #endregion

        #region check expression
        //------check expression-----//

        public static bool checkExpression(string str)
        {
            if (str.Equals(""))
            {
                return false;
            }
            //如果有连续的符号的话返回false
            if (Regex.IsMatch(str, @"[+-/\\*]{2,}")) { return false; }

            //如果出现连续的括号的话返回false
            if (Regex.IsMatch(str, @"[\(\)]{2,}")) { return false; }

            //如果左括号后面出现+*/符号的时候返回false
            if (Regex.IsMatch(str, @"\([+/\\*]+")) { return false; }
            //如果右括号后面出现数字或者没有出现+-*/的时候返回false
            if (Regex.IsMatch(str, @"\)[^+-/\\*]")) { return false; }
            //如果左括号前面没有出现+-*/的时候返回false
            if (Regex.IsMatch(str, @"[^+-/\\*]+\(")) { return false; }
            //如果右括号前面出现+-*/的时候返回fasle
            if (Regex.IsMatch(str, @"[+-/\\*]+\)")) { return false; }
            //递归检查括号是否成对出现
            char item;
            Stack<char> s = new Stack<char>();
            foreach (char i in str)
            {
                item = i;
                if (item == '(')
                {
                    s.Push('(');
                }
                else if (item == ')')
                {
                    if (s.Count > 0)
                    {
                        s.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (s.Count != 0)
            {
                return false;
            }
            return true;
        }//End of  checkExpression(string str)
        #endregion

        #region Postpone processing:expression
        //------Postpone processing:expression-----//
        // A utility function to return 
        // precedence of a given operator 
        // Higher returned value means higher precedence 
        internal static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        // The main method that converts given infix expression 
        // to postfix expression.  
        public static string infixToPostfix(string exp)
        {
            // initializing empty String for result 
            string result = "";

            // initializing empty stack 
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                // If the scanned character is an 
                // operand, add it to output. 
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                // If the scanned character is an '(',
                // push it to the stack. 
                else if (c == '(')
                {
                    stack.Push(c);
                }

                //  If the scanned character is an ')', 
                // pop and output from the stack  
                // until an '(' is encountered. 
                else if (c == ')')
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; // invalid expression
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else // an operator is encountered
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            // pop all the operators from the stack 
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
        #endregion

        #region  Palindrom
        //-----Palindrom-----//
        public static bool palindrom(String ss)
        {
            Stack<char> cstack = new Stack<char>();
            string input = ss;

            var inputToUpper = input.ToUpper(); /*assuming case senstivity is not to be considered */

            foreach (char c in inputToUpper)
            {
                cstack.Push(c);//push the data in the stacks 
            }

            bool isPalindrome = true;
            var noOfItems = cstack.Count;

            for (int i = 0; i < noOfItems; i++)
            {
                if (inputToUpper[i] != cstack.Pop())//judge if equity
                {
                    isPalindrome = false; break;//IF false break
                }
            }

            return isPalindrome;
        }//End of palindrom
        #endregion

        #region Addition of two large number
        //-----Addition of two large numbers-----//
        public static String add2LargeInteger(String str1, String str2)
        {
            // Before proceeding further, make sure length
            // of str2 is larger.
            if (str1.Length > str2.Length)// Find the lengther one
            {
                string t = str1;
                str1 = str2;
                str2 = t;
            }

            // Take an empty string for storing result
            string str = "";

            // Calculate length of both string
            int n1 = str1.Length, n2 = str2.Length;

            // Reverse both of strings
            char[] ch = str1.ToCharArray();
            Array.Reverse(ch);
            str1 = new string(ch);
            char[] ch1 = str2.ToCharArray();
            Array.Reverse(ch1);
            str2 = new string(ch1);

            int carry = 0;
            for (int i = 0; i < n1; i++)
            {
                // Do school mathematics, compute sum of
                // current digits and carry
                int sum = ((int)(str1[i] - '0') +
                        (int)(str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');

                // Calculate carry for next step
                carry = sum / 10;
            }

            // Add remaining digits of larger number
            for (int i = n1; i < n2; i++)
            {
                int sum = ((int)(str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // Add remaining carry
            if (carry > 0)
                str += (char)(carry + '0');

            // reverse resultant string
            char[] ch2 = str.ToCharArray();
            Array.Reverse(ch2);
            str = new string(ch2);

            return str;
        }//End of add2LargeInteger
        #endregion

        #region Base transformation 
        //-----Base transformation-----//
        public static String ten2Base(int N, int D)
        {
            if (D < 2 || D > 16)
            {
                throw new ArgumentOutOfRangeException("D", "只支持将十进制数据转换为二进制至16进制！");
            }
            DS_Stack<char> stack = new DS_Stack<char>();
            do
            {
                int residue = N % D;//取余；
                char c = (residue < 10) ? (char)(residue + 48) : (char)(residue + 55);
                stack.push(c); //进栈；
            }
            while ((N = N / D) != 0);

            string s = string.Empty;
            while (stack.size() > 0)
            {
                s += stack.pop().ToString();
            }
            return s;
        }//End of ten2Base

        // To return value of a char.
        // For example, 2 is returned
        // for '2'. 10 is returned
        // for 'A', 11 for 'B'
        static int val(char c)
        {
            if (c >= '0' && c <= '9')
                return (int)c - '0';
            else
                return (int)c - 'A' + 10;
        }

        // Function to convert a
        // number from given base
        // 'b' to decimal
        public static int bass2Ten(string str,
                          int b_ase)
        {
            int len = str.Length;
            int power = 1; // Initialize
                           // power of base
            int num = 0; // Initialize result
            int i;

            // Decimal equivalent is
            // str[len-1]*1 + str[len-2] *
            // base + str[len-3]*(base^2) + ...
            for (i = len - 1; i >= 0; i--)
            {
                // A digit in input number
                // must be less than
                // number's base
                if (val(str[i]) >= b_ase)
                {
                    Console.WriteLine("Invalid Number");
                    return -1;
                }

                num += val(str[i]) * power;
                power = power * b_ase;
            }

            return num;
        }//End of bass2Ten
        public static Stack<int> PushStack(Stack<int> N1,
                            Stack<int> N2)
        {
            Stack<int> res = new Stack<int>();
            int sum = 0, rem = 0;

            while (N1.Count != 0 && N2.Count != 0)
            {

                // Calculate the sum of the top
                // elements of both the stacks
                sum = (rem + N1.Peek() + N2.Peek());

                // Push the sum into the stack
                res.Push((int)sum % 10);

                // Store the carry
                rem = sum / 10;

                // Pop the top elements
                N1.Pop();
                N2.Pop();
            }

            // If N1 is not empty
            while (N1.Count != 0)
            {
                sum = (rem + N1.Peek());
                res.Push(sum % 10);
                rem = sum / 10;
                N1.Pop();
            }

            // If N2 is not empty
            while (N2.Count != 0)
            {
                sum = (rem + N2.Peek());
                res.Push(sum % 10);
                rem = sum / 10;
                N2.Pop();
            }

            // If carry remains
            while (rem > 0)
            {
                res.Push(rem);
                rem /= 10;
            }

            // Reverse the stack.so that
            // most significant digit is
            // at the bottom of the stack
            while (res.Count != 0)
            {
                N1.Push(res.Peek());
                res.Pop();
            }

            res = N1;
            return res;
        }

        // Function to display the
        // resultamt stack
        public static string display(Stack<int> res)
        {
            int N = res.Count;
            String s = "";

            while (res.Count != 0)
            {
                s = String.Join("", res.Peek()) + s;
                res.Pop();
            }
            return s;
        }
        #endregion

        #region infix postfix prefix
        //-----in to postfix-----//
        //-----postfix to infix-----//
        public  static String post2infix(String ss)
        {
            String result = "";
            if (!post2infix(ss,out result)) 
            {
                result = "";
            }
            post2infix(ss, out result);
            return result;
        }
        public static bool  post2infix(String ss,out String result)
        {
            Stack<String> expStack = new Stack<String>();
            String operators = "+-*/";
            
            bool flag = true;
            //checkExpressionn(ss){ }
            char[] source = ss.ToCharArray();// eack character denotes one operand
            result = "";
            String temp = "";
            foreach(char cc in source)
            {
                if (operators.Contains(cc))//operator
                {
                    if(expStack.Count>1)
                    {
                        temp = expStack.Pop();
                        expStack.Push(("("+expStack.Pop()) + cc + temp+")");// 前两个 oprater 前一个
                        //expStack.Push(cc + expStack.Pop()+temp);//prefix
                    }
                    else { flag = false;break; }
                }
                else
                {
                    expStack.Push(cc.ToString());
                }
            }
            if (expStack.Count==1)
            {
                result = expStack.Pop();
            }
            else { flag = false; }
            return flag;
        }//End of post2infix
        public static bool post2prefix(String ss, out String result)
        {
            Stack<String> expStack = new Stack<String>();
            String operators = "+-*/";

            bool flag = true;
            //checkExpressionn(ss){ }
            char[] source = ss.ToCharArray();// eack character denotes one operand
            result = "";
            String temp = "";
            foreach (char cc in source)
            {
                if (operators.Contains(cc))//operator
                {
                    if (expStack.Count > 1)
                    {
                        temp = expStack.Pop();
                        //expStack.Push(("(" + expStack.Pop()) + cc + temp + ")");// 前两个 oprater 前一个
                        expStack.Push(cc + expStack.Pop() + temp);//prefix
                    }
                    else { flag = false; break; }
                }
                else
                {
                    expStack.Push(cc.ToString());
                }
            }
            if (expStack.Count == 1)
            {
                result = expStack.Pop();
            }
            else { flag = false; }
            return flag;
        }//End of post2prefix
        public static bool prefix2postfix(String ss, out String result)
        {
            Stack<String> expStack = new Stack<String>();
            String operators = "+-*/";

            bool flag = true;
            //checkExpressionn(ss){ }
            // char[] source = ss.ToCharArray() ;// eack character denotes one operand
            List<char> source = ss.ToList();
            source.Reverse();
            result = "";
            String temp = "";
            foreach (char cc in source )
            {
                if (operators.Contains(cc))//operator
                {
                    if (expStack.Count > 1)
                    {
                        temp = expStack.Pop();
                        //expStack.Push(("(" + expStack.Pop()) + cc + temp + ")");// 前两个 oprater 前一个
                        expStack.Push( expStack.Pop() + temp+cc);//prefix
                    }
                    else { flag = false; break; }
                }
                else
                {
                    expStack.Push(cc.ToString());
                }
            }
            if (expStack.Count == 1)
            {
                result = expStack.Pop();
            }
            else { flag = false; }
            source.Reverse();
            return flag;
        }//End of post2prefix
        public static bool prefix2infix(String ss, out String result)
        {
            Stack<String> expStack = new Stack<String>();
            String operators = "+-*/";

            bool flag = true;
            //checkExpressionn(ss){ }
            //char[] source = ss.ToCharArray() ;// eack character denotes one operand
            List<char> source = ss.ToList();
            source.Reverse();
            result = "";
            String temp = "";
            foreach (char cc in source)
            {
                if (operators.Contains(cc))//operator
                {
                    if (expStack.Count > 1)
                    {
                        temp = expStack.Pop();
                        expStack.Push(("(" +temp + cc + expStack.Pop()) + ")");// 前两个 oprater 前一个
                        //expStack.Push(expStack.Pop() + temp + cc);//prefix
                    }
                    else { flag = false; break; }
                }
                else
                {
                    expStack.Push(cc.ToString());
                }
            }
            if (expStack.Count == 1)
            {
                result = expStack.Pop();
            }
            else { flag = false; }
           
            return flag;
        }//End of post2prefix
        #endregion
        #region prostfix evaluation
        public static int evaluatePostfix(string exp)
        {
            Stack<int> stack = new Stack<int>();//创建stack
            for (int i = 0; i < exp.Length; i++)//将每一个字符输入stack
            {
                char c = exp[i];

                if (c == ' ')
                {
                    continue;
                }
                else if (char.IsDigit(c))//如果是一个operand，提取这个数字。把它push到stack中。
                {
                    int n = 0;
                    while (char.IsDigit(c))//如果是operator 将其加入到num中
                    {
                        n = n * 10 + (int)(c - '0');
                        i++;
                        c = exp[i];
                    }
                    i--;

                    stack.Push(n);//将数字push 到 stack中
                }

                else//如果扫描到的operand是一个操作符，从stack中push两个element，应用该operator 和 calculate 
                {
                    int val1 = stack.Pop();
                    int val2 = stack.Pop();

                    switch (c)
                    {
                        case '+':
                            stack.Push(val2 + val1);//加
                            break;

                        case '-':
                            stack.Push(val2 - val1);//减
                            break;

                        case '/':
                            stack.Push(val2 / val1);//除
                            break;

                        case '*':
                            stack.Push(val2 * val1);//乘
                            break;
                    }
                }
            }
            return stack.Pop();
        }//End of evaluatePostfix(string exp)
        #endregion
        #region N-Queens
        ///Solve N-Queens
        public static IEnumerable<Tuple<int, int>> Solve(int n)
        {
            return SolveForRemainder(Enumerable.Empty<Tuple<int, int>>(), n);
        }

        public static void Print(IEnumerable<Tuple<int, int>> queenLocations, char emptySpot = 'O', char queenSpot = 'x')
            //打印一个标有皇后位置的棋盘
        {
            var size = queenLocations.Count();
            if (size == 0) Console.WriteLine("no solution");
            var emptyLine = Enumerable.Range(0, size).Select(_ => emptySpot).ToArray();
            var lines = queenLocations.OrderBy(x => x.Item1).Select(x =>
                new string(emptyLine, 0, x.Item2)
                + queenSpot
                + new string(emptyLine, 0, size - x.Item2 - 1));
            Console.WriteLine(string.Join(Environment.NewLine, lines));
        }

        private static IEnumerable<Tuple<int, int>> SolveForRemainder(IEnumerable<Tuple<int, int>> existingPositions, int range)
            //递归地将皇后放在合法的位置上，当卡住时进行回溯，找到答案后退出。
        {
            if (existingPositions.Count() == range) return existingPositions;
            var potentialNextPositions = NextQueenPossibilities(existingPositions, range);
            var explorations = potentialNextPositions.Select(position =>
                SolveForRemainder(existingPositions.Concat(new[] { position }).ToArray(), range));
            return explorations.FirstOrDefault(x => x.Any()) ?? Enumerable.Empty<Tuple<int, int>>();
        }
        private static bool placeQueen(bool[,] board, int row)//put the Queen in the special place
        {
            bool flag = false;
            int n = board.Length;
            Stack<int> stack = new Stack<int>();//创建stack
            int colum = 0;

            while (colum < n)//小于行位置
            {
                while(row < n)//小于类
                {
                    if (board[colum,row]==false)
                    {
                        stack.Push(colum);
                        stack.Push(row);
                        board[colum,colum] = true;
                        break;
                    }
                    row = row + 1;
                }
                if(row>=n)
                {
                    if(stack.Count()==0)
                    {
                        Console.WriteLine("no answer");
                    }
                    else 
                    {
                        stack.Pop();
                        board[colum, colum] = false;
                    }
                }
                colum = colum - 1;
            }



            return flag;//judge the Queen whther exist
        }//End of placeQueen

        ///Given two lists of numbers, this returns all pairs (the cartesian product).
        private static IEnumerable<Tuple<int, int>> AllCombinations(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a.Join(b, _ => true, _ => true, (m, n) => Tuple.Create(m, n));
        }

        private static bool PositionsAreDiagonal(Tuple<int, int> a, Tuple<int, int> b)//确定两点是否在一个对角线上
        {
            var xdif = a.Item1 - b.Item1;
            var ydif = a.Item2 - b.Item2;
            return (xdif == ydif || xdif + ydif == 0);//即：如果两点之间的斜率为1或-1，则返回真，否则为假。
        }
        private static IEnumerable<Tuple<int, int>> NextQueenPossibilities(IEnumerable<Tuple<int, int>> queens, int range)
        {
            var validCols = Enumerable.Range(0, range).Except(queens.Select(x => x.Item1));//这将返回下一个皇后的所有合法位置。
            var validRows = Enumerable.Range(0, range).Except(queens.Select(x => x.Item2));//给定一组现有的皇后位置。
            return AllCombinations(validCols, validRows).Where(x => !queens.Any(y => PositionsAreDiagonal(x, y)));//这将返回棋盘上所有的点，除了已经被皇后占据的行、列或对角线。
        }
#endregion
    }//End of class daStack

    #region Maze
    public class Maze
    {
        public static IEnumerable<IEnumerable<Tuple<int, int>>> gomaze(int[,] maze, int from_x, int from_y, int to_x, int to_y)//迷宫，入口，出口
        {
            if (from_x == to_x && from_y == to_y)//成功 现在的位置等于出口位置
                yield return new Tuple<int, int>[] { new Tuple<int, int>(to_x, to_y) };//记录位置
            else
            {
                maze[from_x, from_y] = 0;
                for (var i = Math.Max(0, from_x - 1); i <= Math.Min(from_x + 1, maze.GetLength(0) - 1); i++)//对左右两侧进行检查是否为0
                    for (var j = Math.Max(0, from_y - 1); j <= Math.Min(from_y + 1, maze.GetLength(1) - 1); j++)//对上下两边进行检测
                        if ((i == from_x || j == from_y) && !(i == from_x && j == from_y) && maze[i, j] == 1)//如果有位置为1
                        {
                            foreach (var road in gomaze(maze, i, j, to_x, to_y))//对每个位置进行循环
                                yield return new Tuple<int, int>[] { new Tuple<int, int>(from_x, from_y) }.Concat(road);//记录可以走的路线
                        }
            }
        }//
    }//END of Maze
    #endregion

}//End of namespace a107230001_App

