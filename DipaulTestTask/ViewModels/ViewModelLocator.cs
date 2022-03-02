using Microsoft.Extensions.DependencyInjection;

namespace DipaulTestTask.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services
            .GetRequiredService<MainWindowViewModel>();
    }
}
