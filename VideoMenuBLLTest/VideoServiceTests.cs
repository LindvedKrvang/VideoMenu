using System;
using VideoMenuBLL;
using VideoMenuBLL.Services;
using VideoMenuDAL;
using VideoMenuEntities;
using Xunit;

namespace VideoMenuBLLTest
{
    public class VideoServiceTests
    {
        private readonly IService<Video> _videoService;

        public VideoServiceTests()
        {
            IDalFacade mockDal = new MockDalFacade();
            _videoService = new VideoService(mockDal);
        }

        private static readonly  Video TestVideo = new Video()
        {
            Id = 5,
            Name = "Test",
            Genre = EGenre.Undefined
        };

        [Fact]
        public void Test1()
        {

        }
    }
}
