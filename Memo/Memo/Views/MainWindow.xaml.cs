using System.Windows;
using System.Windows.Input;

namespace Memo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Events
            /**
             * 不涉及业务逻辑
             * 不需要使用 MVVM 模式进行绑定事件
             */
            btnMin.Click += BtnMin_Click;

            btnMax.Click += (sender, e) =>
            {

                this.WindowState = (this.WindowState == WindowState.Maximized)
                ? WindowState.Normal : WindowState.Maximized;
            };

            btnClose.Click += (sender, e) =>
            {
                this.Close();
            };

            winColorZone.MouseMove += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            winColorZone.MouseDoubleClick += (sender, e) =>
            {
                this.WindowState = (this.WindowState == WindowState.Normal)
                ? WindowState.Maximized : WindowState.Normal;
            };

            menuBar.SelectionChanged += (sender, e) =>
            {
                drawerHost.IsLeftDrawerOpen = !drawerHost.IsLeftDrawerOpen;
            };

            #endregion
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
