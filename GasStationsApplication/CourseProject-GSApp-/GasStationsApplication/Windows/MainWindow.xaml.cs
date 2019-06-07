using CefSharp.Wpf;
using GasStationsApplication.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

namespace GasStationsApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isJournalDelete = false;
        private bool isLastBackEntryDelete;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(App._MainPage);
        }

        private void GSAround_Click(object sender, RoutedEventArgs e)
        {
            NavigateFrameToPage(App._GSAroundPage);
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            NavigateFrameToPage(App._MainPage);
        }

        private void TruckButton_Click(object sender, RoutedEventArgs e)
        {
            var browser = new ChromiumWebBrowser();
            var win = (App.Current as App).GetNewWindow(browser);
            browser.Address = "https://evakuator-minsk.by/";
            win.Show();
        }

        private void ListGSButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateFrameToPage(App._ListOfGSPage);
        }

        private void NavigateFrameToPage(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateFrameToPage(App._AboutPage);
        }

        private void MainFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            
            if (isJournalDelete)
            {
                while (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
                isJournalDelete = false;

                MainFrame.NavigationService.Navigate(App._MainPage);
                isLastBackEntryDelete = true;
            }
            else if (isLastBackEntryDelete)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                    isLastBackEntryDelete = false;
                }
            }
        }

        #region TitleButtons

        private void WinTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MaximiseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                MaximiseButton.Visibility = Visibility.Hidden;
                FromMaximiseButton.Visibility = Visibility.Visible;
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                MaximiseButton.Visibility = Visibility.Visible;
                FromMaximiseButton.Visibility = Visibility.Hidden;
                this.WindowState = WindowState.Normal;
            }
        }

        private void MinimiseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion

        #region DragSize

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

        private void Side_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (this != null && this.WindowState == WindowState.Normal)
                {
                    Border rect = (Border)sender;
                    switch (rect.Name)
                    {
                        case "TopSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.North);
                                break;
                            }
                        case "BottomSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.South);
                                break;
                            }
                        case "LeftSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.West);
                                break;
                            }
                        case "RightSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.East);
                                break;
                            }
                        case "TopRightSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.NorthEast);
                                break;
                            }
                        case "TopLeftSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.NorthWest);
                                break;
                            }
                        case "BottomLeftSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.SouthWest);
                                break;
                            }
                        case "BottomRightSide":
                            {
                                DragSize(GetWindowHandle(this), SizingAction.SouthEast);
                                break;
                            }
                    }
                }
            }
        }

        #endregion
    }
}
