using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UserImage.Data;
using UserImage.Models;

namespace UserImage.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserContext _db;
        private readonly IWebHostEnvironment _environment;
        public CreateModel(UserContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty, Display(Name = "Image (jpg/png)")]
        public IFormFile UserImage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("User.ImageName");
            if (!ModelState.IsValid || _db.Users == null || User == null)
            {
                return Page();
            }
            else
            {
                User.ImageName = UserImage.FileName;
                var imageFile = Path.Combine(_environment.WebRootPath, "images", "users", UserImage.FileName);
                using var fileStream = new FileStream(imageFile, FileMode.Create);
                await UserImage.CopyToAsync(fileStream);
                _db.Users.Add(User);
                await _db.SaveChangesAsync();
                TempData["success"] = "User Created Successfully."; // For toaster NOTIFICATION POP UPS
                
                return RedirectToPage("./Index");
            }
            
        }
    }
}
