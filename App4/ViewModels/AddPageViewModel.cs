﻿using System;
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

		public AddPageViewModel()
		{
			Title = "Second Page";
		}


	}
}
