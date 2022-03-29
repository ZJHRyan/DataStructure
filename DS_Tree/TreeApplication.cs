using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_DSLibrary.DS_Tree
{
    public class DS_BST<E>
    {
        //----Build binary searching tree by order array:default is ascending---//
        //按顺序排列建立二进制搜索树：默认为升序排列
        public static bool insertNodeInBST(ref DS_TreeNode<double > root,double data)//一次加入一个东西
        {
            bool flag = true;
            DS_TreeNode<double> cur = root, temp = null;
            if (cur == null) root = new DS_TreeNode<double>(cur, data);//check cur if null 检查输入是否为null
            else 
            {
                cur = root;
                while (cur != null)// 检查输入是否为null
                {
                    if(data < cur.data)//if it is larger than left 如果输入值大于左边
                    {
                        if(cur.leftChild==null)//check left if have child 检测做是否有小孩
                        {
                            temp = new DS_TreeNode<double>(cur, data); //将data暂时赋值
                            cur.leftChild = temp;//设置做小孩
                            break;
                        }
                        else { cur = cur.leftChild; }//if left have child continue to left 如果左边有小孩继续左边 
                    }
                    else//it is larger than right 如果data大于右边
                    {
                        if (cur.rightChild==null)//if right have child continue to right 如果没有右小孩
                        {
                            temp = new DS_TreeNode<double>(cur, data); //将data暂时赋值
                            cur.rightChild = temp;//设置做小孩
                            break;
                        }
                        else { cur = cur.rightChild; }
                    }
                }
            }
            return flag;
        }//End of insertNodeInBST

        public static DS_TreeNode<double> createBST(List<double> ll,bool ascending = true)//一次加入一串东西
        {
            DS_TreeNode<double> bsTree = null, cur = null, temp = null;
            if(ll !=null && ll.Count>0)
            {
                foreach(var vv in ll) { insertNodeInBST(ref bsTree, vv); }//将每一个值加入到list中
            }
            return bsTree;
        }
        //---delete the relationshipWithParent---//
    }
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }//End of Node

    public class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value > after.Data) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }//End of BinaryTree

}
