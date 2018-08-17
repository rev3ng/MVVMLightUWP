using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App4.Models;
using App4.Services;
using App4.Views;
using Microsoft.Practices.ServiceLocation;

namespace App4.ViewModels
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>



	public class ViewModelLocator
	{
		public const string StartPageKey = "StartPage";
		public const string SecondPageKey = "SecondPage";
		public const string ThirdPageKey = "ThirdPage";

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			
			
			if (ViewModelBase.IsInDesignModeStatic)
			{
				// Create design time view services and models
				
			}
			else
			{
				// Create run time view services and models
				SimpleIoc.Default.Register<IEmployeesActions, FakeEmployeeRepository>();
			}

			var navig = new FrameNavigationService(Window.Current.Content as Frame);
			navig.Configure(StartPageKey, typeof(StartPage));
			navig.Configure(SecondPageKey, typeof(SecondPage));
			navig.Configure(ThirdPageKey, typeof(ThirdPage));

			//Register your services used here
			SimpleIoc.Default.Register<INavigationService>(() => navig);
			SimpleIoc.Default.Register<StartPageViewModel>();
			SimpleIoc.Default.Register<SecondPageViewModel>();
			SimpleIoc.Default.Register<ThirdPageViewModel>();

		}


		// <summary>
		// Gets the StartPage view model.
		// </summary>
		// <value>
		// The StartPage view model.
		// </value>
		public StartPageViewModel StartPageInstance => ServiceLocator.Current.GetInstance<StartPageViewModel>();
		public SecondPageViewModel SecondPageInstance => ServiceLocator.Current.GetInstance<SecondPageViewModel>();

		public Employee Model1Instance => ServiceLocator.Current.GetInstance<Employee>();
		// <summary>
		// The cleanup.
		// </summary>
		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}

}
