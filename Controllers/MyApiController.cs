using Microsoft.AspNetCore.Mvc;
using MyMongoApi.Services;
using MyMongoApi.Models;

namespace MyProject.Controllers;

[ApiController]
[Route("[controller]")]
public class MyApiController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;
    public MyApiController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet("users")]
    public ActionResult<List<User>> GetUsers()
    {
        return _mongoDbService.GetUsers();
    }

    [HttpGet("shoppingcarts")]
    public ActionResult<List<ShoppingCart>> GetShoppingCarts()
    {
        return _mongoDbService.GetShoppingCarts();
    }
}