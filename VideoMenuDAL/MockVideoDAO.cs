using System;
using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuDAL
{
    public class MockVideoDao : IVideoDao
    {
        private List<Video> _videos = new List<Video>()
        {
            new Video(1, "The good. The bad. The Ugly.", EGenre.Western),
            new Video(2, "Scary Movie 4", EGenre.Comedy),
            new Video(3, "The NoteBook", EGenre.Romantic),
            new Video(4, "Skyfall", EGenre.Action)
        };

        private int IdCounter = 5;

        public void CreateVideos(List<Video> videos)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetVidoes()
        {
            return _videos;
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
            var video = new Video(IdCounter++, name, EGenre.Undefined);
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
    }
}
