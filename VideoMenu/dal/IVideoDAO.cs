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
        void UpdateVideos();
        void DeleteVideo(Video video);
        Video CreateVideo(string name);
    }
}
