using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceSupply.Pages {
    public class AboutModel : PageModel {
        public string Message { get; set; }

        public void OnGet() {
            Message = "You Demand. We Supply. Thats just the way it is.";
        }
    }
}
