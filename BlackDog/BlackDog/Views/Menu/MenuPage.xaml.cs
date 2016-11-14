using BlackDog.Models;
using BlackDog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BlackDog.Views.Menu
{
    public partial class MenuPage : ContentPage
    {
        MasterPage masterPage;
        List<MenuItemModel> menuItems;
        public MenuPage(MasterPage masterPage)
        {
            this.masterPage = masterPage;
            InitializeComponent();

            ListViewMenu.ItemsSource = menuItems = new List<MenuItemModel>
            {
                new MenuItemModel { Title = "Sobre", MenuType = MenuType.Sobre, IconMenu = "ic_information.png" },
                new MenuItemModel { Title = "Clientes", MenuType = MenuType.Cliente, IconMenu = "ic_information.png" }
            };

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await this.masterPage.SelecionarItemMenuAsync(MenuItemViewModel.getPageGeneric(((MenuItemModel)e.SelectedItem).MenuType));
            };
        }       
    }
}
