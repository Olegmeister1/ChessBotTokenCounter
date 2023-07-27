using ChessBotTokenCounter.Core;
using ChessBotTokenCounter.Helper;
using ChessBotTokenCounter.Settings;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace ChessBotTokenCounter.MVVM.View;

public class MainViewModel : Core.ViewModel
{
    public MainViewModel()
    {
        ChangeFilePathCommand = new RelayCommand(ChangeFilePathExecute, (o) => true);

        UpdateTokenCounter();
        SetFileWatcher();
    }

    #region Properties

    private FileSystemWatcher? fileWatcher;

    private int _currentToken;
    public int CurrentToken
    {
        get { return _currentToken; }
        set {
            if(_currentToken != value)
            {
                PreviousToken = CurrentToken;
                _currentToken = value;
                OnPropertyChanged();
            }
        }
    }

    private int? _previousToken;
    public int? PreviousToken
    {
        get { return _previousToken; }
        set {
            _previousToken = value;
            OnPropertyChanged();
        }
    }
    #endregion


    #region Methods

    private void SetFileWatcher()
    {
        string filePath = SettingsHandler.GetFilePath();
        if(filePath is null || !File.Exists(filePath))
        {
            return;
        }

        //The file watcher detects changes in the MyBot.cs file
        fileWatcher = new FileSystemWatcher();

        fileWatcher.Path = Path.GetDirectoryName(filePath)!;

        //One might not have file extensions enabled
        string filter = Path.GetFileNameWithoutExtension(filePath) + "*";
        fileWatcher.Filter = filter;

        //Id really like to know how this is not 'NotifyFilters.LastWrite'
        fileWatcher.NotifyFilter = NotifyFilters.LastAccess;
        fileWatcher.Changed += OnFileChanged;
        fileWatcher.EnableRaisingEvents = true;
    }

    private void UpdateTokenCounter()
    {
        string filePath = SettingsHandler.GetFilePath();
        if(!File.Exists(filePath))
        {
            MessageBox.Show("Please set a valid file path", "", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        string code = FileReader.ReadFile(filePath);

        if(!(code == string.Empty))
        {
            CurrentToken = TokenCounter.CountTokens(code);
        }

        //If there is no previous TokenCount, for example because the application was just started
        if(PreviousToken == 0)
        {
            PreviousToken = null;
        }
    }
    #endregion


    #region Commands

    public RelayCommand? ChangeFilePathCommand { get; set; }
    private void ChangeFilePathExecute(object parameter)
    {
        var inputBox = new InputBoxWindow();
        inputBox.ShowDialog();
        SetFileWatcher();
        UpdateTokenCounter();
    }

    public void OnWindowClosing(object? sender, CancelEventArgs e)
    {
        if(fileWatcher is not null)
        {
            fileWatcher.Dispose();
        }
    }

    private void OnFileChanged(object sender, FileSystemEventArgs e)
    {
        UpdateTokenCounter();
    }

    #endregion





}
