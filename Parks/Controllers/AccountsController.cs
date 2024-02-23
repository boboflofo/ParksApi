using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Parks.Models;

namespace Parks.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager; ;
        _signInManager = signInManager;
        _configuration = configuration;
    }


}