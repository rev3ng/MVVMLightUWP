using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Models;
using App4.Services.Validation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace App4.ViewModels
{
	public class AddPageViewModel : ViewModelBase
	{
		private string _title;
		private string _name;
		private decimal? _salary;
		private string _surname;
		private IEmployeesActions _repo;
		public string Title
		{

			get
			{
				if (_title != null)
				{
					return _title;
				}

				return String.Empty;
			}
			set
			{
				if (value != _title)
				{
					_title = value.Trim();
					RaisePropertyChanged(nameof(Title));
				}
			}
		}

		public string Name
		{

			get
			{
				if (_name != null)
				{
					return _name;
				}

				return String.Empty;
			}
			set
			{
				_name = value.Trim();
				RaisePropertyChanged(nameof(Name));
			}
		}

		public string Surname
		{

			get
			{
				if (_surname != null)
				{
					return _surname;
				}

				return String.Empty;
			}
			set
			{
				_surname = value.Trim();
				RaisePropertyChanged(nameof(Surname));
			}
		}

		public decimal? Salary
		{

			get
			{
				if (_salary != null)
				{
					return _salary;
				}

				return null;
			}
			set
			{
				_salary = value;
				RaisePropertyChanged(nameof(Salary));
			}
		}
	
		public void AddDataToDatabase()
		{
			var key = System.Guid.NewGuid().ToString();
			IEmployee newEmployee = SimpleIoc.Default.GetInstance<IEmployee>(key);
			SimpleIoc.Default.Unregister(key);

			newEmployee.Surname = Surname;
			newEmployee.Name = Name;
			newEmployee.Id = 0;
			newEmployee.Salary = Salary;

			ClearValues();

		}

		private void ClearValues()
		{
			Title = null;
			Surname = null;
			Name = null;
			Salary = null;
		}


		public AddPageViewModel(IEmployeesActions repo)
		{
			_repo = repo;
		}


	}
}
