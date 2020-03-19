using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VisitingStolac.Web.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Post/{id}")]
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
