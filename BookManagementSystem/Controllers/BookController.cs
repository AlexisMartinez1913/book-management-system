using BookManagementSystem.Dtos;
using BookManagementSystem.Exceptions;
using BookManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooks();
            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _authorService.GetAllAuthors();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO bookDto)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.Authors = await _authorService.GetAllAuthors();
                return View(bookDto);
            }

            try
            {
                await _bookService.CreateBook(bookDto);
                return RedirectToAction("Index");
            }
            catch (MaxBooksExceededException ex) 
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            ViewBag.Authors = await _authorService.GetAllAuthors();
            return View(bookDto);
        }
    }
}
