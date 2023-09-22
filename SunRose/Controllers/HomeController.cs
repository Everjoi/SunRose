using Microsoft.AspNetCore.Mvc;
using SunRose.Models;
using SunRose.Services.Interfaces;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace SunRose.Controllers
{
    public class HomeController:Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMessageService _service;


        public HomeController(ILogger<HomeController> logger, IMessageService service)
        {
            _logger = logger;
           _service = service;
        }

        public IActionResult Index()
        {
            var userId = Request.Cookies["UserId"];

            if(string.IsNullOrEmpty(userId))
            {
                _logger.LogInformation("Create new User");
                userId = Guid.NewGuid().ToString();
            }

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
            };
            Response.Cookies.Append("UserId",userId,cookieOptions);


            return View();
        }



        [HttpPost]
        public IActionResult SaveMessage(string message)
        {
            _logger.LogInformation("Saving message");

           var result = _service.SaveMessage(message,Guid.Parse(Request.Cookies["UserId"]));

            if(result == false)
            {
                _logger.LogWarning("Saving message went wrong");
                return View("Views/Error/ErrorView.cshtml");
            }

            return Ok();
        }


        [HttpGet]
        public IActionResult GetUserMessages()
        {

            var messages = _service.GetUserMessages(Guid.Parse(Request.Cookies["UserId"])).Select(msg => new
            {
                message = msg.Text, 
                date = msg.Timestamp.ToString("dd-MM-yyyy HH:mm"),  
                user = msg.UserId.ToString()
            });

            return Json(messages);
        }


        [HttpGet]
        public IActionResult GetAllMessages(string sortBy)
        {
            
            var messages = _service.GetAllMessages().Select(msg => new  
            {
                message = msg.Text,
                date = msg.Timestamp.ToString("dd-MM-yyyy HH:mm"),
                user = msg.UserId.ToString()
            });


            switch(sortBy)
            {
                case "id":
                    messages = messages.OrderBy(m => m.user).ToList();
                break;

                case "time":
                    messages = messages.OrderBy(m => m.date).ToList();
                break;

                default:
                messages = messages.ToList();
                break;
            }

            return Json(messages);

        }



    }
}