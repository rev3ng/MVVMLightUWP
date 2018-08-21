using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace App4.Models
{
	/// <summary>
	/// Defines a Employee operations
	/// </summary>
	public interface IEmployeesActions
	{ 
		ObservableCollection<Employee> GetAllEmployees();
		void AddEmployee(Employee employee);
		void EditEmployee(Employee sourceEmployee, Employee destEmployee);
	}

	public interface IEmployee
	{
		int Id { get; set; }
		string Name { get; set; }
		decimal? Salary { get; set; }
		bool IsHired { get; set; }
		string Surname { get; set; }
	}
}
