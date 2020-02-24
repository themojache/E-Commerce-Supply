using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceSupply.Pages {
    public class ContactModel : PageModel {
        public string Message { get; set; }

        public void OnGet() {
            Message = "We want to hear from you.";
        }
    }
}
