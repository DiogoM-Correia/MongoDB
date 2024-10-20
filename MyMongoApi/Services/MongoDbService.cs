using MongoDB.Driver;
using MyMongoApi.Models;

namespace MyMongoApi.Services;

public class MongoDbService
{
    private readonly IMongoCollection<User> _users;
    private readonly IMongoCollection<ShoppingCart> _shoppingCarts;

    public MongoDbService()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("MyMongoDb");

        _users = database.GetCollection<User>("Users");
        _shoppingCarts = database.GetCollection<ShoppingCart>("ShoppingCarts");
    }

    public List<User> GetUsers()
    {
        return _users.Find(user => true).ToList();
    }

    public List<ShoppingCart> GetShoppingCarts()
    {
        return _shoppingCarts.Find(cart => true).ToList();
    }
}