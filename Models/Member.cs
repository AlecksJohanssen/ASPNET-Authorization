using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class Member  
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Article> articles { get; set; } = new List<Article>();
}

public class Repo {
    private readonly MemberContext _context;
    public Repo(MemberContext context) {
        _context = context;
    }
    public List<Member> GetAllMember() {
            List<Member> allMembers = new List<Member>();
            allMembers = _context.members.ToList();
            var member = from b in allMembers select b;
            return member as List<Member>;
    }
}