using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


[CollectionName("Users")]

public class AppUser : MongoIdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string SupportEmail { get; set; }
}