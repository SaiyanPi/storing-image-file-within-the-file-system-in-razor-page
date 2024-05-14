using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UserImage.Data;
using UserImage.Models;

namespace UserImage.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly UserContext _db;

        public UpdateModel(UserContext db)
        {
            _db = db;
           
        }

        [BindProperty]
        public User user { get; set; }
       
        
        public void OnGet(int id)
        {
            user = _db.Users.Find(id);
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
          
            if (!ModelState.IsValid || _db.Users == null || User == null)
            {
                return Page();
            }
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            TempData["success"] = "User Updated Successfully."; // For toaster NOTIFICATION POP UPS
            
            return RedirectToPage("./Index");
        }
    }
}
