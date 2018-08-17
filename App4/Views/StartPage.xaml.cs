using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App4.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App4.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class StartPage : Page
	{

		public StartPageViewModel Vm => (StartPageViewModel) DataContext;

		public StartPage()
		{
			this.InitializeComponent();
		}

	}
}
