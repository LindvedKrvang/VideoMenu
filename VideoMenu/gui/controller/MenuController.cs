using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.model;

namespace VideoMenu.gui.controller
{
    class MenuController
    {
        private readonly MenuModel _menuModel;

        private bool _programIsRunning;

        public MenuController()
        {
            _menuModel = new MenuModel();
            _programIsRunning = true;
        }

        /// <summary>
        /// Prints a welcome message.
        /// </summary>
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Video Store!");
        }

        /// <summary>
        /// Keeps the program running until it's time terminate it.
        /// </summary>
        public void MenuLoop()
        {
            do
            {
                DisplayMenu();
                var selectedMenuOption = PromptNumberForMenu();
                HandleSelectedMenuOption(selectedMenuOption);
            } while (_programIsRunning);
        }

        /// <summary>
        /// Display the menu.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            var menuOptions = _menuModel.MenuOptions;
            for (var i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {menuOptions[i]}");
            }
        }

        /// <summary>
        /// Gets a number from the user. Validates it and returns it.
        /// </summary>
        /// <returns></returns>
        private int PromptNumberForMenu()
        {
            int input;
            if (!int.TryParse(Console.ReadLine(), out input) || input <= 0 || input > _menuModel.MenuOptions.Count)
            {
                Console.WriteLine("That's not a valid number for this menu. Please choose another:");
                input = PromptNumberForMenu();
            }
            return input;
        }

        /// <summary>
        /// Takes the selectedOption and calls the appropiated method.
        /// </summary>
        /// <param name="selectedOption"></param>
        private void HandleSelectedMenuOption(int selectedOption)
        {
            switch (selectedOption)
            {
                case 1:
                {
                    Console.WriteLine("Option 1 selected!");
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Option 2 selected!");
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Option 3 selected!");
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\nExiting program...");
                    _programIsRunning = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("No option selected!");
                    break;
                }
            }
        }
    }
}