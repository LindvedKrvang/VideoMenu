using System.Collections.Generic;
using VideoMenuDAL;
using VideoMenuEntities;

namespace VideoMenuBLL.Services
{
    internal class VideoService : IVideoService
    {
        private static IVideoRepository _videoRepository;

        public VideoService(IVideoRepository repository)
        {
            _videoRepository = repository;
        }

        /// <summary>
        /// Gets the vidoes from the database and returns them.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVideos()
        {
            return _videoRepository.GetVidoes();
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        public Video CreateVideo(string nameOfVideo)
        {
            return _videoRepository.CreateVideo(nameOfVideo);
        }

        /// <summary>
        /// Removes the video with the parsed ID form the database.
        /// </summary>
        /// <param></param>
        /// <param name="idOfVideo"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idOfVideo)
        {
            return _videoRepository.DeleteVideo(idOfVideo);
        }

        /// <summary>
        /// Updates all the videos in the database.
        /// </summary>
        /// <param name="videos"></param>
        public void UpdateAllVideos(List<Video> videos)
        {
            _videoRepository.UpdateAll(videos);
        }
    }
}
