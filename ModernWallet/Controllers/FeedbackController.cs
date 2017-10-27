using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ModernWallet.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace ModernWallet.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : BaseController
    {
        public FeedbackController(IHostingEnvironment envrnmt) : base(envrnmt) { }

        // POST api/feedback
        [HttpPost]
        public IActionResult Post([FromForm]FeedbackModel feedback)
        {
            // This fields must not have any value (robots detection). 
            if (!string.IsNullOrEmpty(feedback.Dummy) || !ModelState.IsValid)
            {
                return NotFound();
            }

            EmailSender.SendFeedback(feedback);

            var feedbackString = JsonConvert.SerializeObject(feedback);

            FileHelper.Save(_Env, "/Storage/Feedbacks/", feedbackString);

            return Ok(ApplicationSettings.Configuration["Email:Messages:Feedback"]);
        }

    }
}
