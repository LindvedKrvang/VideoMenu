using System;
using VideoMenu.gui.controller;
using VideoMenu.model;

namespace VideoMenu
{
    class Program
    {
        private static MenuController _menuController;

        static void Main(string[] args)
        {
            _menuController = new MenuController();
            _menuController.PrintWelcomeMessage();
            _menuController.MenuLoop();
        }

        
    }
}