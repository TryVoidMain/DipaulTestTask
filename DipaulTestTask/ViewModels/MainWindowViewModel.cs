using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;

using DipaulTestTask.ViewModels.Base;
using DipaulTestTask.Models;
using DipaulTestTask.Infrastucture.Commands;
using DipaulTestTask.Interfaces;
using DipaulTestTask.Views;

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

        private void OnEmployeePositionSourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (e.Property.Name == SelectedEmployee.Pos.ToString())
                return;
            SelectedEmployee.Pos = (Position)Enum.Parse(typeof(Position), e.Property.Name);
        }

        #region Поля и свойства для доступа к данным

        #region Компании

        private ObservableCollection<Company> _Companies;
        public ObservableCollection<Company> Companies
        {
            get => _Companies;
            set => Set(ref _Companies, value);
        }

        #endregion

        #region Сотрудники

        private ObservableCollection<Employee> _Employees;
        public ObservableCollection<Employee> Employees
        {
            get => _Employees;
            set => Set(ref _Employees, value);
        }

        #endregion

        #region Выбранная компания

        private Company _SelectedCompany;
        public Company SelectedCompany
        {
            get => _SelectedCompany;
            set 
            {
                Set(ref _SelectedCompany, value);
                Employees.Clear();
                if (_SelectedCompany is null) return;
                foreach (Employee employee in _SelectedCompany.Employees)
                    Employees?.Add(employee);
            }
        }

        #endregion

        #region Выбранный сотрудник

        private Employee _SelectedEmployee;
        public Employee SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        #endregion

        #endregion

        #region Комманды

        #region Загрузить

        private ICommand _LoadDataCommand;
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommand(OnLoadDataCommandExecuted);

        private void OnLoadDataCommandExecuted(object p)
        {            
            _companiesStorage.Load();
            Companies = new ObservableCollection<Company>(_companiesStorage.Items);
            Employees = new ObservableCollection<Employee>();
            _SelectedCompany = Companies[0];
        }

        #endregion

        #region Сохранить

        private ICommand _SaveDataCommand;
        public ICommand SaveDataCommand => _SaveDataCommand
            ??= new LambdaCommand(OnSaveDataCommandExecuted);

        private void OnSaveDataCommandExecuted(object p)
        {
            _companiesStorage.SaveChanges();
        }

        #endregion

        #region Добавить компанию

        private ICommand _CreateCompanyCommand;
        public ICommand CreateCompanyCommand => _CreateCompanyCommand
            ??= new LambdaCommand(OnCreateCompanyCommandExecuted);

        private void OnCreateCompanyCommandExecuted(object p)
        {
            if (!CompanyEditDialog.Create(
                out var id,
                out var name))
                return;

            var company = new Company
            {
                Id = Companies.DefaultIfEmpty().Max(s => s?.Id ?? 0) + 1,
                Name = name,
                Employees = new List<Employee>()
            };

            _companiesStorage.Items.Add(company);
            Companies.Add(company);
            _companiesStorage.SaveChanges();
        }

        #endregion

        #region Добавить сотрудника

        private ICommand _CreateEmployeeCommand;

        public ICommand CreateEmployeeCommand => _CreateEmployeeCommand
            ??= new LambdaCommand(OnCreateEmployeeCommandExecuted);

        public void OnCreateEmployeeCommandExecuted(object p)
        {
            if (!EmployeesEditDialog.Create(
                out var id,
                out var name,
                out var pos))
                return;

            var employee = new Employee
            {
                Id = id,
                Name = name,
                Pos = pos
            };

            SelectedCompany.Employees.Add(employee);
            Employees.Add(employee);
            _companiesStorage.SaveChanges();
        }

        #endregion

        #region Редактировать

        // Этот функционал скорее не нужен, чем обратное, пусть пока лежит здесь

        /*        private ICommand _EditCompanyCommand;
                public ICommand EditCompanyCommand => _EditCompanyCommand
                    ??= new LambdaCommand(OnEditCompanyCommandExecuted, 
                        CanEditCompanyCommandExecuted);

                private bool CanEditCompanyCommandExecuted(object p) => p is Company;
                private void OnEditCompanyCommandExecuted(object p)
                {
                    if (!(p is Company company)) return;

                    var id = company.Id;
                    var name = company.Name;

                    if (!CompanyEditDialog.ShowDialog(
                        "Редактирование компании",
                        ref id,
                        ref name))
                        return;

                    company.Id = id;
                    company.Name = name;
                }*/

        #endregion

        #region Удалить

        private ICommand _DeleteCompanyCommand;
        public ICommand DeleteCompanyCommand => _DeleteCompanyCommand
            ??= new LambdaCommand(OnDeleteCompanyCommandExecuted, 
                OnDeleteCompanyCommandCanExecute);

        private bool OnDeleteCompanyCommandCanExecute(object p) => p is Company;
        private void OnDeleteCompanyCommandExecuted(object p)
        {
            if (!(p is Company company)) return;

            Companies.Remove(company);
        }

        #endregion

        #endregion
    }
}
