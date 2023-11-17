using GreenFlix.Data;
using GreenFlix.Data.Models;
using GreenFlix.Infrastructure;
using GreenFlix.Models.Provaiders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GreenFlix.Controllers
{
    public class ProvaidersController : Controller
    {
        private readonly GreenFlixDbContext data;

        public ProvaidersController(GreenFlixDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeProvaiderFormModel provaider)
        {
            var userId = this.User.GetId();


            var userIdAlredyProvaider = this.data
                .Provaiders
                .Any(p => p.UserId == userId);

            if (userIdAlredyProvaider)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(provaider);
            }

            var provaiderData = new Provaider
            {
                Name = provaider.Name,
                PhoneNumber= provaider.PhoneNumber,
                UserId = userId
            };

            this.data.Provaiders.Add(provaiderData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(MovieController.All), "Movies");
        }
    }
}
