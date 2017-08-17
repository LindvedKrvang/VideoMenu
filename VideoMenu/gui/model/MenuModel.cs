using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.model
{
    class MenuModel
    {
        public List<string> MenuOptions { get; }

        public MenuModel()
        {
            MenuOptions = new List<string>()
            {
                "Show all vidoes",
                "Create new video",
                "Delete a video",
                "Exit"
            };
        }


    }
}
