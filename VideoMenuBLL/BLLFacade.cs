using VideoMenuBLL.Services;

namespace VideoMenuBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService => new VideoService();
    }
}
