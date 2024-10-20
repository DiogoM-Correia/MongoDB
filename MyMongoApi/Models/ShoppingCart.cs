namespace MyMongoApi.Models;

public class ShoppingCart
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public List<string> Items { get; set; }
}