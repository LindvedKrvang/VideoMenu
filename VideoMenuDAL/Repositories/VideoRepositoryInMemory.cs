using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuEntities;

namespace VideoMenuDAL.Repositories
{
    internal class VideoRepositoryInMemory : IVideoRepository
    {
        private readonly InMemoryContext _context;

        private static int _id = 1;

        public VideoRepositoryInMemory(InMemoryContext context)
        {
            _context = context;
        }

        public List<Video> GetVidoes()
        {
            return _context.Videos.ToList();
        }

        public Video GetVideo(int id)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == id);
        }

        public Video DeleteVideo(int idToRemove)
        {
            var videoToDelete = _context.Videos.FirstOrDefault(v => v.Id == idToRemove);
            _context.Videos.Remove(videoToDelete);
            return videoToDelete;
        }

        public Video CreateVideo(string name)
        {
            var video = new Video()
            {
                Id = _id++,
                Name = name,
                Genre = EGenre.Undefined
            };
            _context.Videos.Add(video);
            return video;
        }

        public List<Video> SearchVideos(string searchQuery)
        {
            int.TryParse(searchQuery, out int id);
            return _context.Videos.Where(v =>
                    v.Name.ToLower().Contains(searchQuery.ToLower())
                    || v.Id == id
                    || v.Genre.ToString().ToLower().Contains(searchQuery.ToLower()))
                .ToList();
        }
    }
}
