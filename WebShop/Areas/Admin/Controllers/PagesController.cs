using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Infrastructure;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        readonly WebShopContext _context;

        public PagesController(WebShopContext context)
        {
            _context = context;
        }

        // IActionResult can return more on less anything
        // if you want to be more specific use for example IRedirectResult
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in _context.Pages orderby p.Sorting select p;
            List<Page> pageList = await pages.ToListAsync();

            // we do not specify the view name here so by default it will look for the View with the method name which is "Index" in this case
            return View(pageList);
        }
    }
}