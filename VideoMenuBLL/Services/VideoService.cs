using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL;
using VideoMenuEntities;

namespace VideoMenuBLL.Services
{
    public class VideoService : IService<Video>
    {
        private readonly IDalFacade _facade;

        public VideoService(IDalFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Receives a list of names and creates videos of them in the database.
        /// </summary>
        /// <param name="nameOfVideos"></param>
        /// <returns></returns>
        public List<Video> CreateAll(List<string> nameOfVideos)
        {
            var videos = new List<Video>();
            using (var uow = _facade.UnitOfWork)
            {
                videos.AddRange(nameOfVideos.Select(nameOfVideo => uow.VideoRepository.CreateVideo(nameOfVideo)));
                uow.Complete();
            }
            return videos;
        }

        /// <summary>
        /// Gets the vidoes from the database and returns them.
        /// </summary>
        /// <returns></returns>
        public List<Video> GetAll()
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
        public Video GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.GetVideo(id);
            }
        }

        /// <summary>
        /// Creates a new video in the database with the given name.
        /// </summary>
        public Video Create(string nameOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var createdVideo = uow.VideoRepository.CreateVideo(nameOfEntity);
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
        public Video Delete(int idOfVideo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var deletedVideo = uow.VideoRepository.DeleteVideo(idOfVideo);
                uow.Complete();
                return deletedVideo;
            }
        }

        /// <summary>
        /// Clears the Db of everything.
        /// </summary>
        public void ClearAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                uow.VideoRepository.ClearAll();
                uow.Complete();
            }
        }

        /// <summary>
        /// Finds the video witch mathces with the id of the parsed video. Then updates the video.
        /// </summary>
        /// <param name="video"></param>
        public void Update(Video video)
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
        public List<Video> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.SearchVideos(searchQuery);
            }
        }
    }
}
