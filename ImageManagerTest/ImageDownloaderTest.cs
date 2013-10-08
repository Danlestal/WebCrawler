using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManager;

namespace ImageManagerTest
{
    [TestClass]
    public class ImageDownloaderTest
    {
        [TestMethod]
        public void DownloadRemoteImageFile()
        {
            string url = @"http://i.imgur.com/XlGVIAO.png";

            ImageDownloader downloader = new ImageDownloader();
            downloader.DownloadRemoteImageFile(url, @"E:\lol\lol.png");
        }
    }
}
