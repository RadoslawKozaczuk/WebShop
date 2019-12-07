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
        // GET /admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in _context.Pages orderby p.Sorting select p;
            List<Page> pageList = await pages.ToListAsync();

            // we do not specify the view name here so by default it will look for the View with the method name which is "Index" in this case
            return View(pageList);
        }

        // GET /admin/pages/details/6
        public async Task<IActionResult> Details(int id)
        {
            Page page = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if(page == null)
                return NotFound();

            return View(page);
        }

        // GET /admin/pages/create
        public IActionResult Create() => View();

        // POST /admin/pages/details/6
        [HttpPost] // if we don't specify the request attribute it is GET by default
        public async Task<IActionResult> Create(Page page)
        {
            // model binding - it is a way to pass data to methods
            if(ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if(slug != null)
                {
                    ModelState.AddModelError("", "The title already exists.");
                    return View(page);
                }

                _context.Add(page);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(page);
        }
    }
}