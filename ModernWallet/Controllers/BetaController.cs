using Microsoft.AspNetCore.Mvc;
using ModernWallet.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace ModernWallet.Controllers
{
    [Route("api/[controller]")]
    public class BetaController : BaseController
    {

        public BetaController(IHostingEnvironment envrnmt):base(envrnmt){}

        // POST api/newsletter
        [HttpPost]
        public IActionResult Post([FromForm]BetaModel beta)
        {
            // This fields must not have any value (robots detection). 
            if (!string.IsNullOrEmpty(beta.Dummy) || !ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return NotFound(errors);
            }

            var newsletterString = JsonConvert.SerializeObject(beta);

            FileHelper.Save(_Env, "/Storage/Beta/", newsletterString);
     
            return Ok(ApplicationSettings.Configuration["Email:Messages:Beta"]);
        }
    }
}
