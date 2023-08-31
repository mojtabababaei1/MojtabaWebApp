﻿using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CodeYad_Blog.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [BindProperty]
        public string UserName { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        [BindProperty]
        public string Password { get; set; }
        public List<UserDto> user { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var user = _userService.LoginUser(new LoginUserDto()
            {
                Password = Password,
                UserName = UserName
            });

            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(claimPrincipal, properties);
            return RedirectToPage("../Index");
        }
    }
}
