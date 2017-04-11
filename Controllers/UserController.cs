using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    
    public class UserController : Controller
    {
        private readonly MemberContext _context;

        public UserController(MemberContext context)
        {
            _context = context;
        }
        [HttpGet("user/index")]
        public IActionResult Index()
        {
            ViewBag.data = _context.members.ToList();;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
