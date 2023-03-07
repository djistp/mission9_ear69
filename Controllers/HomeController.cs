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
        public IActionResult Index(string bookCategory,int pageNum = 1)
        {
            int pageSize = 10;
            var x = new BooksViewModels
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Category)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                    (bookCategory == null 
                        ? repo.Books.Count()
                        : repo.Books.Where(x=> x.Category== bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };
            return View(x);
        }
    }
}
