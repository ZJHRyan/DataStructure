using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_DSLibrary.DS_Tree
{
    public class DS_TreeNode<T>
    {
        #region //---Grobal variable---//
        public DS_TreeNode<T> parent = null;
        public DS_TreeNode<T> leftChild = null;//二元树
        public DS_TreeNode<T> rightChild = null;//二元树
        public List<DS_TreeNode<T>> children = null;//多元树
        public T data;
        #endregion

        #region //---Constructor---//
        public DS_TreeNode()// no data
        {
            //initialSetting();
        }
        public DS_TreeNode(DS_TreeNode<T> pp)//parent 
        {
            parent = pp;
        }
        public DS_TreeNode(DS_TreeNode<T>lc,DS_TreeNode<T>rc)//left + right children
        {
            //initialSetting();
            leftChild = lc;
            rightChild = rc;
        }
        public DS_TreeNode(List<DS_TreeNode<T>>cc)//children
        {
            //initialSetting();
            children = cc;
        }
        public DS_TreeNode( T dd)// data
        {
            data = dd;
        }
        public DS_TreeNode(DS_TreeNode<T>pp,T dd)//parent data
        {
            parent = pp;
            data = dd;
        }
        public DS_TreeNode(DS_TreeNode<T>pp,List<DS_TreeNode<T>>cc)//parent children
        {
            parent = pp;
            children = cc;
        }
        public DS_TreeNode(DS_TreeNode<T> pp, List<DS_TreeNode<T>> cc,T dd)//parent children data
        {
            parent = pp;
            children = cc;
            data = dd;
        }
        public DS_TreeNode(DS_TreeNode<T> pp, DS_TreeNode<T> lc, DS_TreeNode<T> rc)//parent left right 
        {
            parent = pp;
            leftChild = lc;
            rightChild = rc;
        }
        public DS_TreeNode(DS_TreeNode<T> pp, DS_TreeNode<T> lc, DS_TreeNode<T> rc, T dd)//parent left right data
        {
            parent = pp;
            leftChild = lc;
            rightChild = rc;
            data = dd;
        }
        #endregion

        #region//---Accessor/Mutator---//
        //---One data variable
        public void setParent(DS_TreeNode<T> pp) { parent = pp; }
        public void setLeftChild(DS_TreeNode<T> lc) { leftChild = lc; }
        public void setRightChild(DS_TreeNode<T> rc) { rightChild = rc; }
        public void setLRChild(DS_TreeNode<T> lc, DS_TreeNode<T> rc) { leftChild = lc; rightChild = rc; }
        public void setChildren(List<DS_TreeNode<T>> cc) { children = cc; }
        public void setData(T dd) { data=dd; }
        //---Binary tree---//
        //---Multi-tree---//
        #endregion

        #region//---Methods---//
        //---Override Tostring method
        public override string ToString()
        {
            string ss = "";
            if (parent != null) ss += ("Parent's data is" + parent.data.ToString() + "\n");//print data not the node
            else ss += ("The is root node\n");
            ss += ("Data is" + data.ToString() + "\n");//print data except parent 
            if (children != null)
            {
                ss += ("There are (" + children.Count + ") Children ---->");
                foreach(DS_TreeNode<T> tt in children)
                {
                    ss += (tt.data.ToString() + "\t");
                }
            }
            if (leftChild != null) ss += ("The left children data is" + leftChild.data.ToString() + "\n");
            if (rightChild != null) ss += ("The right children data is" + rightChild.data.ToString() + "\n");
            return ss;
        }
        #endregion
    }//End of DS_TreeNode
}//End if nameplace
