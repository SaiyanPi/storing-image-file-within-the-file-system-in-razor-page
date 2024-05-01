using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserImage.Data;
using UserImage.Models;

namespace UserImage.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserContext _db;
        public IndexModel(UserContext db)
        {
            _db = db;
        }
        public IEnumerable<User> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _db.Users.ToListAsync();
        }
    }
}
