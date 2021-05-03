using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotoMover
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y) 
        {
            int returnVal= -1;
            ListViewItem ix = (ListViewItem)x;
            ListViewItem iy = (ListViewItem)y;
            if (ix.SubItems.Count > col && iy.SubItems.Count > col)
            {
                returnVal = String.Compare((ix).SubItems[col].Text,
                                        (iy).SubItems[col].Text);
            }else if(ix.SubItems.Count > col && iy.SubItems.Count <= col){
                returnVal = 1;
            }
            else if (ix.SubItems.Count <= col && iy.SubItems.Count <= col)
            {
                returnVal = 0;
            }
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}
