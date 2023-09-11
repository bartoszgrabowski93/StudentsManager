using Microsoft.AspNetCore.Mvc;
using StudentsManager.Models;
using StudentsManager.ViewModels;

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
                    .Where(p1 => string.IsNullOrWhiteSpace(query) || p1.LastName.Contains(query) || p1.Name.Contains(query) || p1.IndexNumber.Contains(query))
                    .OrderBy(p1 => p1.LastName)
                    .ThenBy(p1 => p1.Name)
                    .ToList();

            var vm = new StudenciIndexViewModel();
            vm.Students = studenci;
            vm.Query = query;

            return View(vm);
                     
            
        }

        public IActionResult Details(int id)
        {
            // 1. Z pomocą ID pobrać z BD dane studenta
            // Edit -> Advanced -> Format Document
            var dbContext = new StudenciDbContext();
            var student = dbContext.Studenci
                .FirstOrDefault(s => s.StudentId == id);
            return View(student);
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

        public IActionResult Delete(int id)
        {
            var dbContext = new StudenciDbContext();
            var studentToDelete = new Students();
            studentToDelete.StudentId = id;

            dbContext.Studenci.Attach(studentToDelete);
            dbContext.Studenci.Remove(studentToDelete);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var dbContext = new StudenciDbContext();
            var studentDoEdycji = dbContext.Studenci
                .FirstOrDefault(s => s.StudentId == id);

            return View(studentDoEdycji);
        }
        [HttpPost]
        public IActionResult Edit(Students edytowanyStudent)
        {

            if (ModelState.IsValid)
            {
                var dbContext = new StudenciDbContext();
                dbContext.Studenci.Attach(edytowanyStudent);
                dbContext.Studenci.Update(edytowanyStudent);
                dbContext.SaveChanges();
                         
                return RedirectToAction("Index");
            }
                       
            return View(edytowanyStudent);
        }
    }
}
