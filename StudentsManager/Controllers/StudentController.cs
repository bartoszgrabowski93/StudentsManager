using Microsoft.AspNetCore.Mvc;
using StudentsManager.Models;

namespace StudentsManager.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(string query)
        {
            ViewBag.Opis = "Ponizej znajduje sie lista studentow";
            // 1. Pobieranie danych - zazwyczaj z db
            var dbContext = new StudenciDbContext();
            var studenci = dbContext.Studenci
                    .Where(p1 => string.IsNullOrWhiteSpace(query) || p1.LastName.Contains(query) || p1.Name.Contains(query))
                    .OrderBy(p1 => p1.LastName)
                    .ThenBy(p1 => p1.Name)
                    .ToList();
            return View(studenci);
                     
            
        }

        public IActionResult Details(int id)
        {
            // 1. Z pomocą ID pobrać z BD dane studenta
            // Edit -> Advanced -> Format Document
            Students st = null;
            if (id == 1)
            {
                st = new Students
                {
                    StudentId = 1,
                    Name = "John",
                    LastName = "Smith",
                    Email = "jsmith@googlemail.com",
                    IndexNumber = "pd0001"
                };
            }
            else if (id == 2)
            {
                st = new Students
                {
                    StudentId = 2,
                    Name = "Ann",
                    LastName = "Long",
                    Email = "ahat@googlemail.com",
                    IndexNumber = "pd0002"
                };
            }

            return View(st);
        }
        // Wyswietlanie pustego formularza
        public IActionResult Create()
        {
            return View();
        }
        // Wysylanie danych z wypelnionego formularza za pomoca HttpPost
        [HttpPost]
        public IActionResult Create(Students nowyStudent)
        {
            // Walidacja! - po stronie servera - MUSI BYĆ ZAWSZE!!!
            if (ModelState.IsValid)
            {
                // zapisz do bazy danych 

                var dbContext = new StudenciDbContext();
                dbContext.Studenci.Add(nowyStudent);
                dbContext.SaveChanges();

                // powrót do listy studentów
                return RedirectToAction("Index");
            }

            // dane są niepoprawne
            // wyświetl użytkownikowi błędy

            // Dodanie studenta do bazy danych
            return View(nowyStudent);
        }

        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
