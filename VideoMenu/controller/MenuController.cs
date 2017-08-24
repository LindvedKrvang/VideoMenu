﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using VideoMenuBLL;
using VideoMenuEntities;
using VideoMenuGUI.model;

namespace VideoMenuGUI.controller
{
    public class MenuController
    {
        private readonly MenuModel _menuModel;
        private readonly BllFacade _blllFacade;

        private bool _programIsRunning;


        public MenuController()
        {
            _menuModel = new MenuModel();
            _blllFacade = new BllFacade();
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
            Console.WriteLine();
            switch (selectedOption)
            {
                case 1:
                {
                    DisplayAllVideos();
                    break;
                }
                case 2:
                {
                    CreateVideo();
                    break;
                }
                case 3:
                {
                    DeleteVideo();
                    break;
                }
                case 4:
                {
                    UpdateVideo();
                    break;
                }
                case 5:
                {
                    SearchVideos();
                    break;
                }
                case 6:
                {
                    ExitProgram();
                    break;
                }
                default:
                {
                    Console.WriteLine("No option selected!");
                    break;
                }
            }
        }

        /// <summary>
        /// Prompt the user for what they want to search. Then shows the result.
        /// </summary>
        private void SearchVideos()
        {
            Console.WriteLine("What do you want to search for?");
            var input = Console.ReadLine();
            var foundVideos = _blllFacade.Service.SearchVideos(input);
            if (foundVideos == null || foundVideos.Count == 0)
            {
                Console.WriteLine("No videos were found..");
                return;
            }
            Console.WriteLine("I found:");
            foundVideos.ForEach(v => Console.WriteLine($"ID: {v.Id}, Name: {v.Name}, Genre: {v.Genre}"));
        }

        /// <summary>
        /// Finds the video to update and updates the name.
        /// </summary>
        private void UpdateVideo()
        {
            Console.WriteLine("Please enter the ID of the video to update:");
            var id = PromptId();

            var nameOfVideoToEdit = _blllFacade.Service.GetVideo(id).Name;
            Console.WriteLine($"The video you have selected is: {nameOfVideoToEdit}.");

            var videoToEdit = new Video(){Id = id};

            Console.WriteLine("Please enter its new name:");
            var name = Console.ReadLine();
            videoToEdit.Name = name;

            _blllFacade.Service.UpdateVideo(videoToEdit);
            Console.WriteLine($"The video is now called: {videoToEdit.Name}.");
        }

        /// <summary>
        /// Exits the program loop.
        /// </summary>
        private void ExitProgram()
        {
            Console.WriteLine("\nExiting program...");
            _programIsRunning = false;
        }

        /// <summary>
        /// Displays all the videos. If there are no vidoes, tells the user.
        /// </summary>
        private void DisplayAllVideos()
        {
            var videos = _blllFacade.Service.GetVideos();

            if (!videos.Any())
            {
                Console.WriteLine("There are no videos available at the current time.");
                return;
            }

            Console.WriteLine("The available videos are:");
            videos.ForEach(v => Console.WriteLine($"Id: {v.Id}. Name: {v.Name}. Genre: {v.Genre}"));
        }

        /// <summary>
        /// Creates a new video.
        /// </summary>
        private void CreateVideo()
        {
            var name = PromptName();
            _blllFacade.Service.CreateVideo(name);
        }

        /// <summary>
        /// Ask for the ID of the video to be deleted. Then deletes it.
        /// </summary>
        private void DeleteVideo()
        {
            Console.WriteLine("Please enter the ID of the video to delete.");
            var idToRemove = PromptId();
            var video = _blllFacade.Service.DeleteVideo(idToRemove);
            Console.WriteLine($"{video.Name} was deleted!");

        }

        /// <summary>
        /// Ask the user for a name.
        /// </summary>
        /// <returns></returns>
        private string PromptName()
        {
            Console.WriteLine("Enter the name of the video:");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets a number from the user. Validates it and checks if there is a video with that ID.
        /// </summary>
        /// <returns></returns>
        private int PromptId()
        {
            var ids = _blllFacade.Service.GetVideos().Select(v => v.Id).ToList();
            int input;
            if (!int.TryParse(Console.ReadLine(), out input) || !ids.Exists(i => i == input))
            {
                Console.WriteLine("There isn't a video with that ID. Please write another ID:");
                input = PromptId();
            }
            return input;
        }
    }
}