using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Models;

namespace App4.Services
{
	public static class AddressValidator
	{
		// this service is for validation logic

		public static void ValidateEmployee(Address address)
		{
			// validate first name
			if (String.IsNullOrEmpty(address.City))
				address.Properties[nameof(address.City)].Errors.Add("City field is required.");

		}
	}
}
