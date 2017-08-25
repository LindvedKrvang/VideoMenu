using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuDAL
{
    public interface IVideoRepository
    {
        //C
        Video CreateVideo(string name);
        
        //R
        List<Video> GetVidoes();
        Video GetVideo(int id);
        List<Video> SearchVideos(string searchQuery);

        //D
        Video DeleteVideo(int idToRemove);

        void ClearAll();
    }
}
