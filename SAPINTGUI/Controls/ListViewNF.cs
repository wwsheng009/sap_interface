using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SAPINTGUI
{
   public class TreeViewNF : System.Windows.Forms.TreeView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }
        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        //private const int WM_VSCROLL = 0x0115;
        //private const int WM_HSCROLL = 0x0114;
        //private const int SB_THUMBTRACK = 5;
        //private const int SB_ENDSCROLL = 8;

        //private const int skipMsgCount = 5;
        //private int currentMsgCount;
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL)
        //    {

        //        var nfy = m.WParam.ToInt32() & 0xFFFF;
        //        if (nfy == SB_THUMBTRACK)
        //        {
        //            currentMsgCount++;
        //            if (currentMsgCount % skipMsgCount == 0)
        //                base.WndProc(ref m);
        //            return;
        //        }
        //        if (nfy == SB_ENDSCROLL)
        //            currentMsgCount = 0;

        //        base.WndProc(ref m);
        //    }
        //    else
        //        base.WndProc(ref m);
        //}

        //public TreeViewNF()
        //{
        //    //Activate double buffering
        //    this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        //    //Enable the OnNotifyMessage event so we get a chance to filter out 
        //    // Windows messages before they get to the form's WndProc
        //    this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        //}

        //protected override void OnNotifyMessage(Message m)
        //{
        //    //Filter out the WM_ERASEBKGND message
        //    if (m.Msg != 0x14)
        //    {
        //        base.OnNotifyMessage(m);
        //    }
        //}
    }
}
