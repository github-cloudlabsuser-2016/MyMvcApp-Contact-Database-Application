using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
namespace MyMvcApp.Controllers
{
    public class UserController : Controller
    {
        public static List<User> Users { get; set; } = new List<User>();

        public IActionResult Index()
        {
            return View(Users);
        }

        public IActionResult Details(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            Users.Add(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(int id, User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            // Update other properties as needed

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Users.Remove(user);
            return RedirectToAction(nameof(Index));
        }
    }

}
