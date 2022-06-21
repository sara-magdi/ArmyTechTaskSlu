using Army.Core.Infrastructure.Models.DTOs;
using Meshini.Core.BLL.Domains;
using Microsoft.AspNetCore.Mvc;

namespace ArmyTechTask.Controllers
{
    public class CardProductsController :Controller
    {
        private readonly CardProductDomain _cardProductdDomain;

        public CardProductsController(CardProductDomain cardProductdDomain)
        {
            _cardProductdDomain = cardProductdDomain;
        }
        public async Task<IActionResult> ConfirmOrder()
        {
            return View((await _cardProductdDomain.GetAll()).Items);
        }

        // GET: Backers/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Backers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CardProductDTO CardProduct)
        {
            if (ModelState.IsValid)
            {
                var InsertBackers = (await _cardProductdDomain.Insert(CardProduct)).Entity;
                return RedirectToAction(nameof(Index));
            }
            return View(CardProduct);
        }
    }
}
