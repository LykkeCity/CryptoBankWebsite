using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace ModernWallet.Controllers
{
    public class BaseController : Controller
    {
        protected IHostingEnvironment _Env;

        public BaseController(IHostingEnvironment envrnmt)
        {
            _Env = envrnmt;
        }
    }
}