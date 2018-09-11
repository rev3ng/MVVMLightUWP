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


namespace App4.ViewModels
{
	public class ViewPageViewModel : ViewModelBase
	{
		public ObservableCollection<IEmployee> Employees = null;

		public ViewPageViewModel()
		{
			Employees = new FakeEmployeeRepository().GetAllEmployees();
		}
	}

}
