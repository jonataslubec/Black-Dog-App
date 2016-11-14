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
    public class MasterPage : MasterDetailPage
    {
        public static bool IsUWPDesktop { get; set; }
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public MasterPage()
        {
            Pages = new Dictionary<MenuType, Xamarin.Forms.NavigationPage>();

            //Setando o MenuPage (Master)
            Master = new MenuPage(this);

            //Setando a Page (Detail)
            //SelecionarMainPage();

            Detail = (NavigationPage)new NavigationPageControl(new Sobre.SobrePage());


            InvalidateMeasure();
        }


        public async void SelecionarMainPage()
        {
            await SelecionarItemMenuAsync(MenuItemViewModel.getPageGeneric(MenuType.Sobre));
        }

       
        public async Task SelecionarItemMenuAsync(string page)
        {

            if (Detail != null)
            {
                if (IsUWPDesktop || Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;

                if (Device.OS == TargetPlatform.Android)
                    await Task.Delay(300);
            }

            //Page newPage;

           // Pages.Add(id, (NavigationPage)new NavigationPageControl(new Generic.GenericPage()));

            //if (!Pages.ContainsKey(id))
            //{
            //switch (id)
            //{
            //    //case MenuType.Sobre:
            //    //    Pages.Add(id, (NavigationPage)new NavigationPageControl(new Sobre.SobrePage()));
            //    //    break;
            //    //case MenuType.Cliente:
            //    //    Pages.Add(id, (NavigationPage)new NavigationPageControl(new Cliente.ClientePage()));
            //    //    break;
            //    case MenuType.Cliente:
            //        Pages.Add(id, (NavigationPage)new NavigationPageControl(new Generic.GenericPage()));
            //        break;

            //}

            //}
            //newPage = Pages[id];

            //Pages.Remove(id);

            //if (newPage == null)
            //    return;

            //if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            //{
            //    await Detail.Navigation.PopToRootAsync();
            //}

            Detail = (NavigationPage)new NavigationPageControl(new Generic.GenericPage(page));
        }
    }
}
