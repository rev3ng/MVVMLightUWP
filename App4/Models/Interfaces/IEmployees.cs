using System;
using System.Collections.ObjectModel;
using App4.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace App4.Models
{
	/// <summary>
	/// Defines a Employee operations
	/// </summary>
	public interface IEmployeesActions
	{ 
		ObservableCollection<IEmployee> GetAllEmployees();
		void AddEmployee(IEmployee employee);
		void EditEmployee(IEmployee sourceEmployee, IEmployee destEmployee);
		IEmployee CloneEmployee(IEmployee sourceEmployee);
	}

	public interface IEmployee 
	{
		int Id { get; set; }
		string Name { get; set; }
		decimal? Salary { get; set; }
		bool? IsHired { get; set; }
		string Surname { get; set; }
		string Email { get; set; }

		IAddress Address { get; set; }
	}
}
