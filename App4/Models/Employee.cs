using System;
using App4.Models.Interfaces;
using GalaSoft.MvvmLight;
using Template10.Validation;

namespace App4.Models
{
	public class Employee : ValidatableModelBase, IEmployee
	{
		private static int _id = 0;

		public Employee()
		{
			
			this.Id = _id;
			_id++;
		}

		public int Id
		{
			get => Read<int>();
			set => Write(value);
		}

		public string Name
		{
			get => Read<string>();
			set => Write(value);
		}

		public string Surname
		{
			get => Read<string>();
			set => Write(value);
		}

		public decimal? Salary
		{
			get => Read<decimal?>();
			set => Write(value);
		}

		public bool? IsHired
		{
			get => Read<bool?>();
			set => Write(value);
		}

		public string Email
		{
			get => Read<string>();
			set => Write(value);
		}

		public IAddress Address
		{
			get => Read<IAddress>();
			set => Write(value);
		}

		public DateTime? CreationDateTime
		{
			get => Read<DateTime?>();
			set => Write(value);
		}

	}

	public class Address : ValidatableModelBase, IAddress
	{
		public string PostalCode
		{
			get => Read<string>();
			set => Write(value);
		}
		public string Country
		{
			get => Read<string>();
			set => Write(value);
		}
		public string City
		{
			get => Read<string>();
			set => Write(value);
		}
		public string StreetAddress
		{
			get => Read<string>();
			set => Write(value);
		}
		public string Number
		{
			get => Read<string>();
			set => Write(value);
		}
	}
}
