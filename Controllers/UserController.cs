using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    
    public class UserController : Controller
    {
        private readonly MemberContext _context;

        public UserController(MemberContext context)
        {
            _context = context;
        }
       [HttpGet("user/blah")]
        public IActionResult blah()
        {
            var data = _context.articles.ToList();
            return View(data);
        }
        [HttpGet("user/member")]
        public IActionResult Member()
        {
            Repo rp = new Repo(_context);
            ViewBag.content= rp.GetAllMember();
            return View();
        }
        [HttpGet("user/linq")]
        public IActionResult Linq2()
        {
            Repo rp = new Repo(_context);
            ViewBag.content= rp.GetAllMemberWithName();
            return View();
        }
        [HttpGet("user/newmember")]
        public IActionResult newmember()
        {
            Repo rp = new Repo(_context);
            rp.createNewMember();
            return View();
        }

        [HttpGet("user/article")]
        public IActionResult article()
        {
            Repo rp = new Repo(_context);
            ViewBag.content= rp.GetThisMemberArticle();
            return View();
        }

        public List<Member> GetAll() {
            return _context.members.ToList();
        }

        [HttpGet("user/updatemember")]
        public IEnumerable<Member> updatemember()
        {
            Repo rp = new Repo(_context);
            rp.updateMember(1);
            var data = _context.members.Include(d => d.articles);
            return data;
        }
        [HttpGet("user/updatememberwitharticle")]
        public IEnumerable<Member> updatememberwitharticle()
        {
            Repo rp = new Repo(_context);
            rp.updateMemberWithArticle(2);
            var data = _context.members.Include(d => d.articles);
            return data;
        }
        [HttpGet("user/deletemember")]
        public IEnumerable<Member> deletemember()
        {
            Repo rp = new Repo(_context);
            rp.deleteMember(2);
            var data = _context.members.Include(d => d.articles);
            return data;
        }

        [HttpGet("user/deletearticle")]
        public IEnumerable<Member> deletearticle()
        {
            Repo rp = new Repo(_context);
            rp.deleteMemberWithArticle(2);
            var data = _context.members.Include(d => d.articles);
            return data;
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
