using BlackDog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlackDog.ViewModels
{
   public class MenuItemViewModel
    {
        public static string getPageGeneric(MenuType type)
        {
            string json = "";
            switch (type)
            {
                case MenuType.Sobre:

                    json = getPage("Sobre");

                    break;
                case MenuType.Cliente:

                    json = getPage("Cliente");

                    break;
                default:
                    break;
            }

            return json;
        }



        private static string getPage(string page)
        {
            ContentPage p = new ContentPage();

            ScrollView scroll = new ScrollView();

            StackLayout stackPai = new StackLayout { Orientation = StackOrientation.Vertical, Spacing = 20 };
            Image img = new Image { Aspect = Aspect.AspectFill, Source = "black_dog_logo.png" };

            StackLayout stackFilho = new StackLayout { Orientation = StackOrientation.Vertical, Padding = 20, Spacing = 10 };
            Label lbl = new Label { Text = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque 
                                           laudantium,
                                            totam rem aperiam,
                                            eaque ipsa quae ab illo inventore veritatis et quasi architecto
                                           beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut
                                          odit aut fugit,
                                            sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.
                                           Neque porro quisquam est,
                                            qui dolorem ipsum quia dolor sit amet,
                                            consectetur,
                                            adipisci velit,
                                            sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat
                                           voluptatem.Ut enim ad minima veniam,
                                            quis nostrum exercitationem ullam corporis suscipit
                                           laboriosam,
                                            nisi ut aliquid ex ea commodi consequatur ? Quis autem vel eum iure reprehenderit
                                           qui in ea voluptate velit esse quam nihil molestiae consequatur,
                                            vel illum qui dolorem eum
                                           fugiat quo voluptas nulla pariatur ? ", LineBreakMode = LineBreakMode.WordWrap, TextColor = Color.Black };

            stackFilho.Children.Add(lbl);


            stackPai.Children.Add(img);
            stackPai.Children.Add(stackFilho);

            scroll.Content = stackPai;

            p.Content = scroll;
            p.Title = page + " Jojo";

            string json = Helpers.JsonHelper<ContentPage>.ToJSON_Object(p, true);

            return json;
        }

    }
}
