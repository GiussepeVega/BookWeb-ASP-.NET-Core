using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> listaCategoria = _dbContext.Categorias.ToList();
            return View(listaCategoria);
        }

        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria obj)
        {
            //if (obj.nombre == obj.order.ToString())
            //{
            //    ModelState.AddModelError("CustomError", "¡El nombre y el order no pueden ser lo mismo!");
            //}
            if (ModelState.IsValid)
            {
                _dbContext.Add(obj);
                _dbContext.SaveChanges();
                TempData["mensaje"] = "La categoria se creo con exito";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Categoria bean = _dbContext.Categorias.FirstOrDefault(c => c.id==id);
            /*
             o sino tambien:
            _dbContext.Categorias.Find(cod);
            _dbContext.Categorias.SingleOrDefault(c => c.id == cod);
             */
            if(bean == null)
            {
                return NotFound();
            }
            return View(bean);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria obj)
        { 
            if (ModelState.IsValid)
            {
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                TempData["mensaje"] = "La categoria se actualizo con exito";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categoria bean = _dbContext.Categorias.FirstOrDefault(c => c.id == id);
            if (bean == null)
            {
                return NotFound();
            }
            return View(bean);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            Categoria bean = _dbContext.Categorias.Find(id);
            if(bean == null)
            {
                return NotFound();
            }
            _dbContext.Remove(bean);
            _dbContext.SaveChanges();
            TempData["mensaje"] = "La categoria se elimino con exito";
            return RedirectToAction("Index");
        }

    }
}
