using BookManagementSystem.Dtos;
using BookManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthors();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDTO authorDto)
        {
            if (!ModelState.IsValid)
            {
                return View(authorDto);
            }

            await _authorService.CreateAuthor(authorDto);
            return RedirectToAction("Index");
        }
    }
}
