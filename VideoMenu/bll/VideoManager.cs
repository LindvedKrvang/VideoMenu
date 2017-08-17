using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.be;
using VideoMenu.dal;

namespace VideoMenu.bll
{
    class VideoManager
    {
        private readonly IVideoDAO _videoDao;

        public VideoManager()
        {
            _videoDao = new MockVideoDao();
        }

        /// <summary>
        /// Gets the vidoes from the database and returns them.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVideos()
        {
            return _videoDao.GetVidoes();
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        /// <param name="name"></param>
        public Video CreateVideo(string name)
        {
            return _videoDao.CreateVideo(name);
        }

        /// <summary>
        /// Removes the video with the parsed ID form the database.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idToRemove)
        {
            return _videoDao.DeleteVideo(idToRemove);
        }
    }
}
