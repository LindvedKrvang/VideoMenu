﻿using System.Collections.Generic;
using System.Linq;
using VideoMenuBLL;
using VideoMenuEntities;

namespace VideoMenuGUI.gui.model
{
    public class VideoModel
    {
        private readonly VideoManager _videoManager;

        public List<Video> Videos { get; }

        public VideoModel()
        {
            _videoManager = new VideoManager();
            Videos = new List<Video>(_videoManager.GetVideos());
        }

        /// <summary>
        /// Adds a video to the model.
        /// </summary>
        /// <param name="video"></param>
        public void AddVideo(Video video)
        {
            Videos.Add(video);
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        /// <param name="name"></param>
        public void CreateVideo(string name)
        {
            var video = _videoManager.CreateVideo(name);
            Videos.Add(video);
        }

        /// <summary>
        /// Returns all the active id's.
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            var ids = new List<int>();
            foreach (var video in Videos)
            {
                ids.Add(video.Id);
            }
            return ids;
        }

        /// <summary>
        /// Deletes the video with the parsed ID.
        /// </summary>
        /// <param name="idToRemove"></param>
        public Video DeleteVideo(int idToRemove)
        {
            var videoToRemove = _videoManager.DeleteVideo(idToRemove);
            Videos.Remove(videoToRemove);
            return videoToRemove;
        }

        /// <summary>
        /// Returns the first video with the parsed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetVideo(int id)
        {
            return Videos.First(v => v.Id == id);
        }

        /// <summary>
        /// Updates all the videos in the database.
        /// </summary>
        public void UpdateAllVideos()
        {
            _videoManager.UpdateAll(Videos);
        }
    }

}
