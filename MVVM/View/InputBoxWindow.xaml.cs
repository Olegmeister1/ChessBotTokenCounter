using System;
using System.Windows;
using ChessBotTokenCounter.MVVM.ViewModel;

namespace ChessBotTokenCounter.MVVM.View;

public partial class InputBoxWindow : Window
{
    public InputBoxWindow()
    {
        InitializeComponent();
        DataContext = new InputBoxViewModel();

        var viewModel = (InputBoxViewModel)DataContext;
        viewModel.OnCloseRequested += ViewModel_OnCloseRequested;
    }

    private void ViewModel_OnCloseRequested(object? sender, EventArgs e)
    {
        this.Close();
    }
}
