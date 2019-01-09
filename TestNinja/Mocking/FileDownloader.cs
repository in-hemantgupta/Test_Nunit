using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestNinja.Mocking
{
    class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
