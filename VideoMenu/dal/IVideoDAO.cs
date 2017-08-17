using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.be;

namespace VideoMenu.dal
{
    interface IVideoDAO
    {
        void CreateVidoes(List<Video> videos);
        List<Video> GetVidoes();
        void UpdateVideos();
        void DeleteVideo(Video video);
    }
}
