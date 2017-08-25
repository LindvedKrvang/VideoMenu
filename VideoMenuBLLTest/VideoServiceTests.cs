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
            IDalFacade dal = new DalFacade();
            _videoService = new VideoService(dal);
            _videoService.ClearAll();
        }

        private static readonly Video TestVideo = new Video()
        {
            Id = 5,
            Name = "Test",
            Genre = EGenre.Undefined
        };

        [Fact]
        public void VideoService_GetVideo_NotNull()
        {
            var videoCreated = _videoService.CreateVideo(TestVideo.Name);
            var video = _videoService.GetVideo(videoCreated.Id);

            Assert.NotNull(video);
        }

        [Fact]
        private void VideoService_GetAllVideos_Equal()
        {
            _videoService.CreateVideo(TestVideo.Name);
            _videoService.CreateVideo(TestVideo.Name);
            var result = _videoService.GetVideos().Count;
            var expectedResult = 2;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        private void VideoService_CreateVideo_Contains()
        {
            var videoCreated = _videoService.CreateVideo(TestVideo.Name);
            var videos = _videoService.GetVideos();

            Assert.Contains(videoCreated, videos);
        }

        [Fact]
        private void DeleteVideoTest()
        {
            var video1 = _videoService.CreateVideo(TestVideo.Name + "1");
            var video2 = _videoService.CreateVideo(TestVideo.Name + "2");

            _videoService.DeleteVideo(video2.Id);

            Assert.DoesNotContain(video2, _videoService.GetVideos());
        }
    }
}