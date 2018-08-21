using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace App4.Services.Validation
{
	public class ValidationErrors : ObservableObject
	{
		private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();

		public bool IsValid
		{
			get { return this._validationErrors.Count < 1; }
		}

		public void Clear()
		{
			_validationErrors.Clear();
		}

		public string this[string fieldName]
		{
			get
			{
				return this._validationErrors.ContainsKey(fieldName) ? this._validationErrors[fieldName] : string.Empty;
			}



			set
			{
				if (this._validationErrors.ContainsKey(fieldName))
				{
					if (string.IsNullOrWhiteSpace(value))
					{
						this._validationErrors.Remove(fieldName);
					}
					else
					{
						this._validationErrors[fieldName] = value;
					}
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(value))
					{
						this._validationErrors.Add(fieldName, value);
					}
				}

				this.RaisePropertyChanged();
				this.RaisePropertyChanged("InValid");
			}
		}
	}
}
