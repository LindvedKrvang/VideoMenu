using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuDAL
{
    public interface IVideoRepository
    {
        List<Video> GetVidoes();
        Video GetVideo(int id);
        Video DeleteVideo(int idToRemove);
        Video CreateVideo(string name);
        List<Video> SearchVideos(string searchQuery);
    }
}
