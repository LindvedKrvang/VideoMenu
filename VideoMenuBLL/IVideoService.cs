using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuBLL
{
    public interface IVideoService
    {
        //C
        Video CreateVideo(string nameOfVideo);
        
        //R
        List<Video> GetVideos();
        Video GetVideo(int id);
        List<Video> SearchVideos(string searchQuery);

        //U
        void UpdateVideo(Video video);

        //D
        Video DeleteVideo(int idOfVideo);
    }
}
