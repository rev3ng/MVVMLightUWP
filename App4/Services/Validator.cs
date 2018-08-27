using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Models;
using Template10.Validation;

namespace App4.Services.UserService
{
	public static class Validator
	{
		// this service is for validation logic

		public static void ValidateEmployee(Employee user)
		{
			// validate first name
			if (string.IsNullOrEmpty(user.Name))
				user.Properties[nameof(user.Name)].Errors.Add("Name is required.");
			else if (user.Name.Length < 2)
				user.Properties[nameof(user.Name)].Errors.Add("Name length is invalid.");

			// validate last name
			if (string.IsNullOrEmpty(user.Surname))
				user.Properties[nameof(user.Surname)].Errors.Add("Surname is required.");
			else if (user.Surname.Length < 2)
				user.Properties[nameof(user.Surname)].Errors.Add("Surname length is invalid.");

			// validate email
			if (string.IsNullOrEmpty(user.Email))
				user.Properties[nameof(user.Email)].Errors.Add("Email is required.");
			else if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(user.Email))
				user.Properties[nameof(user.Email)].Errors.Add("A valid Email is required.");

			//validate IsHIred
			if (user.IsHired == null)
				user.Properties[nameof(user.IsHired)].Errors.Add("IsHired field is required.");

			//validate Salary
			if (user.Salary == null)
				user.Properties[nameof(user.Salary)].Errors.Add("Salary field is required.");
			else if (user.Salary < 0)
				user.Properties[nameof(user.Salary)].Errors.Add("Salary cannot be less than 0.");

		}
	}
}
