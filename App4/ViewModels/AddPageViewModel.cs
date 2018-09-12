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
using App4.Services;
using Template10.Interfaces.Validation;
using System.Reflection;
using App4.Models.Interfaces;
using Template10.Validation;

namespace App4.ViewModels
{
	public class AddPageViewModel : ViewModelBase
	{

		#region Private variables

		private IEmployeesActions _repo;

		#endregion

		private Employee _selected;
		private Address _address;

		public Address SelectedAddress
		{
			get => _address;
			set { Set(ref _address, value, true, nameof(SelectedAddress)); }
		}

		public Employee SelectedEmployee { get => _selected;
			set { Set(ref _selected, value, true, nameof(SelectedEmployee)); }
		}
		void ValidateEmployee(IValidatableModel user)
		{
			EmplyeeValidator.ValidateEmployee(user as Employee);
		}

		void ValidateAddress(IValidatableModel addres)
		{
			AddressValidator.ValidateEmployee(addres as Address);
		}

		public void AddDataToDatabase2()
		{
			//SelectedEmployee.Validator = e => Validate(e);
			SelectedEmployee.Validate();
			SelectedAddress.Validate();
			if (SelectedEmployee.IsValid && SelectedAddress.IsValid)
			{
				SelectedEmployee.CreationDateTime = DateTime.Now;
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
			SelectedEmployee.CreationDateTime = null;

		}
		

		private Employee GetEmptyEmployee (out Address address)
		{
			Employee newEmployee = (Employee)SimpleIoc.Default.GetInstanceWithoutCaching<IEmployee>();
			newEmployee.Validator = e => ValidateEmployee(e);

			address = (Address)SimpleIoc.Default.GetInstanceWithoutCaching<IAddress>();
			address.Validator = e => ValidateAddress(e);

			return newEmployee;
		}

		public AddPageViewModel(IEmployeesActions repo)
		{
			_repo = repo;
			_selected = GetEmptyEmployee(out _address);
			_selected.Validate();
		}


	}
}
