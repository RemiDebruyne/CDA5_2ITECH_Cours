using exo_4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exo_4.Controllers;
public class ProductController(FakeDb db) : Controller
{
    // GET: ProductController
    public ActionResult Index()
    {

        return View(db.Products);
    }

    // GET: ProductController/Details/5
    public ActionResult Details(Guid id)
    {
        var product = db.Products.SingleOrDefault(p => p.Id == id);
        return View(product);
    }

    // GET: ProductController/Create
    public ActionResult Create()
    {
        Random random = new Random();

        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5),
            Price = random.Next(100),
            Stock = random.Next(100),
        };

        db.Products.Add(product);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Delete(Guid id)
    {
        var product = db.Products.SingleOrDefault(p => p.Id == id);
        db.Products.Remove(product);
        return RedirectToAction(nameof(Index));
    }


    // POST: ProductController/Create
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

    // GET: ProductController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ProductController/Edit/5
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

    // POST: ProductController/Delete/5
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

    public static string RandomString(string chars, int length)
    {
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
