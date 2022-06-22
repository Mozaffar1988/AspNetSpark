using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSpark.Data;
using AspNetSpark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSpark.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }
        public async Task<IActionResult> OnGetAsync(string? id)


        {
            if (id == null)
            {
                return NotFound();
            }


            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id==id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            var applicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(s => s.Id == ApplicationUser.Id);
            //var ApplicationUserDB = await _db.ApplicationUser.FirstOrDefaultAsync((s => s.Id == ApplicationUser.Id));
            var t = ApplicationUser.Id;
            applicationUser.Name = ApplicationUser.Name;
            applicationUser.Email = ApplicationUser.Email;
            applicationUser.PhoneNumber = ApplicationUser.PhoneNumber;
            applicationUser.Address = ApplicationUser.Address;
            applicationUser.City = ApplicationUser.City;
            applicationUser.PostalCode = ApplicationUser.PostalCode;
            await _db.SaveChangesAsync();
           
            return RedirectToPage("Index");
        }
    }
}
