using System;
using GalaSoft.MvvmLight;
using Template10.Validation;

namespace App4.Models
{
	public class Employee : ValidatableModelBase, IEmployee
	{

		public int Id
		{
			get { return Read<int>(); }
			set { Write(value); }
		}

		public string Name
		{
			get { return Read<string>(); }
			set { Write(value); }
		}

		public string Surname
		{
			get { return Read<string>(); }
			set { Write(value); }
		}

		public decimal? Salary
		{
			get { return Read<decimal?>(); }
			set { Write(value); }
		}

		public bool? IsHired
		{
			get { return Read<bool?>(); }
			set { Write(value); }
		}

		public string Email
		{
			get { return Read<string>(); }
			set { Write(value); }
		}

		public decimal SalaryConverter(string val)
		{
			decimal.TryParse(val, out decimal result);
			return result;
		}

		public override string ToString()
		{
			return Name + " " + Salary.ToString();
		}

	}
}
