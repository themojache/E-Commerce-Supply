# E-Commerce-Supply
Demo ASP.NET Core E-Commerce Supply Site

To open Clone/Download the master branch of the repository. Open 
E-Commerce-Supply (either the sln or the csproj file). Run using ISS Express (Ctrl + F5, F5, or the Run button from withing Visual Studio).

Completed at the request of a recruitment agency asking if I could create a quick clone of their clients webite. This was written over a couple days. Designed it with a setup-less design in mind (no SQL database connection dependancies). Use of SQL is the [second thing you are recommended to look at when you initally start working with ASP](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql).

My main desire was to touch up the site and remove some of the Javascript and library dependancies. I have learned that it is good web design to prevent repetative redirects with menus and to creativly pop up elements in ways which don't require Javascript. Javascript is used in storing Cart information, which would be verified when going to place an order.

The Client's site uses IcoMoon font files (some premium varient). I have removed the premium font files from the repositiory in order to not violate any licencing. I have opted to include the IcoMoon-Free varient to display some of the icons of the site.

Some images and text were sampled from the client. This site was based on their site, just re-wrote it as an example ASP.NET Core E-Commerce site.

## Tech Stack
ASP.NET Core (HTML5, CSS3, Javascript). Mostly adheres to spec. I'm sure there are a few CSS property values or something that I use which have cross browser support but are not in the spec.

## Todo
1. Plenty of UI touch up work (Mostly a focus on Responsive Design as this was all done on a large resolution monitor, though there is some responsive design implemented already).
2. Clean up Javascript (re-write). Also make the localStorage less verbose (Store: ID, Name, Price, and Quantity). Could add a small (reversable) barrier by encoding the data in the cart.
3. Implement some SQL, for User/Items. Would be able to add filterabilty on search rather easy with an actual database.
4. Make it so people could actually order items (Payment processing)
