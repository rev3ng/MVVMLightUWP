using System;
using System.Collections.ObjectModel;

namespace App4.Models
{
	class FakeEmployeeRepository : IEmployeesActions
	{
		private static readonly ObservableCollection<IEmployee> Employees = new ObservableCollection<IEmployee>();

		public ObservableCollection<IEmployee> GetAllEmployees()
		{
			return Employees;
		}

		public void AddEmployee(IEmployee employee)
		{
			Employees.Add(employee);
		}

		public void EditEmployee(IEmployee sourceEmployee, IEmployee destEmployee)
		{
			throw new NotImplementedException();
		}
	}
}
