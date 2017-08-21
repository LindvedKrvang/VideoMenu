using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.Services;
using VideoMenuEntities;

namespace VideoMenuBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService => new VideoService();
    }
}
