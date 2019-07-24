using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication5.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication5.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Home/Modules");

            if (ModelState.IsValid)
            {
                // check if user accounts exisits in original db
                var mypassword = "";
                using (var db = new ModelDbContext())
                {
                    // check for exsisting account email
                    var myuser = db.Users.Where(x => x.Email == Input.Email).SingleOrDefault();
                    if (myuser != null)
                    {
                        // check password
                        mypassword = myuser.Password;
                        if (Input.Password == myuser.Password)
                        {
                            // forward request to new login

                            //
                            //
                            // This doesn't count login failures towards account lockout
                            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                            //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                            if (result.Succeeded)
                            {
                                int userId = 0;
                                CookieOptions option = new CookieOptions();
                                option.Expires = DateTime.Now.AddMinutes(1200);
                                option.IsEssential = true;

                                var user = db.Users.Where(x => x.Email == Input.Email);
                                if (user.Any())
                                {
                                    userId = user.Single().User_Id;
                                    Response.Cookies.Append("uID", userId.ToString(), option);
                                    Response.Cookies.Append("uN", user.Single().First_Name, option);

                                }
                                _logger.LogInformation("User logged in.");
                                //await _signInManager.SignInAsync(user, isPersistent: true);
                                if (Request.Cookies.Where(x => x.Key == "lastVisited").Any())
                                {
                                    var lastVisited = (Request.Cookies.Where(x => x.Key == "lastVisited").SingleOrDefault().Value.ToString());
                                    if (lastVisited == "PreTest")
                                        return LocalRedirect("~/CME/PreTest/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                    else if (lastVisited == "Activity")
                                        return LocalRedirect("~/CME/Activity/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString() + "/0");
                                    else if (lastVisited == "PostTest")
                                        return LocalRedirect("~/CME/PostTest/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                    else if (lastVisited == "Results")
                                        return LocalRedirect("~/CME/Results/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                    else if (lastVisited == "ClaimCredit")
                                        return LocalRedirect("~/CME/ClaimCredit/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                    else if (lastVisited == "Evaluation")
                                        return LocalRedirect("~/CME/Evaluation/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                }
                                return LocalRedirect(returnUrl);
                            }
                            else
                            {
                                // create new account in identity user table
                                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                                var resultCreate = await _userManager.CreateAsync(user, Input.Password);
                                if (resultCreate.Succeeded)
                                {
                                    await _signInManager.SignInAsync(user, isPersistent: true);
                                    int userId = 0;
                                    CookieOptions option = new CookieOptions();
                                    option.Expires = DateTime.Now.AddMinutes(1200);
                                    option.IsEssential = true;

                                    var userExisting = db.Users.Where(x => x.Email == Input.Email);
                                    if (userExisting.Any())
                                    {
                                        userId = userExisting.Single().User_Id;
                                        Response.Cookies.Append("uID", userId.ToString(), option);
                                        Response.Cookies.Append("uN", userExisting.Single().First_Name, option);

                                    }
                                    if (Request.Cookies.Where(x => x.Key == "lastVisited").Any())
                                    {
                                        var lastVisited = (Request.Cookies.Where(x => x.Key == "lastVisited").SingleOrDefault().Value.ToString());
                                        if (lastVisited == "PreTest")
                                            return LocalRedirect("~/CME/PreTest/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                        else if (lastVisited == "Activity")
                                            return LocalRedirect("~/CME/Activity/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString() + "/0");
                                        else if (lastVisited == "PostTest")
                                            return LocalRedirect("~/CME/PostTest/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                        else if (lastVisited == "Results")
                                            return LocalRedirect("~/CME/Results/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                        else if (lastVisited == "ClaimCredit")
                                            return LocalRedirect("~/CME/ClaimCredit/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                        else if (lastVisited == "Evaluation")
                                            return LocalRedirect("~/CME/Evaluation/" + Request.Cookies.Where(x => x.Key == "CaseId").SingleOrDefault().Value.ToString());
                                    }
                                    return LocalRedirect(returnUrl);
                                }
                            }
                            //if (result.RequiresTwoFactor)
                            //{
                            //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                            //}
                            if (result.IsLockedOut)
                            {
                                _logger.LogWarning("User account locked out.");
                                return RedirectToPage("./Lockout");
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                                return Page();
                            }
                            //
                            //


                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }


            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
