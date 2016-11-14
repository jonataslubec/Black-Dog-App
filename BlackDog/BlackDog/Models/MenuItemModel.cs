using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDog.Models
{
    public enum MenuType
    {
        Sobre,
        Cliente
    }

    public class MenuItemModel : BaseModel
    {
        public MenuItemModel()
        {
            MenuType = MenuType.Sobre;
        }

        private string _iconMenu;
        public string IconMenu
        {
            get { return Helpers.StringHelper.FixPathImage(_iconMenu); }
            set { _iconMenu = value; }
        }

        public MenuType MenuType { get; set; }
    }
}
