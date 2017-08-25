﻿using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL.Context;
using VideoMenuEntities;

namespace VideoMenuDAL.Repositories
{
    internal class MockVideoRepository : IVideoRepository
    {


        //private static List<Video> _videos = new List<Video>()
        //{
        //    new Video()
        //    {
        //        Id = 1,
        //        Name = "The good. The bad. The Ugly",
        //        Genre = EGenre.Western
        //    },
        //    new Video()
        //    {
        //        Id = 2,
        //        Name = "Scary Movie 4",
        //        Genre = EGenre.Comedy
        //    },
        //    new Video()
        //    {
        //        Id = 3,
        //        Name = "The NoteBook",
        //        Genre = EGenre.Romantic
        //    },
        //    new Video()
        //    {
        //        Id = 4,
        //        Name = "Skyfall",
        //        Genre = EGenre.Action
        //    }
        //};

        private int _idCounter = 5;

        /// <summary>
        /// Returns all videos.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVidoes()
        {
            return MockContext.Videos;
        }

        /// <summary>
        /// Returns the first instance that have the parsed id. Returns null if none is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetVideo(int id)
        {
            return MockContext.Videos.FirstOrDefault(v => v.Id == id);
        }

        /// <summary>
        /// Deletes a the video with the parsed ID. Returns it.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idToRemove)
        {
            var videoToDelete = MockContext.Videos.Find(v => v.Id == idToRemove);
            MockContext.Videos.Remove(videoToDelete);
            return videoToDelete;
        }

        /// <summary>
        /// Creates a new video with the given name.
        /// </summary>
        /// <param name="name"></param>
        public Video CreateVideo(string name)
        {
            var video = new Video()
            {
                Id = _idCounter++,
                Name = name,
                Genre = EGenre.Undefined
            };
            MockContext.Videos.Add(video);
            return video;
        }

        /// <summary>
        /// Returns the videos where their id, names or genre contains the searchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Video> SearchVideos(string searchQuery)
        {
            int.TryParse(searchQuery, out int id);
            return MockContext.Videos.Where(v =>
                    v.Name.ToLower().Contains(searchQuery.ToLower())
                    || v.Id == id
                    || v.Genre.ToString().ToLower().Contains(searchQuery.ToLower()))
                .ToList();
        }
    }
}