using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
 
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class BookController : Controller
    {
        [Route("book/home")]
 
        public IActoinResult Home(){
            return View();
        }
        [Route("book/books")]
 
        public IActoinResult Books(){
            return View();
        }
        [Route("book/authors")]
 
        public IActoinResult Authors(){
            return View();
        }
        [Route("book/categories")]
 
        public IActoinResult Categories(){
            return View();
        }
    }
}
 
 
 
//Authors.cshtml
 
 
@page
@model dotnetapp.Views.Book.Authors
@{
    ViewData["Title"] = "Authors";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
 
 
//book.cshtml
@page
@model dotnetapp.Views.Book.Books
@{
    ViewData["Title"] = "Books";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
 
 
 
//Categories.cshtml
@page
@model dotnetapp.Views.Book.Categories
@{
    ViewData["Title"] = "Categories";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>

//Bookcontroller
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
 
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class BookController : Controller
    {
        [Route("book/home")]
 
        public IActoinResult Home(){
            return View();
        }
        [Route("book/books")]
 
        public IActoinResult Books(){
            return View();
        }
        [Route("book/authors")]
 
        public IActoinResult Authors(){
            return View();
        }
        [Route("book/categories")]
 
        public IActoinResult Categories(){
            return View();
        }
    }
}
 
 
 
//Authors.cshtml
 
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
 
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class BookController : Controller
    {
        [Route("book/home")]
 
        public IActoinResult Home(){
            return View();
        }
        [Route("book/books")]
 
        public IActoinResult Books(){
            return View();
        }
        [Route("book/authors")]
 
        public IActoinResult Authors(){
            return View();
        }
        [Route("book/categories")]
 
        public IActoinResult Categories(){
            return View();
        }
    }
}
 
 
 
 
//book.cshtml
@page
@model dotnetapp.Views.Book.Books
@{
    ViewData["Title"] = "Books";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
 
 
 
//Categories.cshtml
@page
@model dotnetapp.Views.Book.Categories
@{
    ViewData["Title"] = "Categories";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
 
//home.cshtml
@page
@model dotnetapp.Views.Book.Home
@{
    ViewData["Title"] = "Home";
}
 
<h1>@ViewData["Title"]</h1>
 
<div>
   
</div>
 
