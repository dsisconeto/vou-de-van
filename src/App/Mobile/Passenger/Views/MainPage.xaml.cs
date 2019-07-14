using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Iconize;
using VouDeVan.App.Mobile.Passanger.Models;
using VouDeVan.App.Mobile.Passanger.Views.Home;
using VouDeVan.App.Mobile.Passanger.Views.Lines;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VouDeVan.App.Mobile.Passanger.Views
{
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> _menuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //_menuPages.Add((int)MenuItemType.About, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        _menuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.About:
                        _menuPages.Add(id, new NavigationPage(new LinesPage()));
                        break;
                }
            }

            var newPage = _menuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}