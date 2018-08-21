using App4.Services.Validation;
using GalaSoft.MvvmLight;

namespace App4.Models
{
	public class Employee : ObservableObject, IEmployee
	{
		private int _id;
		private string _name;
		private decimal? _salary;
		private bool _isHired;
		private string _surname;

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

		public override string ToString()
		{
			return Name + " " + Salary.ToString();
		}
	}
}
