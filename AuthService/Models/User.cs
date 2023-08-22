namespace AuthService.Models;
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string[] Scopes { get; set; }

    public User(string username, string password, string role, string[] scopes){
        Username = username;
        Password = password;
        Role = role;
        Scopes = scopes;
    }
};