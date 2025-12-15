using Utilities;
using Utilities.Entities;
using Utilities.Reppository;

ApplicationDbContext context = new();

ContactRepository contactRepository = new(context);

contactRepository.Add(new Contact()
{
    Firstname = "jean",
    Lastname = "paul",
    Birthdate = DateTime.Now.AddYears(-10),
    Email = "mail@mail.com",
    PhoneNumber = "06 01 02 03 04"
});

contactRepository.SaveChanges();

var contact = contactRepository.GetById(1);

Console.WriteLine($"name : {contact.Firstname} {contact.Lastname}, birthdate : {contact.Birthdate}, Email : {contact.Email}, PhoneNumber : {contact.PhoneNumber}");