using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserImage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string TimeOfDay { get; set; }
        public void OnGet()
        {
            TimeOfDay = "evening";
            if (DateTime.Now.Hour < 18)
            {
                TimeOfDay = "afternoon";
            }
            if (DateTime.Now.Hour < 12)
            {
                TimeOfDay = "morning";
            }

        }
    }
}
