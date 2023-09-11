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
                IndexNumber = "pd0001"
            };
            var s2 = new Studenci
            {
                IdStudent = 2,
                Name = "Ann",
                LastName = "Long",
                Email = "ahat@googlemail.com",
                IndexNumber = "pd0002"
            };
            list.Add(s1);
            list.Add(s2);

            // 2. Dwie metody na przekazanie danych do widoku

            // 2.1 Użycie ViewBag - mniej preferowane, ponieważ jest typem dynamicznym
            ViewBag.Opis = "Ponizej znajduje sie lista studentow";

            // 2.2 Dane silnie typowane - trzeba dodać do widoku "@model List<Studenci>"
            return View(list);
        }

        public IActionResult Details(int id)
        {
            // 1. Z pomocą ID pobrać z BD dane studenta
            // Edit -> Advanced -> Format Document
            Studenci st = null;
            if (id == 1)
            {
                st = new Studenci
                {
                    IdStudent = 1,
                    Name = "John",
                    LastName = "Smith",
                    Email = "jsmith@googlemail.com",
                    IndexNumber = "pd0001"
                };
            }
            else if (id == 2)
            {
                st = new Studenci
                {
                    IdStudent = 2,
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
        public IActionResult Create(Studenci nowyStudent)
        {
            // Walidacja! - po stronie servera - MUSI BYĆ ZAWSZE!!!
            if (ModelState.IsValid)
            {
                // zapisz do bazy danych 
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
