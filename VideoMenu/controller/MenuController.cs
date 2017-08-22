using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuGUI.model;

namespace VideoMenuGUI.gui.controller
{
    public class MenuController
    {
        private readonly MenuModel _menuModel;
        private readonly VideoModel _videoModel;

        private bool _programIsRunning;

        public MenuController()
        {
            _menuModel = new MenuModel();
            _videoModel = new VideoModel();
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
            var foundVideos = _videoModel.SearchVideos(input);
            if (foundVideos == null || foundVideos.Count == 0)
            {
                Console.WriteLine("No videos were found..");
                return;
            }
            Console.WriteLine("I found:");
            foreach (var video in foundVideos)
            {
                Console.WriteLine($"ID: {video.Id}, Name: {video.Name}, Genre: {video.Genre}");
            }
        }

        /// <summary>
        /// Finds the video to update and updates the name.
        /// </summary>
        private void UpdateVideo()
        {
            Console.WriteLine("Please enter the ID of the video to update:");
            var id = PromptId();
            var video = _videoModel.GetVideo(id);
            Console.WriteLine($"The video you have selected is: {video.Name}.");
            Console.WriteLine("Please enter its new name:");
            var name = Console.ReadLine();
            video.Name = name;
            _videoModel.UpdateAllVideos();
            Console.WriteLine($"The video is now called: {video.Name}.");
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
            var videos = _videoModel.Videos;

            if (!videos.Any())
            {
                Console.WriteLine("There are no videos available at the current time.");
                return;
            }

            Console.WriteLine("The available videos are:");
            foreach (var video in videos)
            {
                Console.WriteLine($"Id: {video.Id}. Name: {video.Name}. Genre: {video.Genre}");
            }
        }

        /// <summary>
        /// Creates a new video.
        /// </summary>
        private void CreateVideo()
        {
            var name = PromptName();
            _videoModel.CreateVideo(name);
        }

        /// <summary>
        /// Ask for the ID of the video to be deleted. Then deletes it.
        /// </summary>
        private void DeleteVideo()
        {
            Console.WriteLine("Please enter the ID of the video to delete.");
            var idToRemove = PromptId();
            var video = _videoModel.DeleteVideo(idToRemove);
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
            var ids = _videoModel.GetIds();
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