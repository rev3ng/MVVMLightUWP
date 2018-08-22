using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace App4.Services.Validation
{
	public abstract class ValidationBase : ObservableObject
	{

		protected ValidationBase()
		{
			this.ValidationErrors = new ValidationErrors();
		}

		public ValidationErrors ValidationErrors { get; set; }


		public bool IsValid { get; private set; }

		public void Validate()
		{
			this.ValidationErrors.Clear();
			this.ValidateSelf();
			this.IsValid = this.ValidationErrors.IsValid;
			this.RaisePropertyChanged("IsValid");
			this.RaisePropertyChanged("ValidationErrors");
		}

		protected abstract void ValidateSelf();
	}
}
