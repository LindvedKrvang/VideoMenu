using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL;
using VideoMenuEntities;

namespace VideoMenuBLL.Services
{
    internal class VideoService : IVideoService
    {
        private DalFacade _facade;

        public VideoService(DalFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Gets the vidoes from the database and returns them.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVideos()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.GetVidoes();
            }
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        public Video CreateVideo(string nameOfVideo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var createdVideo = uow.VideoRepository.CreateVideo(nameOfVideo);
                uow.Complete();
                return createdVideo;
            }
        }

        /// <summary>
        /// Removes the video with the parsed ID form the database.
        /// </summary>
        /// <param></param>
        /// <param name="idOfVideo"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idOfVideo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var deletedVideo = uow.VideoRepository.DeleteVideo(idOfVideo);
                uow.Complete();
                return deletedVideo;
            }
        }

        /// <summary>
        /// Updates all the videos in the database.
        /// </summary>
        /// <param name="videos"></param>
        public void UpdateAllVideos(List<Video> videos)
        {
            //_videoRepository.UpdateAll(videos);
        }

        /// <summary>
        /// Search all videos from the database if their name contains the searchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Video> SearchVideos(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.SearchVideos(searchQuery);
            }
        }
    }
}
