using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public IEnumerable<Member> Get()
        {
            var data = _context.members.Include(d => d.articles);
            return data;
        }
        
        public IActionResult Index()
        {
            ViewBag.dataContent = _context.members.ToList();
            return View();
        }

        public List<Member> GetAll() {
            return _context.members.ToList();
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
