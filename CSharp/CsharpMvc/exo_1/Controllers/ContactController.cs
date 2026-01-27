using exo_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace exo_1.Controllers;

public class ContactController : Controller
{
    public IActionResult Contacts()
    {
        ViewBag.Contacts = new List<string>() { "jean", "marie", "lisa", "paul" };

        List<Contact> contacts = [
            new(){
                Name = "Jack"
            },
            new(){
                Name = "steve"
            }];

        ContactList contacts2 = new()
        {
            Contacts = [
        new(){
                    Name = "Jack"
                },
                new(){
                    Name = "steve"
                }]
        };

        return View(contacts);
    }

    public IActionResult DisplayContact()
    {
        ViewData["contact"] = "Pierre";
        return View();
    }

    public IActionResult AddContact()
    {
        return View();
    }
}
