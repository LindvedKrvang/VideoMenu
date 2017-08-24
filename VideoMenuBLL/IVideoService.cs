using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuBLL
{
    public interface IVideoService
    {
        List<Video> GetVideos();
        Video GetVideo(int id);
        Video CreateVideo(string nameOfVideo);
        Video DeleteVideo(int idOfVideo);
        void UpdateVideo(Video video);
        List<Video> SearchVideos(string searchQuery);
    }
}
