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
using System.Reflection;

namespace App4.ViewModels
{
	public class AddPageViewModel : ViewModelBase
	{

		#region Private variables

		private IEmployeesActions _repo;

		#endregion

		private Employee _selected;

		public Employee SelectedEmployee { get => _selected;
			set { Set(ref _selected, value, true, nameof(SelectedEmployee)); }
		}
		void Validate(IValidatableModel user)
		{
			Validator.ValidateEmployee(user as Employee);
		}

		public void AddDataToDatabase2()
		{
			//SelectedEmployee.Validator = e => Validate(e);
			SelectedEmployee.Validate();
			if (SelectedEmployee.IsValid)
			{
				_repo.AddEmployee(SelectedEmployee);
				ClearValues();
				//SelectedEmployee = GetEmptyEmployee();
			}
			else
			{
				;
			}

		}

		
		private void ClearValues()
		{
			SelectedEmployee.Name = null;
			SelectedEmployee.Surname = null;
			SelectedEmployee.Email = null;
			SelectedEmployee.IsHired = null;
			SelectedEmployee.Salary = null;

		}
		

		private Employee GetEmptyEmployee ()
		{
			Employee newEmployee = (Employee)SimpleIoc.Default.GetInstanceWithoutCaching<IEmployee>();
			newEmployee.Validator = e => Validate(e);
			return newEmployee;
		}

		public AddPageViewModel(IEmployeesActions repo)
		{
			_repo = repo;
			_selected = GetEmptyEmployee();
			_selected.Validate();
		}


	}
}
