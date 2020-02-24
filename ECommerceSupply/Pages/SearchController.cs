using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerceSupply.Models;

namespace ECommerceSupply.Pages {
    //[Route("search")]
    public class SearchController : Controller {
        public IActionResult Index() {
            return View("Results", new Results {
                Message = "You sucessfully searched for nothing!"
            });
        }
        [HttpGet("Search")]
        public IActionResult Index(string q) { //if I made a global search variable I could check for Name contains here
            if(q == null || String.IsNullOrEmpty(q)) return Index();
            var output = new Results {
                Message = $"Searching for \"{q}\""
            };
            //ViewData["Message"] = ViewBag.Message = output;
            return View("Results", output);
        }
        public IActionResult Flag(string id) { //if I made a global search variable I could check if item has a Flag of id
            if(id == null) return NotFound(Index()); //demonstration of another handler, Ok/Content are some others used
            var output = new Results {
                Message = $"Searching for Items considered \"{id}\""
            };
            return View("Results", output);
        }
        public IActionResult Market(string id, string groupID) {
            string outputStr = "This is my default Market";
            if(groupID != null) outputStr += "/sectionID";
            if(id == null) return View("Results", new Results { Message = outputStr });
            outputStr = $"Searching for Items in the \"{id}\" market";
            if(groupID != null) outputStr += $" and in the \"{groupID}\" section.";
            var itemList = new List<Item>(); //generally use SQL here rather than returning a specific list, less setup seems better for demo purposes
            switch(id.ToLower()) {
                case "lamps":
                    itemList.Add(new Item { Name = "Lamp", Price = (decimal)3.50, Quantity = 10000 });
                    break;
                case "datacomm":
                    itemList.Add(new Item { Quantity = 12 });
                    itemList[0].Name = "Ethernet"; //not "going to affect performance" to deal with a list like so, but should use better instanciation methods, just an example
                    itemList[0].Price = (decimal)99.99;
                    itemList[0].AvalibleUntil = new DateTime(2025, 10, 25); //"New Model" planned or something
                    break;
                default:
                    break;
            }
            var output = new Results {
                Message = outputStr,
                Items = itemList
            };
            return View("Results", output);//return Content(output, "text/html");
        }
        public IActionResult Section(string id, string groupID) {
            string outputStr = "This is my default section";
            if(groupID != null) outputStr += "/group";
            if(id == null) return View("Results", new Results {Message = outputStr});
            outputStr = $"Searching for Items with SectionID of \"{id}\"";
            if(groupID != null) outputStr += $" and GroupID of \"{groupID}\"";
            var itemList = new List<Item>(); //generally use SQL here rather than returning a specific list, less setup seems better for demo purposes
            switch(id) {
                case "2":
                    itemList.Add(new Item { Quantity = 12, Image = "/images/icons/02IconBoxes.png" });
                    itemList[0].Name = "Metal Switch Box"; //not "going to affect performance" to deal with a list like so, but should use better instanciation methods, just an example
                    itemList[0].Price = (decimal)5.50;
                    break;
                case "10":
                    itemList.Add(new Item { Image = "/images/icons/02IconLamps.png", Quantity = 32, Name = "Bulb", Price = (decimal)2.01 });
                    itemList.Add(new Item { Quantity = 32, Name = "LED Light", Price = (decimal)3.01 });
                    itemList.Add(new Item { Quantity = 50, Name = "Headband LED Light", Price = (decimal)12.01 });
                    itemList.Add(new Item { Quantity = 7, Name = "Wrist LED Light", Price = (decimal)4.31 });
                    break;
                default:
                    break;
            }
            return View("Results", new Results { Message = outputStr, Items = itemList });
            //return Content(outputStr, "text/html");
        }
    }
}
