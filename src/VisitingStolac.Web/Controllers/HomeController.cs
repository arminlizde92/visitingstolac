using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.Common;
using VisitingStolac.Web.ViewModels.Home;

namespace VisitingStolac.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<PostDto> posts = new List<PostDto>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://api.visitstolac.info/api/Post/All/3/1/ENG").Result;
                if(response.IsSuccessStatusCode)
                {
                    posts = response.Content.ReadAsAsync<List<PostDto>>().Result;
                }
            }
             return View(new HomeIndexVM() { posts = posts });
        }

        public IActionResult Route()
        {
            return View();
        }

        public IActionResult PostDetails(int id)
        {
            return View();
        }
    }
}
