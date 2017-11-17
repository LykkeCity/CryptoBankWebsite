using Microsoft.AspNetCore.Mvc;
using ModernWallet.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace ModernWallet.Controllers
{
    [Route("api/[controller]")]
    public class NewsletterController : BaseController
    {

        public NewsletterController(IHostingEnvironment envrnmt) :base(envrnmt) {}

        // POST api/newsletter
        [HttpPost]
        public IActionResult Post([FromForm]NewsletterModel newsletter)
        {
            // This fields must not have any value (robots detection). 
            if (!string.IsNullOrEmpty(newsletter.Dummy) || !ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return NotFound(errors);
            }

            AzureStorageHelper.Store(newsletter);

            return Ok(ApplicationSettings.Configuration["Email:Messages:Newsletter"]);
        }
    }
}
