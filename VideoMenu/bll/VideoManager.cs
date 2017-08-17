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
    }
}
