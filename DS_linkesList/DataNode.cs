using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a107230001_DSLibrary.DS_linkesList
{
    public class DataNode<E>
    {
        #region //----------Global Data--------------//
        private E pData; //
        private DataNode<E> pPrev = null; //
        private DataNode<E> pNext = null; //

        #region //----------Data Property--------------//
        //public 這三項是對外的取得&設定Data的窗口。(與下方的 Accessor/Mutator 相同)
        //get & set 可以設定誰有權力取得或設定 pPrev & pNext & pData 的合法性
        //未來要設定(取得或設定條件時)可以經這裡處理。(Property 與 Accessor/Mutator，選一處處理即可)
        public DataNode<E> prev { get { return pPrev; } set { pPrev = value; } }
        public DataNode<E> next { get { return pNext; } set { pNext = value; } }
        public E data { get { return pData; } set { pData = value; } }
        #endregion
        #endregion

        #region //----------Action--------------//

        #region //----------Constructor(資料進入點)--------------//
        public DataNode() { }

        //Circularly & Doubly(環狀與雙向鏈結串列) 專用進入點通道
        public DataNode(E dd, DataNode<E> pp, DataNode<E> nn) { data = dd; prev = pp; next = nn; }

        //Singly(單向鏈結串列) 專用進入點通道
        public DataNode(E dd, DataNode<E> nn) { data = dd; prev = null; next = nn; }
        #endregion

        #region //----------Accessor/Mutator--------------//
        ////對外的取得&設定Data的窗口。(與上方的 Property 相同)
        //get & set 可以設定誰有權力取得或設定 pPrev & pNext & pData 的合法性
        //未來要設定(取得或設定條件時)可以經這裡處理。(Property 與 Accessor/Mutator，選一處處理即可)
        public E getData() { return data; }
        public DataNode<E> getNext() { return next; }
        public DataNode<E> getPrev() { return prev; }


        public void setData(E dd) { data = dd; }
        public void setNext(DataNode<E> nn) { next = nn; }
        public void setPrev(DataNode<E> pp) { prev = pp; }

        #endregion
        #endregion
    }// end of DataNode<E>
}//end of namespace a107230001_DSLibrary.DS_linkesList
