using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using UserImage.Data;
using UserImage.Models;

namespace UserImage.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserContext _db;
        private readonly IWebHostEnvironment _environment;

        public DeleteModel(UserContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [BindProperty]
        public User user { get; set; }

        public void OnGet(int id)
        {
            user = _db.Users.Find(id);
        }

        
        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid) //server side validation
            {
                var userFromDb = _db.Users.Find(user.UserId);
                var filepath = Path.Combine(_environment.WebRootPath, "images", "users", user.ImageName);
                if (userFromDb != null || user.MiddleName == null)
                {
                    user.MiddleName = "helper";
                    _db.Users.Remove(userFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "User Deleted Successfully.";
                    return RedirectToPage("./Index");
                }
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                } 
            }
            return Page();
        }
    }
}