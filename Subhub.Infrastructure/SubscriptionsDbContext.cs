using Microsoft.EntityFrameworkCore;
// imports Subscription
//Entities represent the objects that will be stored in the database
using Subhub.Domain.Entities; 
namespace Subhub.Infrastructure;

//DbContext represents a session with the database, manages the conection with the database
//this class inherits from DbContext - represents database context for managing subscriptions
public class SubscriptionsDbContext : DbContext
{
//constructor class - takes an instance of DbContextOptions as param as pass to DbContext
  public SubscriptionsDbContext(DbContextOptions options) : base(options)
  {

  }
//it represents a collection of Subscription entities. This property will be used to query and manipulate the Subscription entities in the database.
  public DbSet<Subscription> Subscriptions {get; set;}
}
