using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuDAL
{
    public interface IVideoRepository
    {
        List<Video> GetVidoes();
        Video DeleteVideo(int idToRemove);
        Video CreateVideo(string name);
        void UpdateAll(List<Video> videos);
    }
}
