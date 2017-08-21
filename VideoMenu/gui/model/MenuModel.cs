using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.model
{
    public class MenuModel
    {
        public List<string> MenuOptions { get; }

        public MenuModel()
        {
            MenuOptions = new List<string>()
            {
                "Show all vidoes",
                "Create new video",
                "Delete a video",
                "Update video",
                "Exit"
            };
        }


    }
}
