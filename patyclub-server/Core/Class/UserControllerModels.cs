public class loginArgs{
    public string account {get; set;}
    public string password {get; set;}
}

public class forgetPwdArgs{
    public string userEmail{get; set;}
}

public class changePwdWithTokenArgs{
    public string token{get; set;}
    public string newPwd{get; set;}
}