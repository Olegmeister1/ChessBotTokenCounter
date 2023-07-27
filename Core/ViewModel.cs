using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ChessBotTokenCounter.Core;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnCanExecuteChanged()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
