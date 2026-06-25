using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


[CollectionName("Users")]

public class AppUser : MongoIdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}