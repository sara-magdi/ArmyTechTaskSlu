using Army.Core.Infrastructure.Enums;
using Army.Core.Infrastructure.Models.DTOs;
using Army.Core.Infrastructure.Models.Entites.Common;
using Meshini.Core.BLL.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: CardProducts
        public async Task<IActionResult> Index()
        {
            return View((await _cardProductdDomain.GetAll()).Items);
        }
        // GET: CardProducts/Create
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

        // GET: CardProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CardProductDTO cardProduct = (await _cardProductdDomain.GetById(id.Value)).Entity;
            return cardProduct == null ? NotFound() : View(cardProduct);
        }

        // POST: CardProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CardProductDTO cardProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ResultEntity<CardProductDTO> UpdatecardProductResult = await _cardProductdDomain.Update(cardProduct);
                    if (UpdatecardProductResult.Status == StatusEnum.Success)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        foreach (string message in UpdatecardProductResult.Messages)
                        {
                            ModelState.AddModelError("", message);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await cardProductExists(cardProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cardProduct);
        }

        // GET: CardProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CardProductDTO cardProduct = (await _cardProductdDomain.GetById(id.Value)).Entity;
            return cardProduct == null ? NotFound() : View(cardProduct);
        }

        // POST: CardProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CardProductDTO cardProduct = (await _cardProductdDomain.GetById(id)).Entity;
            CardProductDTO x = (await _cardProductdDomain.Delete(cardProduct)).Entity;
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> cardProductExists(int id)
        {
            ResultEntity<CardProductDTO>cardProductResult = await _cardProductdDomain.GetById(id);
            CardProductDTO cardProduct = cardProductResult.Entity;
            return cardProduct != null;
        }
    }
}
