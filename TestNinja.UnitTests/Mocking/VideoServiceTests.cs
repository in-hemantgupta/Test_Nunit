using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        /*Method DI*/
        //[Test]
        //public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        //{
        //    VideoService service = new VideoService();
        //    var result = service.ReadVideoTitle(new FakeFileReader());
        //    Assert.That(result, Does.Contain("Error").IgnoreCase);
        //}

        /*Property DI*/
        //[Test]
        //public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        //{
        //    VideoService service = new VideoService();
        //    service.FileReader = new FakeFileReader();
        //    var result = service.ReadVideoTitle();
        //    Assert.That(result, Does.Contain("Error").IgnoreCase);
        //}

        /*Constructor DI*/
        //[Test]
        //public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        //{
        //    VideoService service = new VideoService(new FakeFileReader());
        //    var result = service.ReadVideoTitle();
        //    Assert.That(result, Does.Contain("Error").IgnoreCase);
        //}

        VideoService videoService;
        Mock<IFileReader> fileReader;
        Mock<IVideoRepository> videoRepo;

        [SetUp]
        public void SetUp()
        {
            fileReader = new Mock<IFileReader>();
            videoRepo = new Mock<IVideoRepository>();
            videoService = new VideoService(fileReader.Object, videoRepo.Object);
        }
        /*using MOQ*/
        [Test]
        public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        {
            fileReader.Setup(fr => fr.ReadAllText("video.txt")).Returns("");
            var result = videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ShouldReturnVideo()
        {
            fileReader.Setup(fr => fr.ReadAllText("video.txt")).Returns("{ Id:1, IsProcessed : false, Title:\"A\" }");
            var result = videoService.ReadVideoTitle();
            Assert.That(result, Is.EqualTo("a").IgnoreCase);
        }

        [Test]
        public void UnprocessedVideosAsCsv_WhenCalled_ShouldReturnListOfInt()
        {
            videoRepo.Setup(v => v.GetUnProcessedVideos()).Returns(new List<Video> { new Video { Id = 1 }, new Video { Id = 2 } });

            var ids = videoService.GetUnprocessedVideosAsCsv();
            Assert.That(ids, Is.EqualTo("1,2"));
        }

    }
}

