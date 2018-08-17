using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace App4.ViewModels
{
	public class AddPageViewModel : ViewModelBase
	{
		private string _title;
		private IEmployeesActions _repo;
		public string Title
		{

			get
			{
				return _title;
			}
			set
			{
				if (value != _title)
				{
					_title = value;
					RaisePropertyChanged("Title");
				}
			}
		}

		public RelayCommand AddClickButtonCommand { get; private set; }

		private void AddDataToDatabase()
		{

		}

		public AddPageViewModel(IEmployeesActions repo)
		{
			this.AddClickButtonCommand = new RelayCommand(AddDataToDatabase);
			_repo = repo;
			Title = "Second Page";
		}


	}
}
