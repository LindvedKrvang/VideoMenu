using VideoMenuBLL.Services;
using VideoMenuDAL;
using VideoMenuEntities;

namespace VideoMenuBLL
{
    public class BllFacade
    {
        public IService<Video> Service => new VideoService(new DalFacade());
    }
}
