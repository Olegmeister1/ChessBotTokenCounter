using ChessBotTokenCounter.Core;
using ChessBotTokenCounter.Settings;
using System;
using System.IO;
using System.Windows;

namespace ChessBotTokenCounter.MVVM.ViewModel;

public class InputBoxViewModel : Core.ViewModel
{
    public InputBoxViewModel() 
    {
        ChangeFilePathCommand = new RelayCommand(ChangeFilePathExecute, (o) => true);

        FilePath = SettingsHandler.GetFilePath();
    }


    public event EventHandler? OnCloseRequested;

    private string _filePath = string.Empty;
    public string FilePath
    {
        get { return _filePath; }
        set {
            _filePath = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand ChangeFilePathCommand { get; set; }
    private void ChangeFilePathExecute(object parameter)
    {
        if(!File.Exists(FilePath))
        {
            MessageBox.Show(
                "This file does not exist on your computer." + Environment.NewLine +
                "Your path should have the following format:" + Environment.NewLine +
                @"D:\X\Chess-Challenge\Chess-Challenge\src\My Bot\MyBot.cs", "",
                MessageBoxButton.OK, MessageBoxImage.Error);

        } else if(!FilePath.EndsWith(".cs"))
        {
            MessageBox.Show(
                "This Parser can only accepts C#-files (.cs)", "",
                MessageBoxButton.OK, MessageBoxImage.Error);

        } else
        {
            SettingsHandler.SetFilePath(FilePath);

            //Tell the window to close
            OnCloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }


    

}
