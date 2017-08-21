using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuEntities;

namespace VideoMenuBLL
{
    public interface IVideoService
    {
        List<Video> GetVideos();
        Video CreateVideo(string nameOfVideo);
        Video DeleteVideo(int idOfVideo);
        void UpdateAllVideos(List<Video> videos);
    }
}
