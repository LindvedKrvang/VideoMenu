using System;
using VideoMenu.model;

namespace VideoMenu
{
    class Program
    {
        private static MenuModel _menuModel;

        static void Main(string[] args)
        {
            _menuModel = new MenuModel();
            PrintWelcomeMessage();
            DisplayMenu();
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Video Store!");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            var menuOptions = _menuModel.MenuOptions;
            for (var i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i} : {menuOptions[i]}");
            }
        }
    }
}