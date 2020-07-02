using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IOTManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IOTManagementApp.Areas.Identity.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ILogger<LoginModel> _logger;

        public ChangePasswordModel(SignInManager<User> signInManager,
            ILogger<LoginModel> logger,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.ChangePassword = 0;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
                var result = await _userManager.ChangePasswordAsync(user, "BygMig123!" ,Input.Password);
     
                return LocalRedirect(returnUrl);
            }

            return Page();
        }
    }
}
