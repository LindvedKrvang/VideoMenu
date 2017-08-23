using VideoMenuBLL.Services;
using VideoMenuDAL;

namespace VideoMenuBLL
{
    public class BllFacade
    {
        public IVideoService VideoService => new VideoService(new DalFacade().VideoRepository);
    }
}
