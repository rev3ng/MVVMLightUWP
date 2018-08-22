using System;
using App4.Services.Validation;
using GalaSoft.MvvmLight;

namespace App4.Models
{
	public class Employee : ValidationBase, IEmployee
	{
		private int _id;
		private string _name;
		private decimal? _salary;
		private bool _isHired;
		private string _surname;
		private string _email;

		public int Id
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

		public decimal? Salary
		{
			get => _salary;
			set { Set(() => Salary, ref _salary, value); }
		}

		public bool IsHired
		{
			get => _isHired;
			set { Set(() => IsHired, ref _isHired, value); }
		}

		public string Email
		{
			get => _email;
			set { Set(() => Email, ref _email, value); }
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
	}
}
