using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App4.Models;
using App4.Services;
using App4.Views;

namespace App4.ViewModels
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>



	public class ViewModelLocator
	{
		public const string StartPageKey = "StartPage";
		public const string StartPageContentKey = "StartPageContent";
		public const string AddPageKey = "AddPage";
		public const string ViewPageKey = "ViewPage";

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			//ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			
			
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
			navig.Configure(StartPageContentKey, typeof(StartPageContent));
			navig.Configure(AddPageKey, typeof(AddPage));
			navig.Configure(ViewPageKey, typeof(ViewPage));

			//Register your services used here
			SimpleIoc.Default.Register<INavigationService>(() => navig);
			SimpleIoc.Default.Register<StartPageViewModel>();
			SimpleIoc.Default.Register<AddPageViewModel>();
			SimpleIoc.Default.Register<ViewPageViewModel>();
			SimpleIoc.Default.Register<IEmployee ,Employee>();

		}


		// <summary>
		// Gets the StartPage view model.
		// </summary>
		// <value>
		// The StartPage view model.
		// </value>
		public StartPageViewModel StartPageInstance => SimpleIoc.Default.GetInstance<StartPageViewModel>();
		public AddPageViewModel AddPageInstance => SimpleIoc.Default.GetInstance<AddPageViewModel>();
		public ViewPageViewModel ViewPageInstance => SimpleIoc.Default.GetInstance<ViewPageViewModel>();

		// <summary>
		// The cleanup.
		// </summary>
		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}

}
