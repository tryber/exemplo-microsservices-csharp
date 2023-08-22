namespace AuthService.Models;
public class AuthToken{
    public string? Token {get; set;}
    public int ExpiresIn { get; set; }

    public AuthToken(string? token, int expiresIn){
        Token = token;
        ExpiresIn = expiresIn;
    }
};