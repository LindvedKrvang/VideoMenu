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
        public void GetVideoTest()
        {
            var video = _videoService.GetVideo(1);

            Assert.NotNull(video);
        }

        [Fact]
        private void GetAllVideosTest()
        {
            var result = _videoService.GetVideos().Count;
            var expectedResult = 4;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        private void CreateVideoTest()
        {
            
        }
    }
}
