using System.Windows;
using System.Linq;
using DipaulTestTask.Infrastucture.Commands.Base;

namespace DipaulTestTask.Infrastucture.Commands
{
    class CloseWIndowCommand : Command
    {
        protected override void Execute(object p)
        {
            var window = p as Window;
            if (window is null)
                window = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(w => w.IsFocused);

            if (window is null)
                window = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(w => w.IsActive);
            
            window?.Close();
        }
    }
}
