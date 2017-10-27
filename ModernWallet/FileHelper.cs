using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernWallet
{
    public static class FileHelper
    {
        public static void Save(IHostingEnvironment env, string path, string content)
        {
            var webRootInfo = string.Format("{0}{1}", env.ContentRootPath, path);
            var file = System.IO.Path.Combine(webRootInfo, string.Format("{0}.json", DateTime.Now));
            System.IO.File.WriteAllText(file, content);
        }
    }
}
