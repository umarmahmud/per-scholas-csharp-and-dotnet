using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace RemoteTypist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public delegate IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool Handled);

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += Window_Loaded;

        }

        public IntPtr WndPrc(IntPtr hwdn, int msg, IntPtr wParam, IntPtr lParam, ref bool Handled)
        {

            return IntPtr.Zero;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hWnd = FindWindow("Notepad", null);

            var child = FindWindowEx(hWnd, new IntPtr(0), "Edit", null);

            if (hWnd.ToInt32() == 0)
            {
                Status.Content = "Unable to locate Notepad";
            }
            else
            {
                Status.Content = "Notepad located. Start typing!";
            }

            // create HwndSource instance
            HwndSource a = (HwndSource)HwndSource.FromVisual(tb);

            HwndSourceHook cb = WndPrc;

            // hook into textbox's windows procedure
            a.AddHook(WndPrc);

            // send messages to notepad
            Console.WriteLine(hWnd);
            Console.WriteLine(child);
            Console.WriteLine(SendMessage(child, 0x0100, 0, tb.Text) );
            SendMessage(child, 0x000C, 0, tb.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hWnd = FindWindow("Notepad", null);

            var child = FindWindowEx(hWnd, new IntPtr(0), "Edit", null);

            SendMessage(child, 0x000C, 0, tb.Text);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var hWnd = FindWindow("Notepad", null);
            var child = FindWindowEx(hWnd, new IntPtr(0), "Edit", null);
            if (hWnd.ToInt32() == 0)
            {
                Status.Content = "Unable to locate Notepad";
            }
            else
            {
                Status.Content = "Notepad located. Start typing!";
            }

            Console.WriteLine(hWnd);
            Console.WriteLine(child);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

    }
}
