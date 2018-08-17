using GalaSoft.MvvmLight;

namespace App4.Models
{
	public class Employee : ObservableObject, IEmployee
	{
		private int _id;
		private string _name;
		private decimal _salary;
		private bool _isHired;

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

		public decimal Salary
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
