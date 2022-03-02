using DipaulTestTask.ViewModels.Base;

namespace DipaulTestTask.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Главное окно программы";
        public string Title 
        { 
            get => _Title; 
            set => Set(ref _Title, value); 
        }

    }
}
