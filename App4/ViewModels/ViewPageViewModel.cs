using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using App4.Models;
using App4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Toolkit.Uwp.UI.Extensions;


namespace App4.ViewModels
{
	public class ViewPageViewModel : ViewModelBase
	{
		private readonly ObservableCollection<IEmployee> _originalEmployees = null;
		public ObservableCollection<IEmployee> Employees;
		private readonly INavigationService _navigationService = null;

		private ListView _content = null;
		private Frame _mainFrame = null;

		public void SortCollection()
		{
			//Employees = new ObservableCollection<IEmployee>(
			//	from i in Employees orderby i.Name select i);

			var result = _originalEmployees.Select(n => n)
				.Where(n => n.Name.StartsWith("K")).ToList();
			
			Employees = new ObservableCollection<IEmployee>();
			foreach (var x in result)
			{
				Employees.Add(x);
			}

			//Employees = null;
			//RaisePropertyChanged(nameof(Employees));
			RefreshView();
		}

		public ViewPageViewModel(IEmployeesActions repo, INavigationService naviagationService)
		{
			_navigationService = naviagationService;
			_originalEmployees = repo.GetAllEmployees();
			Employees = _originalEmployees;
		}

		private void RefreshView()
		{
			if (_mainFrame == null)
			{
				_mainFrame = Window.Current.Content as Frame;
				_content = _mainFrame.FindChild<ListView>();
			}

			if (_content != null)
			{
				_content.ItemsSource = null;
				_content.ItemsSource = Employees;
			}
			
		}
	}

}
