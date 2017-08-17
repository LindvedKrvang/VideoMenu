using System.Collections.Generic;
using VideoMenu.be;
using VideoMenu.bll;

namespace VideoMenu.gui.model
{
    class VideoModel
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
    }

}
