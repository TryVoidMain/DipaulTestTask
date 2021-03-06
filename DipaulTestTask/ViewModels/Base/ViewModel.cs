using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DipaulTestTask.ViewModels.Base
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual void Set<T>(
            ref T field, T value, [CallerMemberName] string PropertyName = "")
        {
            if (Equals(field, value))
                return;
            field = value;
            OnPropertyChanged(PropertyName);
        }
                
    }
}
