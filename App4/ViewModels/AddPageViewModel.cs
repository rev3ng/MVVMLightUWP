using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Controls;
using App4.Models;
using App4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using App4.Services.UserService;
using Template10.Interfaces.Validation;

namespace App4.ViewModels
{
	public class AddPageViewModel : ViewModelBase
	{

		#region Private variables

		private IEmployeesActions _repo;

		#endregion

		public  ObservableCollection<Employee> NewEmployees { get; } = new ObservableCollection<Employee>();

		private Employee _selected;

		public Employee SelectedEmployee { get => _selected;
			set { Set(ref _selected, value); }
		}
		public Employee newEmployee = (Employee)SimpleIoc.Default.GetInstanceWithoutCaching<IEmployee>();
		void Validate(IValidatableModel user)
		{
			Validator.ValidateEmployee(user as Employee);
		}

		/*public void AddDataToDatabase()
		{

			newEmployee.Validator = e => Validate(e);

			newEmployee.Name = Name;
			newEmployee.Surname = Surname;
			newEmployee.Salary = newEmployee.SalaryConverter(Salary);
			newEmployee.Email = Email;
			newEmployee.Id = 0;
			newEmployee.IsHired = true;

			newEmployee.Validate();
			
			_repo.AddEmployee(newEmployee);
			//this.ValidationErrors[]
			//ClearValues();

		}
		*/

		public void AddDataToDatabase2()
		{
			//SelectedEmployee.Validator = e => Validate(e);
			_repo.AddEmployee(SelectedEmployee);

		}

		/*
		private void ClearValues()
		{
			Name = null;
			Surname = null;
			Email = null;
			Salary = null;
			Id = null;
			IsHired = null;
		}
		*/

		public AddPageViewModel(IEmployeesActions repo)
		{
			_repo = repo;
			_selected = new Employee{Validator = e => Validate(e)};
		}


	}
}
