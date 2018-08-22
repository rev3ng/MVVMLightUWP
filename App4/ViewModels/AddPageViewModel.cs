using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Models;
using App4.Services.Validation;
using App4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace App4.ViewModels
{
	public class AddPageViewModel : ViewModelBase
	{

		#region Private variables

		private IEmployeesActions _repo;
		private string _id;
		private string _name;
		private string _salary;
		private bool? _isHired;
		private string _surname;
		private string _email;

		#endregion


		#region Properties
		public string Id
		{
			get => _id;
			set { Set(() => Id, ref _id, value); }
		}

		public string Name
		{
			get => _name;
			set { Set(() => Name, ref _name, value); }
		}

		public string Surname
		{
			get => _surname;
			set { Set(() => Surname, ref _surname, value); }
		}

		public string Salary
		{
			get => _salary;
			set { Set(() => Salary, ref _salary, value); }
		}

		public bool? IsHired
		{
			get => _isHired;
			set { Set(() => IsHired, ref _isHired, value); }
		}

		public string Email
		{
			get => _email;
			set { Set(() => Email, ref _email, value); }
		}

		public ValidationErrors ValidationErrors { get; private set; }

#endregion


		public void AddDataToDatabase()
		{
			

			var key = System.Guid.NewGuid().ToString();
			IEmployee newEmployee = SimpleIoc.Default.GetInstance<IEmployee>(key);
			SimpleIoc.Default.Unregister(key);

			((ValidationBase) newEmployee).Validate();
			ValidationErrors = ((ValidationBase) newEmployee).ValidationErrors;

			newEmployee.Name = Name;
			newEmployee.Surname = Surname;
			newEmployee.Salary = newEmployee.SalaryConverter(Salary);
			newEmployee.Email = Email;
			newEmployee.Id = 0;
			newEmployee.IsHired = true;

			_repo.AddEmployee(newEmployee);

			ClearValues();

		}

		private void ClearValues()
		{
			Name = null;
			Surname = null;
			Email = null;
			Salary = null;
			Id = null;
			IsHired = null;
		}


		public AddPageViewModel(IEmployeesActions repo)
		{
			_repo = repo;
		}


	}
}
