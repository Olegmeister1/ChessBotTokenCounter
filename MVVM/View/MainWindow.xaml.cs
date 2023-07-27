using ChessBotTokenCounter.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessBotTokenCounter.MVVM.View;
using ChessBotTokenCounter.MVVM.ViewModel;
using ChessBotTokenCounter.Core;

namespace ChessBotTokenCounter.MVVM.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel();
            Closing += viewModel.OnWindowClosing;

            DataContext = viewModel;
        }

        /// <summary>
        /// This makes it possible to drag and drop the Window everywhere.
        /// Comment out if not desired
        /// </summary>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }

}
