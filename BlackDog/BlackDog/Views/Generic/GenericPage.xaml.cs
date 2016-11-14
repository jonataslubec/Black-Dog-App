using BlackDog.Models;
using BlackDog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BlackDog.Views.Generic
{
    public partial class GenericPage : ContentPage
    {
        public GenericPage(string pageModel)
        {
            InitializeComponent();

            ContentPage p = Helpers.JsonHelper<ContentPage>.FromJSON_Object(pageModel, true);

            BindingContext = new BaseViewModel
            {
                Title = p.Title
            };


            Content = p.Content;
        }
    }
}
