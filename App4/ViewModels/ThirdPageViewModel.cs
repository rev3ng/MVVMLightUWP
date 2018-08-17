using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App4.Models;
using App4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Toolkit.Uwp.UI.Extensions;


namespace App4.ViewModels
{
	public class ThirdPageViewModel : ViewModelBase
	{
		private bool _isLoading;
		private INavigationService _navigationService;
		public bool IsLoading
		{
			get => _isLoading;
			set
			{
				_isLoading = value;
				RaisePropertyChanged("IsLoading");

			}
		}
		private string _title;
		public string Title
		{

			get => _title;
			set
			{
				if (value != _title)
				{
					_title = value;
					RaisePropertyChanged("Title");
				}
			}
		}

		public void NavigateCommandAction(object sender, RoutedEventArgs e)
		{
			_navigationService.NavigateTo("SecondPage");
		}

		public ThirdPageViewModel(INavigationService navigationService, IEmployeesActions employeesActions)
		{
			Title = "Third PAGE";
			_navigationService = navigationService;
		}
	}

}
