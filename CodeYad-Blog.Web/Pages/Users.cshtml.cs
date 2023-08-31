using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeYad_Blog.Web.Pages
{
    public class UsersModel : PageModel
    {
        private readonly IUserService _userService;
        public UsersModel(IUserService userService)
        {
            _userService = userService;
        }

       
        public int UserId { get; set; }
        public string UserName { get; set; }

       
        public void OnGet()
        {
        }
    }
}
