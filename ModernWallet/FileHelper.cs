using Microsoft.AspNetCore.Hosting;
using System;

namespace ModernWallet
{
    public static class FileHelper
    {
        public static void Save(IHostingEnvironment env, string path, string content)
        {
            var webRootInfo = string.Format("{0}{1}", env.ContentRootPath, path);
            var file = System.IO.Path.Combine(webRootInfo, string.Format("{0}.json", DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss.fff")));
            System.IO.File.WriteAllText(file, content);
        }
    }
}
