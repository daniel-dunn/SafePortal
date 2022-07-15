using EasyPortal.Models;
using EasyPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileUserService UserService;
        public User User { get; private set; }

        public PortalItem[] Items { get; private set; }
        public IndexModel(ILogger<IndexModel> logger,
                JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public void OnGet()
        {
            User = UserService.GetUser();
            Items = User.PortalItems;

        }
    }
}