using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlackDog.Views.Menu
{
    public class NavigationPageControl : NavigationPage
    {
        public NavigationPageControl(Page root) : base(root)
        {
            Init();
            SetBackButtonTitle(root, "Voltar");
        }

        public NavigationPageControl()
        {
            Init();
        }

        void Init()
        {
            BarBackgroundColor = Color.FromHex("#3F51B5");
            BarTextColor = Color.White;

        }
    }
}
