using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader FileReader { get; set; }
        private IVideoRepository VideoRepository { get; set; }

        public VideoService(IFileReader fileReader, IVideoRepository videoRepository)
        {
            FileReader = fileReader;
            VideoRepository = videoRepository;
        }

        public string ReadVideoTitle()
        {
            var str = FileReader.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        //public string ReadVideoTitle(IFileReader fileReader)
        //{
        //    var str = fileReader.ReadAllText("video.txt");
        //    var video = JsonConvert.DeserializeObject<Video>(str);
        //    if (video == null)
        //        return "Error parsing the video.";
        //    return video.Title;
        //}

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = VideoRepository.GetUnProcessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}