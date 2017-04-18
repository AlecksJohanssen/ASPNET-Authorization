using System.Collections.Generic;

public class Member  
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Article> articles { get; set; } = new List<Article>();
}

public class Repo {
    public List<Member> MemberList { get; set; }
    
}