using System.Collections.Generic;

public class Member  
{
    public int Id { get; set; }
    public string First_name { get; set; }
}

public class Repo {
    public List<Member> MemberList { get; set; }
    
}