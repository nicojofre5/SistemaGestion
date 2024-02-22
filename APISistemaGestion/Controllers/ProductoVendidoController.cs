using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISistemaGestion.Controllers
{
    public class ProductoVendidoController : Controller
    {
        // GET: ProductoVendidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductoVendidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoVendidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoVendidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoVendidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoVendidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoVendidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoVendidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
