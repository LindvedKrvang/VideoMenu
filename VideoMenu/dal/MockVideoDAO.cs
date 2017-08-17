using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.be;

namespace VideoMenu.dal
{
    class MockVideoDao : IVideoDAO
    {
        private readonly List<Video> _videos = new List<Video>()
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

        public void UpdateVideos()
        {
            throw new NotImplementedException();
        }

        public void DeleteVideo(Video video)
        {
            
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
    }
}
