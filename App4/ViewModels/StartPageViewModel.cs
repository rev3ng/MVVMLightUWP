﻿using System;
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


namespace App4.ViewModels
{
	public class StartPageViewModel : ViewModelBase
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

		public void NavigateCommandAction(object sender, TappedRoutedEventArgs e)
		{
			if ((sender as NavigationViewItem).Tag.Equals("Add Page"))
			{
				_navigationService.NavigateTo(nameof(AddPage));
			}
			else if ((sender as NavigationViewItem).Tag.Equals("View Page"))
			{
				_navigationService.NavigateTo(nameof(ViewPage));
			}
			else if ((sender as NavigationViewItem).Tag.Equals("Main Page"))
			{
				_navigationService.NavigateTo(nameof(StartPageContent));
			}
		}

		public StartPageViewModel(INavigationService navigationService, IEmployeesActions employeesActions)
		{
			Title = "Start PAGE";
			_navigationService = navigationService;
			//_navigationService.NavigateTo(nameof(StartPageContent));
		}
	}

}
