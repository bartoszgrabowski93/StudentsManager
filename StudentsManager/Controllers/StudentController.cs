using Microsoft.AspNetCore.Mvc;
using StudentsManager.Models;

namespace StudentsManager.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {

            // 1. Pobieranie danych - zazwyczaj z db
            var list = new List<Studenci>();
            var s1 = new Studenci
            {
                IdStudent = 1,
                Name = "John",
                LastName = "Smith",
                Email = "jsmith@googlemail.com",
                BirthDate = DateTime.Now
            };
            var s2 = new Studenci
            {
                IdStudent = 2,
                Name = "Ann",
                LastName = "Long",
                Email = "ahat@googlemail.com",
                BirthDate = DateTime.Now
            };
            list.Add(s1);
            list.Add(s2);

            // 2. Dwie metody na przekazanie danych do widoku

            // 2.1 Użycie ViewBag - mniej preferowane, ponieważ jest typem dynamicznym
            ViewBag.Opis = "Ponizej znajduje sie lista studentow";

            // 2.2 Dane silnie typowane - trzeba dodać do widoku "@model List<Studenci>"
            return View(list);
        }
            



           
        

        public IActionResult Details()
        {
            return View();
        }
    }
}
