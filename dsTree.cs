using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a107230001_DSLibrary;

namespace a107230001_App
{
    public class DS_BET
    {
        public static a107230001_DSLibrary.DS_Tree.DS_TreeNode<String> bExpressionTree(string exper)
        {
            Stack<a107230001_DSLibrary.DS_Tree.DS_TreeNode<String>> ss = new Stack<a107230001_DSLibrary.DS_Tree.DS_TreeNode<string>>();
            a107230001_DSLibrary.DS_Tree.DS_TreeNode<String> pp, ll, rr, temp;//右值 运算值  左值
            bool flag = true;
            int rp = 0, lp = 0;

            foreach (char cc in exper)//输入每一个值
            {
                if (cc == ' ') { } //如果输入值为空 就不执行 防错
                else if (cc == ')')//如果碰到）就推出到（ 右值 运算值  左值
                {
                    rp++;
                    if (ss.Count > 2)
                    {
                        rr = ss.Pop();//推入右值
                        pp = ss.Pop();//推入运算符号
                        ll = ss.Pop();//推入左值
                        pp.setLeftChild(ll);//将左值定义为左小孩
                        pp.setRightChild(rr);//将右值 赋值为 右小孩
                        ll.setParent(pp);//将运算符号设为父亲
                        rr.setParent(pp);//将运算符号设为父亲
                        ss.Push(pp);//推出运算符号
                    }
                    else { flag = false; break; }
                }
                else if (isOperatpor(cc) || char.IsLetter(cc))//如果为运算符号
                {
                    temp = new a107230001_DSLibrary.DS_Tree.DS_TreeNode<string>((cc.ToString()));
                    ss.Push(temp);//推出运算符号
                }
                else if (cc == '(') { lp++; }//如果碰到（ 累加
                else { flag = false; break; }

            }
            if ((flag == true) && (ss.Count == 1) && (lp == rp)) { return (ss.Pop()); }//如果就剩一个值就成功
            else { return null; }//否则为失败

        }//End of bExpressionTree
        static bool isOperatpor(char cc)//创建运算符号
        {
            if ((cc == '+') || (cc == '-') || (cc == '*') || (cc == '/') || (cc == '%') || (cc == '^')) return true;
            else return false;
        }
        static bool isOperatpor(string cc)//创建运算符号
        {
            if ((cc == "+") || (cc == "-") || (cc == "*") || (cc == "/") || (cc == "%") || (cc == "^")) return true;
            else return false;
        }
    }
    public class Node//创建node
    {
        public int key, height;
        public Node left, right;

        public Node(int d)
        {
            key = d;//root
            height = 1;//高度
        }
    }

    public class AVLTree
    {
        public Node root;

        int height(Node N)// 一个获得树高的实用函数 
        {
            if (N == null)
                return 0;
            return N.height;
        }
        int max(int a, int b) // 一个实用函数，用于 
        
        {
            return (a > b) ? a : b;// 得到两个整数的最大值 
        }


        public Node rightRotate(Node y) // 一个向右转的实用函数 
        {
            Node x = y.left; //旋转以y为根的子树 
            Node T2 = x.right;

            x.right = y;
            y.left = T2;// 进行旋转 
            // 更新高度 
            y.height = max(height(y.left), height(y.right)) + 1;
            x.height = max(height(x.left), height(x.right)) + 1;

            return x;// 返回新的根 
        }

        public Node leftRotate(Node x)// 一个实用的函数，用于向左 
        {
            Node y = x.right;
            Node T2 = y.left; //旋转以x为根的子树 

            y.left = x;
            x.right = T2; // 进行旋转 

            // Update heights 
            x.height = max(height(x.left), height(x.right)) + 1;
            y.height = max(height(y.left), height(y.right)) + 1;

            // Return new root 
            return y;
        }

        int getBalance(Node N) // 获得节点N的平衡系数 
        {
            if (N == null)
                return 0;
            return height(N.left) - height(N.right);
        }

        public Node insert(Node node, int key)
        {
            /* 1.执行正常的BST旋转 */
            if (node == null)
                return (new Node(key));

            if (key < node.key)
                node.left = insert(node.left, key);
            else if (key > node.key)
                node.right = insert(node.right, key);
            else // Equal keys not allowed 
                return node;

            /* 2. 更新这个祖先节点的高度 */
            node.height = 1 + max(height(node.left),
                                height(node.right));
            /* 获取这个祖先节点的平衡系数，以检查这个节点是否成为了一个新的节点。
         节点的平衡系数，以检查该节点是否成为 
         不平衡 */
            int balance = getBalance(node);

            // If this node becomes unbalanced, then 
            // there are 4 cases Left Left Case 
            if (balance > 1 && key < node.left.key)
                return rightRotate(node);

            // Right Right Case 
            if (balance < -1 && key > node.right.key)
                return leftRotate(node);

            // Left Right Case 
            if (balance > 1 && key > node.left.key)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            // Right Left Case 
            if (balance < -1 && key < node.right.key)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }

        /*给定一个非空的二进制搜索树，返回该树中键值最小的节点。
       在该树中找到的键值最小的节点。
       请注意，不需要对整个树进行 
       搜索。*/
        Node minValueNode(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
                current = current.left;

            return current;
        }

        public Node deleteNode(Node root, int key)
        {
            // 第1步：执行标准的BST删除 
            if (root == null)
                return root;
            // 如果要删除的键小于 
            //根的键，那么它就位于左子树中 
            if (key < root.key)
                root.left = deleteNode(root.left, key);
            // 如果要删除的键大于 
            //根的键，那么它就在右边的子树上 
            else if (key > root.key)
                root.right = deleteNode(root.right, key);
            // 如果键值与根的键值相同，那么这个节点就是。
            // 将被删除 
            else
            {

                // node with only one child or no child 
                if ((root.left == null) || (root.right == null))
                {
                    Node temp = null;
                    if (temp == root.left)
                        temp = root.right;
                    else
                        temp = root.left;

                    // No child case 
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else // One child case 
                        root = temp; // Copy the contents of 
                                     // the non-empty child 
                }
                else
                {
                    // 有两个孩子的节点。获取依次的 
                    // 继承者（在右边子树中最小的）。
                    Node temp = minValueNode(root.right);

                    // Copy the inorder successor's data to this node 
                    root.key = temp.key;

                    // Delete the inorder successor 
                    root.right = deleteNode(root.right, temp.key);
                }
            }

            // If the tree had only one node then return 
            if (root == null)
                return root;
            // 第二步：更新当前节点的高度 
            root.height = max(height(root.left),
                        height(root.right)) + 1;

            // 第3步：获得平衡系数
            // 该节点的平衡系数（以检查 
            // 这个节点是否变得不平衡) 
            int balance = getBalance(root);

            // If this node becomes unbalanced, 
            // then there are 4 cases 
            // Left Left Case 
            if (balance > 1 && getBalance(root.left) >= 0)
                return rightRotate(root);

            // Left Right Case 
            if (balance > 1 && getBalance(root.left) < 0)
            {
                root.left = leftRotate(root.left);
                return rightRotate(root);
            }

            // Right Right Case 
            if (balance < -1 && getBalance(root.right) <= 0)
                return leftRotate(root);

            // Right Left Case 
            if (balance < -1 && getBalance(root.right) > 0)
            {
                root.right = rightRotate(root.right);
                return leftRotate(root);
            }

            return root;
        }
        public void preOrder(Node node)// 一个实用的函数，用于打印前序遍历的 
        // 树的前序遍历。该函数还可以打印每个 
        // 节点的旋转 
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                preOrder(node.left);
                preOrder(node.right);
            }
        }
    }
}
