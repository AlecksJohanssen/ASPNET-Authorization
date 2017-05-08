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
    public IEnumerable<Member> GetAllMember() {
            IEnumerable<Member> allMembers;
            allMembers = _context.members.ToList();
            var member = from user in allMembers select user; // LINQ 
            return member as IEnumerable<Member>;
    }

    public IEnumerable<Member> test() {
        IEnumerable<Member> members = _context.members.ToList();
        var selected = _context.members.Where(hello => hello.id == 2);// LAMBDA EXPRESSION
        var test = from member in _context.members where member.id == 2 select member; // NO LAMBDA EXPRESSION
        return selected as IEnumerable<Member>;
    }


    public IEnumerable<Member> GetAllMemberWithName() {
        IEnumerable<Member> members = _context.members.ToList();
        var selectedMember = _context.members.Where(user => user.name == "VuongCBR" && user.id == 1).ToList();
        return selectedMember as IEnumerable<Member>;
    }

    public IEnumerable<Member> GetThisMemberArticle() {
        IEnumerable<Member> members = _context.members.ToList();
        var selectedArticle = _context.members.Where(user => user.name == "VuongCBR").Include(article => article.articles).ToList();
        return selectedArticle as IEnumerable<Member>;
    }
   // public IEnumerable<Member> GetMemberWithName() {
     //   var members = from details in _context.members where details.name == "Johannes" select details;
    //}

    public void createNewMember() {
        Member member = new Member();
        member.name = "AlecksJohannes";
        member.articles = new List<Article>();
        _context.members.Add(member);
        _context.SaveChanges();
    }

    public void createMemberWithArticle() {
        Member member = new Member();
        member.name = "AlecksJohannes";
        member.articles = new List<Article>();
        Article article = new Article();
        article.memberid = 1;
        article.title = "Hello Wolrd";
        article.content = "AlecksJohanna";
        member.articles.Add(article);
        _context.members.Add(member);
        _context.SaveChanges();
    }

    public void updateMember(int id) {
        var currentMember = _context.members.Where(member => member.id == 2).FirstOrDefault();
        currentMember.name = "John Wick";
        _context.SaveChanges();
    }

    public void updateMemberWithArticle(int id) {
        var currentMember = _context.members.Where(member => member.id == id).Include(article => article.articles).FirstOrDefault();
        currentMember.name = "JohannesBurg";
        var thisArticle = currentMember.articles.FirstOrDefault();
        thisArticle.title = "I hope no one sees me";
        _context.SaveChanges();
    }

    public void deleteMember(int id) {
        var deleteOrderDetails =
        from details in _context.members
        where details.id == id
        select details;
        _context.members.Remove(deleteOrderDetails.FirstOrDefault());
        _context.SaveChanges();
    }

    public void deleteMemberWithArticle(int dataId) {
        var thisMember = from details in _context.members.Include(member => member.articles)
        where details.id == dataId
        select details;
        Console.WriteLine(new DateTime());
        _context.articles.Remove(thisMember.FirstOrDefault().articles.FirstOrDefault());
        _context.SaveChanges();
    }
}