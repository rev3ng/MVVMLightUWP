using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using App4.Models;
using App4.Services.Validation;
using App4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace App4.ViewModels
{
	public class AddPageViewModel : ValidationBase
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


		#endregion


		protected override void ValidateSelf()
		{
			if (string.IsNullOrWhiteSpace(this._name))
			{
				this.ValidationErrors["Name"] = "Name is required.";
			}

			if (string.IsNullOrWhiteSpace(this._surname))
			{
				this.ValidationErrors["Surname"] = "Surname is required.";
			}
		}



		public void AddDataToDatabase()
		{
			
			Employee newEmployee = (Employee) SimpleIoc.Default.GetInstanceWithoutCaching<IEmployee>();
			
		
			newEmployee.Name = Name;
			newEmployee.Surname = Surname;
			newEmployee.Salary = newEmployee.SalaryConverter(Salary);
			newEmployee.Email = Email;
			newEmployee.Id = 0;
			newEmployee.IsHired = true;

			newEmployee.Validate();

			_repo.AddEmployee(newEmployee);
			Validate();
			//this.ValidationErrors[]
			//ClearValues();

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
