using Microsoft.AspNetCore.Mvc;
using mission9_ear69.Models;
using mission9_ear69.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_ear69.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo; 

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;
            var x = new BooksViewModels
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };
            return View(x);
        }
    }
}
