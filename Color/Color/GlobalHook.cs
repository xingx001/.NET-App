using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Color
{
    /// <summary>
    /// Win32 Api 全局钩子
    /// </summary>
    /// <remarks>
    /// @author zhangyp
    /// @since  19-04-01
    /// 钩子(Hook)，是Windows消息处理机制的一个平台，应用程序可以在上面设置子程以监视指定窗口的某种消息，而且所监视的窗口可以是其他进程所创建的
    /// </remarks>
    public class GlobalHook
    {
        #region Win32
        /**
         * 钩子实际上是一个处理消息的程序段，通过系统调用，把它挂入系统。
         * 每当特定的消息发出，在没有到达目的窗口前，钩子程序就先捕获该消息，亦即钩子函数先得到控制权。
         * 这时钩子函数即可以加工处理（改变）该消息，也可以不作处理而继续传递该消息，还可以强制结束消息的传递。
         * 
         * 钩子链表：
         * 每一个Hook都有一个与之相关联的指针列表，称之为钩子链表，由系统来维护。
         * 这个列表的指针指向指定的，应用程序定义的，被Hook子程调用的**回调函数**，也就是该钩子的各个处理子程。
         * 当与指定的Hook类型关联的消息发生时，系统就把这个消息传递到Hook子程。 
         * 一些Hook子程可以只监视消息，或者修改消息，或者停止消息的前进，避免这些消息传递到下一个Hook子程或者目的窗口。
         * 最后安装的钩子放在链的开始， 而最早安装的钩子放在最后，也就是后加入的先获得控制权。
         * Windows 并不要求钩子子程的卸载顺序一定得和安装顺序相反。
         * 每当有一个钩子被卸载，Windows 便释放其占用的内存，并更新整个Hook链表。
         * 如果程序安装了钩子，但是在尚未卸载钩子之前就结束了，那么系统会自动为它做卸载钩子的操作。
         */

        /// <summary>
        /// 把一个应用程序定义的钩子子程安装到钩子链表中,SetWindowsHookEx函数总是在Hook链的开头安装Hook子程
        /// <para><remark>当指定类型的Hook监视的事件发生时，系统就调用与这个Hook关联的 Hook链的开头的Hook子程。
        /// 每一个Hook链中的Hook子程都决定是否把这个事件传递到下一个Hook子程。
        /// Hook子程传递事件到下一个 Hook子程需要调用CallNextHookEx函数。</remark></para>
        /// </summary>
        /// <param name="idHook">钩子类型</param>
        /// <param name="lpfn">回调函数地址</param>
        /// <param name="hInstance">实例句柄</param>
        /// <param name="threadId">线程ID</param>
        /// <returns>若此函数执行成功,则返回值就是该挂钩处理过程的句柄;若此函数执行失败,则返回值为NULL(0).若想获得更多错误信息,请调用GetLastError函数.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        /// <summary>
        /// 释放钩子
        /// </summary>
        /// <param name="idHook">要删除的钩子的句柄。这个参数是上一个函数SetWindowsHookEx的返回值.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);


        /// <summary>
        /// 可以将钩子信息传递到当前钩子链中的下一个子程，一个钩子程序可以调用这个函数之前或之后处理钩子信息。
        /// </summary>
        /// <param name="idHook">当前钩子的句柄</param>
        /// <param name="nCode">钩子代码; 就是给下一个钩子要交待的</param>
        /// <param name="wParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <param name="lParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        /// <summary>
        /// 将指定的虚拟键码和键盘状态翻译为相应的字符或字符串
        /// 由给定的键盘布局句柄标识的物理键盘布局和输入语言来翻译代码。
        /// <para><remark>若键盘布局中原先存放了一个死键，则提供给ToAscii函数的参数可能不足以翻译虚拟键码。</remark></para>
        /// </summary>
        /// <param name="uVirtKey">指定要翻译的虚拟键码</param>
        /// <param name="uScanCode">定义被翻译键的硬件扫描码。若该键处于up状态，则该值的最高位被设置</param>
        /// <param name="lpbKeyState">指向包含当前键盘状态的一个256字节数组。
        /// 数组的每个成员包含一个键的状态。
        /// 若某字节的最高位被设置，则该键处于down状态。
        /// 若最低位被设置，则表明该键被触发。
        /// 在此函数中，仅有capslock键的触发位是相关的。
        /// NumloCk和scroll loCk键的触发状态将被忽略。</param>
        /// <param name="lpwTransKey">指向接受翻译所得字符或字符串的缓冲区。</param>
        /// <param name="fuState">定义一个菜单是否处于激活状态。若一菜单是活动的，则该参数为1，否则为0。</param>
        /// <returns>返回值：若定义的键为死键，则返回值为负值。
        /// 否则，返回值应为如下的值：
        /// 0：对于当前键盘状态，所定义的虚拟键没有翻译。
        /// 1：一个字符被拷贝到缓冲区。
        /// 2：两个字符被拷贝到缓冲区。
        /// 当一个存储在键盘布局中的死键（重音或双音字符）无法与所定义的虚拟键形成一个单字符时，通常会返回该值。</returns>
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        /// <summary>
        /// 应用程序可以调用该函数来检取所有虚拟键的当前状态
        /// <para><remark>当键盘消息被从该线程的消息队列中移去时，虚拟键的状态发生改变。
        /// 当键盘消息被发送到该线程的消息队列中，或者，当键盘消息被发送到其他线程的消息队列或被从其他线程的消息队列中检取到时，虚拟键的状态不发生改变。
        /// </remark></para>
        /// </summary>
        /// <param name="pbKeyState">指向一个256字节的数组，数组用于接收每个虚拟键的状态。</param>
        /// <returns>若函数调用成功，则返回非0值。若函数调用不成功，则返回值为0。若要获得更多的错误信息，可以调用GetLastError函数。</returns>
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        /// <summary>
        /// 检索指定虚拟键的状态。
        /// 该状态指定此键是UP状态，DOWN状态，还是被触发的（开关每次按下此键时进行切换）。
        /// </summary>
        /// <param name="vKey">定义一虚拟键。
        /// 若要求的虚拟键是字母或数字（A～Z，a～z或0～9），nVirtKey必须被置为相应字符的ASCII码值，对于其他的键，nVirtKey必须是一虚拟键码。</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(int vKey);
        #endregion

        /// <summary>
        /// 钩子子程是一个应用程序定义的回调函数(CALLBACK Function)
        /// </summary>
        /// <param name="nCode">Hook代码,Hook子程使用这个参数来确定任务</param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        public const int WH_MOUSE_LL = 14;
        public const int WH_KEYBOARD_LL = 13;

        public const int WH_MOUSE = 7;
        public const int WH_KEYBOARD = 2;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_MBUTTONUP = 0x208;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_MBUTTONDBLCLK = 0x209;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        #region 虚拟密钥代码常量 SHIFT CAPITAL NUMLOCK CONTROL ALT
        public const byte VK_SHIFT = 0x10;
        public const byte VK_CAPITAL = 0x14;
        public const byte VK_NUMLOCK = 0x90;

        public const byte VK_LSHIFT = 0xA0;
        public const byte VK_RSHIFT = 0xA1;
        public const byte VK_LCONTROL = 0xA2;
        public const byte VK_RCONTROL = 0x3;
        public const byte VK_LALT = 0xA4;
        public const byte VK_RALT = 0xA5;
        #endregion

        public const byte LLKHF_ALTDOWN = 0x20;

        /// <summary>
        /// 是否设置钩子
        /// </summary>
        protected bool _isHooked;

        /// <summary>
        /// 钩子类型
        /// </summary>
        protected int _hookType;
        /// <summary>
        /// 钩子回调函数
        /// </summary>
        protected HookProc _hookProc;

        /// <summary>
        /// 返回的钩子句柄
        /// </summary>
        protected int _hHook;


        public GlobalHook()
        {
            Application.ApplicationExit += Application_ApplicationExit;
            //this.Point = new Point();
        }

        #region 设置钩子
        /// <summary>
        /// 设置钩子
        /// </summary>
        public void Hook()
        {
            if (!_isHooked && _hookType != 0)
            {
                // Make sure we keep a reference to this delegate!
                // If not, GC randomly collects it, and a NullReference exception is thrown
                _hookProc = new HookProc(HookCallbackProc);

                _hHook = SetWindowsHookEx(_hookType, _hookProc,
                    Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);

                // Were we able to sucessfully start hook?
                _isHooked = (_hHook != 0);
            }
        }
        #endregion

        #region 卸载钩子
        /// <summary>
        /// 卸载钩子
        /// </summary>
        public void UnHook()
        {
            if (_isHooked)
            {
                UnhookWindowsHookEx(_hHook);
                _isHooked = false;
            }
        } 
        #endregion

        /// <summary>
        /// 钩子回调虚方法，需重写
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected virtual int HookCallbackProc(int nCode, int wParam, IntPtr lParam)
        {

            // This method must be overriden by each extending hook
            return 0;
        }

        #region 应用程序退出
        /// <summary>
        /// 应用程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (_isHooked)
                this.UnHook();
        } 
        #endregion

        #region 鼠标钩子原代码
        //private Point point;
        //private Point Point
        //{
        //    get { return point; }
        //    set
        //    {
        //        if (point == value)
        //            return;
        //        point = value;
        //        MouseMoveEvent?.Invoke(this, new MouseEventArgs(MouseButtons.Left, 0, point.X, point.Y, 0));
        //    }
        //}

        //private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        //{
        //    MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
        //    if (nCode < 0)
        //    {
        //        return CallNextHookEx(hHook, nCode, wParam, lParam);
        //    }
        //    else
        //    {
        //        this.Point = new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);
        //        return CallNextHookEx(hHook, nCode, wParam, lParam);
        //    }
        //}
        ////委托+事件（把钩到的消息封装为事件，由调用者处理）
        //public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
        //public event MouseMoveHandler MouseMoveEvent; 
        #endregion

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

    [StructLayout(LayoutKind.Sequential)]
    public class MouseLLHookStruct
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class KeyboardHookStruct
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }

}
