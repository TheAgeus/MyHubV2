namespace HubApi.Models
{
  public class User
  {
    public int Id {get;set;}
    public required string FistNames {get;set;}
    public required string PaternalLastName {get;set;}
    public required string MaternalLastName {get;set;}
    public required string Mail {get;set;}
    public required string Password {get;set;}
  }
}