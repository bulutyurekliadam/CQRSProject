using CQRSProject.CQRSPattern.Commands;
using CQRSProject.CQRSPattern.Handlers;
using CQRSProject.CQRSPattern.Queries;
using CQRSProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CQRSProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategorByIdQueryHandler _getCategorByIdQueryHandler;
        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, GetCategorByIdQueryHandler getCategorByIdQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategorByIdQueryHandler = getCategorByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getCategoryQueryHandler.Handle();

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryCommand command)
        {
            _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = _getCategorByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(values);
        }
    }
}
