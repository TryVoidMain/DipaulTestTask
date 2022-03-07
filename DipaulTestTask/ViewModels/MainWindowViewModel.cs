using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using DipaulTestTask.ViewModels.Base;
using DipaulTestTask.Models;
using DipaulTestTask.Infrastucture.Commands;
using DipaulTestTask.Interfaces;

namespace DipaulTestTask.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly ICompanyStorage _companiesStorage;

        public MainWindowViewModel(ICompanyStorage companyStorage)
        {
           _companiesStorage = companyStorage;
        }

        private string _Title = "Главное окно программы";
        public string Title 
        { 
            get => _Title; 
            set => Set(ref _Title, value); 
        }

        private ObservableCollection<Company> _Companies;
        public ObservableCollection<Company> Companies
        {
            get => _Companies;
            set => Set(ref _Companies, value);
        }

        private ObservableCollection<Employee> _Employees;
        public ObservableCollection<Employee> Employees
        {
            get => _Employees;
            set => Set(ref _Employees, value);
        }

        private ICommand _LoadDataCommand;
        public ICommand LoadDataCommand => _LoadDataCommand 
            ??= new LambdaCommand(OnLoadDataCommandExecuted);

        private void OnLoadDataCommandExecuted(object p)
        {            
            _companiesStorage.Load();
            Companies = new ObservableCollection<Company>(_companiesStorage.Items);
            Employees = new ObservableCollection<Employee>();
        }
        private ICommand _SaveDataCommand;
        public ICommand SaveDataCommand => _SaveDataCommand
            ??= new LambdaCommand(OnSaveDataCommandExecuted);

        private void OnSaveDataCommandExecuted(object p)
        {
            _companiesStorage.SaveChanges();
        }

        private Company _SelectedCompany;
        public Company SelectedCompany
        {
            get => _SelectedCompany;
            set 
            { 
                Set(ref _SelectedCompany, value);
                Employees.Clear();
                foreach(Employee employee in _SelectedCompany.Employees)
                {
                    Employees.Add(employee);
                }
            }
        }

        private Employee _SelectedEmployee;
        public Employee SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        private void OnEmployeePositionSourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (e.Property.Name == SelectedEmployee.Pos.ToString())
                return;
            SelectedEmployee.Pos = (Position)Enum.Parse(typeof(Position), e.Property.Name);
        }
    }
}
