using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VouDeVan.App.Mobile.Passanger.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VouDeVan.App.Mobile.Passanger.Views
{
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage => Application.Current.MainPage as MainPage;

        public MenuPage()
        {
            InitializeComponent();

            var menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Id = MenuItemType.Browse, Title = "Browse" },
                new HomeMenuItem { Id = MenuItemType.About, Title = "About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}