using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        const int WM_SYSCOMMAND = 0x112;
        const int SC_SIZE = 0xF000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static IntPtr GetWindowHandle(Window window)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            return helper.Handle;
        }

        void DragSize(IntPtr handle, SizingAction sizingAction)
        {
            SendMessage(handle, WM_SYSCOMMAND, (IntPtr)(SC_SIZE + sizingAction), IntPtr.Zero);
            SendMessage(handle, 514, IntPtr.Zero, IntPtr.Zero);
        }

        public enum SizingAction
        {
            North = 3,
            South = 6,
            East = 2,
            West = 1,
            NorthEast = 5,
            NorthWest = 4,
            SouthEast = 8,
            SouthWest = 7
        }

        private Window GetCurrWin()
        {
            ContentControl contentControl = (ContentControl)userCtrl.Parent;
            Grid BaseGrid = (Grid)contentControl.Parent;
            return (Window)BaseGrid.Parent;
        }

        private void X_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window BaseWin = GetCurrWin();
            BaseWin.Close();
        }

        private void Max_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window BaseWin = GetCurrWin();
            if (BaseWin.WindowState == WindowState.Normal)
            {
                Maxed.Visibility = Visibility.Visible;
                UnMaxed.Visibility = Visibility.Hidden;
                BaseWin.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                BaseWin.WindowState = WindowState.Maximized;
            }
            else
            {
                Maxed.Visibility = Visibility.Hidden;
                UnMaxed.Visibility = Visibility.Visible;
                BaseWin.WindowState = WindowState.Normal;
            }
        }

        private void Min_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window BaseWin = GetCurrWin();
            BaseWin.WindowState = WindowState.Minimized;
        }

        private void Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window BaseWin = GetCurrWin();
            BaseWin.DragMove();
        }

        private void rectSizeNorthWest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.NorthWest);
                }
            }
        }

        private void rectSizeNorthEast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.NorthEast);
                }
            }
        }

        private void rectSizeSourthWest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.SouthWest);
                }
            }
        }

        private void rectSizeSourthEast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.SouthEast);
                }
            }
        }

        private void rectSizeWest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.West);
                }
            }
        }

        private void rectSizeEast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.East);
                }
            }
        }

        private void rectSizeNorth_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.North);
                }
            }
        }

        private void rectSizeSourth_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window BaseWin = GetCurrWin();
                if (BaseWin != null && BaseWin.WindowState == WindowState.Normal)
                {
                    DragSize(GetWindowHandle(BaseWin), SizingAction.South);
                }
            }
        }
    }
}
