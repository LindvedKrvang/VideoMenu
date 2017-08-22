using System;
using System.Linq;
using VideoMenuDAL;
using Xunit;

namespace VideoMenuDALTest
{
    public class MockVideoRepositoryTest
    {
        [Fact]
        public void GetVideosTest()
        {
            var repo = new DalFacade().VideoRepository;
            var videos = repo.GetVidoes();

            Assert.NotNull(videos);
        }

        [Fact]
        public void CreateVideoTest()
        {
            var repo = new DalFacade().VideoRepository;
            var testName = "TestVideo";
            repo.CreateVideo(testName);

            var videos = repo.GetVidoes();

            Assert.Equal(videos[videos.Count - 1].Name, testName);
        }

        [Fact]
        public void DeleteVideoTest()
        {
            var repo = new DalFacade().VideoRepository;
            var testName = "TestVideo";
            var video = repo.CreateVideo(testName);

            repo.DeleteVideo(video.Id);

            var videosAfterDelete = repo.GetVidoes();
            var videoShouldBeNull = videosAfterDelete.FirstOrDefault(v => v.Id == video.Id);
            Assert.Null(videoShouldBeNull);
        }
    }
}
