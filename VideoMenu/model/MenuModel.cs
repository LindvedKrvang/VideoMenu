using System.Collections.Generic;

namespace VideoMenuGUI.gui.model
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
