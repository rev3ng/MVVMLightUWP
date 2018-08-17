using System;
using System.Collections.ObjectModel;

namespace App4.Models
{
	class FakeEmployeeRepository : IEmployeesActions
	{
		private static readonly ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

		public ObservableCollection<Employee> GetAllEmployees()
		{
			return Employees;
		}

		public void AddEmployee(Employee employee)
		{
			Employees.Add(employee);
		}

		public void EditEmployee(Employee sourceEmployee, Employee destEmployee)
		{
			throw new NotImplementedException();
		}
	}
}
