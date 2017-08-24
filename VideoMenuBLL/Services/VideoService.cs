using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL;
using VideoMenuEntities;

namespace VideoMenuBLL.Services
{
    internal class VideoService : IService<Video>
    {
        private readonly DalFacade _facade;

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
        /// Gets the video that have the parsed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetVideo(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.GetVideo(id);
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
        /// Finds the video witch mathces with the id of the parsed video. Then updates the video.
        /// </summary>
        /// <param name="video"></param>
        public void UpdateVideo(Video video)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var videoToEdit = uow.VideoRepository.GetVideo(video.Id);
                videoToEdit.Name = video.Name;
                uow.Complete();
            }
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
