using Microsoft.AspNetCore.Mvc;
using Mission11_Woodman.Models;
using Mission11_Woodman.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Woodman.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepository;
        public HomeController(IBookRepository temp)
        {
            _bookRepository = temp;
        }

        public IActionResult Index(int pageNum)
        {

            int pageSize = 10;

            var list = new BooksListViewModel
            {
                Books = _bookRepository.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepository.Books.Count()
                }
            };

            return View(list);
        }

    }
}
