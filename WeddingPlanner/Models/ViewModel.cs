#pragma warning disable CS8618
namespace WeddingPlanner.Models;

class ViewModel
{
    public User User {get;set;} = new User();
    public LoginUser LoginUser {get;set;} = new LoginUser();
}