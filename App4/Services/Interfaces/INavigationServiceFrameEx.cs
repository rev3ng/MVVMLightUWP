using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace App4.Services
{
    public interface INavigationServiceFrameEx : INavigationService
    {
	    bool CanGoBack { get; }
	    bool RemoveBackEntry();
	}
}
