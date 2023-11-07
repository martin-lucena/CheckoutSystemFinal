using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckoutSystem.DataAccess;
using CheckoutSystem.Models;
using CheckoutSystem.ViewModels;

namespace CheckoutSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CheckoutSystemDbContext _context;

        public CustomersController(CheckoutSystemDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return _context.Customers != null ? 
                          View(await _context.Customers.ToListAsync()) :
                          Problem("Entity set 'CheckoutSystemDbContext.Customers'  is null.");
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Include(c => c.Films)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Email,CustomerType")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Email,CustomerType")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'CheckoutSystemDbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> CalculateTotalPrice(int customerId, int numDVDFilms, int numBluRayFilms)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            decimal total;
            if (customer.CustomerType == Enums.CustomCustomerType.Member)
            {
                total = CalculateMemberPrice(numDVDFilms, numBluRayFilms);
            }
            else
            {
                total = CalculateNotMemberPrice(numDVDFilms, numBluRayFilms);
            }
            ViewBag.TotalPrice = total;
            return View("AllCustomersTotalPayments");
        }

        private decimal CalculateMemberPrice(int numDVDFilms, int numBluRayFilms)
        {

            decimal dvdPrice = 29;
            decimal bluRayPrice = 39;
            decimal discountDVD = 0.10m;
            decimal discountBluRay = 0.15m;
            decimal total = 0;

            // Calculate the total price for the rented DVDs and BluRay films without the discount
            decimal totalPriceWithoutDiscount = (numDVDFilms * (1 - discountDVD) * dvdPrice) + (numBluRayFilms * (1 - discountBluRay) * bluRayPrice);

            // Check if the member rents 4 films or fewer
            if (numDVDFilms + numBluRayFilms < 4)
            {
                total = totalPriceWithoutDiscount;
            }

            // Check if the member rents more than 4 films
            else
            {
                // Calculate the price for the first 4 films (100 SEK)
                total += 100;

                // Calculate the price for the fifth film based on its type
                if (numDVDFilms + numBluRayFilms > 4)
                {
                    total += (numDVDFilms - 4) * (dvdPrice * (1 - discountDVD) + (numBluRayFilms - 4) * (bluRayPrice * (1 - discountBluRay)));
                }
                else if (numDVDFilms > 4)
                {
                    total += (numDVDFilms - 4) * (dvdPrice * (1 - discountDVD));
                }
                else if (numBluRayFilms > 4)
                {
                    total += (numBluRayFilms - 4) * (bluRayPrice * (1 - discountBluRay));
                }
            }

            return total;
        }

        private decimal CalculateNotMemberPrice(int numDVDFilms, int numBluRayFilms)
        {
            decimal dvdPrice = 29;
            decimal bluRayPrice = 39;

            decimal total = (numDVDFilms * dvdPrice) + (numBluRayFilms * bluRayPrice);
            return total;
        }

        [ActionName("AllCustomersTotalPayments")]
        public async Task<IActionResult> GetAllCustomersWithPayments()
        {
            var customers = _context.Customers.Include(c => c.Films).ToList();
            var customerPayments = new List<CustomerTotalPaymentViewModel>();

            foreach (var customer in customers)
            {
                decimal totalPayment = 0;

                if (customer.CustomerType == Enums.CustomCustomerType.Member)
                {
                    totalPayment = CalculateMemberPrice(customer.Films.Count(f => f.FilmMediaType == Enums.CustomMediaType.DVD), customer.Films.Count(f => f.FilmMediaType == Enums.CustomMediaType.BluRay));
                }
                else
                {
                    totalPayment = CalculateNotMemberPrice(customer.Films.Count(f => f.FilmMediaType == Enums.CustomMediaType.DVD), customer.Films.Count(f => f.FilmMediaType == Enums.CustomMediaType.BluRay));
                }

                customerPayments.Add(new CustomerTotalPaymentViewModel { Customer = customer, TotalPayment = totalPayment });
            }

            return View(customerPayments);


        }
    }
}
