using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.be;

namespace VideoMenu.dal
{
    interface IVideoDAO
    {
        void CreateVideos(List<Video> videos);
        List<Video> GetVidoes();
        Video DeleteVideo(int idToRemove);
        Video CreateVideo(string name);
        void UpdateAll(List<Video> videos);
    }
}
