using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight.Views;


namespace App4.Services
{
	public class FrameNavigationService : INavigationService
	{
		private readonly Dictionary<string, Type> _pagesByKey;
		private string _currentPageKey;
		private Frame _mainContentFrame;

		public FrameNavigationService(Frame mainContentFrame)
		{
			_pagesByKey = new Dictionary<string, Type>();
			_mainContentFrame = mainContentFrame;
	
		}

		public string CurrentPageKey
		{
			get => _currentPageKey;
			private set
			{
				if (_currentPageKey == value)
				{
					return;
				}

				_currentPageKey = value;
				// TODO: on propertychanged
			}
		}
	
		public void Configure(string key, Type pageType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(key))
				{
					_pagesByKey[key] = pageType;
				}
				else
				{
					_pagesByKey.Add(key, pageType);
				}
			}
		}

		public void GoBack()
		{
			throw new NotImplementedException();
		}

		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		public void NavigateTo(string pageKey, object parameter)
		{
			if (_mainContentFrame == null)
			{
				_mainContentFrame = Window.Current.Content as Frame;
				_mainContentFrame = _mainContentFrame.FindChild<Frame>();
			}


			lock (_pagesByKey)
			{
				if (!_pagesByKey.ContainsKey(pageKey))
				{
					throw new ArgumentException(string.Format("No such page: {0} ", pageKey), nameof(pageKey));
				}

				_mainContentFrame.Navigate(_pagesByKey[pageKey]);
				CurrentPageKey = pageKey;
			}
		}
	}
}
