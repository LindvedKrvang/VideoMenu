using System.Collections.Generic;
using System.Linq;
using VideoMenuEntities;

namespace VideoMenuDAL.Repositories
{
    internal class MockVideoRepository : IVideoRepository
    {
        private static List<Video> _videos = new List<Video>()
        {
            new Video()
            {
                Id = 1,
                Name = "The good. The bad. The Ugly",
                Genre = EGenre.Western
            },
            new Video()
            {
                Id = 2,
                Name = "Scary Movie 4",
                Genre = EGenre.Comedy
            },
            new Video()
            {
                Id = 3,
                Name = "The NoteBook",
                Genre = EGenre.Romantic
            },
            new Video()
            {
                Id = 4,
                Name = "Skyfall",
                Genre = EGenre.Action
            }
        };

        private int _idCounter = 5;
        
        public List<Video> GetVidoes()
        {
            return _videos;
        }

        public Video GetVideo(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes a the video with the parsed ID. Returns it.
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public Video DeleteVideo(int idToRemove)
        {
            var videoToDelete = _videos.Find(v => v.Id == idToRemove);
            _videos.Remove(videoToDelete);
            return videoToDelete;
        }

        /// <summary>
        /// Creates a new video with the given name.
        /// </summary>
        /// <param name="name"></param>
        public Video CreateVideo(string name)
        {
            var video = new Video()
            {
                Id = _idCounter++,
                Name = name,
                Genre = EGenre.Undefined
            };
            _videos.Add(video);
            return video;
        }

        /// <summary>
        /// Updates all the video.
        /// </summary>
        /// <param name="videos"></param>
        public void UpdateAll(List<Video> videos)
        {
            _videos = videos;
        }

        /// <summary>
        /// Returns the videos where their id, names or genre contains the searchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Video> SearchVideos(string searchQuery)
        {
            int.TryParse(searchQuery, out int id);
            return _videos.Where(v => 
                v.Name.ToLower().Contains(searchQuery.ToLower()) 
                || v.Id == id 
                || v.Genre.ToString().ToLower().Contains(searchQuery.ToLower()))
                .ToList();
        }
    }
}
