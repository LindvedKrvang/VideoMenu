using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuDAL
{
    public interface IVideoDao
    {
        List<Video> GetVidoes();
        Video DeleteVideo(int idToRemove);
        Video CreateVideo(string name);
        void UpdateAll(List<Video> videos);
    }
}
