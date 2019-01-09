using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName, string path)
        {
            try
            {
                _fileDownloader.DownloadFile(string.Format("http://example.com/{0}/{1}", customerName, installerName), path);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}