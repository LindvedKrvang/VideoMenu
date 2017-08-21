using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL;
using VideoMenuEntities;

namespace VideoMenuBLL.Services
{
    public class VideoService : IVideoService
    {
        private static readonly IVideoDao VideoDao = new MockVideoDao();

        /// <summary>
        /// Gets the vidoes from the database and returns them.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVideos()
        {
            return VideoDao.GetVidoes();
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        /// <param name="name"></param>
        public Video CreateVideo(string nameOfVideo)
        {
            return VideoDao.CreateVideo(nameOfVideo);
        }

        /// <summary>
        /// Removes the video with the parsed ID form the database.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idOfVideo)
        {
            return VideoDao.DeleteVideo(idOfVideo);
        }

        /// <summary>
        /// Updates all the videos in the database.
        /// </summary>
        /// <param name="videos"></param>
        public void UpdateAllVideos(List<Video> videos)
        {
            VideoDao.UpdateAll(videos);
        }
    }
}
