using System.Collections.Generic;
using System.Windows.Input;

namespace thepat.Models
{
    public class MenuItemModel
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }

        public List<MenuItemModel> MenuItems { get; private set; }

        public MenuItemModel()
        {
            MenuItems = new List<MenuItemModel>();
        }
    }
}
