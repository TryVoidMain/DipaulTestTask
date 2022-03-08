using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

using DipaulTestTask.Models;


namespace DipaulTestTask.Views
{

    public partial class EmployeesEditDialog : Window
    {
        public EmployeesEditDialog()
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
            ref string name,
            ref Position pos)
        {
            var window = new EmployeesEditDialog
            {
                Title = title,
                EmployeeId = { Text = id.ToString() },
                EmployeeName = { Text = name },
                EmployeePos = { SelectedItem = pos },

                Owner = Application
                .Current
                .Windows
                .Cast<Window>()
                .FirstOrDefault(window => window.IsActive)
            };

            if (window.ShowDialog() != true) return false;

            id = int.Parse(window.EmployeeId.Text);
            name = window.EmployeeName.Text;

            return true;
        }

        public static bool Create(
            out int id,
            out string name,
            out Position pos)
        {
            name = null;
            id = 0;
            pos = Position.Developer;

            return ShowDialog(
                "Создать компанию",
                ref id,
                ref name,
                ref pos);
        }
    }
}
