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

        public void CreateVidoes(List<Video> videos)
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
    }
}
