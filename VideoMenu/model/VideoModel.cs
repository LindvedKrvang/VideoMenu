using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.be;

namespace VideoMenu.model
{
    class VideoModel
    {
        public List<Video> Videos { get; }

        public VideoModel()
        {
            Videos = new List<Video>();
        }

        /// <summary>
        /// Adds a video to the model.
        /// </summary>
        /// <param name="video"></param>
        public void AddVideo(Video video)
        {
            Videos.Add(video);
        }
    }
}
