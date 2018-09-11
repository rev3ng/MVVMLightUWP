using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;

namespace App4.Models
{
	class FakeEmployeeRepository : IEmployeesActions
	{
		private static readonly ObservableCollection<IEmployee> Employees = new ObservableCollection<IEmployee>();

		public ObservableCollection<IEmployee> GetAllEmployees()
		{
			return Employees;
		}

		public FakeEmployeeRepository()
		{
			for (int i = 0; i < 10; i++)
			{
				Employees.Add(new Employee{Name = $"{i}Name", Surname = $"{i}Surname", Salary = 1200M, Email = $"mail@mail + {i}", IsHired = true});
			}

			Employees.Add(new Employee { Name = $"1Name", Surname = $"1Surname", Salary = 1200M, Email = $"mail@mail", IsHired = true });
			Employees.Add(new Employee { Name = $"1Name", Surname = $"1Surname", Salary = 1200M, Email = $"mail@mail", IsHired = true });
			Employees.Add(new Employee { Name = $"1Name", Surname = $"1Surname", Salary = 1200M, Email = $"mail@mail", IsHired = true });
			Employees.Add(new Employee { Name = $"1Name", Surname = $"1Surname", Salary = 1200M, Email = $"mail@mail", IsHired = true });
			Employees.Add(new Employee { Name = $"1Name", Surname = $"1Surname", Salary = 1200M, Email = $"mail@mail", IsHired = true });
		}

		public void AddEmployee(IEmployee employee)
		{
			Employees.Add(CloneEmployee(employee));
		}

		public void EditEmployee(IEmployee sourceEmployee, IEmployee destEmployee)
		{
			throw new NotImplementedException();
		}

		public IEmployee CloneEmployee(IEmployee sourceEmployee)
		{
			var result = SimpleIoc.Default.GetInstanceWithoutCaching<IEmployee>();

			result.Name = sourceEmployee.Name;
			result.Email = sourceEmployee.Email;
			result.Id = sourceEmployee.Id;
			result.IsHired = sourceEmployee.IsHired;
			result.Salary = sourceEmployee.Salary;
			result.Surname = sourceEmployee.Surname;

			return result;
		}
	}
}
