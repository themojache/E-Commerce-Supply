using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerceSupply.Models;

namespace ECommerceSupply.Pages {
    //[Route("sign")]
    public class SignInController : Controller {
        public IActionResult Index() {
            ViewData["Message"] = ViewBag.Message = "Invalid and Unhandled Sign Attempt"; //can be handled better on client side but should still be here on server side
            return View("SignIn", new User());
        }
        [HttpPost("sign/in")]
        public IActionResult In(string s_accNum, string s_user, string s_pass, string s_remember) {
            User output;
            if(String.IsNullOrEmpty(s_accNum) || String.IsNullOrEmpty(s_user) || String.IsNullOrEmpty(s_pass)) {
                ViewData["Message"] = ViewBag.Message = "Invalid Sign In Attempt";
                output = new User();
            } else {
                ViewData["Message"] = "Sign In";
                output = new User {
                    Username = s_user,
                    Password = new String('*', s_pass.Length)
                };
                int temp = -1;
                if(Int32.TryParse(s_accNum, out temp)) output.AccountID = temp; //ideally this should not be user input, and just come from the DB (user + pass should be unique). I would not set here like this normally but for demo (sanitized user input), I will
                ViewBag.Message = "Attempted failed as not connected to a SQL database.";
                ViewBag.Remember = s_remember == null ? false : (s_remember.ToLower() == "on"); //"on" should be consistent across all browsers, shouldn't submit to post data if not checked but still good to check if it is "checked" due to potential changes in behavior in the future
            }
            return View("SignIn", output);
        }
        [HttpPost("sign/reg")]
        public IActionResult Reg(string r_user, string r_pass, string r_passC) {
            User output;
            if(String.IsNullOrEmpty(r_user) || String.IsNullOrEmpty(r_pass) || String.IsNullOrEmpty(r_passC)) {
                ViewData["Message"] = ViewBag.Message = "Invalid Registration Attempt"; //can be handled better on client side but should still be here on server side
                output = new User();
            } else {
                var Passwords_Match = r_pass == r_passC;
                ViewData["Message"] = "Register";
                output = new User {
                    Username = r_user
                };
                ViewBag.Message = $"Passwords{(Passwords_Match ? String.Empty : " don't")} Match."; //should be done on client side as well
                if(Passwords_Match) output.Password = new String('*', r_pass.Length);
            }
            
            
            return View("SignIn", output);
        }
        [HttpPost("sign/forgot")]
        public IActionResult Forgot(string txtEmailAddress) {
            User output;
            if(String.IsNullOrEmpty(txtEmailAddress) || String.IsNullOrWhiteSpace(txtEmailAddress)) { //these are both useful for validation but hardly handle all edge cases one should check for, this is just demo functionality
                ViewData["Message"] = ViewBag.Message = "Invalid Attempt to Recover User Details"; //can be handled better on client side but should still be here on server side
                output = new User();
            } else {
                ViewData["Message"] = "Forgot Password";
                output = new User {
                    Email = txtEmailAddress
                };
                ViewBag.Message = "You attempted to recover User info, but this app does not store user info as it is not connected to a database.";
            }
            return View("SignIn", output);
        }
    }
}
