W4 D1 S1 Q2
 
//blogcontroller
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace dotnetapp.Controllers
{
    public class BlogController : Controller
    {
        [Route("blog/home")]
        public IActionResult Home(){
         return View();
        }
        [Route("blog/posts")]
        public IActionResult Posts(){
         return View();
        }
        [Route("blog/authors")]
        public IActionResult Authors(){
         return View();
        }
        [Route("blog/categories")]
        public IActionResult Categories(){
         return View();
        }
    }
}
 
 
 
//authors.cshtml
 
 
@page
@model dotnetapp.Views.Blog.Authors
@{
    ViewData["Title"] = "Authors";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
 
//categories.cshtm
 
@page
@model dotnetapp.Views.Blog.Categories
@{
    ViewData["Title"] = "Categories";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
 
 
//home.cshtml
 
@page
@model dotnetapp.Views.Blog.Home
@{
    ViewData["Title"] = "Home";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
//post.cshtml
 
@page
@model dotnetapp.Views.Blog.Posts
@{
    ViewData["Title"] = "Posts";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
