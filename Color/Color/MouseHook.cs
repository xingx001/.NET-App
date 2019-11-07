using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Color
{
    /// <summary>
    /// Win32 Api鼠标钩子
    /// </summary>
    /// <remarks>
    /// @author zhangyp
    /// @since  19-04-01
    /// </remarks>
    public class MouseHook
    {
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        private Point point;
        private Point Point
        {
            get { return point; }
            set
            {
                if (point == value)
                    return;
                point = value;
                MouseMoveEvent?.Invoke(this, new MouseEventArgs(MouseButtons.Left, 0, point.X, point.Y, 0));
            }
        }

        private int hHook;
        public const int WH_MOUSE_LL = 14;
        public HookProc hProc;
        public MouseHook()
        {
            this.Point = new Point();
        }
        public int SetHook()
        {
            hProc = new HookProc(MouseHookProc);
            hHook = SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
            return hHook;
        }
        public void UnHook()
        {
            UnhookWindowsHookEx(hHook);
        }
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
            if (nCode < 0)
            {
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                this.Point = new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
        //委托+事件（把钩到的消息封装为事件，由调用者处理）
        public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
        public event MouseMoveHandler MouseMoveEvent;

    }

    [StructLayout(LayoutKind.Sequential)]
    public class POINT
    {
        public int x;
        public int y;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class MouseHookStruct
    {
        public POINT pt;
        public int hwnd;
        public int wHitTestCode;
        public int dwExtraInfo;
    }
}
