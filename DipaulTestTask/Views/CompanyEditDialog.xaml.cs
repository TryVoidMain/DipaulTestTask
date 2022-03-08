using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;


namespace DipaulTestTask.Views
{
    public partial class CompanyEditDialog : Window
    {
        public CompanyEditDialog()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = !((Button)e.OriginalSource).IsCancel;
            Close();
        }

        public static bool ShowDialog(
            string title, 
            ref int id,
            ref string name)
        {
            var window = new CompanyEditDialog
            {
                Title = title,
                CompanyId = { Text = id.ToString() },
                CompanyName = { Text = name },
                
                Owner=Application
                .Current
                .Windows
                .Cast<Window>()
                .FirstOrDefault(window => window.IsActive)
            };

            if (window.ShowDialog() != true) return false;

            id = int.Parse(window.CompanyId.Text);
            name = window.CompanyName.Text;

            return true;
        }

        public static bool Create(
            out int id,
            out string name)
        {
            name = null;
            id = 0;

            return ShowDialog(
                "Создать компанию",
                ref id,
                ref name);
        }
    }
}
