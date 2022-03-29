using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_DSLibrary.DS_Tree
{
    #region//===Class CreateTree for testing multi-tree applications===//
    public class DS_CreateTree
    { 
        //--- Grobal data---//
        public DS_TreeNode<string> root;
        //----Construstor---//
        public DS_CreateTree(int tree)
        {
            if (tree == 1)
            {
                List<DS_TreeNode<String>> tempC;//建立多元树
                DS_TreeNode<String> aa = new DS_TreeNode<String>("A");//parent only one
                DS_TreeNode<String> bb = new DS_TreeNode<String>(aa, "B");//parent and children
                DS_TreeNode<String> cc = new DS_TreeNode<String>(aa, "C");
                DS_TreeNode<String> dd = new DS_TreeNode<String>(aa, "D");
                DS_TreeNode<String> ee = new DS_TreeNode<String>(bb, "E");
                DS_TreeNode<String> ff = new DS_TreeNode<String>(bb, "F");
                DS_TreeNode<String> gg = new DS_TreeNode<String>(bb, "G");
                DS_TreeNode<String> hh = new DS_TreeNode<String>(ff, "H");
                tempC = new List<DS_TreeNode<String>>();//建立新树
                tempC.Add(hh);
                ff.setChildren(tempC);
                tempC = new List<DS_TreeNode<string>>();//建立新的树 f为parent node
                tempC.Add(ee);
                tempC.Add(ff);
                tempC.Add(gg);
                bb.setChildren(tempC);//efg是b的children
                tempC = new List<DS_TreeNode<string>>();//b为parent node
                tempC.Add(bb);
                tempC.Add(cc);
                tempC.Add(dd);
                aa.setChildren(tempC);//bcd是a的小孩
                root = aa;//a是root
            }
            if(tree==2)
            {
                List<DS_TreeNode<String>> tempC;//建立多元树
                DS_TreeNode<String> aa = new DS_TreeNode<String>("A");//parent only one
                DS_TreeNode<String> bb = new DS_TreeNode<String>(aa, "B");//parent and children
                DS_TreeNode<String> cc = new DS_TreeNode<String>(aa, "C");
                DS_TreeNode<String> dd = new DS_TreeNode<String>(aa, "D");
                DS_TreeNode<String> ee = new DS_TreeNode<String>(bb, "E");
                DS_TreeNode<String> ff = new DS_TreeNode<String>(bb, "F");
                DS_TreeNode<String> gg = new DS_TreeNode<String>(cc, "G");
                DS_TreeNode<String> hh = new DS_TreeNode<String>(cc, "H");
                DS_TreeNode<String> ii = new DS_TreeNode<String>(ff, "I");
                DS_TreeNode<String> jj = new DS_TreeNode<String>(ff, "J");
                DS_TreeNode<String> kk = new DS_TreeNode<String>(ff, "K");
                tempC = new List<DS_TreeNode<String>>();//建立新树
                tempC.Add(ii);
                tempC.Add(jj);
                tempC.Add(kk);
                ff.setChildren(tempC);
                tempC = new List<DS_TreeNode<string>>();
                tempC.Add(ee);
                tempC.Add(ff);
                bb.setChildren(tempC);
                tempC = new List<DS_TreeNode<string>>();
                tempC.Add(gg);
                tempC.Add(hh);
                cc.setChildren(tempC);
                tempC = new List<DS_TreeNode<string>>();
                tempC.Add(bb);
                tempC.Add(cc);
                tempC.Add(dd);
                aa.setChildren(tempC);
                root = aa;//a是root

            }
        }

        //---Methods---//
        public override string ToString()
        {
            string ss = "The tree root contains:\n";
            ss += root.ToString();//data;
            return ss;
        }
    }
    #endregion
    #region//===Class CreateBinaryTree for testing binary tree applications===//
    #endregion
    #region//===Class  for Tree traversal===//
    public  class DS_TreeTraversal<T>
    {
        #region//===classs for tree traversal===//
        public static List<T>dfsPreorder(DS_TreeNode<T>root)//中 左 右
        {
            List<T> ll = new List<T>();
            Stack<DS_TreeNode<T>> ss = new Stack<DS_TreeNode<T>>();//创造 queue
            DS_TreeNode<T> dd;//创造TREE
            if (root !=null)//如果有树
            {
                dd = root;
                ss.Push(dd);//推出Node
                while(ss.Count > 0)//如果树的child的node不为0
                {
                    dd = ss.Pop();//推出
                    ll.Add(dd.data);//添加
                    if (dd.children != null)
                    {
                        for (int i = dd.children.Count - 1; i >= 0; i--)//For loop 将每一个树推出
                        {
                            ss.Push(dd.children[i]);//将child 推出
                        }
                    }
                }
            }

            return ll;
        }
        public static List<T> dfsPostorder(DS_TreeNode<T> root)//左 右 中
        {
            List<T> ll = new List<T>();//创造 list
            Stack<DS_TreeNode<T>> ss = new Stack<DS_TreeNode<T>>();//创造stack
            Stack<Boolean> visited = new Stack<Boolean>();//记录访问过的地方
            DS_TreeNode<T> dd;
            if (root != null)
            {
                dd = root;//设置树根
                ss.Push(dd);// 将dd推入
                visited.Push(false);//记录是否有走过
                while (ss.Count > 0)//停止条件为数量不为0
                {
                    dd = ss.Peek();
                    if ((dd.children == null) ||(visited.Peek()==true)||(dd.children.Count==0))//如果孩子不为空，和孩子的数量不为0，和已经访问过的位置
                    {
                        dd = ss.Pop();//推出最上面的
                        ll.Add(dd.data);//添加读入的data child
                        visited.Pop();//推出已经访问过的位置
                    }
                    else
                    {
                        visited.Pop();//推出访问过的地方
                        visited.Push(true);//推出
                        for (int i = dd.children.Count - 1; i >= 0; i--)//进入for loop 循环 长度为child为长度
                        {
                            ss.Push(dd.children[i]);//将每一个孩子推出
                            visited.Push(false);//将访问过的地方推出为false
                        }
                    }
                }
            }

            return ll;
        }


        public static List<T> bfs(DS_TreeNode<T>root)
        {
            List<T> ll = new List<T>();//创造list
            Queue<DS_TreeNode<T>> qq = new Queue<DS_TreeNode<T>>();//新queue
            DS_TreeNode<T> dd;
            if(root != null)
            {
                dd = root;//从root开始
                qq.Enqueue(dd);//Enqueue root 跟
                while(qq.Count>0)//queue 不是空的
                {
                    dd = qq.Dequeue();
                    ll.Add(dd.data);//加入值
                    if(dd.children !=null)//enqueue 孩子
                    {
                        foreach(var vv in dd.children)
                        {
                            qq.Enqueue(vv);//将每一个值加入queen中
                        }
                    }
                }
            }
            return ll;
        }
        public static List<T> BtPreorder(DS_TreeNode<T> root)//中 左 右
        {
            List<T> ll = new List<T>();
            Stack<DS_TreeNode<T>> ss = new Stack<DS_TreeNode<T>>();//创造 queue
            DS_TreeNode<T> dd;//创造TREE
            if(root != null)
            {
                dd = root;//树根
                ss.Push(dd);//推入树根
                while(ss.Count >0)
                {
                    dd = ss.Pop();//取出root树根
                    ll.Add(dd.data);//添加data
                    if (dd.rightChild != null) { ss.Push(dd.rightChild); }//推入右小孩
                    if (dd.leftChild != null) { ss.Push(dd.leftChild); }//推入左小孩
                }
            }
            return ll;
        }
        public static List<T> BtInorder1(DS_TreeNode<T> root)//左 中 右
        {
            List<T> ll = new List<T>();
            Stack<DS_TreeNode<T>> ss = new Stack<DS_TreeNode<T>>();//创造 queue
            DS_TreeNode<T> dd;//创造TREE
            if (root != null)
            {
                dd = root;
                while (ss.Count > 0)
                {
                    dd = ss.Pop();//
                    ll.Add(dd.data);//添加data
                    if (dd.rightChild != null) { ss.Push(dd.rightChild); }//推入右小孩
                    ss.Push(dd);//中
                    if (dd.leftChild != null) { ss.Push(dd.leftChild); }//推入左小孩

                }
                
            }
            return ll;
        }
        public static List<T> BtInorderList(DS_TreeNode<T> root)
        {
            List<T> ll = new List<T>();//建立list
            Stack<DS_TreeNode<T>> ss = new Stack<DS_TreeNode<T>>();//创造 stack
            Stack<Boolean> visited = new Stack<Boolean>();//记录访问过的地方
            DS_TreeNode<T> dd;//创造TREE
            if (root != null)//树根的值不为空
            {
                dd = root;
                while (dd != null)//如果树的child的node不为0
                {
                    while (dd != null)//检查值是否为空
                    {
                        if (dd.rightChild != null)//右小孩不为空
                        {
                            ss.Push(dd.rightChild);//推入右小孩
                            visited.Push(false);//将右小孩显示没有访问过
                        }
                        ss.Push(dd);//放入节点
                        visited.Push(false);//该节点未被访问
                        dd = dd.leftChild;//放入左小孩
                    }
                    dd = ss.Pop();//取出没有左小孩的节点
                    ll.Add(dd.data);//加入资料
                    while(ss.Count>0 && dd.rightChild == null)//还有没有右小孩 和 是否为空
                    {
                        visited.Push(true);//有小孩被访问
                        dd = ss.Pop();//依序推出
                        ll.Add(dd.data);//加资料
                    }
                    if (ss.Count > 0)
                    {
                        dd = ss.Pop();//推出最上层的data
                    }
                    else return ll;
                }
            }
            return ll;
        }
        public static List<T> BTinorder(DS_TreeNode<T> root)
        {
            List<T> ll = new List<T>();
            Stack<DS_TreeNode<T>> ss = new Stack<DS_TreeNode<T>>();
            DS_TreeNode<T> dd;
            dd = root;
            while(dd != null)
            {
                while (dd != null)
                {
                    if (dd.rightChild != null) { ss.Push(dd.rightChild); }
                    ss.Push(dd);
                    dd = dd.leftChild;
                }
                dd = ss.Pop();
                while ((ss.Count>0)&(dd.rightChild==null))
                {
                    ll.Add(dd.data);
                    dd = ss.Pop();
                }
                ll.Add(dd.data);
                if (ss.Count > 0) { dd = ss.Pop(); }
                else break;
            }
            return ll;
        }

        #endregion
    }//End of DS_TreeTraversal
    public class DS_BTnodeRotation<T>
    {
        public static bool rightRotation(ref DS_TreeNode<T> root , DS_TreeNode<T> nn)
        {
            bool flag = false;
            if (nn != null)
            {
                DS_TreeNode<T> pp = nn.parent;
                DS_TreeNode<T> cc = nn;
                if ((pp != null) && (pp.leftChild == cc))//不可以树根 必须左小孩
                {
                    // 处理X 的父亲处理
                    if (pp.parent != null)//如果root没有parent
                    {
                        if (pp.parent.rightChild == pp) { pp.parent.rightChild = cc; }//如果toot为右小孩
                        else { pp.parent.leftChild = cc; }
                    }
                    else { root = cc; }//头head 没有root
                    cc.rightChild.parent = pp;//将有小孩的父亲变为头
                    pp.leftChild = cc.rightChild;//将父亲的做小孩变为现有值的右小孩
                    cc.rightChild = pp;//将data的右小孩变为父亲
                    cc.parent = pp.parent;//将转的值的父亲变为上一级父亲的父亲
                    pp.parent = cc;//将转的值变为父亲
                    flag = true;
                }
            }
            return flag;
        }
        public static bool leftRotation(ref DS_TreeNode<T> root, DS_TreeNode<T> nn)
        {
            bool flag = false;
            if (nn != null)
            {
                DS_TreeNode<T> pp = nn.parent;
                DS_TreeNode<T> cc = nn;
                if ((pp != null) && (pp.rightChild == cc))//不可以树根 必须左小孩
                {
                    // 处理X 的父亲处理
                    if (pp.parent != null)//如果root没有parent
                    {
                        if (pp.parent.leftChild == pp) { pp.parent.leftChild = cc; }//如果toot为右小孩
                        else { pp.parent.rightChild = cc; }
                    }
                    else { root = cc; }//头 没有root
                    cc.leftChild.parent = pp;//将有小孩的父亲变为头
                    cc.parent = pp.parent;//将转的值的父亲变为上一级父亲的父亲
                    pp.parent = cc;//将转的值变为父亲
                    pp.rightChild = cc.leftChild;
                    cc.leftChild = pp;

                    flag = true;
                }
            }
            return flag;
        }
    }

    #endregion
    #region//===class for Binary search tree===//
    public class DS_BinarySearchingTree<E>
    {
        public DS_TreeNode<E> root;
        public DS_BinarySearchingTree()
        {
            root = null;
        }
        public DS_BinarySearchingTree(List<E>data)
        {
            if (data == null) root = null;
            foreach(var vv in data)
            {

            }
        }
        
    }
    #endregion
}
