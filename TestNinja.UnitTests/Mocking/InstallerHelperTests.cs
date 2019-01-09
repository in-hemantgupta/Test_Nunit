using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        Mock<IFileDownloader> _fileDownloader;
        InstallerHelper _helper;

        [SetUp]
        public void Setup()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _helper = new InstallerHelper(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_DownloadFails_ShouldReturnFalse()
        {
            _fileDownloader.Setup(f => f.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _helper.DownloadInstaller("customer", "installer", null);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ShouldReturnTrue()
        {
            var result = _helper.DownloadInstaller("customer", "installer", null);
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
